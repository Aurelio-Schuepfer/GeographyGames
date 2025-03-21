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
    /// Interaction logic for NordamerikaWindow.xaml
    /// </summary>
    public partial class NordamerikaWindow : Window
    {
        private int totalCountries = 19;
        private int correctAnswers = 0;
        private int remainingCountries = 19;

        private List<string> allCountries = new List<string>()
        {
            "Kanada", "USA", "Grönland", "Mexiko", "Bahamas", "Belize",
            "Costa Rica", "Barbados", "Dom Rep", "El Salvador", "Guatemala", "Haiti",
            "Honduras", "Jamaika", "Kuba", "Nicaragua", "Panama", "Grönland", "Puerto Rico"
        };

        private List<string> countries;

        private string currentCountry;
        public NordamerikaWindow()
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
            if (correctAnswers == 19)
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
            remainingCountries = 19;
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
        private void Bahamas_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Barbados_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Belize_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void CostaRica_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void DomRep_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void ElSalvador_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Guatemala_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Haiti_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Honduras_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Jamaika_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kanada_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Kuba_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Mexiko_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Nicaragua_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Panama_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void USA_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void Grönland_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
        private void PuertoRico_Click(object sender, RoutedEventArgs e) => Country_Click(sender, e);
    }
}
