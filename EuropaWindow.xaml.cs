using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Geography_Games_42
{
    public partial class EuropaWindow : Window
    {
        private int totalCountries = 32;
        private int correctAnswers = 0;
        private int remainingCountries = 32;

        private List<string> allCountries = new List<string>()
        {
            "Spanien", "Frankreich", "Litauen", "Belarus", "Norwegen", "Russland",
            "Aserbaidschan", "Türkei", "Bulgarien", "Ukraine", "Moldawien", "Rumänien",
            "Montenegro", "Kroatien", "Bosnien", "Polen", "Tschechien",
            "Irland", "Schottland", "England", "Österreich", "Italien",
            "Schweiz", "Deutschland", "Niederlande", "Belgien", "Portugal", "Serbien",
            "Griechenland", "Nordmazedonien", "Kosovo", "Albanien"
        };
        private List<string> countries;
        private string currentCountry;

        public EuropaWindow()
        {
            this.Loaded += (s, e) => App.ApplyFullscreenMode(this);
            InitializeComponent();
            countries = new List<string>(allCountries);
            SelectRandomCountry();
            if (Settings.IsFullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            this.KeyDown += EuropaWindow_KeyDown;

        }
        private void EuropaWindow_KeyDown(object sender, KeyEventArgs e)
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
            if (correctAnswers == 32)
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

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }
        private void ResetGame()
        {
            correctAnswers = 0;
            remainingCountries = 32;
            UpdateScore();
            countries = new List<string>(allCountries);
            SelectRandomCountry();
            WinText.Visibility = Visibility.Hidden;
            Reset.Visibility = Visibility.Hidden;

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
        private void Zypern_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Spanien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Frankreich_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Litauen_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Belarus_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Norwegen_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Russland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Aserbaidschan_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Türkei_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Bulgarien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Ukraine_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Moldawien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Rumänien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Montenegro_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kroatien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void BosnienundHerzegowina_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Polen_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Tschechien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Irland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Schottland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void England_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Österreich_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Italien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Schweiz_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Deutschland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Niederlande_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Belgien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Portugal_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Serbien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Griechenland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Nordmazedonien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kosovo_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Albanien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Ungarn_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Slowenien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Slowakei_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Schweden_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Nordirland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Lettland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Island_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Georgien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Finnland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Armenien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Estland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
    }
}
