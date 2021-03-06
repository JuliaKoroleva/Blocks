﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                                             { 0, 0, 0, 0 } };

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

        private int score = 0;

        public int getScore()
        {
            return score;
        }

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

            figure0 = new Figure(shape0, Colors.Orchid); figure1 = new Figure(shape1, Colors.Coral); figure2 = new Figure(shape2, Colors.Coral);
            figure3 = new Figure(shape3, Colors.MediumVioletRed); figure4 = new Figure(shape4, Colors.MediumVioletRed); figure5 = new Figure(shape5, Colors.MediumVioletRed);
            figure6 = new Figure(shape6, Colors.MediumVioletRed); figure7 = new Figure(shape7, Colors.DeepSkyBlue); figure8 = new Figure(shape8, Colors.RoyalBlue);
            figure9 = new Figure(shape9, Colors.RoyalBlue); figure10 = new Figure(shape10, Colors.Crimson); figure11 = new Figure(shape11, Colors.Crimson);
            figure12 = new Figure(shape12, Colors.Crimson); figure13 = new Figure(shape13, Colors.Crimson); figure14 = new Figure(shape14, Colors.Teal);
            figure15 = new Figure(shape15, Colors.Teal); figure16 = new Figure(shape16, Colors.Salmon);

            figuresArray = new Figure[17] {figure0, figure1, figure2, figure3, figure4, figure5, figure6,
                                           figure7, figure8, figure9, figure10, figure11, figure12, figure13,
                                           figure14, figure15, figure16};

            canvasMain = Redraw(mainField, canvasMain, Colors.MediumSpringGreen);

            canvasUpper1 = Redraw(shapeField, canvasUpper1, Colors.MediumSpringGreen);
            canvasUpper2 = Redraw(shapeField, canvasUpper2, Colors.MediumSpringGreen);

        }

        public Canvas Redraw(int[,] field, Canvas currentCanvas, Color color) //МЕТОД ПЕРЕРИСОВКИ КАНВАСА
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

                    if ((field[i, j] != 0))
                    {
                        rect.Fill = new SolidColorBrush(color);
                        rect.Stroke = new SolidColorBrush(Colors.Gray);
                    }

                    Canvas.SetLeft(rect, rect.Width * j);
                    Canvas.SetTop(rect, rect.Height * i);
                    currentCanvas.Children.Add(rect);
                }
            }
            return currentCanvas;
        }

        public Canvas RedrawMove(int[,] field, Canvas currentCanvas) //МЕТОД ПЕРЕРИСОВКИ КАНВАСА ПРИ ДВИЖЕНИИ КУРСОРА
        {
            canvasMain.Children.Clear();
            Redraw(mainField, canvasMain, Colors.MediumSpringGreen);

            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Rectangle rect = new Rectangle();

                    rect.Stroke = new SolidColorBrush(Colors.DarkViolet);
                    rect.StrokeThickness = 3;
                    rect.Width = cellWidth;
                    rect.Height = cellHeight;

                    if (field[i, j] != 0)
                    {
                        Canvas.SetLeft(rect, rect.Width * j);
                        Canvas.SetTop(rect, rect.Height * i);
                        currentCanvas.Children.Add(rect);
                    }
                }
            }
            return currentCanvas;
        }


        public Canvas Delete_Rows_Columns(ref int[,] field, Canvas currentCanvas) //МЕТОД УДАЛЕНИЯ ЗАПОЛНЕННЫХ РЯДОВ И КОЛОНОК
        {
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
                    rect.Fill = new SolidColorBrush(Colors.White);
                    rect.Stroke = new SolidColorBrush(Colors.Gray);
                    rect.Width = cellWidth;
                    rect.Height = cellHeight;

                    for (int j2 = 0; j2 < N; j2++)
                    {
                        currentCanvas.Children.Clear();
                        canvasMain = Redraw(mainField, canvasMain, Colors.MediumSpringGreen);
                        Canvas.SetLeft(rect, rect.Width * j2);
                        Canvas.SetTop(rect, rect.Height * i);

                        currentCanvas.Children.Add(rect);

                        field[i, j2] = 0;
                    }
                    score += 10;
                }

                if (!flag_columns) //если весь столбец заполнен
                {
                    Rectangle rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Gray);
                    rect.Width = cellWidth;
                    rect.Height = cellHeight;
                    rect.Fill = new SolidColorBrush(Colors.White);

                    for (int j2 = 0; j2 < N; j2++)
                    {
                        currentCanvas.Children.Clear();
                        canvasMain = Redraw(mainField, canvasMain, Colors.MediumSpringGreen);

                        Canvas.SetLeft(rect, rect.Width * i);
                        Canvas.SetTop(rect, rect.Height * j2);
                        currentCanvas.Children.Add(rect);

                        field[j2, i] = 0;
                    }
                    score += 10;
                }

                flag_rows = false;
                flag_columns = false;
            }

            return currentCanvas;
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

            Redraw(figuresArray[randValue].shape, currentCanvas, figuresArray[randValue].color);
            flag = randValue;

            return flag;
        }

        public bool CheckedPlace(int[,] bigFigure, int[,] mainField) //МЕТОД, ПРОВЕРЯЮЩИЙ, ЧТО КЛЕТКИ ПОД ФИГУРОЙ СВОБОДНЫ
        {
            bool flag = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if ((mainField[i, j] == 1) && (bigFigure[i, j] == 1))
                        flag = true;
                }
            }

            if (flag)
                return false;
            else
                return true;
        }

        public bool Transforming(int[,] figure, int Ycell, int Xcell) //МЕТОД, ПРЕОБРАЗУЮЩИЙ МАССИВ ФИГУРЫ В МАССИВ РАЗМЕРА ОСНОВНОГО ПОЛЯ
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    bigFigure[i, j] = 0;
                }

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (figure[i, j] != 0)
                    {
                        int newX = Xcell + j;
                        int newY = Ycell + i;

                        if ((newX > N - 1) || (newX < 0) || (newY > N - 1) || (newY < 0))
                        {
                            return false;
                        }

                        else
                        {
                            bigFigure[newY, newX] = figure[i, j];
                        }
                    }
                }
            }
            return true;
        }

        public int[,] Add_Figure_To_Array(int[,] figure, int[,] field)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (figure[i, j] == 1)
                        field[i, j] = 1;
                }
            }

            return field;
        }

        private void canvasUpper1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Is_Inside_Canvas(canvasUpper1))
            {
                selected1 = true;
                canvasMain.IsEnabled = true;
            }
        }

        private void canvasUpper2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Is_Inside_Canvas(canvasUpper2))
            {
                selected2 = true;
                canvasMain.IsEnabled = true;
            }
        }

        private void canvasMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Random r = new Random();
            mousePosition = Mouse.GetPosition(this);
            int Xcell = Convert.ToInt32((mousePosition.X - 120) / 40) + 1; //"КООРДИНАТА Х" КЛЕТКИ НА ОСНОВНОМ ПОЛЕ, НА КОТОРОЙ НАХОДИТСЯ КУРСОР
            int Ycell = Convert.ToInt32((mousePosition.Y - 290) / 40); //"КООРДИНАТА У" КЛЕТКИ НА ОСНОВНОМ ПОЛЕ, НА КОТОРОЙ НАХОДИТСЯ КУРСОР

            if (selected1)
            {
                if (Transforming(figuresArray[currentFigureNumber1].shape, Ycell, Xcell))
                {
                    if (CheckedPlace(bigFigure, mainField))
                    {
                        Redraw(bigFigure, canvasMain, Colors.MediumSpringGreen);
                        mainField = Add_Figure_To_Array(bigFigure, mainField);
                        canvasMain = Delete_Rows_Columns(ref mainField, canvasMain);

                        canvasUpper1.Children.Clear();
                        currentFigureNumber1 = DrawFigures(r, canvasUpper1);

                    }
                    selected1 = false;
                }
            }

            else if (selected2)
            {
                if (Transforming(figuresArray[currentFigureNumber2].shape, Ycell, Xcell))
                {
                    if (CheckedPlace(bigFigure, mainField))
                    {

                        Redraw(bigFigure, canvasMain, Colors.MediumSpringGreen);
                        mainField = Add_Figure_To_Array(bigFigure, mainField);
                        canvasMain = Delete_Rows_Columns(ref mainField, canvasMain);

                        canvasUpper2.Children.Clear();
                        currentFigureNumber2 = DrawFigures(r, canvasUpper2);
                    }
                    selected2 = false;
                }
            }
            canvasMain.IsEnabled = false;
            Score.Content = getScore().ToString("0");
        }


        private void canvasMain_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = Mouse.GetPosition(this);
            int Xcell = Convert.ToInt32((mousePosition.X - 120) / 40) + 1; //"КООРДИНАТА Х" КЛЕТКИ НА ОСНОВНОМ ПОЛЕ, НА КОТОРОЙ НАХОДИТСЯ КУРСОР
            int Ycell = Convert.ToInt32((mousePosition.Y - 290) / 40); //"КООРДИНАТА У" КЛЕТКИ НА ОСНОВНОМ ПОЛЕ, НА КОТОРОЙ НАХОДИТСЯ КУРСОР

            if (selected1)
            {
                Transforming(figuresArray[currentFigureNumber1].shape, Ycell, Xcell);
                RedrawMove(bigFigure, canvasMain);
            }

            else if (selected2)
            {
                Transforming(figuresArray[currentFigureNumber2].shape, Ycell, Xcell);
                RedrawMove(bigFigure, canvasMain);
                selected2 = true;
                canvasMain.IsEnabled = true;
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
            GameRules();
        }

        private void GameRules()
        {
            MessageBox.Show("Правила игры: Переставляйте фигуры на поле так, чтобы заполнить горизонтальную и вертикальную линии. Чтобы поставить фигуру: сначала нажмите на нее, а затем нажмите на место на главном поле, куда Вы хотите поставить фигуру. Чтобы начать новую игру нажмите F2. Наберите как можно больше очков. Удачи!");
        }

        private void AboutGame()
        {
            MessageBox.Show("Blocks game 1.0 разработчики: Егорова Софья, Келесиди София, Королева Юлия  20.03.2015");
        }

        private void RestartGame()
        {
            canvasUpper1.Children.Clear();
            canvasUpper2.Children.Clear();

            Rectangle rect = new Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Gray);
            rect.Width = cellWidth;
            rect.Height = cellHeight;
            rect.Fill = new SolidColorBrush(Colors.White);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    canvasMain.Children.Clear();
                    canvasMain = Redraw(mainField, canvasMain, Colors.MediumSpringGreen);
                    Canvas.SetLeft(rect, rect.Width * i);
                    Canvas.SetTop(rect, rect.Height * j);
                    canvasMain.Children.Add(rect);
                    mainField[i, j] = 0;
                }

            }
            score = 0;
            Score.Content = getScore().ToString("0");
            Start.IsEnabled = true;
        }

        private void SaveResults(int score)
        {
            FileStream fs = new FileStream("../../data.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("{0} Вы набрали {1} очков", DateTime.Now, score);
            sw.Close();
            fs.Close();
        }


        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    SaveResults(score);
                    this.Close();
                    break;
                case Key.F1:
                    GameRules();
                    break;
                case Key.F2:
                    SaveResults(score);
                    RestartGame();
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