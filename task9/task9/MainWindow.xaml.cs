using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using System.Windows.Media.Animation;

namespace task9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            indicator.IsEnabled = false;
            this.Title = "Блокнот";
            button_save.IsEnabled = false;
        }
        string path = null;
        public static string DialogCall(string type)
        {
            switch (type){
                case "open":
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "TXT Files | *.txt";

                    if (ofd.ShowDialog() == true) return ofd.FileName;
                    else return null;

                case "save":
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "TXT Files | *.txt";

                    if (sfd.ShowDialog() == true) return sfd.FileName;
                    else return null;
                default:
                    throw new ArgumentException("Given dialog type not found");
            }
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                path = DialogCall("open");
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = await sr.ReadToEndAsync();
                    textBox.Text = line;
                }
                this.Title = path;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string savePath = path ?? DialogCall("save");
                string[] lines = textBox.Text.Split('\n');
                File.WriteAllLines(savePath, lines);
            }
            catch(Exception exc1)
            {
                MessageBox.Show(exc1.Message);
            }
            var animation = new ColorAnimation();
            animation.From = Colors.RoyalBlue;
            animation.To = Colors.Green;
            indicator.IsEnabled = true;
           

            animation.Duration = TimeSpan.FromSeconds(0.7);


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, indicator);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Border.BorderBrush).(SolidColorBrush.Color)"));
            storyboard.Begin();      
         
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            indicator.IsEnabled = false;
            button_save.IsEnabled = true;
        }
    }
}
