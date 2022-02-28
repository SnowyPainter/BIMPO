using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace BIMPO_BusIness_Management_Process_Observer
{
    public static class XmlAccount
    {
        public const string BasicPath = "./user_account.xml";

        public static string[] BasicData_Personal =
        {
            "Name",
            "Hobby"
        };

        public static void CreateBasic(List<string> dataList, string xml = BasicPath)
        {

            if (File.Exists(xml))
                File.Delete(xml);

            var dataDocument = new XDocument();

            var root = new XElement("Root");
            var personal = new XElement("Personal");

            for (int i = 0; i < BasicData_Personal.Length; i++)
            {
                personal.Add(new XElement(BasicData_Personal[i], dataList[i]));
            }

            root.Add(personal);

            dataDocument.Add(root);

            dataDocument.Save(xml);
        }

        public static bool Defects(string xml = BasicPath)
        {
            var accountDataDoc = new XmlDocument();

            accountDataDoc.Load(xml);

            XmlNode personal = accountDataDoc.GetElementsByTagName("Personal")[0] ;

            if (personal != null && personal.HasChildNodes)
            {
                for (int i = 0; i < personal.ChildNodes.Count; i++)
                {
                    if (!(personal.ChildNodes[i].Name == BasicData_Personal[i]))
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        public static string GetName(string xml = BasicPath)
        {
            var accountDataDoc = new XmlDocument();
            accountDataDoc.Load(xml);
            return accountDataDoc.GetElementsByTagName("Name")[0].InnerText;
        }
        
    }
}
