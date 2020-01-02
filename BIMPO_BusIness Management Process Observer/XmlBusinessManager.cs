using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;

namespace BIMPO_BusIness_Management_Process_Observer
{
    public static class XmlBusinessManager
    {
        const string BasicPath = "./user_business.xml";
        
        public static void CreateBasic(string xml = BasicPath)
        {

            if (File.Exists(xml))
                File.Delete(xml);

            var dataDocument = new XDocument();

            var root = new XElement("Root");

            dataDocument.Add(root);

            dataDocument.Save(xml);
        }
        public static bool Defects(string xml = BasicPath)
        {
            if(!File.Exists(xml))
            {
                CreateBasic();
                return true;
            }

            var accountDataDoc = new XmlDocument();
            accountDataDoc.Load(xml);

            XmlNode root = accountDataDoc.GetElementsByTagName("Root")[0];

            if (root == null)
                return false;

            return true;
        }

        public static bool ExistBusiness(string title, string xml = BasicPath)
        {
            var doc = new XmlDocument();
            doc.Load(xml);

            foreach (XmlNode busin in doc.GetElementsByTagName("BusinessTitle"))
                if (busin.InnerText == title) return true;

            return false;
        }

        public static void CreateNewBusiness(Business info, string xml = BasicPath)
        {
            var accountDataDoc = XDocument.Load(xml);

            if (ExistBusiness(info.BusinessTitle))
                return;

            var business = new XElement("Business",
                new XElement("BusinessTitle", info.BusinessTitle),
                new XElement("Degdate", info.Degdate),
                new XElement("Progress", info.Progress.ToString()),
                new XElement("Deadline", new XElement("Start"), new XElement("End")),
                new XElement("Memos"),
                new XElement("Tasks"));

            accountDataDoc.Element("Root").Add(business);
            accountDataDoc.Save(xml);
        }
        public static bool TaskXmlFindDefects(string business_title, int task_index, string xml = BasicPath)
        {
            var doc = new XmlDocument();
            doc.Load(xml);

            var headerBusiness = doc.SelectSingleNode("//Business/BusinessTitle[text()='" + business_title + "']");
            string[] taskElements = new string[] { "Title", "Describe", "Priority", "Accomplished" };

            bool hasDefects = false;

            if (headerBusiness == null)
            {
                throw new XmlException($"BusinessTitle중에 {business_title}를 찾을 수 없습니다.");
            }

            XmlNode business = headerBusiness.ParentNode;

            XmlNode task = business.SelectSingleNode($"Tasks/Task[@Index='{task_index}']");

            foreach (var element in taskElements)
            {
                if (task.SelectSingleNode(element) == null)
                {
                    hasDefects = true;
                    var taskNode = doc.CreateNode(XmlNodeType.Element, element, "");
                    taskNode.InnerText = "False";
                    task.AppendChild(taskNode);
                }
            }
            doc.Save(xml);

            return hasDefects;
        }
        public static void CreateNewTask(string parentBusiness, WorkTask task, string xml = BasicPath)
        {
            XDocument doc = XDocument.Load(xml);

            XElement business = doc.Root.Elements("Business")
                .SingleOrDefault(b => b.Element("BusinessTitle").Value == parentBusiness);

            if (business == null)
                return;

            int tasksCount = business.Descendants("Task") == null ? 0 : business.Descendants("Task").Count();

            if (business.Element("Tasks") == null)
                business.Add(new XElement("Tasks"));

            var taskNode = new XElement("Task", new XAttribute("Index", tasksCount),
                new XElement("Title", task.Title),
                new XElement("Describe", task.Content),
                new XElement("Priority", task.Priority),
                new XElement("Accomplished", task.Accomplished));

            business.Element("Tasks").Add(taskNode);

            doc.Save(xml);
        }

        public static void CreateNewMemo(string parentBusiness, Memo memo, string xml = BasicPath)
        {
            XDocument doc = XDocument.Load(xml);

            XElement business = doc.Root.Elements("Business")
                .SingleOrDefault(b => b.Element("BusinessTitle").Value == parentBusiness);

            if (business == null)
                return;

            var memos = business.Element("Memos");
            int memosCount = business.Descendants("Memo") == null ? 0 : business.Descendants("Memo").Count();

            if (memos == null)
                return;

            var memoNode = new XElement("Memo", new XAttribute("Index", memosCount),
                new XElement("Title", memo.Title),
                new XElement("Content", memo.Content),
                new XElement("Color", new ColorConverter().ConvertToString(memo.BackgroundColor)));

            memos.Add(memoNode);

            doc.Save(xml);
        }

        public static void DeleteBusiness(string title, string xml = BasicPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            var business = doc.SelectSingleNode("//Business/BusinessTitle[text()='" + title + "']");
            var root = doc.GetElementsByTagName("Root")[0];

            if (business != null && root != null)
            {
                root.RemoveChild(business.ParentNode);
                doc.Save(xml);
            }
        }
        public static void DeleteTask(string title, int index, string xml = BasicPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            var bsTitle = doc.SelectSingleNode("//Business/BusinessTitle[text()='" + title + "']");

            if (bsTitle == null)
                return;

            var tasklist = bsTitle.ParentNode.SelectSingleNode("Tasks");
            tasklist.RemoveChild(bsTitle.ParentNode.SelectSingleNode($"Tasks/Task[@Index='{index}']"));

            doc.Save(xml);
        }

        public static void SetDeadline(string business_title, Deadline deadline, string xml = BasicPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            var headerBusiness = doc.SelectSingleNode("//Business/BusinessTitle[text()='" + business_title + "']");

            if (headerBusiness == null)
            {
                //throw new XmlException($"BusinessTitle중에 {business_title}를 찾을 수 없습니다.");
                return;
            }

            XmlNode business = headerBusiness.ParentNode;

            business.SelectSingleNode("Deadline/Start").InnerText = deadline.Start.ToShortDateString();
            business.SelectSingleNode("Deadline/End").InnerText = deadline.End.ToShortDateString();

            doc.Save(xml);
        }

        public static void SetTaskTitle(string business_title, int task_index, string new_title, string xml = BasicPath)
        {
            SetTaskAttribute(business_title, task_index, "Title", new_title);
        }
        public static void SetTaskDescribeText(string business_title, int task_index, string new_describe, string xml = BasicPath)
        {
            SetTaskAttribute(business_title, task_index, "Describe", new_describe);
        }
        public static void SetTaskPriority(string business_title, int task_index, string new_priority, string xml = BasicPath)
        {
            SetTaskAttribute(business_title, task_index, "Priority", new_priority);
        }
        public static void SetTaskAccomplished(string business_title, int task_index, bool accomplished, string xml = BasicPath)
        {
            SetTaskAttribute(business_title, task_index, "Accomplished", accomplished.ToString());
        }
        private static void SetTaskAttribute(string business_title, int task_index, string attr, string value, string xml = BasicPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            var headerBusiness = doc.SelectSingleNode("//Business/BusinessTitle[text()='" + business_title + "']");

            if (headerBusiness == null)
            {
                throw new XmlException($"BusinessTitle중에 {business_title}를 찾을 수 없습니다.");
            }

            XmlNode business = headerBusiness.ParentNode;
            XmlNode task = business.SelectSingleNode($"Tasks/Task[@Index='{task_index}']");
            var attrNode = task.SelectSingleNode(attr);

            if (attrNode != null)
            {
                attrNode.InnerText = value;
                doc.Save(xml);
            }
            else
            {
                throw new XmlException($"Business Task에는 {attr}라는 Attribute가 없습니다.");
            }

        }
        public static IEnumerable<Business> GetBusinesses(string xml = BasicPath)
        {
            var accountDataDoc = new XmlDocument();
            accountDataDoc.Load(xml);
            foreach (XmlNode busniess in accountDataDoc.GetElementsByTagName("Business"))
            {
                var start = busniess.SelectSingleNode("Deadline/Start").InnerText;
                var degdate = busniess.SelectSingleNode("Degdate").InnerText;

                if (busniess.HasChildNodes)
                    yield return new Business()
                    {
                        BusinessTitle = busniess.SelectSingleNode("BusinessTitle").InnerText,
                        Degdate = start == "" ? degdate : start,
                        Progress = int.Parse(busniess.SelectSingleNode("Progress").InnerText)
                    };
            }
        }
        public static int GetTotalBusinessProgressAverage(string xml = BasicPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            XmlNodeList progresses = doc.GetElementsByTagName("Progress");

            int totalLen = progresses.Count;
            int total = 0;

            for (int i = 0; i < totalLen; i++)
            {
                int val;
                if (!int.TryParse(progresses[i].InnerText, out val))
                {
                    BusinessMessageBox.Show("진행도를 불러오는 중에 문제가 생겼습니다.", "진행도 결점", MessageBoxButton.OK, Error:true);
                    progresses[i].InnerText = "0";
                    continue;
                }

                total += val;
            }

            doc.Save(xml);

            return total <= 0 || totalLen <= 0 ? -1 : total / totalLen;
        }

        public static Deadline GetDeadline(string business_title, string xml = BasicPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            XmlNode business = doc.SelectSingleNode($"//Root/Business[BusinessTitle[contains(text(), '{business_title}')]]");
            if (business == null)
            {
                throw new XmlException($"BusinessTitle중에 결점이 있어 요소를 찾을 수 없습니다.");
            }
            
            string s = business.SelectSingleNode("Deadline/Start").InnerText, e = business.SelectSingleNode("Deadline/End").InnerText;

            if (s == "" || e == "")
                return null;

            var startDate = Convert.ToDateTime(s);
            var endDate = Convert.ToDateTime(e);

            return new Deadline(startDate, endDate);
        }

        public static int GetBusinessProgress(string business_title, string xml = BasicPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            XmlNode business = doc.SelectSingleNode($"//Root/Business[BusinessTitle[contains(text(), '{business_title}')]]");

            int value;
            if (!int.TryParse(business.SelectSingleNode("Progress").InnerText, out value))
                return -1;

            return value;
        }

        public static int ReassignBusinessProgress(string business_title, string xml = BasicPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            XmlNode business = doc.SelectSingleNode($"//Root/Business[BusinessTitle[contains(text(), '{business_title}')]]");

            XmlNodeList tasks = business.SelectNodes("Tasks/Task");
            if (tasks == null)
                return -1;

            float allTasksCount = tasks.Count, accomplished = 0;
            float progress = 0;
            try
            {
                foreach (XmlNode task in tasks)
                {
                    if (task.SelectSingleNode("Accomplished").InnerText == "True")
                        accomplished++;
                }

                progress = accomplished / allTasksCount;
                business.SelectSingleNode("Progress").InnerText = (Math.Round(progress * 100)).ToString();
            }
            catch
            {
                if (TaskXmlFindDefects(business_title, int.Parse(business.Attributes["Index"].Value)))
                    ReassignBusinessProgress(business_title);
            }
            doc.Save(xml);

            return accomplished == 0 ? 0 : (int)(progress * 100);
        } //some progress problem (start)

        public static List<WorkTask> GetAllTasks(string business_title, string xml = BasicPath)
        {
            var accountDataDoc = new XmlDocument();
            accountDataDoc.Load(xml);
            XmlNode business = accountDataDoc.SelectSingleNode($"//Root/Business[BusinessTitle[contains(text(), '{business_title}')]]");
            XmlNode tasks = business.SelectSingleNode("Tasks");
            List<WorkTask> result = new List<WorkTask>();

            int currentTaskIndex = -1;

            try
            {
                foreach (XmlNode task in tasks.SelectNodes("Task"))
                {
                    if (!int.TryParse(task.Attributes["Index"].Value, out currentTaskIndex))
                        return null;

                    result.Add(new WorkTask(
                        currentTaskIndex,
                        task.SelectSingleNode("Title").InnerText,
                        task.SelectSingleNode("Describe").InnerText,
                        task.SelectSingleNode("Priority").InnerText,
                        bool.Parse(task.SelectSingleNode("Accomplished").InnerText)
                    ));
                }

            }
            catch
            {
                if (TaskXmlFindDefects(business_title, currentTaskIndex))
                {
                    return GetAllTasks(business_title);
                }
            }

            return result;
        }

        public static List<Memo> GetAllMemos(string business_title, string xml = BasicPath)
        {
            var accountDataDoc = new XmlDocument();
            accountDataDoc.Load(xml);
            XmlNode business = accountDataDoc.SelectSingleNode($"//Root/Business[BusinessTitle[contains(text(), '{business_title}')]]");
            List<Memo> result = new List<Memo>();

            XmlNode memos = business.SelectSingleNode("Memos");
            XmlNodeList memoList = memos.SelectNodes("Memo");

            for (int i = 0;i < memoList.Count;i++)
            {
                result.Add(new Memo(
                    memoList[i].SelectSingleNode("Title").InnerText,
                    memoList[i].SelectSingleNode("Content").InnerText,
                    new BrushConverter().ConvertFromString(memoList[i].SelectSingleNode("Color").InnerText) as SolidColorBrush)
                );
            }
            return result;
        }

        public static List<Memo> SelectSomeMemos(string business_title, int limit = 1,string xml = BasicPath)
        {
            if (limit < 1) return null;

            var accountDataDoc = new XmlDocument();
            accountDataDoc.Load(xml);
            XmlNode business = accountDataDoc.SelectSingleNode($"//Root/Business[BusinessTitle[contains(text(), '{business_title}')]]");
            List<Memo> result = new List<Memo>();

            XmlNode memos = business.SelectSingleNode("Memos");

            if (memos == null)
                return null;

            XmlNodeList memoList = memos.SelectNodes($"Memo[position() > last() - {limit}]");

            foreach (XmlNode memo in memoList)
            {
                result.Add(new Memo(
                    memo.SelectSingleNode("Title").InnerText,
                    memo.SelectSingleNode("Content").InnerText,
                    new BrushConverter().ConvertFromString(memo.SelectSingleNode("Color").InnerText) as SolidColorBrush
                ));
            }

            return result;
        }

    }
}
