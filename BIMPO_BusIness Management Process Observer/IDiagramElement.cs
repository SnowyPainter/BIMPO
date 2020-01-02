using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BIMPO_BusIness_Management_Process_Observer
{
    interface IDiagramElement
    {
        string Title { get; set; }
        string Content { get; set; }
    }
}
