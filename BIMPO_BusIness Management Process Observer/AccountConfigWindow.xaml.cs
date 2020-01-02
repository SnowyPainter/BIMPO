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
    /// AccountConfigWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AccountConfigWindow : Window
    {
        public AccountConfigWindow()
        {
            InitializeComponent();
        }

        public List<string> DataList = new List<string>();

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            DataList.Add(NameTextBox.Text);
            DataList.Add(HobbyTextBox.Text);

            this.Close();
        }
    }
}
