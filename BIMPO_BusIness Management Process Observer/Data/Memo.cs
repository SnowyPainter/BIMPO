using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BIMPO_BusIness_Management_Process_Observer
{
    public class Memo:IDiagramElement
    {
        public Memo()
        {

        }
        public Memo(string title, string content, Brush color)
        {
            Title = title;
            Content = content;
            BackgroundColor = color;
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public Brush BackgroundColor { get; set; }
        public List<string> Tags { get; set; }
    }
}
