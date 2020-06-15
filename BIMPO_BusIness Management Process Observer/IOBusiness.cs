using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace BIMPO_BusIness_Management_Process_Observer
{
    public static class IOBusiness
    {
        public static bool ExistBusiness(string businessName, string rootPath="./")
        {
            return Directory.Exists(rootPath + $"{businessName}");
        }
        public static bool ExistTask(string businessName, string taskName, string rootPath ="./")
        {
            return Directory.Exists(rootPath+$"{businessName}/{taskName}");
        }
        public static void CreateBusinessDirectory(string businessName, string rootPath = "./")
        {
            Directory.CreateDirectory(rootPath + businessName);
        }
        public static void CreateTaskDirectory(string businessName, string taskName, string rootPath = "./")
        {
            if (!Directory.Exists(rootPath + businessName))
                CreateBusinessDirectory(businessName, rootPath);
            //throw new IOException($"{businessName} - 비지니스 디렉터리가 존재하지 않습니다.");
            else
            {
                Directory.CreateDirectory(rootPath + businessName + "/" + taskName);
            }
        }
        private static void attachFile(string savePath, string attachFile)
        {
            File.Copy(attachFile, savePath);
        }
        public static void AttachFileToTask(string businessName, string taskName, string filePath)
        {
            attachFile($"./{businessName}/{taskName}/{Path.GetFileName(filePath)}", filePath);
        }
        public static void AttachFileToAccountBook(string businessName, string filePath)
        {
            if (!Directory.Exists($"./{businessName}/AccountBooks/"))
                Directory.CreateDirectory($"./{businessName}/AccountBooks/");

            attachFile($"./{businessName}/AccountBooks/{Path.GetFileName(filePath)}", filePath);
        }
        public static IEnumerable<string> GetTaskFileNames(string businessName, string taskName, string rootPath = "./")
        {
            if (Directory.Exists($@"{rootPath}/{businessName}/{taskName}"))
            {
                foreach (var filepath in Directory.GetFiles($@"{rootPath}/{businessName}/{taskName}"))
                {
                    yield return Path.GetFileName(filepath);
                }
            }
            else
                yield return null;
        }
        public static IEnumerable<AccountBook> GetAccountBooks(string businessName, string rootPath="./")
        {
            if (Directory.Exists($@"{rootPath}/{businessName}/AccountBooks"))
            {
                foreach (var filepath in Directory.GetFiles($@"{rootPath}/{businessName}/AccountBooks"))
                {
                    yield return new AccountBook(Path.GetFileName(filepath));
                }
            }
            else
                yield return null;
        }

        public static void Save(string filePath, object objToSerialize)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, objToSerialize);
                }
            }
            catch (IOException)
            {
                throw;
            }
        }
        public static List<T> Load<T>(string filePath) where T : new()
        {
            List<T> rez = new List<T>();

            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    rez = bin.Deserialize(stream) as List<T>;
                }
            }
            catch (IOException)
            {
                throw;
            }

            return rez;
        }
    }
}
