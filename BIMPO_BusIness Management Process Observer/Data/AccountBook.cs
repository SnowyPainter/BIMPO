using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMPO_BusIness_Management_Process_Observer
{
    public class AccountBook
    {
        public AccountBook(string fileName)
        {
            FileName = fileName;
        }
        public string FileName { get; set; }
    }
}
