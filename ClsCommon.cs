using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Tools
{
    public class ClsCommon
    {
        static public string IncludeTrailingBackslash(string path)
        {
            if (!path.EndsWith("\\")) path += "\\";
            return path;
        }

        static public string GetNoteplus()
        {
            const string userRoot = "HKEY_LOCAL_MACHINE";
            const string subkey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\notepad++.exe";
            const string keyName = userRoot + "\\" + subkey;

            return Registry.GetValue(keyName, "", "").ToString();
        }
    }
}
