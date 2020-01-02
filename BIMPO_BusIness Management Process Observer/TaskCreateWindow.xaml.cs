using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// TaskCreateWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TaskCreateWindow : Window
    {
        private readonly string business;
        public WorkTask Result = null;
        public TaskCreateWindow(string ParentBusiness)
        {
            InitializeComponent();
            business = ParentBusiness;
        }

        //<Window title bar>

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BusinessMessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void WindowDragMove_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        //</Window title bar>
        private void TaskPriorityTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void CreateNewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if(TitleTextbox.Text != "" && DescribeTextbox.Text != "" && TaskPriorityTextbox.Text != "")
            {
                Result = new WorkTask(0, TitleTextbox.Text, DescribeTextbox.Text, TaskPriorityTextbox.Text);

                XmlBusinessManager.CreateNewTask(business, Result);
                BusinessMessageBox.Show($"새 업무, {Result.Title}를 생성 완료했습니다.", "업무 생성");
                this.Close();
            }
            else
            {
                BusinessMessageBox.Show("빈 칸을 채워주세요.", "정보 입력");
            }
        }
    }
}
