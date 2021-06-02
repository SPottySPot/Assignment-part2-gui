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

namespace Assignment_part2_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RandomSet mySet = new RandomSet(0);
        int seed;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CreateArrayButton_Click(object sender, RoutedEventArgs e)
        {
            mySet = new RandomSet(int.Parse(ArrayLengthField.Text));
            ArrayBox.Text = string.Join(", ", mySet.arr);
            mySet.writeFile("2a.txt");
            MessageBox.Show("the array has been written to the file 2a.txt and array textbox has been updated");
        }

        private void CreateSeedButton_Click(object sender, RoutedEventArgs e)
        {
            seed = int.Parse(SeedValueBox.Text);
            mySet.Seed(seed);
            ArrayBox.Text = string.Join(", ", mySet.arr);
            MessageBox.Show("the seed has been placed in the array");
        }

        private void FindSeedButton_Click(object sender, RoutedEventArgs e)
        {
            
            FindSeedBox.Text = ""+ (mySet.search(seed)+1);
        }

        private void BubbleButton_Click(object sender, RoutedEventArgs e)
        {
            mySet.sortBubble();
            BubbleBox.Text = string.Join(", ", mySet.sortedArr);
            BubblePassBox.Text = "Passes: " + mySet.bubblePasses;
            CompareSorts();
        }

        private void OddEvenButton_Click(object sender, RoutedEventArgs e)
        {
            mySet.sortOddEven();
            OddEvenBox.Text = string.Join(", ", mySet.sortedArr);
            OddEvenPassBox.Text = "Passes: " + mySet.oddEvenPasses;
            CompareSorts();
        }

        private void CompareSorts()
        {
            if(mySet.bubblePasses>0 && mySet.oddEvenPasses > 0)
            {
                ComparisonBox.Text="Odd Even sort is "+ ((float)mySet.bubblePasses / (float)mySet.oddEvenPasses * 100) + "% more efficient";
            }
        }
    }
}
