using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QA_Tools
{
    public class ClsTools: IDisposable
    {
        public void Dispose()
        {
            
        }

        string GetServerURI(string attrName)
        {
            string URI = "";
            string configXml = ClsCommon.IncludeTrailingBackslash(Directory.GetCurrentDirectory()) + "config.xml";
            if (!File.Exists(configXml)) return "";

            XDocument xml = XDocument.Load(configXml);
            var conList = from c in xml.Root.Descendants("Connections")
                          select c.Elements("Connection");
            foreach (XElement conn in conList.ElementAtOrDefault(0))
                if (conn.Attribute("name").Value.ToUpper().Equals(attrName.ToUpper()))
                {
                    URI = conn.Element("Server").Value;
                    if (URI.Substring(URI.Length - 1, 1) != "/") URI += '/';
                }
            return URI;
        }

        private string CallApi(string URI, string body)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                client.Headers[HttpRequestHeader.Accept] = "*/*";
                try
                {
                    var result = client.UploadString(URI, "POST", body);
                    return result;
                }
                catch (WebException e)
                {
                    return e.Message;
                }
            }

        }

        public string Tokenize(string plainText)
        {
            string URI = GetServerURI("TokenizerAPI") + "tokens";
            string data = "[\"" + plainText + "\"]";
            return CallApi(URI, data);
        }

        public string Detokenize(string tokenText)
        {
            string URI = GetServerURI("TokenizerAPI") + "ids";
            string data = "[\"" + tokenText + "\"]";
            return CallApi(URI, data);
        }

        public string CCGPost(string sysYear, string core, 
            string key, string oper, string table, string keyValue)
        {
            string URI = GetServerURI("CoreCopyGetUrl");
            if (URI == "") return "";

            string data = "{" +
                "\"systemYear\": " + "\"" + sysYear + "\"," +
                "\"tableName\": " + "\"" + table.ToUpper() + "\"," +
                "\"key\": " + key + "," +
                "\"keyValue\": " + "\"" + keyValue + "\"," +
                "\"operator\": " + "\"" + oper + "\"," +
                "\"core\": " + core + "}";
            return CallApi(URI, data);
        }
    }
}
