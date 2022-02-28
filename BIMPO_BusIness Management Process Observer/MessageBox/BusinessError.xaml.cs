using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BIMPO_BusIness_Management_Process_Observer
{
    /// <summary>
    /// BusinessError.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BusinessError : Window
    {
        public MessageBoxResult Result = MessageBoxResult.None;

        public BusinessError(string caption, string text)
        {
            InitializeComponent();
            captionTextBlock.Text = caption;
            contentTextBlock.Text = text;
        }

        private void OkBtn_Clicked_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;

            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
