using System;
using System.Collections.Generic;
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

namespace MatrixCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double[,] FirstMatrix = new double[2, 2];
        double[,] SecondMatrix = new double[2, 2];
        public MainWindow()
        {
            InitializeComponent();

            Col1.Items.Add(new ComboBoxItem() { Content = "2" });
            Col1.Items.Add(new ComboBoxItem() { Content = "3" });
            Col1.Items.Add(new ComboBoxItem() { Content = "4" });
            Col1.Items.Add(new ComboBoxItem() { Content = "5" });
            Col1.Items.Add(new ComboBoxItem() { Content = "6" });
            Col1.Items.Add(new ComboBoxItem() { Content = "7" });

            Row1.Items.Add(new ComboBoxItem() { Content = "2" });
            Row1.Items.Add(new ComboBoxItem() { Content = "3" });
            Row1.Items.Add(new ComboBoxItem() { Content = "4" });
            Row1.Items.Add(new ComboBoxItem() { Content = "5" });
            Row1.Items.Add(new ComboBoxItem() { Content = "6" });
            Row1.Items.Add(new ComboBoxItem() { Content = "7" });

            Col2.Items.Add(new ComboBoxItem() { Content = "2" });
            Col2.Items.Add(new ComboBoxItem() { Content = "3" });
            Col2.Items.Add(new ComboBoxItem() { Content = "4" });
            Col2.Items.Add(new ComboBoxItem() { Content = "5" });
            Col2.Items.Add(new ComboBoxItem() { Content = "6" });
            Col2.Items.Add(new ComboBoxItem() { Content = "7" });


            initializeGrid(grid1, FirstMatrix);
            initializeGrid(grid2, SecondMatrix);

        }

        private void initializeGrid(Grid grid, double[,] matrix)
        {
            if (grid != null)
            {
                // Reset the grid before doing anything
                grid.Children.Clear();
                grid.ColumnDefinitions.Clear();
                grid.RowDefinitions.Clear();
                // Get the dimensions
                int rows = matrix.GetLength(0);
                int columns = matrix.GetLength(1);
                // Add the correct number of coumns to the grid
                for (int x = 0; x < columns; x++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star), });
                }
                for (int y = 0; y < rows; y++)
                {
                    // GridUnitType.Star - The value is expressed as a weighted proportion of available space
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star), });
                }
                // Fill each cell of the grid with an editable TextBox containing the value from the matrix 
                for (int x = 0; x < columns; x++)
                {
                    for (int y = 0; y < rows; y++)
                    {
                        double cell = (double)matrix[y, x];
                        TextBox t = new TextBox();
                        t.Text = cell.ToString();
                        t.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        t.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        t.SetValue(Grid.RowProperty, y);
                        t.SetValue(Grid.ColumnProperty, x);
                        grid.Children.Add(t);
                    }
                }
            }
        }

        private double[,] getValuesFromGrid(Grid grid, double[,] matrix)
        {
            int columns = grid.ColumnDefinitions.Count;
            int rows = grid.RowDefinitions.Count;
            // Iterate over cells in Grid, copying to matrix array
            for (int c = 0; c < grid.Children.Count; c++)
            {
                TextBox t = (TextBox)grid.Children[c];
                int row = Grid.GetRow(t);
                int column = Grid.GetColumn(t);
                matrix[row, column] = double.Parse(t.Text);
            }
            return matrix;
        }
        private void Col1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var CurrItem = (ComboBoxItem)Col1.SelectedItem;
            FirstMatrix = new double[FirstMatrix.GetLength(0), int.Parse(CurrItem.Content.ToString())];
            initializeGrid(grid1, FirstMatrix);
            SecondMatrix = new double[int.Parse(CurrItem.Content.ToString()), SecondMatrix.GetLength(1)];
            initializeGrid(grid2, SecondMatrix);
        }

        private void Row1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var CurrItem = (ComboBoxItem)Row1.SelectedItem;
            FirstMatrix = new double[int.Parse(CurrItem.Content.ToString()), FirstMatrix.GetLength(1)];
            initializeGrid(grid1, FirstMatrix);
            
        }

        private void Col2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string col2 = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();
            SecondMatrix = new double[SecondMatrix.GetLength(0), int.Parse(col2)];
            initializeGrid(grid2, SecondMatrix);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FirstMatrix = getValuesFromGrid(grid1, FirstMatrix);
            SecondMatrix = getValuesFromGrid(grid2, SecondMatrix);
            var Result = MultiplyMatrices(FirstMatrix, SecondMatrix);
            initializeGrid(grid3, Result);
        }

        public static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (colsA != rowsB)
            {
                // ex
            }

            double[,] result = new double[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += matrixA[i,k] * matrixB[k,j];
                    }
                    result[i,j] = sum;
                }
            }

            return result;
        }

        public static void FillMatrixRandom(double[,] matrix, int minValue, int maxValue)
        {
            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            FillMatrixRandom(FirstMatrix, 1, 200);
            FillMatrixRandom(SecondMatrix, 1, 200);
            initializeGrid(grid1, FirstMatrix);
            initializeGrid(grid2, SecondMatrix);
        }
    }
}
