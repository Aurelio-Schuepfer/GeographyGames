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
using System.Windows.Shapes;

namespace Geography_Games_42
{
    /// <summary>
    /// Interaction logic for AsienWindow.xaml
    /// </summary>
    public partial class AsienWindow : Window
    {
        private int totalCountries = 42;
        private int correctAnswers = 0;
        private int remainingCountries = 42;

        private List<string> allCountries = new List<string>()
        {
            "Afghanistan", "Armenien", "Aserbaidschan", "Katar und Bahrain", "Bangladesch",
            "Bhutan", "China", "Georgien", "Indien", "Indonesien", "Irak",
            "Iran", "Israel", "Japan", "Jemen", "Jordanien",
            "Kambodscha", "Kasachstan", "Kirgistan", "Nordkorea", "Südkorea",
            "Kuwait", "Laos", "Libanon", "Malaysia", "Mongolei", "Myanmar",
            "Nepal", "Oman", "Pakistan", "Philippinen", "Russland", "Saudi-Arabien", 
            "Sri Lanka", "Syrien", "Tadschikistan",
            "Thailand", "Türkei", "Turkmenistan", "Usbekistan", "UAE", "Vietnam"
            
        };
        private List<string> countries;
        private string currentCountry;
        public AsienWindow()
        {
            InitializeComponent();
            countries = new List<string>(allCountries);
            SelectRandomCountry();
            this.KeyDown += AsienWindow_KeyDown;
        }
        private void AsienWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Settings.IsFullscreen = false;
                App.ApplyFullscreenMode(this);
            }
        }

        private void SelectRandomCountry()
        {
            if (countries.Count > 0)
            {
                var random = new Random();
                int index = random.Next(countries.Count);
                currentCountry = countries[index];
                LandText.Text = currentCountry;
                remainingCountries = countries.Count;
            }
            else
            {
                remainingCountries = 0;
                WinGame();

            }

            UpdateScore();

            if (remainingCountries == 0)
            {
                WinGame();
            }
        }

        private void UpdateScore()
        {
            ScoreText.Text = $"Score: {correctAnswers}/{totalCountries}";
            if (correctAnswers == 42)
            {
                Reset.Visibility = Visibility.Visible;
            }
        }

        private void CheckAnswer(string country, bool isCorrect)
        {
            if (isCorrect)
            {
                correctAnswers++;
                FeedbackText.Text = $"{country}";
                FeedbackText.Foreground = System.Windows.Media.Brushes.Green;
                countries.Remove(country);
                SelectRandomCountry();
            }
            else
            {
                FeedbackText.Text = $"{country}";
                FeedbackText.Foreground = System.Windows.Media.Brushes.Red;
            }

            UpdateScore();
            remainingCountries--;

            if (remainingCountries == 0)
            {
                WinGame();
            }
        }

        private void WinGame()
        {
            if (correctAnswers == totalCountries)
            {
                FeedbackText.Text = $"Herzlichen Glückwunsch, du hast {correctAnswers}/{totalCountries} richtig erraten!";
            }
            else
            {
                FeedbackText.Text = $"Du hast {correctAnswers}/{totalCountries} Länder richtig erraten. Versuche es nochmal!";
            }
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            correctAnswers = 0;
            remainingCountries = 42;
            UpdateScore();
            countries = new List<string>(allCountries);
            SelectRandomCountry();
            WinText.Visibility = Visibility.Hidden;
            Reset.Visibility = Visibility.Hidden;

        }

        private void Country_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string clickedCountry = button.Tag.ToString();

            bool isCorrect = clickedCountry == currentCountry;

            CheckAnswer(clickedCountry, isCorrect);
            FeedbackText.Text = clickedCountry;

            if (!isCorrect)
            {
                countries.Remove(currentCountry);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LänderWindow Länder = new LänderWindow();
            App.ApplyFullscreenMode(Länder);
            Länder.Show();
            this.Close();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow info = new InfoWindow();
            App.ApplyFullscreenMode(info);
            info.Show();
        }
        private void Afghanistan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Ägypten_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Aserbaidschan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Armenien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);

        private void Bahrain_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Bangladesch_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Bhutan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void China_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Georgien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Indien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Indonesien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Irak_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Iran_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Israel_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Japan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Jemen_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Jordanien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kambodscha_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kasachstan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Katar_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kirgistan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Nordkorea_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Südkorea_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kuwait_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Laos_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Libanon_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Malaysia_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Mongolei_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Myanmar_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Nepal_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Oman_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Pakistan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Philippinen_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Russland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void SaudiArabien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Srilanka_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Syrien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Tadschikistan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Thailand_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Türkei_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Turkmenistan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Taiwan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);

        private void Usbekistan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void UAE_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Vietnam_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
    }
}
