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

namespace EasterSunday
{
    /// <author>Thomas LaSalle</author>
    /// <summary>
    /// A fun program which will compute the date of Easter
    /// Sunday based on a given year.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateEaster_Click(object sender, RoutedEventArgs e)
        {

            //Check that the provided year is numeric
            int year;
            if(!int.TryParse(yearInput.Text, out year))
            {
                easterDate.Text = "Invalid year";
            }
            else
            {
                //Check to see that the year is greater than 0
                if(year > 0)
                {
                    //Perform the calculations
                    int a = year % 19;
                    int b = year / 100;
                    int c = year % 100;
                    int d = b / 4;
                    int ee = b % 4;
                    int g = (8 * b + 13) / 25;
                    int h = (19 * a + b - d - g + 15) % 30;
                    int j = c / 4;
                    int k = c % 4;
                    int m = (a + 11 * h) / 319;
                    int r = (2 * ee + 2 * j - k - h + m + 32) % 7;
                    int n = (h - m + r + 90) / 25;
                    int p = (h - m + r + n + 19) % 32;

                    //Create the Month String used for display
                    String month;

                    if(n == 3)
                    {
                        month = "March ";
                    }
                    else
                    {
                        month = "April ";
                    }

                    //Display the date of Easter Sunday
                    easterDate.Text = month + p + ", " + year; 
                }
                else
                {
                    //Only check years greater than 0
                    easterDate.Text = "Year must be greater than 0";
                }
            }
            
        }
    }
}
