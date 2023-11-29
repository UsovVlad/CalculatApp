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

namespace CalculatorApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement element in MainRoot.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "C")
            {
                textInput.Text = "";
                textOutput.Text = "";
            }
            else if (str == "Del")
            {
                if (textInput.Text.Length > 0)
                {
                    textInput.Text = textInput.Text.Substring(0, textInput.Text.Length - 1);
                    textOutput.Text = "";
                }
            }
            else if (str == "=" && !textInput.Text.EndsWith("="))
            {
                string value = new DataTable().Compute(textInput.Text, null).ToString();//временная замена
                textOutput.Text = value;
                textInput.Text += "=";
            }
            else
            {
                if (textInput.Text.EndsWith("="))
                {
                    textInput.Text = textInput.Text.Substring(0, textInput.Text.Length - 1);
                }
                textInput.Text += str;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
