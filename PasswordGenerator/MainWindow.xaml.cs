using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        
        private readonly string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string numerics = "1234567890";
        private readonly string specials = "!@#$%&[]()=?+*-_";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            var seed = "";

            seed = GetCasing(seed);
            seed = GetNumerics(seed);
            seed = GetSpecials(seed);
            passwordTextBox.Text = GetPassword((int)lengthSlider.Value, seed);
        }

        private string GetSpecials(string seed)
        {
            if (specialsCheckbox.IsChecked == true)
            {
                seed += specials;
                if (!string.IsNullOrEmpty(excludeSpecialsTextBox.Text))
                    seed = FilterCharacters(seed, excludeSpecialsTextBox.Text);
            }

            return seed;
        }

        private string GetNumerics(string seed)
        {
            if (numericsCheckbox.IsChecked == true)
                seed += numerics;
            return seed;
        }

        private string GetCasing(string seed)
        {
            switch (casingComboBox.SelectedIndex)
            {
                case 1:
                    seed += letters;
                    break;
                case 2:
                    seed += letters.ToLower();
                    break;
                default:
                    seed += letters;
                    seed += letters.ToLower();
                    break;
            }

            return seed;
        }

        private string GetPassword(int length, string seed)
        {
            return new string(Enumerable.Repeat(seed, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string FilterCharacters(string seed, string filter)
        {
            filter = new string(filter.Distinct().ToArray());
            foreach (var c in filter)
                seed = seed.Replace(c.ToString(), "");

            return seed;
        }
    }
}
