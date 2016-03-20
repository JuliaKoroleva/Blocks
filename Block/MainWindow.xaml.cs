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
using System.Windows.Media.Animation;
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

        public int[,] bigFigure = new int[N, N];

        int currentFigureNumber1 = 0;
        int currentFigureNumber2 = 0;

        bool selected1 = false;
        bool selected2 = false;

        Point mousePosition;
        Point shift;

        Figure[] figuresArray;

        Figure figure0; Figure figure1; Figure figure2;
        Figure figure3; Figure figure4; Figure figure5;
        Figure figure6; Figure figure7; Figure figure8;
        Figure figure9; Figure figure10; Figure figure11;
        Figure figure12; Figure figure13; Figure figure14;
        Figure figure15; Figure figure16;

        int[,] shape0 = new int[M, M] { { 0, 0, 0, 0 },
                                            { 0, 1, 0, 0 },
                                            { 0, 0, 0, 0 },
                                            { 0, 0, 0, 0 } };
        int[,] shape1 = new int[M, M] { { 0, 0, 0, 0 },
                                            { 0, 1, 1, 0 },
                                            { 0, 0, 0, 0 },
                                            { 0, 0, 0, 0 } };

        int[,] shape2 = new int[M, M] { { 0, 0, 0, 0 },
                                            { 0, 1, 0, 0 },
                                            { 0, 1, 0, 0 },
                                            { 0, 0, 0, 0 } };

        int[,] shape3 = new int[M, M] { { 0, 0, 0, 0 },
                                            { 0, 1, 1, 0 },
                                            { 0, 1, 0, 0 },
                                            { 0, 0, 0, 0 } };

        int[,] shape4 = new int[M, M] { { 0, 0, 0, 0 },
                                            { 0, 1, 1, 0 },
                                            { 0, 0, 1, 0 },
                                            { 0, 0, 0, 0 } };

        int[,] shape5 = new int[M, M] { { 0, 0, 0, 0 },
                                            { 0, 0, 1, 0 },
                                            { 0, 1, 1, 0 },
                                            { 0, 0, 0, 0 } };

        int[,] shape6 = new int[M, M] { { 0, 0, 0, 0 },
                                            { 0, 1, 0, 0 },
                                            { 0, 1, 1, 0 },
                                            { 0, 0, 0, 0 } };

        int[,] shape7 = new int[M, M] { { 0, 0, 0, 0 },
                                            { 0, 1, 1, 0 },
                                            { 0, 1, 1, 0 },
                                            { 0, 0, 0, 0 } };

        int[,] shape8 = new int[M, M] { { 0, 1, 0, 0 },
                                            { 0, 1, 0, 0 },
                                            { 0, 1, 0, 0 },
                                            { 0, 0, 0, 0 } };

        int[,] shape9 = new int[M, M] { { 0, 0, 0, 0 },
                                             { 1, 1, 1, 0 },
                                             { 0, 0, 0, 0 },
                                             { 0, 0, 0, 0 } };

        int[,] shape10 = new int[M, M] { { 1, 1, 1, 0 },
                                             { 1, 0, 0, 0 },
                                             { 1, 0, 0, 0 },
                                             { 0, 0, 0, 0 } };

        int[,] shape11 = new int[M, M] { { 1, 1, 1, 0 },
                                             { 0, 0, 1, 0 },
                                             { 0, 0, 1, 0 },
                                             { 0, 0, 1, 0 } };

        int[,] shape12 = new int[M, M] { { 0, 0, 1, 0 },
                                             { 0, 0, 1, 0 },
                                             { 1, 1, 1, 0 },
                                             { 0, 0, 0, 0 } };

        int[,] shape13 = new int[M, M] { { 1, 0, 0, 0 },
                                             { 1, 0, 0, 0 },
                                             { 1, 1, 1, 0 },
                                             { 0, 0, 0, 0 } };

        int[,] shape14 = new int[M, M] { { 0, 1, 0, 0 },
                                             { 0, 1, 0, 0 },
                                             { 0, 1, 0, 0 },
                                             { 0, 1, 0, 0 } };

        int[,] shape15 = new int[M, M] { { 0, 0, 0, 0 },
                                             { 1, 1, 1, 1 },
                                             { 0, 0, 0, 0 },
                                             { 0, 0, 0, 0 } };

        int[,] shape16 = new int[M, M] { { 1, 1, 1, 0 },
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

            figure0 = new Figure(shape0); figure1 = new Figure(shape1); figure2 = new Figure(shape2);
            figure3 = new Figure(shape3); figure4 = new Figure(shape4); figure5 = new Figure(shape5);
            figure6 = new Figure(shape6); figure7 = new Figure(shape7); figure8 = new Figure(shape8);
            figure9 = new Figure(shape9); figure10 = new Figure(shape10); figure11 = new Figure(shape11);
            figure12 = new Figure(shape12); figure13 = new Figure(shape13); figure14 = new Figure(shape14);
            figure15 = new Figure(shape15); figure16 = new Figure(shape16);

            figuresArray = new Figure[17] {figure0, figure1, figure2, figure3, figure4, figure5, figure6,
                                           figure7, figure8, figure9, figure10, figure11, figure12, figure13,
                                           figure14, figure15, figure16};

            canvasMain = Redraw(mainField, canvasMain);
            canvasUpper1 = Redraw(shapeField, canvasUpper1);
            canvasUpper2 = Redraw(shapeField, canvasUpper2);

        }

        public Canvas Redraw(int[,] field, Canvas currentCanvas) //МЕТОД ПЕРЕРИСОВКИ КАНВАСА
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Rectangle rect = new Rectangle();

                    if (field.GetLength(0) == N)
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
                                rect.Stroke = new SolidColorBrush(Colors.Gray);
                                break;
                            case 1:
                                rect.Fill = new SolidColorBrush(Colors.LightGreen);
                                rect.Stroke = new SolidColorBrush(Colors.Gray);
                                break;
                            case 2:
                                rect.Fill = new SolidColorBrush(Colors.LightSkyBlue);
                                rect.Stroke = new SolidColorBrush(Colors.Gray);
                                break;
                            case 3:
                                rect.Fill = new SolidColorBrush(Colors.Yellow);
                                rect.Stroke = new SolidColorBrush(Colors.Gray);
                                break;
                            case 4:
                                rect.Fill = new SolidColorBrush(Colors.Plum);
                                rect.Stroke = new SolidColorBrush(Colors.Gray);
                                break;
                            case 5:
                                rect.Fill = new SolidColorBrush(Colors.LightPink);
                                rect.Stroke = new SolidColorBrush(Colors.Gray);
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

        public Canvas Delete_Rows_Columns(ref int[,] field, Canvas canvas_Main) //МЕТОД УДАЛЕНИЯ ЗАПОЛНЕННЫХ РЯДОВ И КОЛОНОК
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


        public bool Is_Inside_Canvas(Canvas currentCanvas) // МЕТОД ПРОВЕРКИ НА ТО, ЧТО КУРСОР НАХОДИТСЯ ВНУТРИ КАНВАСА
        {
            mousePosition = Mouse.GetPosition(currentCanvas);

            if ((mousePosition.X > 0) && (mousePosition.Y > 0) && (mousePosition.X < currentCanvas.Width) && (mousePosition.Y < currentCanvas.Height))
                return true;

            else
                return false;
        }


        public int DrawFigures(Random rand, Canvas currentCanvas) //МЕТОД, СЛУЧАЙНЫМ ОБРАЗОМ РИСУЮЩИЙ ФИГУРЫ
        {
            int flag = 0;

            var randValue = rand.Next() % 17;

            Redraw(figuresArray[randValue].shape, currentCanvas);
            flag = randValue;

            return flag;
        }

        public bool CheckedPlace(int[,] bigFigure) //МЕТОД, ПРОВЕРЯЮЩИЙ, ЧТО КЛЕТКИ ПОД ФИГУРОЙ СВОБОДНЫ
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if ((mainField[i, j] == 1) && (bigFigure[i, j] == 1))
                        return false;
                    else
                        return true;
                }
            }
            return true;
        }

        public int[,] Transforming(int[,] figure, int a, int c) //МЕТОД, ПРЕОБРАЗУЮЩИЙ МАССИВ ФИГУРЫ В МАССИВ РАЗМЕРА ОСНОВНОГО ПОЛЯ
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (figure[i, j] != 0)
                        mainField[a + i, c + j] = figure[i, j];
                    else
                        mainField[i, j] = 0;
                }
            }
            return mainField;
        }

        private void canvasUpper1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Is_Inside_Canvas(canvasUpper1))
            {
                selected1 = true;
            }
        }

        private void canvasMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Random r = new Random();
            mousePosition = Mouse.GetPosition(this);
            int a = Convert.ToInt32((mousePosition.X - 80) / 40) + 1; //"КООРДИНАТА Х" КЛЕТКИ НА ОСНОВНОМ ПОЛЕ, НА КОТОРОЙ НАХОДИТСЯ КУРСОР
            int c = Convert.ToInt32((mousePosition.Y - 240) / 40); //"КООРДИНАТА У" КЛЕТКИ НА ОСНОВНОМ ПОЛЕ, НА КОТОРОЙ НАХОДИТСЯ КУРСОР

            if (selected1)
            {

                bigFigure = Transforming(figuresArray[currentFigureNumber1].shape, a, c);

                if (CheckedPlace(bigFigure))
                {
                    canvasMain.Children.Clear();
                    Redraw(bigFigure, canvasMain);

                    canvasUpper1.Children.Clear();
                    currentFigureNumber1 = DrawFigures(r, canvasUpper1);
                }
            }

            else if (selected2)
            {
                bigFigure = Transforming(figuresArray[currentFigureNumber2].shape, a, c);

                if (CheckedPlace(bigFigure))
                {

                    Redraw(bigFigure, canvasMain);
                    canvasUpper2.Children.Clear();
                    currentFigureNumber2 = DrawFigures(r, canvasUpper2);
                }
            }
        }

        private void canvasUpper2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Is_Inside_Canvas(canvasUpper2) == true)
            {
                selected2 = true;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameStart();
        }

        private void GameStart()
        {
            Random r = new Random();
            currentFigureNumber1 = DrawFigures(r, canvasUpper1);
            currentFigureNumber2 = DrawFigures(r, canvasUpper2);
            Start.IsEnabled = false;
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Правила игры: ");
        }

        private void GameRules()
        {
            MessageBox.Show("Правила игры: ");
        }

        private void AboutGame()
        {
            MessageBox.Show("Blocks game 1.0 разработчики: Егорова Софья, Келесиди София, Королева Юлия  20.03.2015");
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    this.Close();
                    break;
                case Key.F1:
                    GameRules();
                    break;
                case Key.F2:
                    GameStart();
                    break;
                case Key.F11:
                    AboutGame();
                    break;
                    default:
                    break;
            }
        }
    }
}