using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace BIMPO_BusIness_Management_Process_Observer
{
    public static class BusinessMessageBox
    {
        public static MessageBoxResult Show(string Content, string Caption, MessageBoxButton type = MessageBoxButton.OK, bool Error = false)
        {
            if (type == MessageBoxButton.OK && Error)
            {
                BusinessError be = new BusinessError(Caption, Content);
                be.ShowDialog();
                return be.Result;
            }
            else if (type == MessageBoxButton.OK)
            {
                BusinessMessage bm = new BusinessMessage(Caption, Content);
                bm.ShowDialog();

                return bm.Result;
            }
            else if(type == MessageBoxButton.YesNo)
            {
                BusinessQuestion bq = new BusinessQuestion(Caption, Content);
                bq.ShowDialog();

                return bq.Result;
            }
            else
            {
                return MessageBoxResult.None;
            }
        }
    }
}
