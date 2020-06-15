using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMPO_BusIness_Management_Process_Observer
{
    public class Business
    {
        public string BusinessTitle { get; set; }
        public string Degdate { get; set; }
        public int Progress { get; set; }
        public int BusinessScale { get; set; }
        public int MonthlySales { get; set; }
        //public Deadline Deadline { get; set; }
        //public List<Memo> Memos { get; set; }
        //public List<WorkTask> Tasks { get; set; }
    }
}
