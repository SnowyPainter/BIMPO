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
    /// BusinessMessage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BusinessMessage : Window
    {

        public MessageBoxResult Result = MessageBoxResult.None;

        public BusinessMessage(string caption, string text, int height= 169, int width= 364)
        {
            InitializeComponent();
            captionTextBlock.Text = caption;
            contentTextBlock.Text = text;

            this.Height = height;
            this.Width = width;
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
