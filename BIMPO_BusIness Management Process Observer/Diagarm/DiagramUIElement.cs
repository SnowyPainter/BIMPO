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
    public class DiagramUIElement : IDiagramUIElement
    {
        public DiagramUIElement()
        {

        }
        public DiagramUIElement(string title, string content, Brush bc, Thickness margin, int tag)
        {
            Title = title;
            Content = content;
            BackgroundColorHex = (bc as SolidColorBrush).Color.ToString();
            Margin = margin.ToString();
            Tag = tag;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string BackgroundColorHex { get; set; }
        public string Margin { get; set; }
        public int Tag { get; set; }
    }
}
