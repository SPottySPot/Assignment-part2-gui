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
    public partial class MainWindow : Window
    {
        RandomSet mySet = new RandomSet(0);
        int seed;
        public MainWindow()
        {
            InitializeComponent();
        }

        //creates an array when the button is clicked
        private void CreateArrayButton_Click(object sender, RoutedEventArgs e)
        {
            //takes the requested length of the array and converts it to an int
            mySet = new RandomSet(int.Parse(ArrayLengthField.Text));
            //prints array to screen
            ArrayBox.Text = string.Join(", ", mySet.arr);
            //writes to file
            mySet.writeFile("2a.txt");
            //creates popup
            MessageBox.Show("the array has been written to the file 2a.txt and array textbox has been updated");
        }

        //changes an item in the array to the seed
        private void CreateSeedButton_Click(object sender, RoutedEventArgs e)
        {
            //converts the requested seed to an int
            seed = int.Parse(SeedValueBox.Text);
            //runs the seed function
            mySet.Seed(seed);
            //prints it to the gui
            ArrayBox.Text = string.Join(", ", mySet.arr);
            //prints it to the screen
            MessageBox.Show("the seed has been placed in the array");
        }

        //find the seed
        private void FindSeedButton_Click(object sender, RoutedEventArgs e)
        {
            //uses the inputs from before to find the seed
            FindSeedBox.Text = ""+ (mySet.search(seed)+1);
        }

        //runs the bubble sort
        private void BubbleButton_Click(object sender, RoutedEventArgs e)
        {
            //runs the bubble sort function
            mySet.sortBubble();
            //writes it to the gui
            BubbleBox.Text = string.Join(", ", mySet.sortedArr);
            //writes the amount of passes to the gui
            BubblePassBox.Text = "Passes: " + mySet.bubblePasses;
            CompareSorts();
        }

        private void OddEvenButton_Click(object sender, RoutedEventArgs e)
        {
            //runs the odd even sort function
            mySet.sortOddEven();
            //writes it to the gui
            OddEvenBox.Text = string.Join(", ", mySet.sortedArr);
            //writes the amount of passes to the gui
            OddEvenPassBox.Text = "Passes: " + mySet.oddEvenPasses;
            CompareSorts();
        }

        //compares the efficiency of the two sorts
        private void CompareSorts()
        {
            if(mySet.bubblePasses>0 && mySet.oddEvenPasses > 0)
            {
                //writes the difference in efficiency of the two functions
                ComparisonBox.Text="Odd Even sort is "+ ((float)mySet.bubblePasses / (float)mySet.oddEvenPasses * 100) + "% more efficient";
            }
        }
    }
}
