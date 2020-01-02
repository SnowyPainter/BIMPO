using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BIMPO_BusIness_Management_Process_Observer
{
    /// <summary>
    /// BusinessWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BusinessWindow : Window
    {
        readonly string BusinessName;
        public BusinessWindow(string businessName)
        {
            InitializeComponent();

            BusinessName = businessName.Trim();
            WindowTitle.Content = BusinessName;
            DeadlineDatesInit(BusinessName);
            BusinessProgressBarInit(BusinessName);
            DirectoryInit(BusinessName);
        }
        private void DirectoryInit(string businessName)
        {
            if (!Directory.Exists($"./{businessName}"))
                IOBusiness.CreateBusinessDirectory(businessName);
        }
        private void TaskListView_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshTaskListView();
        }
        private void MemoStack_Loaded(object sender, RoutedEventArgs e)
        {
            var memos = XmlBusinessManager.SelectSomeMemos(BusinessName, 5); //least three
            CreateMemoStacks(memos);
        }
        private void CreateMemoStacks(List<Memo> memos)
        {
            MemoStack.Children.Clear();

            foreach (Memo memo in memos)
            {
                StackPanel memoGrid = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Background = memo.BackgroundColor,
                    Height = 220,
                    Width = 260,
                    Margin = new Thickness(0, 20, 0, 0)
                };
                memoGrid.Children.Add(new TextBlock
                {
                    TextWrapping = TextWrapping.WrapWithOverflow,
                    Text = memo.Title,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10, 10, 0, 0),
                    FontSize = 18
                });
                memoGrid.Children.Add(new TextBlock
                {
                    TextWrapping = TextWrapping.WrapWithOverflow,
                    Text = memo.Content,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10, 10, 10, 0),
                    FontSize = 15
                });
                MemoStack.Children.Add(memoGrid);
            }
        }
        public void DeadlineDatesInit(string business)
        {
            StartDate_DatePicker.IsEnabled = false;
            EndDate_DatePicker.IsEnabled = false;

            Deadline savedDates = XmlBusinessManager.GetDeadline(business);
            if (savedDates != null)
            {
                StartDate_DatePicker.SelectedDate = savedDates.Start == null ? StartDate_DatePicker.DisplayDate : savedDates.Start;
                EndDate_DatePicker.SelectedDate = savedDates.End == null ? DateTime.Now : savedDates.End;

                int leftDays = (EndDate_DatePicker.SelectedDate.Value - DateTime.Now).Days;
                var absLeftDays = Math.Abs(leftDays);

                LeftDatesLabel.Content = leftDays < 0 ? $"{absLeftDays}일 지남" : $"{absLeftDays}일 남음";
            }

        }
        public void BusinessProgressBarInit(string business)
        {
            BusinessProgressBar.Value = XmlBusinessManager.GetBusinessProgress(business);
        }
        // </Inits>

        //<Window title bar>

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BusinessWndow_Closing(object sender, CancelEventArgs e)
        {
            if (BusinessMessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                e.Cancel = true;
        }
        private void WindowDragMove_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
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
        private void ShowHowtoBtn_Click(object sender, RoutedEventArgs e)
        {
            InformationWindow iw = new InformationWindow("비지니스 관리", "간편하고 자유로운 비지니스 관리에 대한 내용입니다.", Information.BusinessWindow);
            iw.Show();
        }
        //</Window title bar>
        BrushConverter BrushConv = new BrushConverter();

        //<dead line bar>
        bool IsDeadlineEditMode = false;
        DateTime LastDeadlineEndDate, LastDeadlineStartDate;

        private void SaveDeadlineDateBn_Click(object sender, RoutedEventArgs e)
        {
            if (IsDeadlineEditMode)
            {

                if (StartDate_DatePicker.SelectedDate != null && EndDate_DatePicker.SelectedDate != null)
                {
                    var startDate = StartDate_DatePicker.SelectedDate.Value;
                    var endDate = EndDate_DatePicker.SelectedDate.Value;

                    int leftDays = (EndDate_DatePicker.SelectedDate.Value - DateTime.Now).Days;
                    var absLeftDays = Math.Abs(leftDays);

                    LeftDatesLabel.Content = leftDays < 0 ? $"{absLeftDays}일 지남" : $"{absLeftDays}일 남음";
                    XmlBusinessManager.SetDeadline(BusinessName, new Deadline(startDate, endDate));

                    BusinessMessageBox.Show($"데드라인을 {startDate.ToShortDateString()}에서 {endDate.ToShortDateString()}까지로 설정했습니다.",
                        "데드라인 설정", MessageBoxButton.OK);
                }
                else
                {
                    BusinessMessageBox.Show("데드라인 설정이 잘 못 되었습니다 올바른 값을 입력해주세요.", "정보 입력", Error: true);
                }
                SaveDeadlineDateBn.Content = "데드라인 설정";
                SaveDeadlineDateBn.Background = (Brush)BrushConv.ConvertFrom("#FFF06200");
            }
            else
            {
                SaveDeadlineDateBn.Content = "변경 확인";
                SaveDeadlineDateBn.Background = (Brush)BrushConv.ConvertFrom("#FF00B439");
            }

            StartDate_DatePicker.IsEnabled = !IsDeadlineEditMode;
            EndDate_DatePicker.IsEnabled = !IsDeadlineEditMode;
            IsDeadlineEditMode = !IsDeadlineEditMode;
        }

        private void EndDate_DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var startDate = StartDate_DatePicker.SelectedDate == null ? StartDate_DatePicker.DisplayDate : StartDate_DatePicker.SelectedDate.Value;

            if (DateTime.Compare(startDate, EndDate_DatePicker.SelectedDate.Value) > 0)
            {
                BusinessMessageBox.Show("시작일 보다 이전의 날짜는 설정이 불가능합니다.", "정보 입력", Error: true);
                EndDate_DatePicker.SelectedDate = LastDeadlineEndDate;
            }
        }

        private void EndDate_DatePicker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (EndDate_DatePicker.SelectedDate != null)
                LastDeadlineEndDate = EndDate_DatePicker.SelectedDate.Value;
            else
                LastDeadlineEndDate = DateTime.Now;
        }

        private void StartDate_DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EndDate_DatePicker.SelectedDate == null)
                return;

            if (DateTime.Compare(StartDate_DatePicker.SelectedDate.Value, EndDate_DatePicker.SelectedDate.Value) > 0)
            {
                BusinessMessageBox.Show("종료일 보다 앞선 날짜는 설정이 불가능합니다.", "정보 입력", Error: true);
                StartDate_DatePicker.SelectedDate = LastDeadlineStartDate;
            }
        }
        private void StartDate_DatePicker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (StartDate_DatePicker.SelectedDate != null)
                LastDeadlineStartDate = StartDate_DatePicker.SelectedDate.Value;

        }
        //</dead line bar>
        //<Work Flow Form> / ListView
        bool SortedDescending = true; // Refresh
        private void SortPriorityHeader_Click(object sender, RoutedEventArgs e)
        {
            if (SortedDescending)
                SortPriorityIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowDown;
            else
                SortPriorityIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowUp;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(TaskListView.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription("Priority", SortedDescending ? ListSortDirection.Ascending : ListSortDirection.Descending));

            SortedDescending = !SortedDescending;
        }
        private void TaskPriorityTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //Refreshing
        public void RefreshTaskListView()
        {
            List<WorkTask> tasks = XmlBusinessManager.GetAllTasks(BusinessName);
            if (tasks == null)
            {
                BusinessMessageBox.Show("업무 파일에 심각한 오류가 있습니다.", "에러", MessageBoxButton.OK, true);
            }
            BusinessProgressBar.Value = XmlBusinessManager.ReassignBusinessProgress(BusinessName);
            TitleTextbox.Text = "";
            DescribeTextbox.Text = "";
            TaskPriorityTextbox.Text = "";
            SelectedTask = null;
            TaskListView.ItemsSource = tasks;
        }
        public void RefreshTaskFiles()
        {
            if (SelectedTask != null)
                FileListbox.ItemsSource = IOBusiness.GetTaskFileNames(BusinessName, SelectedTask.Title);
        }
        public void RefreshLeastMemoStacks(int howMany)
        {
            var memos = XmlBusinessManager.SelectSomeMemos(BusinessName, howMany);
            CreateMemoStacks(memos);
        }
        //Refreshing
        //</Work Flow Form>
        //<Task Options>

        WorkTask SelectedTask;

        bool IsEditMode = false;
        private void DeleteTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask == null)
            {
                BusinessMessageBox.Show("선택된 업무가 없습니다.", "삭제 실패");
                return;
            }
            else if (BusinessMessageBox.Show($"정말 {SelectedTask.Title}를 삭제하시겠습니까?", "삭제", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                XmlBusinessManager.DeleteTask(BusinessName, SelectedTask.Index);

                BusinessMessageBox.Show($"{SelectedTask.Title}에 대한 삭제가 완료되었습니다.", "삭제 완료");

                SelectedTask = null;

                RefreshTaskListView();
            }
        }

        private void EditTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask == null)
            {
                BusinessMessageBox.Show("선택된 업무가 없습니다.", "업무 선택");
                return;
            }

            if (IsEditMode) //saving
            {
                EditTaskBtn.Content = "수정";
                EditTaskBtn.Background = Brushes.Gray;

                if (SelectedTask.Title == TitleTextbox.Text
                    && SelectedTask.Content == DescribeTextbox.Text
                    && SelectedTask.Priority == TaskPriorityTextbox.Text
                    && SelectedTask.Accomplished == AccomplishCheckBox.IsChecked)
                {
                    BusinessMessageBox.Show("변경사항이 없습니다.", "정보 변경");
                }
                else
                {
                    if (SelectedTask.Title != TitleTextbox.Text)
                    {
                        var nowPath = AppDomain.CurrentDomain.BaseDirectory;

                        if (Directory.Exists($@".\{BusinessName}\{SelectedTask.Title}"))
                            Directory.Move($@"{nowPath}{BusinessName}\{SelectedTask.Title}", $@"{nowPath}{BusinessName}\{TitleTextbox.Text}");

                        XmlBusinessManager.SetTaskTitle(BusinessName, SelectedTask.Index, TitleTextbox.Text);
                    }
                    if (SelectedTask.Content != DescribeTextbox.Text)
                        XmlBusinessManager.SetTaskDescribeText(BusinessName, SelectedTask.Index, DescribeTextbox.Text);
                    if (SelectedTask.Priority != TaskPriorityTextbox.Text)
                        XmlBusinessManager.SetTaskPriority(BusinessName, SelectedTask.Index, TaskPriorityTextbox.Text);
                    if (SelectedTask.Accomplished != AccomplishCheckBox.IsChecked)
                        XmlBusinessManager.SetTaskAccomplished(BusinessName, SelectedTask.Index, bool.Parse(AccomplishCheckBox.IsChecked.ToString()));

                    BusinessMessageBox.Show("변경 완료되었습니다.", "정보 변경");
                    RefreshTaskListView();
                }
            }
            else
            {
                EditTaskBtn.Background = Brushes.Green;
                EditTaskBtn.Content = "변경 확인";
            }

            TitleTextbox.IsEnabled = !TitleTextbox.IsEnabled;
            DescribeTextbox.IsEnabled = !DescribeTextbox.IsEnabled;
            TaskPriorityTextbox.IsEnabled = !TaskPriorityTextbox.IsEnabled;
            AccomplishCheckBox.IsEnabled = !AccomplishCheckBox.IsEnabled;
            AddFileBtn.IsEnabled = !AddFileBtn.IsEnabled;
            IsEditMode = !IsEditMode;

        }
        private void TaskListView_MouseDoubleCick(object sender, MouseButtonEventArgs e)
        {
            WorkTask selected = (sender as ListView).SelectedItem as WorkTask;
            if (selected == null)
                return;
            else if (SelectedTask != null && SelectedTask.Equals(selected))
            {
                TitleTextbox.Text = "";
                DescribeTextbox.Text = "";
                TaskPriorityTextbox.Text = "";
                AccomplishCheckBox.IsChecked = false;
                AddFileBtn.IsEnabled = false;
                FileListbox.ItemsSource = null;

                SelectedTask = null;

                return;
            }

            TitleTextbox.Text = selected.Title;
            DescribeTextbox.Text = selected.Content;
            TaskPriorityTextbox.Text = selected.Priority.ToString();
            AccomplishCheckBox.IsChecked = selected.Accomplished;
            FileListbox.ItemsSource = IOBusiness.GetTaskFileNames(BusinessName, selected.Title);
            AddFileBtn.IsEnabled = true;

            SelectedTask = selected;
        }

        private void OpenCreateTaskWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            TaskCreateWindow window = new TaskCreateWindow(BusinessName);
            window.ShowDialog();

            if (window.Result != null)
            {
                RefreshTaskListView();
            }
        }

        //Add Task File To taskDirectory ( csv, py any else)
        private void AddFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask == null)
                return;

            if (!Directory.Exists($"./{BusinessName}/{SelectedTask.Title}"))
                IOBusiness.CreateTaskDirectory(BusinessName, SelectedTask.Title);

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                IOBusiness.AttachFileToTask(BusinessName, SelectedTask.Title, ofd.FileName);

                BusinessMessageBox.Show("파일 추가가 완료되었습니다.", "업무 파일");

                RefreshTaskFiles();
            }
        }
        //Open Task File
        private void FileListbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string selectedTitle = FileListbox.SelectedItem as string;

            if (SelectedTask == null || selectedTitle == null)
                return;

            if (BusinessMessageBox.Show($"{selectedTitle}을(를) 여시겠습니까?", "열기", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    Process.Start($@"{AppDomain.CurrentDomain.BaseDirectory}/{BusinessName}/{SelectedTask.Title}/{selectedTitle}");
                }
                catch (Win32Exception)
                {
                    BusinessMessageBox.Show("열려고 시도했지만 연결된 프로그램이 없었습니다.", "열기 실패", Error: true);
                }
            }
        }
        //</TaskOptions>
        //<Memo>
        private void CreateNewMemoBtn_Click(object sender, RoutedEventArgs e)
        {
            MemoCreation window = new MemoCreation(BusinessName);
            window.ShowDialog();

            RefreshLeastMemoStacks(3);
        }
        private void SeeAllMemosBtn_Click(object sender, RoutedEventArgs e)
        {
            DiagramShowWindow memoWindow = new DiagramShowWindow(BusinessName);

            memoWindow.ShowDialog();
        }
        //</Memo>

    }
}
