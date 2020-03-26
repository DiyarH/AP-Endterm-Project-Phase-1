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

namespace AP_Endterm_Project_Phase_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DateTime today = DateTime.Today;
            for (int i = 1901; i <= 2050; ++i)
            {
                year.Items.Add(i);
            }
            for (int i = 1; i <= 12; ++i)
            {
                month.Items.Add(i);
            }
            for (int i = 1; i <= 31; ++i)
            {
                day.Items.Add(i);
            }
            year.SelectedItem = today.Year;
            month.SelectedItem = today.Month;
            day.SelectedItem = today.Day;
            nextPage.IsEnabled = tab.SelectedIndex < (tab.Items.Count - 1);
            previousPage.IsEnabled = tab.SelectedIndex > 0;
        }

        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex++;
        }

        private void previousPage_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedIndex--;
        }

        private void tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (nextPage != null)
            {
                nextPage.IsEnabled = tab.SelectedIndex < (tab.Items.Count - 1);
            }
            if (previousPage != null)
            {
                previousPage.IsEnabled = tab.SelectedIndex > 0;
            }
        }

        private void colorValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (colorValue != null)
            {
                colorValue.Text = ((int)red.Value).ToString("X").PadLeft(2, '0') + ((int)green.Value).ToString("X").PadLeft(2, '0') + ((int)blue.Value).ToString("X").PadLeft(2, '0');
            }
            if (shape != null)
            {
                shape.Fill = new SolidColorBrush(Color.FromRgb((byte)red.Value, (byte)green.Value, (byte)blue.Value));
            }
        }
    }
}
