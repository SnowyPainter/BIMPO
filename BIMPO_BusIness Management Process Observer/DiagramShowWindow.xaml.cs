using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace BIMPO_BusIness_Management_Process_Observer
{
    /// <summary>
    /// MemoChartWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DiagramShowWindow : Window
    {
        readonly string BusinessName;
        bool TaskList = true;
        public DiagramShowWindow(string busName)
        {
            InitializeComponent();

            BusinessName = busName;
        }

        private void WorkItemListview_Loaded(object sender, RoutedEventArgs e)
        {
            if (TaskList)
                WorkItemListview.ItemsSource = XmlBusinessManager.GetAllTasks(BusinessName);
            else
                WorkItemListview.ItemsSource = XmlBusinessManager.GetAllMemos(BusinessName);
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
        private void Snapshot(UIElement source, int quality, string path)
        {
            RenderTargetBitmap renderTargetBitmap =
                new RenderTargetBitmap((int)source.RenderSize.Width, (int)source.RenderSize.Height, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(source);
            PngBitmapEncoder pngImage = new PngBitmapEncoder();
            pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            using (Stream fileStream = File.Create(path))
            {
                pngImage.Save(fileStream);
            }
        }
        private void ShareBtn_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "메모 스냅샷을 저장할 위치";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            saveFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (saveFileDialog.ShowDialog() == true)
            {
                Snapshot(DiagramCanvas, 100, saveFileDialog.FileName);
            }
        }
        private void DownloadDiagramBtn_Click(object sender, RoutedEventArgs e)
        {
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}/{BusinessName}";
            System.Diagnostics.Process.Start(path);
        }
        private void ShowHowtoBtn_Click(object sender, RoutedEventArgs e) //how to. inform
        {
            InformationWindow informWindow = new
                InformationWindow("다이어그램의 사용", "다이어그램 사용방법에 대해 간단히 서술합니다", Information.DiagramShowWindow);
            informWindow.Show();
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BusinessMessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                e.Cancel = true;

            if (!SaveDiagramInformations())
            {
                if (BusinessMessageBox.Show("저장 도중에 문제가 생겼습니다.\n종료하시겠습니까??", "종료", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                    e.Cancel = true;
            }

        }
        private void WindowDragMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        //</Window title bar>
        private bool SaveDiagramInformations()
        {
            //saving locations and stacks
            if (!IOBusiness.ExistBusiness(BusinessName))
                IOBusiness.CreateBusinessDirectory(BusinessName);

            var duie = DiagramUIPanelToDiagramUIElements(DiagramUIElements);
            var diaUiLines = DiagramLineToUILines(DiagramLines);
            string businessDirectory = $"./{BusinessName}/";
            IOBusiness.Save(businessDirectory + FileNames.DiagramControlsSave, duie);
            IOBusiness.Save(businessDirectory + FileNames.DiagramLinesSave, diaUiLines);
            return true;
        }
        //Convert diagramline class to class that contains UI information (DiagramUILine)
        private List<DiagramUIElement> DiagramUIPanelToDiagramUIElements(List<StackPanel> uielements)
        {
            List<DiagramUIElement> returnElements = new List<DiagramUIElement>();
            foreach (var uie in uielements)
            {
                Thickness margin = uie.Margin;
                Brush bc = uie.Background;
                int tag = int.Parse(uie.Tag.ToString());
                string title = uie.Children.OfType<TextBlock>()
                    .FirstOrDefault(t => t.Tag.ToString() == "title").Text;
                string content = (uie.Children.OfType<Label>()
                    .FirstOrDefault(l => l.Tag.ToString() == "content").Content as TextBlock).Text;

                returnElements.Add(new DiagramUIElement(title, content, bc, margin, tag));
            }
            return returnElements;
        }
        private List<DiagramUILine> DiagramLineToUILines(List<DiagramLine> diaLines)
        {
            List<DiagramUILine> diaUiLines = new List<DiagramUILine>();

            foreach (var line in diaLines)
            {
                int startTag = int.Parse((line.StartElement as StackPanel).Tag.ToString());
                int endTag = int.Parse((line.EndElement as StackPanel).Tag.ToString());
                diaUiLines.Add(new DiagramUILine(startTag, endTag
                    , new Point(line.Line.X1, line.Line.Y1), new Point(line.Line.X2, line.Line.Y2), line.Line.Stroke));
            }

            return diaUiLines;
        }
        //<Memo Listview>
        //<ControlDrag and Drop>
        private bool MMove = false;
        private Point MPoint1;
        private Point MPoint2;
        private StackPanel diagramPanel;
        private List<DiagramLine> connectedLines;

        //MouseDown EventHandler ---------
        private void DiagramElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is StackPanel))
                return;

            diagramPanel = (StackPanel)sender;

            if (!movingLine && e.RightButton == MouseButtonState.Pressed)
            {
                if (DiagramLines.Any(l => l.CheckConnected(diagramPanel) != 0))
                {
                    BusinessMessageBox.Show("이 객체에 연결된 다이어그램선이 있습니다.", "다이어그램 객체 삭제");
                }
                else if (BusinessMessageBox.Show("정말 이 객체를 삭제하시겠습니까?", "다이어그램 객체 삭제", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DiagramUIElements.Remove(diagramPanel);
                    DiagramCanvas.Children.Remove(diagramPanel);
                }
            }
            else // If not trying to delete it
            {
                Func<List<DiagramLine>, UIElement, List<DiagramLine>> GetConnectedLines
                = (Lines, BaseElement) =>
                {
                    List<DiagramLine> lines = new List<DiagramLine>();
                    foreach (var line in Lines)
                    {
                        if (line.CheckConnected(BaseElement) != 0)
                            lines.Add(line);
                    }
                    return lines;
                };
                connectedLines = GetConnectedLines(DiagramLines, diagramPanel);
                MPoint1 = e.GetPosition(DiagramCanvas);
                MPoint2 = e.GetPosition(diagramPanel);

                MPoint1.X -= diagramPanel.Margin.Left + MPoint2.X;
                MPoint1.Y -= diagramPanel.Margin.Top + MPoint2.Y;

                Mouse.Capture(diagramPanel);

                MMove = true;
            }

        }
        //MouseMove EventHandler ---------
        private void DiagramElement_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is StackPanel)
            {
                //check move indicator
                if (MMove == true)
                {
                    //get control moved
                    diagramPanel = (StackPanel)sender;

                    //get container pointer
                    var currentPoint = e.GetPosition(DiagramCanvas);

                    //check which mouse button is pressed
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        //update control margin thickness
                        diagramPanel.Margin = new Thickness(
                            currentPoint.X - MPoint1.X - MPoint2.X,
                            currentPoint.Y - MPoint1.Y - MPoint2.Y,
                            diagramPanel.Margin.Right,
                            diagramPanel.Margin.Bottom
                        );
                    }
                    foreach (var diaLine in connectedLines)
                    {
                        if (diaLine.CheckConnected(diagramPanel) == 1) //Start X1, Y1
                        {
                            diaLine.SetXY1(diagramPanel.Margin.Left + diaLine.StartElementMarginDistance.Left, diagramPanel.Margin.Top + diaLine.StartElementMarginDistance.Top);
                        }
                        else //End X2, Y2
                        {
                            diaLine.SetXY2(diagramPanel.Margin.Left + diaLine.EndElementMarginDistance.Left, diagramPanel.Margin.Top + diaLine.EndElementMarginDistance.Top);
                        }
                    }
                }
            }
        }
        //MouseUp EventHandler ---------
        private void DiagramElement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            connectedLines = null;
            MMove = false;
            diagramPanel = null;
            Mouse.Capture(null);
        }
        //</ControlDrag and Drop>
        //<Mouse Enter/Leave -> Draw Flow line>
        private void DiagramElement_MouseEnter(object sender, MouseEventArgs e)
        {
            var panel = sender as StackPanel;
            if (!movingLine && panel != null)
            {
                var startingDrawlineBtn = panel.Children.OfType<Grid>().FirstOrDefault();
                startingDrawlineBtn.Visibility = Visibility.Visible;
            }
            else if (movingLine && panel != startElement as StackPanel)
            {
                endElement = panel;
                isOverEnd = true;
            }

            if (movingLine && panel == startElement as StackPanel)
                isOverMy = true;
        }
        private void DiagramElement_MouseLeave(object sender, MouseEventArgs e)
        {
            var panel = sender as StackPanel;

            var startingDrawlineBtn = panel.Children.OfType<Grid>().FirstOrDefault();
            startingDrawlineBtn.Visibility = Visibility.Hidden;

            if (movingLine && panel == startElement as StackPanel)
            {
                isOverMy = false;
            }
            else if (movingLine)
            {
                endElement = null;
                isOverEnd = false;
            }
        }
        //</Mouse Enter/Leave -> Draw Flow line>
        //<Starting Draw line flow>
        //MouseDown EventHandler ---------
        private Line flowLine; //reality wpf moving
        private UIElement startElement, endElement;
        private List<DiagramLine> DiagramLines = new List<DiagramLine>();
        private List<StackPanel> DiagramUIElements = new List<StackPanel>();
        private bool movingLine = false, isOverEnd = false, isOverMy = false;//처음생성하고 나간 여부
        private void DrawLine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid && !movingLine && e.RightButton == MouseButtonState.Pressed)
            {
                var parent = sender as Grid;
                var location = e.GetPosition(DiagramCanvas);
                flowLine = new Line
                {
                    StrokeThickness = 4,
                    Stroke = parent.Parent.GetValue(BackgroundProperty) as Brush,
                    X1 = location.X,
                    Y1 = location.Y,
                    X2 = location.X,
                    Y2 = location.Y,
                };
                DiagramCanvas.Children.Add(flowLine);
                Panel.SetZIndex(flowLine, 2);
                startElement = parent.Parent as UIElement;

                movingLine = true;
                isOverMy = true;
            }
        }
        private void DiagramLine_MouseRightButtonDown(object sender, MouseButtonEventArgs e) //DELETE LINE
        {
            Line line = sender as Line;
            if (!movingLine)
            {
                if (BusinessMessageBox.Show("정말 이 선을 삭제 하시겠습니까?", "다이어그램 선 삭제", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DiagramLines.RemoveAll(l => l.Line == line);
                    DiagramCanvas.Children.Remove(line);
                }
            }
        }
        private void DiagramCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingLine)
            {
                var pos = e.GetPosition(DiagramCanvas);
                flowLine.X2 = pos.X;
                flowLine.Y2 = pos.Y;
            }
        }
        private void DiagramCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (movingLine && isOverEnd && !isOverMy)
            {
                flowLine.MouseRightButtonDown += new MouseButtonEventHandler(DiagramLine_MouseRightButtonDown);
                DiagramLine newLine = new DiagramLine(flowLine, startElement, endElement);
                DiagramLines.Add(newLine);

                movingLine = false;
                isOverMy = false;
                isOverEnd = false;
                flowLine = null;
                Mouse.Capture(null);
            }
            else if (movingLine && !isOverEnd && !isOverMy)
            {
                DiagramCanvas.Children.Remove(flowLine);
                movingLine = false;
                flowLine = null;
                Mouse.Capture(null);
            }
        }

        //</Starting Draw line flow>
        //create IDiagramElement to canvas dynamically
        private void MemoListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IDiagramElement diagramElement;

            var selectedItem = (sender as ListView).SelectedItem;

            if (selectedItem == null)
                return;

            if (!TaskList)
                diagramElement = selectedItem as Memo;
            else
                diagramElement = selectedItem as WorkTask;

            int count = DiagramCanvas.Children.OfType<StackPanel>().Count();

            CreateDiagramUIElement(count, diagramElement.Title, diagramElement.Content, new Thickness(10, 10, 10, 10)
                , (selectedItem is Memo) ? (selectedItem as Memo).BackgroundColor : Brushes.Gray);
        }
        private void CreateDiagramUIElement(int tag, string title, string contents, Thickness margin, Brush background)
        {

            var stackPanel = new StackPanel
            {
                Tag = tag.ToString(),
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Top,
                Background = background,
                Margin = margin
            }; //Memo textPanel
            stackPanel.Children.Add(new TextBlock
            {
                Tag = "title",
                TextWrapping = TextWrapping.WrapWithOverflow,
                Text = title,
                Margin = new Thickness(5, 10, 0, 0),
                Foreground = Brushes.White
            }); // Title textblock
            var contentTextblock = new Label
            {
                Tag = "content",
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(0, 40, 0, 0),
                Width = 150
            };
            var content = new TextBlock
            {
                Foreground = Brushes.White,
                FontSize = 11,
                TextWrapping = TextWrapping.WrapWithOverflow,
                Text = contents
            }; // Content textblock
            contentTextblock.Content = content;
            var startingDrawlinePanel = new Grid
            {
                Width = 30,
                Height = 30,
                Background = Brushes.Transparent,
                VerticalAlignment = VerticalAlignment.Bottom,
                Visibility = Visibility.Hidden
            };
            var plusIcon = new PackIcon
            {
                Kind = PackIconKind.AddBox,
                Width = 30,
                Height = 30,
                Foreground = Brushes.White
            };

            startingDrawlinePanel.Children.Add(plusIcon);
            stackPanel.Children.Add(contentTextblock); // add content textlbock
            stackPanel.Children.Add(startingDrawlinePanel); // draw line btn

            //Drag and Move triggers for
            stackPanel.MouseDown += new MouseButtonEventHandler(DiagramElement_MouseDown);
            stackPanel.MouseMove += new MouseEventHandler(DiagramElement_MouseMove);
            stackPanel.MouseUp += new MouseButtonEventHandler(DiagramElement_MouseUp);

            stackPanel.MouseEnter += new MouseEventHandler(DiagramElement_MouseEnter);
            stackPanel.MouseLeave += new MouseEventHandler(DiagramElement_MouseLeave);

            startingDrawlinePanel.MouseDown += new MouseButtonEventHandler(DrawLine_MouseDown);

            DiagramUIElements.Add(stackPanel);
            DiagramCanvas.Children.Add(stackPanel);
            Panel.SetZIndex(stackPanel, 3);
        }
        private void CreateDiagramUILine(int startTag, int endTag, Point xy1, Point xy2, Brush stroke)
        {
            Line line = new Line
            {
                StrokeThickness = 4,
                Stroke = stroke,
                X1 = xy1.X,
                Y1 = xy1.Y,
                X2 = xy2.X,
                Y2 = xy2.Y,
            };
            StackPanel startEle = DiagramCanvas.Children.OfType<StackPanel>()
                .FirstOrDefault(p => int.Parse(p.Tag.ToString()) == startTag);
            StackPanel endEle = DiagramCanvas.Children.OfType<StackPanel>()
                .FirstOrDefault(p => int.Parse(p.Tag.ToString()) == endTag);

            line.MouseRightButtonDown += new MouseButtonEventHandler(DiagramLine_MouseRightButtonDown);
            DiagramLine dl = new DiagramLine(line, startEle, endEle);

            DiagramLines.Add(dl);
            DiagramCanvas.Children.Add(line);
            Panel.SetZIndex(line, 2);
        }
        //Load Serialized Diagram Information and Adding ui elements on Canvas
        private void DiagramCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            var brushConverter = new BrushConverter();

            if (File.Exists($"./{BusinessName}/{FileNames.DiagramControlsSave}"))
            {
                var elements = IOBusiness.Load<DiagramUIElement>($"./{BusinessName}/{FileNames.DiagramControlsSave}");
                int tagCount = 0;
                foreach (var element in elements)
                {
                    CreateDiagramUIElement(tagCount++, element.Title, element.Content,
                        (Thickness)new ThicknessConverter().ConvertFromString(element.Margin),
                        new BrushConverter().ConvertFromString(element.BackgroundColorHex) as SolidColorBrush);
                }
            }
            if(File.Exists($"./{BusinessName}/{FileNames.DiagramLinesSave}"))
            {
                var lines = IOBusiness.Load<DiagramUILine>($"./{BusinessName}/{FileNames.DiagramLinesSave}");
                foreach (var line in lines)
                {
                    CreateDiagramUILine(line.StartElementTag, line.EndElementTag
                        , new Point(line.x1, line.y1), new Point(line.x2, line.y2),
                        brushConverter.ConvertFromString(line.strokeColorHex) as SolidColorBrush);
                }
            }
        }
        private void SetListToTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            TaskList = true;
            WorkItemListview.ItemsSource = XmlBusinessManager.GetAllTasks(BusinessName);
        }
        private void SetListToMemoBtn_Cick(object sender, RoutedEventArgs e)
        {
            TaskList = false;
            WorkItemListview.ItemsSource = XmlBusinessManager.GetAllMemos(BusinessName);
        }
        private void DiagramSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!SaveDiagramInformations())
            {
                BusinessMessageBox.Show("저장 도중에 문제가 생겼습니다.", "저장 오류", Error: true);
            }
            else
            {
                BusinessMessageBox.Show("저장 완료 / "+DateTime.Now.ToShortTimeString(), "저장 성공");
            }
        }
    }
}
