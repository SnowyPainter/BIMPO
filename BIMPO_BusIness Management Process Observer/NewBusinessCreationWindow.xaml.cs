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
    /// NewBusinessCreationWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewBusinessCreationWindow : Window
    {
        public NewBusinessCreationWindow()
        {
            InitializeComponent();
        }
        private void WindowDragMove_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        public Business b = new Business();
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if(BusinessTitle.Text == "")
            {
                BusinessMessageBox.Show("비지니스명을 지어주세요", "정보 입력");
                return;
            }
            else if(XmlBusinessManager.ExistBusiness(BusinessTitle.Text))
            {
                BusinessMessageBox.Show("존재하는 비지니스입니다.", "정보 입력", Error:true);
                return;
            }

            b.BusinessTitle = BusinessTitle.Text.Trim();
            b.Degdate = DateTime.Now.ToShortDateString();
            b.Progress = 0;

            int bs = 0, ms = 0;
            if(int.TryParse(BusinessScale_Textbox.Text, out bs))
            {
                b.BusinessScale = bs;
            }
            else
            {
                BusinessMessageBox.Show("숫자만 입력해주세요", "정보 입력", Error: true);
                return;
            }
            
            if(int.TryParse(MonthlySales_Textbox.Text, out ms)) {
                b.MonthlySales = ms;
            }
            else
            {
                BusinessMessageBox.Show("숫자만 입력해주세요", "정보 입력", Error: true);
                return;
            }

            XmlBusinessManager.CreateNewBusiness(b);

            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BusinessMessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
