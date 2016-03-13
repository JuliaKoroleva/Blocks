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
        public int[,] mainField = new int[N, N];

        const int M = 4;
        const int K = 5;
        public int[,] shapeField = new int[M, K];

        Figure figure1; Figure figure2; Figure figure3;
        Figure figure4; Figure figure5; Figure figure6;
        Figure figure7; Figure figure8; Figure figure9;
        Figure figure10; Figure figure11; Figure figure12;
        Figure figure13; Figure figure14; Figure figure15;
        Figure figure16; Figure figure17;

        int[,] shape1 = new int[M, M] { { 0, 0, 0, 0 }, 
                                            { 0, 1, 0, 0 }, 
                                            { 0, 0, 0, 0 }, 
                                            { 0, 0, 0, 0 } };
        int[,] shape2 = new int[M, M] { { 0, 0, 0, 0 }, 
                                            { 0, 1, 1, 0 }, 
                                            { 0, 0, 0, 0 }, 
                                            { 0, 0, 0, 0 } };

        int[,] shape3 = new int[M, M] { { 0, 0, 0, 0 }, 
                                            { 0, 1, 0, 0 }, 
                                            { 0, 1, 0, 0 }, 
                                            { 0, 0, 0, 0 } };

        int[,] shape4 = new int[M, M] { { 0, 0, 0, 0 }, 
                                            { 0, 1, 1, 0 }, 
                                            { 0, 1, 0, 0 }, 
                                            { 0, 0, 0, 0 } };

        int[,] shape5 = new int[M, M] { { 0, 0, 0, 0 }, 
                                            { 0, 1, 1, 0 }, 
                                            { 0, 0, 1, 0 }, 
                                            { 0, 0, 0, 0 } };

        int[,] shape6 = new int[M, M] { { 0, 0, 0, 0 }, 
                                            { 0, 0, 1, 0 }, 
                                            { 0, 1, 1, 0 }, 
                                            { 0, 0, 0, 0 } };

        int[,] shape7 = new int[M, M] { { 0, 0, 0, 0 }, 
                                            { 0, 1, 0, 0 }, 
                                            { 0, 1, 1, 0 }, 
                                            { 0, 0, 0, 0 } };

        int[,] shape8 = new int[M, M] { { 0, 0, 0, 0 }, 
                                            { 0, 1, 1, 0 }, 
                                            { 0, 1, 1, 0 }, 
                                            { 0, 0, 0, 0 } };

        int[,] shape9 = new int[M, M] { { 0, 1, 0, 0 }, 
                                            { 0, 1, 0, 0 }, 
                                            { 0, 1, 0, 0 }, 
                                            { 0, 0, 0, 0 } };

        int[,] shape10 = new int[M, M] { { 0, 0, 0, 0 }, 
                                             { 1, 1, 1, 0 }, 
                                             { 0, 0, 0, 0 }, 
                                             { 0, 0, 0, 0 } };

        int[,] shape11 = new int[M, M] { { 1, 1, 1, 0 }, 
                                             { 1, 0, 0, 0 }, 
                                             { 1, 0, 0, 0 }, 
                                             { 0, 0, 0, 0 } };

        int[,] shape12 = new int[M, M] { { 1, 1, 1, 0 }, 
                                             { 0, 0, 1, 0 }, 
                                             { 0, 0, 1, 0 }, 
                                             { 0, 0, 1, 0 } };

        int[,] shape13 = new int[M, M] { { 0, 0, 1, 0 }, 
                                             { 0, 0, 1, 0 }, 
                                             { 1, 1, 1, 0 }, 
                                             { 0, 0, 0, 0 } };

        int[,] shape14 = new int[M, M] { { 1, 0, 0, 0 },
                                             { 1, 0, 0, 0 }, 
                                             { 1, 1, 1, 0 }, 
                                             { 0, 0, 0, 0 } };

        int[,] shape15 = new int[M, M] { { 0, 1, 0, 0 }, 
                                             { 0, 1, 0, 0 }, 
                                             { 0, 1, 0, 0 }, 
                                             { 0, 1, 0, 0 } };

        int[,] shape16 = new int[M, M] { { 0, 0, 0, 0 }, 
                                             { 1, 1, 1, 1 }, 
                                             { 0, 0, 0, 0 }, 
                                             { 0, 0, 0, 0 } };

        int[,] shape17 = new int[M, M] { { 1, 1, 1, 0 }, 
                                             { 1, 1, 1, 0 }, 
                                             { 1, 1, 1, 0 }, 
                                             { 0, 0, 0, 0 } };

        double cellWidth = 40.0;
        double cellHeight = 40.0;

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < N; i++) //Создаем массив-схему основного поля
            {
                for (int j = 0; j < N; j++)
                {
                    mainField[i, j] = 0;
                }
            }

            for (int i = 0; i < M; i++) //Создаем массив-схему верхнего поля
            {
                for (int j = 0; j < K; j++)
                {
                    shapeField[i, j] = 0;
                }
            }

            canvasMain = Redraw(mainField, canvasMain);
            canvasUpper1 = Redraw(shapeField, canvasUpper1);
            canvasUpper2 = Redraw(shapeField, canvasUpper2);
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
                        Random rand = new Random();
                        switch (rand.Next() % 6)
                        {
                            case 0:
                                rect.Fill = new SolidColorBrush(Colors.LightCoral);
                                break;
                            case 1:
                                rect.Fill = new SolidColorBrush(Colors.LightGreen);
                                break;
                            case 2:
                                rect.Fill = new SolidColorBrush(Colors.LightSkyBlue);
                                break;
                            case 3:
                                rect.Fill = new SolidColorBrush(Colors.Yellow);
                                break;
                            case 4:
                                rect.Fill = new SolidColorBrush(Colors.Plum);
                                break;
                            case 5:
                                rect.Fill = new SolidColorBrush(Colors.LightPink);
                                break;
                            default:
                                break;
                        }
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

                if (!flag_columns) //если весь столбец заполнен
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


        public void DrawFigures(Random rand, Canvas currentCanvas)
        {
            switch (rand.Next() % 17)
            {
                case 0:
                    figure1 = new Figure(shape1);
                    Redraw(shape1, currentCanvas);
                    break;
                case 1:
                    figure2 = new Figure(shape2);
                    Redraw(shape2, currentCanvas);
                    break;
                case 2:
                    figure3 = new Figure(shape3);
                    Redraw(shape3, currentCanvas);
                    break;
                case 3:
                    figure4 = new Figure(shape4);
                    Redraw(shape4, currentCanvas);
                    break;
                case 4:
                    figure5 = new Figure(shape5);
                    Redraw(shape5, currentCanvas);
                    break;
                case 5:
                    figure6 = new Figure(shape6);
                    Redraw(shape6, currentCanvas);
                    break;
                case 6:
                    figure7 = new Figure(shape7);
                    Redraw(shape7, currentCanvas);
                    break;
                case 7:
                    figure8 = new Figure(shape8);
                    Redraw(shape8, currentCanvas);
                    break;
                case 8:
                    figure9 = new Figure(shape9);
                    Redraw(shape9, currentCanvas);
                    break;
                case 9:
                    figure10 = new Figure(shape10);
                    Redraw(shape10, currentCanvas);
                    break;
                case 10:
                    figure11 = new Figure(shape11);
                    Redraw(shape11, currentCanvas);
                    break;
                case 11:
                    figure12 = new Figure(shape12);
                    Redraw(shape12, currentCanvas);
                    break;
                case 12:
                    figure13 = new Figure(shape13);
                    Redraw(shape13, currentCanvas);
                    break;
                case 13:
                    figure14 = new Figure(shape14);
                    Redraw(shape14, currentCanvas);
                    break;
                case 14:
                    figure15 = new Figure(shape15);
                    Redraw(shape15, currentCanvas);
                    break;
                case 15:
                    figure16 = new Figure(shape16);
                    Redraw(shape16, currentCanvas);
                    break;
                case 16:
                    figure17 = new Figure(shape17);
                    Redraw(shape17, currentCanvas);
                    break;
                default:
                    break;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            DrawFigures(r, canvasUpper1);
            DrawFigures(r, canvasUpper2);
            Start.IsEnabled = false;
        }

    }
}