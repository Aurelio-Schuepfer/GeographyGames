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
    /// Interaction logic for AfrikaWindow.xaml
    /// </summary>
    public partial class AfrikaWindow : Window
    {
        private int totalCountries = 51;
        private int correctAnswers = 0;
        private int remainingCountries = 51;

        private List<string> allCountries = new List<string>()
        {
            "Ägypten", "Algerien", "Angola", "Äquatorialguinea", "Äthiopien",
            "Benin", "Botswana", "Burkina Faso", "Burundi", "Dschibuti", "Elfenbeinküste",
            "Eritrea", "Eswatini", "Gabun", "Gambia", "Ghana",
            "Guinea", "Guinea-Bissau", "Kamerun", "Kenia", "Kongo",
            "DR Kongo", "Lesotho", "Liberia", "Libyen", "Madagaskar", "Malawi",
            "Mali", "Marokko", "Mauretanien", "Mosambik", "Namibia",
            "Niger", "Nigeria", "Ruanda",
            "Sambia", "São Tomé und Príncipe", "Senegal", "Sierra Leone", "Simbabwe", "Somalia",
            "Südafrika", "Sudan", "Südsudan", "Togo", "Tschad",
            "Tunesien", "Uganda", "Zentralafrikanische REP", "Tansania", "Westsahara"

        };
        private List<string> countries;
        private string currentCountry;
        public AfrikaWindow()
        {
            InitializeComponent();
            countries = new List<string>(allCountries);
            SelectRandomCountry();
            if (Settings.IsFullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            this.KeyDown += AfrikaWindow_KeyDown;

        }
        private void AfrikaWindow_KeyDown(object sender, KeyEventArgs e)
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
            if (remainingCountries == 0)
            {
                WinGame();
            }
        }

        private void UpdateScore()
        {
            ScoreText.Text = $"Score: {correctAnswers}/{totalCountries}";
            if (correctAnswers == 51)
            {
                Reset.Visibility = Visibility.Visible;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }
        private void ResetGame()
        {
            correctAnswers = 0;
            remainingCountries = 51;
            UpdateScore();
            countries = new List<string>(allCountries);
            SelectRandomCountry();
            WinText.Visibility = Visibility.Hidden;
            Reset.Visibility = Visibility.Hidden;

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
                WinText.Visibility = Visibility.Visible;
            }
            else
            {
                WinText.Visibility = Visibility.Visible;
            }
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
        private void Ägypten_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Algerien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Angola_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Äquatorialguinea_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);

        private void Äthiopien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Benin_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Botswana_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void BurkinaFaso_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Burundi_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Dschibuti_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Elfenbeinküste_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Eritrea_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Eswatini_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Gabun_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Gambia_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Ghana_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Guinea_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void GuineaBissau_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kamerun_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kenia_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kongo_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void DRKongo_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Lesotho_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Liberia_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Libyen_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Madagaskar_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Malawi_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Mali_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Marokko_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Mauretanien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Mauritius_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Mosambik_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Namibia_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Niger_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Nigeria_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Ruanda_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Sambia_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void SaoTome_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Senegal_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void SierraLeone_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Simbabwe_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Somalia_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);

        private void Südafrika_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Sudan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Südsudan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Togo_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Tschad_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Tunesien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Uganda_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Westsahara_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void ZentralafrikanischeRepublik_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Tansania_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
    }
}
