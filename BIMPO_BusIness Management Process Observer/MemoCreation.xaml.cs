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
    /// MemoCreateWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MemoCreation : Window
    {

        readonly string BusinessName;

        public Memo Result = new Memo();

        public MemoCreation(string business)
        {
            InitializeComponent();

            BusinessName = business;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BusinessMessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void ColorChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            BackgroundGrid.Background = btn.Background;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Result.Title = TitleTextBox.Text;
            Result.Content = ContentTextBox.Text;
            Result.BackgroundColor = BackgroundGrid.Background;

            XmlBusinessManager.CreateNewMemo(BusinessName, Result);

            BusinessMessageBox.Show("새 메모를 만들었습니다.", "메모 생성");

            this.Close();
        }
        
    }
}
