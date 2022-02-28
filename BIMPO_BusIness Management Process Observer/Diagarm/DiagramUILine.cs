using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BIMPO_BusIness_Management_Process_Observer
{
    
    [Serializable]
    class DiagramUILine
    {
        public DiagramUILine()
        {

        }
        public DiagramUILine(int startTag, int endTag,
            Point xy1, Point xy2, Brush stroke)
        {
            StartElementTag = startTag; EndElementTag = endTag;
            x1 = (int)xy1.X;
            y1 = (int)xy1.Y;
            x2 = (int)xy2.X;
            y2 = (int)xy2.Y;

            strokeColorHex = stroke.ToString();
        }
        public int StartElementTag { get; set; }
        public int EndElementTag { get; set; }

        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public string strokeColorHex { get; set; }
    }
}
