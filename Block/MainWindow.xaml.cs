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

        const int N = 10; //размер поля
        public int[,] mainField = new int[N, N] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }; //массив-схема основного поля

        const int M = 4;
        public int[,] shapeField = new int[M, N] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

        public int[,] figure1 = new int[M, M] { { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure2 = new int[M, M] { { 0, 0, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure3 = new int[M, M] { { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure4 = new int[M, M] { { 0, 0, 0, 0 }, { 0, 1, 1, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure5 = new int[M, M] { { 0, 0, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure6 = new int[M, M] { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure7 = new int[M, M] { { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure8 = new int[M, M] { { 0, 0, 0, 0 }, { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure9 = new int[M, M] { { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure10 = new int[M, M] { { 0, 0, 0, 0 }, { 1, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure11 = new int[M, M] { { 1, 1, 1, 0 }, { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure12 = new int[M, M] { { 1, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } };
        public int[,] figure13 = new int[M, M] { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 1, 1, 1, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure14 = new int[M, M] { { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 1, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure15 = new int[M, M] { { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 } };
        public int[,] figure16 = new int[M, M] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        public int[,] figure19 = new int[M, M] { { 1, 1, 1, 0 }, { 1, 1, 1, 0 }, { 1, 1, 1, 0 }, { 0, 0, 0, 0 } };


        double cellWidth = 40.0;
        double cellHeight = 40.0;

        public MainWindow()
        {
            InitializeComponent();

            //перенос фигуры на поле

            canvasMain = Redraw(mainField, canvasMain);
            canvasUpper = Redraw(shapeField, canvasUpper);
        }

        public Canvas Redraw(int[,] field, Canvas currentCanvas)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);


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

        public Canvas Delete_Rows_Columns(ref int[,] field, Canvas canvas_Main)
        {
            //int rows = field.GetLength(1);
            //int columns = field.GetLength(0);
            bool flag_rows = false; //false - если ряд полностью заполнен, true - если в ряду есть хотя бы один 0
            bool flag_columns = false; //false - если столбец полностью заполнен, true - если в столбце есть хотя бы один 0

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (field[i, j] == 0) //в ряду есть хотя бы одна свободная клетка
                        flag_rows = true; 

                    if (field[j, i] == 0) //в столбце есть хотя бы одна свободная клетка
                        flag_columns = true;
                }

                if (!flag_rows) //если весь ряд заполнен
                {
                    Rectangle rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Gray);
                    rect.Width = cellWidth;
                    rect.Height = cellHeight;

                    for (int j2 = 0; j2 < N; j2++)
                    {
                        Canvas.SetLeft(rect, rect.Width * j2);
                        Canvas.SetTop(rect, rect.Height * i);
                        canvas_Main.Children.Add(rect);

                        field[i, j2] = 0;
                    }
                }

                if (!flag_rows) //если весь столбец заполнен
                {
                    Rectangle rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Gray);
                    rect.Width = cellWidth;
                    rect.Height = cellHeight;

                    for (int j2 = 0; j2 < N; j2++)
                    {
                        Canvas.SetLeft(rect, rect.Width * i);
                        Canvas.SetTop(rect, rect.Height * j2);
                        canvas_Main.Children.Add(rect);

                        field[j2, i] = 0;
                    }
                }

                flag_rows = false;
                flag_columns = false;
            }

            return canvas_Main;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
    }


}