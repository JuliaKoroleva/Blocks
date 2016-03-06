using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Block
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const int N = 3; //размер поля
        public int[,] field = new int[N, N] { { 0, 1, 0 }, { 0, 2, 1 }, { 0, 0, 0 } }; //массив-схема основного поля



        public MainWindow()
        {
            InitializeComponent();
            canvasMain = Redraw(field, canvasMain);
        }

        public Canvas Redraw(int[,] field, Canvas currentCanvas)
        {
            int rows = field.GetLength(1);
            int columns = field.GetLength(0);
            double cellWidth = currentCanvas.Width / Convert.ToDouble(rows);
            double cellHeight = currentCanvas.Width / Convert.ToDouble(columns);



            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Gray);
                    rect.Width = cellWidth;
                    rect.Height = cellHeight;

                    if (field[i, j] != 0)
                    {
                        rect.Fill = new SolidColorBrush(Colors.LightCoral);
                    }

                    Canvas.SetLeft(rect, rect.Width * j);
                    Canvas.SetTop(rect, rect.Height * i);
                    currentCanvas.Children.Add(rect);
                }
            }

            return currentCanvas;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
    }


}