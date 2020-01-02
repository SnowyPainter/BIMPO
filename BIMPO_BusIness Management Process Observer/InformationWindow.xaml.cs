using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.IO;

namespace BIMPO_BusIness_Management_Process_Observer
{
    /// <summary>
    /// InformationWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InformationWindow : Window
    {
        private string[] diagramShow_Information = {
            "축소 다이어그램 기능을 사용하는 방법은 정말 간단합니다.",
            "[움직임]",
            "마우스 왼쪽클릭과 움직임을 통해서 요소를 움직일수 있습니다.",
            "[관계된 요소 연결]",
            "요소위에 마우스 포인터를 가져다 놓으면, 밑에[+] 모양 버튼이 생깁니다",
            "그것을 마우스 오른쪽 클릭으로 클릭한후, 마우스를 움직여 다른 요소 위에서",
            "다시 마우스 오른쪽 클릭을 하시면 됩니다.",
            "[요소 연결선 삭제]",
            "연결선에 마우스 포인터를 대고, 오른쪽 클릭을 누르시면 삭제를 묻는 창이 뜨고",
            "확인을 하시면 삭제가 됩니다."
        };
        private string[] businessManage_Information =
        {
            "비지니스 관리 창에서의 모든 기능들에대해 설명합니다.",
            "[데드라인 설정]",
            "데드라인을 시작 날짜, 종료 날짜로 설정합니다.",
            "[업무]",
            "\t[업무생성]",
            "\t\t'새 업무' 버튼을 눌러 생성합니다.",
            "\t[업무수정]",
            "\t\t업무 콘텐츠 옆의 '수정'버튼을 눌러 제목과 내용을 편집합니다.",
            "\t\t완료 여부를 설정가능합니다. 진척도에 영향을 미칩니다.",
            "\t[업무파일]",
            "\t\t업무 파일을 추가합니다.\n파일 리스트에서 더블클릭을 통해 열 수 있습니다.",
            "[메모]",
            "전체보기를 통해 다이어그램쇼로 연결할 수 있습니다.",
            "'새 메모' 버튼을 눌러 메모를 생성할 수 있습니다."
        };

        public InformationWindow(string title, string description)
        {
            InitializeComponent();

            WindowTitle.Text = title == null ? "제목없음" : title;
            DescribeText.Text = description == null || description == "" ? "부가 설명 없음" : description;
        }
        public InformationWindow(string title, string description, string contents) :this(title, description)
        {
            ContentsTextBlock.Text = contents == null || contents == "" ? "빈 설명 창입니다" : contents;
        }
        public InformationWindow(string title, string description, Information whatAbout) :this(title, description)
        {
            if (whatAbout == Information.BusinessWindow)
                ContentsTextBlock.Text = string.Join("\n", businessManage_Information);
            else if (whatAbout == Information.DiagramShowWindow)
                ContentsTextBlock.Text = string.Join("\n", diagramShow_Information);
        }
        //<Window Title Bar>
        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BusinessMessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }
        private void WindowDragMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        //</>
        

    }

    public enum Information
    {
        DiagramShowWindow,
        BusinessWindow
    }
}
