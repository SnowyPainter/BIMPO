using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIMPO_BusIness_Management_Process_Observer
{
    interface IDiagramUIElement : IDiagramElement
    { 
        int Tag { get; set; }
        string Margin { get; set; }
        string BackgroundColorHex { get; set; }
    }
}
