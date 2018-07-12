using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Net;
using VK_COM.Constants;

namespace VkCommands.Utils
{
    class XmlProcessor
    {
        public static string getInnerText(XmlDocument doc, string nodeName)
        {
            string innerText = string.Empty;
            try { innerText = Regex.Replace(doc.SelectSingleNode(".//" + nodeName).InnerText, @"\t|\n|\r", ""); }
            catch { return string.Empty; }
            return innerText;
        }

        public static string getInnerText(XmlNode node, string nodeName)
        {
            string innerText = string.Empty;
            try { innerText = Regex.Replace(node.SelectSingleNode(".//" + nodeName).InnerText, @"\t|\n|\r", ""); }
            catch { return string.Empty; }
            return innerText;
        }

        public static XmlNodeList getNodes(XmlDocument doc, string nodeName)
        {
            XmlNodeList nodeList = null;
            try { nodeList = doc.SelectNodes(".//" + nodeName); }
            catch { return null; }
            return nodeList;
        }

        public static XmlNodeList getNodes(XmlNode node, string nodeName)
        {
            XmlNodeList nodeList = null;
            try { nodeList = node.SelectNodes(".//" + nodeName); }
            catch { return null; }
            return nodeList;
        }

        public static XmlDocument getXml(string url)
        {
            XmlDocument doc = null;
            try
            {
                string xml = string.Empty;
                using (WebClient webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    xml = webClient.DownloadString(url);
                }
                doc = new XmlDocument();
                doc.LoadXml(xml);

                System.Threading.Thread.Sleep(CommonConstans.DEFAULT_COMMAND_INTERVAL);
            }
            catch { return null; }
            return doc;
        }
    }
}
