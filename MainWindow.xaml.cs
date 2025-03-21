using System.Windows;
using System.Windows.Input;

namespace Geography_Games_42
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Loaded += (s, e) => App.ApplyFullscreenMode(this);
            InitializeComponent();
            FullscreenToggle.IsChecked = Settings.IsFullscreen;
            ApplyFullscreenMode();
            this.KeyDown += MainWindow_KeyDown;
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Settings.IsFullscreen = false;
                App.ApplyFullscreenMode(this);
            }
        }

        private async void ShowFullscreenHint()
        {
            FullscreenHint.Visibility = Visibility.Visible;  
            await Task.Delay(3000); 
            FullscreenHint.Visibility = Visibility.Collapsed; 
        }
        private void FullscreenToggle_Checked(object sender, RoutedEventArgs e)
        {
            Settings.IsFullscreen = true;
            App.ApplyFullscreenMode(this);
            ShowFullscreenHint(); 
        }


        private void ApplyFullscreenMode()
        {
            if (Settings.IsFullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
            }
        }

        private void ToggleFullscreen(object sender, RoutedEventArgs e)
        {
            Settings.IsFullscreen = !Settings.IsFullscreen;

            if (Settings.IsFullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
            }
        }


        private void FlaggenButton_Click(object sender, RoutedEventArgs e)
        {
            FlaggenWindow flaggenWindow = new FlaggenWindow();
            App.ApplyFullscreenMode(flaggenWindow);
            this.Hide();
            flaggenWindow.Show();
        }

        private void Wissen_Click(object sender, RoutedEventArgs e)
        {
            WissenWindow WissenWindow = new WissenWindow();
            App.ApplyFullscreenMode(WissenWindow);
            this.Hide();
            WissenWindow.Show();
        }
        private void Länder_Click(object sender, RoutedEventArgs e)
        {
            LänderWindow LänderWindow = new LänderWindow();
            App.ApplyFullscreenMode(LänderWindow);
            this.Hide();
            LänderWindow.Show();
        }
        private void LügenTest_Click(object sender, RoutedEventArgs e)
        {
            LügenTest lügenTest = new LügenTest();
            App.ApplyFullscreenMode(lügenTest);
            this.Hide();
            lügenTest.Show();
        }

    }
}
