using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace BIMPO_BusIness_Management_Process_Observer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string userAccountXmlPath = "./user_account.xml";
            string businessXmlPath = "./user_business.xml";

            if (!File.Exists(userAccountXmlPath) || !XmlAccount.Defects())
            {
                BusinessMessageBox.Show("계정을 새로 만듭니다.", "데이터 손실", MessageBoxButton.OK, Error:true);

                AccountConfigWindow confWindow = new AccountConfigWindow();
                confWindow.ShowDialog();

                XmlAccount.CreateBasic(confWindow.DataList);
            }

            if (!File.Exists(businessXmlPath) || !XmlBusinessManager.Defects())
                XmlBusinessManager.CreateBasic();
                
        }
        //<Window title bar>
        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void StartupWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Application.Current.Windows.Count / 2 > 1)
            {
                BusinessMessageBox.Show("현재 열려있는 모든 창을 다 닫아주세요.", "종료", Error: true);
                e.Cancel = true;
            }
            else if (BusinessMessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                e.Cancel = true;
        }
        private void WindowDragMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            BackgroundGrid.Background =
                (SolidColorBrush)new BrushConverter().ConvertFrom(backgroundColors[random.Next(0, backgroundColors.Length)]);
            RefreshBusinessList();
        }
        //</window title bar>

        string[] randomGreetings =
        {
            "좋은 하루입니다",
            "똑똑, 안녕하세요!",
            "짹짹, 활기찬 하루입니다",
            "기분만은 산뜻한 하루입니다"
        };
        string[] backgroundColors =
        {
            "#6DAFBF",
            "#ABD4E3",
            "#8DCEDD",
            "#9292A6",
            "#F2CC85",
        };

        Random random = new Random();

        private void StartupWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Greeting settings
            GreetingLabel.Content = $"{randomGreetings[random.Next(0, randomGreetings.Length)]} {XmlAccount.GetName()}님";
            BackgroundGrid.Background = 
                (SolidColorBrush)new BrushConverter().ConvertFrom(backgroundColors[random.Next(0,backgroundColors.Length)]);

            RefreshBusinessList();
        }

        private void MakeNewBusinessBtn_Clicked(object sender, RoutedEventArgs e)
        {
            NewBusinessCreationWindow window = new NewBusinessCreationWindow();
            window.ShowDialog();

            RefreshBusinessList();
        }
        private void RefreshBusinessList()
        {
            try
            {
                IEnumerable<Business> businesses = XmlBusinessManager.GetBusinesses();
                var val = XmlBusinessManager.GetTotalBusinessProgressAverage();
                int progressAver = val > 100 ? 100 : val;

                BusinessListView.ItemsSource = businesses;
                ProgressAverBar.Value = progressAver;
                AttainedBusinessPercentage.Text = progressAver == -1 ? "전체 0% 달성" : $"전체 {progressAver}% 달성";
            }
            catch
            {
                BusinessMessageBox.Show("목록을 불러오는데에 실패하였습니다. 프로그램 파일을 건드렸는지 확인 부탁드립니다.", "에러", MessageBoxButton.OK, Error:true);
            }
        }
        private void BusinessListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Business selected = BusinessListView.SelectedItem as Business;
            if (selected == null)
                return;
        
            BusinessTitle.Text = selected.BusinessTitle;
            BusinessProcessBar.Value = XmlBusinessManager.ReassignBusinessProgress(selected.BusinessTitle);
        }
        private void DeleteBusinessBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BusinessTitle.Text == "")
            {
                BusinessMessageBox.Show("선택된 업무가 없습니다.", "업무 선택");
                return;
            }

            string msg = $"정말로 {BusinessTitle.Text}/{BusinessProcessBar.Value}% 를 삭제하시겠습니까?";
            if (BusinessMessageBox.Show(msg, "삭제", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if(XmlBusinessManager.ExistBusiness(BusinessTitle.Text))
                {
                    XmlBusinessManager.DeleteBusiness(BusinessTitle.Text);
                    BusinessTitle.Text = "";

                    RefreshBusinessList();
                }
            }
        }
        private void OpenBusinessBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BusinessTitle.Text == "")
            {
                BusinessMessageBox.Show("선택된 업무가 없습니다.", "업무 선택");
                return;
            }

            BusinessWindow bw = new BusinessWindow(BusinessTitle.Text);

            bw.Show();
        }

        bool _IsAnimating = false;
        private void Db_Completed(object sender, EventArgs e)
        {
            _IsAnimating = false;
        }
        private void ProgressAverBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_IsAnimating)
                return;

            _IsAnimating = true;

            DoubleAnimation doubleAnimation = new DoubleAnimation
            (e.OldValue, e.NewValue, new Duration(TimeSpan.FromSeconds(0.5)), FillBehavior.Stop);
            doubleAnimation.Completed += Db_Completed;

            ((ProgressBar)sender).BeginAnimation(ProgressBar.ValueProperty, doubleAnimation);

            e.Handled = true;
        }
    }
}
