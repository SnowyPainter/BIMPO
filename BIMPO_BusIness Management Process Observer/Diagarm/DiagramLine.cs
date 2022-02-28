using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BIMPO_BusIness_Management_Process_Observer
{
    public class DiagramLine
    {
        public Line Line { get; }

        public Thickness StartElementMarginDistance { get; }
        public Thickness EndElementMarginDistance { get; }

        public UIElement StartElement { get; }
        public UIElement EndElement { get; }

        public DiagramLine(Line usedLine, UIElement startElement, UIElement endElement)
        {
            Line = usedLine;
            StartElement = startElement;
            EndElement = endElement;

            Thickness endEl = (EndElement as StackPanel).Margin, startEl = (startElement as StackPanel).Margin;
            StartElementMarginDistance = new Thickness(Line.X1 - startEl.Left, Line.Y1 - startEl.Top, 0, 0);
            EndElementMarginDistance = new Thickness(Line.X2 - endEl.Left, Line.Y2 - endEl.Top,0,0);
        }
        public void SetXY1(double x, double y)
        {
            Line.X1 = x;
            Line.Y1 = y;
        }
        public void SetXY2(double x, double y)
        {
            Line.X2 = x;
            Line.Y2 = y;
        }
        public int CheckConnected(UIElement element)
        {
            if ((StartElement == element || EndElement == element))
                return StartElement == element ? 1 : 2;
            else
                return 0;
        }
    }
}
