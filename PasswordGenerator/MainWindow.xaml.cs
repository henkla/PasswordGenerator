using System;
using System.Linq;
using System.Windows;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();

        private string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string numerics = "1234567890";
        private string specials = "!@#$%&[]()=?+*-_";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            var seed = "";

            seed += letters;
            seed += letters.ToLower();
            seed += numerics;
            seed += specials;

            passwordTextBox.Text = RandomString((int)lengthSlider.Value, seed);
        }
        
        public string RandomString(int length, string seed)
        {
            return new string(Enumerable.Repeat(seed, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
