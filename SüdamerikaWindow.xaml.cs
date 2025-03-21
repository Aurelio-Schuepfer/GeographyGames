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
    /// Interaction logic for SüdamerikaWindow.xaml
    /// </summary>
    public partial class SüdamerikaWindow : Window
    {
        private int totalCountries = 13;
        private int correctAnswers = 0;
        private int remainingCountries = 13;

        private List<string> allCountries = new List<string>()
        {
            "Kolumbien", "Venezuela", "Guyana", "Suriname und Fr Guyana", "Ecuador",
            "Peru", "Bolivien", "Chile", "Argentinien", "Uruguay", "Paraguay",
            "Brasilien", "Falklandinseln (Malvinen)"
        };

        private List<string> countries;

        private string currentCountry;
        public SüdamerikaWindow()
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
        }

        

        private void SelectRandomCountry()
        {
            var random = new Random();
            if (remainingCountries > 0)
            {
                int index = random.Next(countries.Count);
                currentCountry = countries[index];
                LandText.Text = currentCountry;
            }
        }

        private void UpdateScore()
        {
            ScoreText.Text = $"Score: {correctAnswers}/{totalCountries}";
            if (correctAnswers == 13)
            {
                Reset.Visibility = Visibility.Visible;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void CheckAnswer(string country, bool isCorrect)
        {
            if (isCorrect)
            {
                correctAnswers++;
                FeedbackText.Text = $"{country}";
                FeedbackText.Foreground = System.Windows.Media.Brushes.Green;

                countries.Remove(country);
                remainingCountries--;

                if (remainingCountries > 0)
                {
                    SelectRandomCountry();
                }
            }
            else
            {
                FeedbackText.Text = $"{country}";
                FeedbackText.Foreground = System.Windows.Media.Brushes.Red;
            }

            UpdateScore();

            if (remainingCountries == 0)
            {
                WinGame();
            }
        }

        private void ResetGame()
        {
            correctAnswers = 0;
            remainingCountries = 13;
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
                WinText.Visibility = Visibility.Visible;

            }
            else
            {
                WinText.Text = $"Du hast {correctAnswers}/{totalCountries} Länder richtig erraten. Versuche es nochmal!";

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
        private void Kolumbien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Venezuela_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Guyana_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Suriname_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Ecuador_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Peru_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Bolivien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Chile_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Argentinien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Uruguay_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Paraguay_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Brasilien_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Falklandinseln_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
    }
}
