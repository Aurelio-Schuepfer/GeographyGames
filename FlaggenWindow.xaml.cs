using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Geography_Games_42
{
    public partial class FlaggenWindow : Window
    {
        private Dictionary<string, string> countryToFlag = new Dictionary<string, string>();
        private string correctAnswer;
        private string currentFlagPath;
        private int score = 0;
        private Random zufall = new Random();

        public FlaggenWindow()
        {
            this.Loaded += (s, e) => App.ApplyFullscreenMode(this);
            InitializeComponent();
            LadeFlaggen();
            LadeZufallsFlagge();
            FlaggeImage.Visibility = Visibility.Visible;

            Button1.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;
            Button3.Visibility = Visibility.Visible;
            Button4.Visibility = Visibility.Visible;

            SetAnswerButtons();

            if (Settings.IsFullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            this.KeyDown += FlaggenWindow_KeyDown;

        }
        private void FlaggenWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Settings.IsFullscreen = false;
                App.ApplyFullscreenMode(this);
            }
        }

        private void LadeFlaggen()
        {
            string[] flaggenDateien = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Assets\Flaggen"), "*.png");

            foreach (var flagge in flaggenDateien)
            {
                string countryName = Path.GetFileNameWithoutExtension(flagge);
                countryToFlag[countryName] = flagge;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            App.ApplyFullscreenMode(mainWindow);
            mainWindow.Show();
            this.Close();
        }

        private void LadeZufallsFlagge()
        {
            if (countryToFlag.Count > 0)
            {
                var randomCountryName = countryToFlag.Keys.ElementAt(zufall.Next(countryToFlag.Count));
                currentFlagPath = countryToFlag[randomCountryName];

                BitmapImage flagge = new BitmapImage();
                flagge.BeginInit();
                flagge.UriSource = new Uri(currentFlagPath, UriKind.Relative);
                flagge.CacheOption = BitmapCacheOption.OnLoad;
                flagge.EndInit();

                FlaggeImage.Source = flagge;

                correctAnswer = randomCountryName;
            }
        }

        private void SetAnswerButtons()
        {
            if (string.IsNullOrEmpty(correctAnswer))
                return;

            List<string> answerOptions = new List<string> { correctAnswer };

            while (answerOptions.Count < 4)
            {
                string randomCountry = countryToFlag.Keys.ElementAt(zufall.Next(countryToFlag.Count));
                if (!answerOptions.Contains(randomCountry))
                {
                    answerOptions.Add(randomCountry);
                }
            }

            answerOptions = answerOptions.OrderBy(a => zufall.Next()).ToList();

            Button1.Content = answerOptions[0];
            Button2.Content = answerOptions[1];
            Button3.Content = answerOptions[2];
            Button4.Content = answerOptions[3];
        }

        private async void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string selectedAnswer = clickedButton.Content.ToString();

            FlaggeImage.Visibility = Visibility.Hidden;

            if (selectedAnswer == correctAnswer)
            {
                CorFlabel.Visibility = Visibility.Visible;
                CorFlabel.FontSize = 60;
                CorFlabel.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("Green"));
                CorFlabel.Content = "Richtig!";

                await Task.Delay(1000);

                CorFlabel.Visibility = Visibility.Hidden;

                score++;
            }
            else
            {
                CorFlabel.Visibility = Visibility.Visible;
                CorFlabel.FontSize = 25;
                CorFlabel.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF0000"));
                CorFlabel.Content = $"Falsch!";
                await Task.Delay(1000);
                CorFlabel.Content = $"Die richtige Antwort ist: {correctAnswer}";

                await Task.Delay(1500);

                CorFlabel.Visibility = Visibility.Hidden;

                score = 0;
            }

            ScoreLabel.Content = $"Score: {score}";

            await Task.Delay(500);

            LadeZufallsFlagge();
            SetAnswerButtons();

            FlaggeImage.Visibility = Visibility.Visible;
        }
    }
}
