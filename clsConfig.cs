using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_Tools
{
    class ClsIniFile
    {
        public static int capacity = 512;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key,
            string defaultValue, StringBuilder value, int size, string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string section, string key, string defaultValue,
            [In, Out] char[] value, int size, string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSection(string section, IntPtr keyValue,
            int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool WritePrivateProfileString(string section, string key,
            string value, string filePath);

        public static string[] ReadSections(string filePath)
        {
            // first line will not recognize if ini file is saved in UTF-8 with BOM 
            while (true)
            {
                char[] chars = new char[capacity];
                int size = GetPrivateProfileString(null, null, "", chars, capacity, filePath);

                if (size == 0)
                {
                    return null;
                }

                if (size < capacity - 2)
                {
                    string result = new String(chars, 0, size);
                    string[] sections = result.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
                    return sections;
                }

                capacity *= 2;
            }
        }

        public static string[] ReadKeys(string section, string filePath)
        {
            // first line will not recognize if ini file is saved in UTF-8 with BOM 
            while (true)
            {
                char[] chars = new char[capacity];
                int size = GetPrivateProfileString(section, null, "", chars, capacity, filePath);

                if (size == 0)
                {
                    return null;
                }

                if (size < capacity - 2)
                {
                    string result = new String(chars, 0, size);
                    string[] keys = result.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
                    return keys;
                }

                capacity *= 2;
            }
        }

        public static string ReadValue(string section, string key, string filePath, string defaultValue = "")
        {
            var value = new StringBuilder(capacity);
            GetPrivateProfileString(section, key, defaultValue, value, value.Capacity, filePath);
            return value.ToString();
        }
    }

    public class ClsConfig
    {
        private string pSection, pKey, pValue;
        private Dictionary<string, Dictionary<string, string[]>> oConfigList = new Dictionary<string, Dictionary<string, string[]>>();
        private static string configFileName;

        public string RootFolder { get; set; }

        public bool ReadIni()
        {
            var fName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            fName = Path.ChangeExtension(fName, ".ini");
            if (!File.Exists(fName))
            {
                MessageBox.Show("File does not exists: " + fName);
                return true;
            }

            try
            {
                string[] Sections = ClsIniFile.ReadSections(fName);
                foreach (string Section in Sections)
                {
                    if (Section.ToUpper() == "ROOT")
                    {

                    }
                    else
                    {
                        pSection = Section;
                        string[] KeyList = ClsIniFile.ReadKeys(Section, fName);

                        //Create list for each Section
                        Dictionary<string, string[]> oDetailList = new Dictionary<string, string[]>();
                        foreach (string Key in KeyList)
                        {
                            pKey = Key;
                            string Value = ClsIniFile.ReadValue(Section, Key, fName);
                            string[] arrDetails = Value.Split(',');
                            pValue = Value;
                            oDetailList.Add(Key, arrDetails);
                        }
                        oConfigList.Add(Section, oDetailList);
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Log(e.Message);
                throw new Exception(@"[There is an issue read .ini file]: Section: " + pSection + ", Key: " + pKey + ", Value:" + pValue);
            }
        }

        public Dictionary<string, string[]> GetConfig(char RecordType)
        {
            return oConfigList[RecordType + "Record"];
        }

        public string GetRequirement(string key)
        {
            var v = oConfigList.Keys;
            return "NotImplemented";
        }

        public static void Log(string logMessage)
        {
            string fn = Path.ChangeExtension(Application.ExecutablePath, ".log");
            using (StreamWriter w = File.AppendText(fn))
                w.WriteLine(DateTime.Now.ToString("yyMMdd HHmmss") + $": {logMessage}");
        }

        static public string GetKey(string key, string defaultValue = "")
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, defaultValue);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                Properties.Settings.Default.Reload();
            }

            return config.AppSettings.Settings[key].Value;
        }

        static public void SetKey(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                if (config.AppSettings.Settings[key] == null)
                    config.AppSettings.Settings.Add(key, value);

                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                Properties.Settings.Default.Reload();
            }
            catch (Exception e)
            { ClsConfig.Log("SetKey: " + key + ": " + value + ": " + e.Message); }
        }

        static public string[] GetApis()
        {
            try
            {
                List<string> result = new List<string>();
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                var api = config.AppSettings.Settings.AllKeys.Where(x => x.Contains("Api"));
                foreach (string el in api)
                {
                    string URI = config.AppSettings.Settings[el].Value;
                    if (URI != "")
                        result.Add(URI);
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                ClsConfig.Log("GetApis: " + e.Message);
                return null;
            }
        }

        static public string[] GetConnections()
        {
            List<string> connList = new List<string>();
            foreach (ConnectionStringSettings c in ConfigurationManager.ConnectionStrings)
            {
                if (c.Name.Contains("LocalSQLServer")) continue;
                connList.Add(c.Name);
            }
            return connList.ToArray();
        }

        static public string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}
