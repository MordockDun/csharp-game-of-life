using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int distanceBetweenLines = 10;
        private SolidColorBrush backgroundColor = Brushes.LightGray;
        private SolidColorBrush gridLineColor = Brushes.Gray;
        private DoubleCollection gridLineStroke = new DoubleCollection { 1.0, 2.0 };
        private int numberOfVerticalLines;
        private int numberOfHorizontalLines;

        public MainWindow()
        {
            InitializeComponent();
            MyCanvas.Background = backgroundColor;
        }

        private void DrawCellButtonOnClick(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int numberOfCells = random.Next(100);
            for (int i = 0; i < numberOfCells; i++)
            {
                int x = random.Next(numberOfHorizontalLines);
                int y = random.Next(numberOfVerticalLines);

                DrawCell(x, y);
            }
        }

        private void DrawCell(int x, int y)
        {
            Rectangle cell = new Rectangle();
            cell.Width = distanceBetweenLines;
            cell.Height = distanceBetweenLines;
            cell.Fill = Brushes.Red;
            cell.Stroke = Brushes.Blue;

            Canvas.SetLeft(cell, distanceBetweenLines * y);
            Canvas.SetTop(cell, distanceBetweenLines * x);

            MyCanvas.Children.Add(cell);
        }

        private void DrawGrid()
        {
            MyCanvas.Children.Clear();

            double acutualWidth = MyCanvas.ActualWidth;
            numberOfVerticalLines = (int)Math.Floor(acutualWidth / distanceBetweenLines);
            Debug.WriteLine("Drawing " + numberOfVerticalLines + " vertical lines");
            for (int i = 0; i < numberOfVerticalLines; i++)
            {
                DrawVerticalLine(i);
            }

            double acutualHeight = MyCanvas.ActualHeight;
            numberOfHorizontalLines = (int)Math.Floor(acutualHeight / distanceBetweenLines);
            Debug.WriteLine("Drawing " + numberOfHorizontalLines + " horizontal lines");
            for (int i = 0; i < numberOfHorizontalLines; i++)
            {
                DrawHorizontalLine(i);
            }
        }

        private void DrawVerticalLine(int lineNumber)
        {
            Line v1 = GetNewLine();
            v1.X1 = distanceBetweenLines * lineNumber;
            v1.X2 = distanceBetweenLines * lineNumber;
            v1.Y1 = 0;
            v1.Y2 = (int)MyCanvas.ActualHeight;
            MyCanvas.Children.Add(v1);
        }

        private void DrawHorizontalLine(int lineNumber)
        {
            Line v1 = GetNewLine();
            v1.X1 = 0;
            v1.X2 = (int)MyCanvas.ActualWidth;
            v1.Y1 = distanceBetweenLines * lineNumber;
            v1.Y2 = distanceBetweenLines * lineNumber;
            MyCanvas.Children.Add(v1);
        }

        private void DrawGridButtonOnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Canvas height " + MyCanvas.ActualHeight);
            Debug.WriteLine("Canvas width " + MyCanvas.ActualWidth);

            DrawGrid();
        }

        private Line GetNewLine()
        {
            Line line = new Line();
            line.Stroke = gridLineColor;
            line.StrokeDashArray = gridLineStroke;
            return line;
        }
    }
}