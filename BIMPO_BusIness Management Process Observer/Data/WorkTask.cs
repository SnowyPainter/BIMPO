using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BIMPO_BusIness_Management_Process_Observer
{
    public class WorkTask:IEquatable<WorkTask>, IDiagramElement
    {
        public WorkTask(int index, string title, string describe, string priority, bool accomplished = false)
        {
            Index = index;
            Title = title;
            Content = describe;
            Priority = priority;
            Accomplished = accomplished;

            BackgroundColor = Brushes.Gray;
        }

        public bool Equals(WorkTask other)
        {
            return other.Index == Index;
        }

        public int Index { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Priority { get; set; }
        public bool Accomplished { get; set; }

        public Brush BackgroundColor { get; set; }
    }
}
