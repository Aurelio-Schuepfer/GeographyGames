using System.Windows;
using System.Windows.Input;

namespace Geography_Games_42
{
    public partial class LänderWindow : Window
    {
        public LänderWindow()
        {
            this.Loaded += (s, e) => App.ApplyFullscreenMode(this);
            InitializeComponent();
            if (Settings.IsFullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            this.KeyDown += LänderWindow_KeyDown;

        }
        private void LänderWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Settings.IsFullscreen = false;
                App.ApplyFullscreenMode(this);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            App.ApplyFullscreenMode(mainWindow);
            mainWindow.Show();
            this.Close();
        }

       
private void Europa_Click(object sender, RoutedEventArgs e)
        {
            EuropaWindow europaWindow = new EuropaWindow();
            App.ApplyFullscreenMode(europaWindow);
            this.Hide();  
            europaWindow.Show();
        }

        private void Asien_Click(object sender, RoutedEventArgs e)
        {
            AsienWindow asienWindow = new AsienWindow();
            App.ApplyFullscreenMode(asienWindow);
            this.Hide();  
            asienWindow.Show();
        }

        private void Afrika_Click(object sender, RoutedEventArgs e)
        {
            AfrikaWindow afrikaWindow = new AfrikaWindow();
            App.ApplyFullscreenMode(afrikaWindow);
            this.Hide(); 
            afrikaWindow.Show();
        }

        private void Nordamerika_Click(object sender, RoutedEventArgs e)
        {
            NordamerikaWindow nordamerikaWindow = new NordamerikaWindow();
            App.ApplyFullscreenMode(nordamerikaWindow);
            this.Hide(); 
            nordamerikaWindow.Show();
        }

        private void Südamerika_Click(object sender, RoutedEventArgs e)
        {
            SüdamerikaWindow suedamerikaWindow = new SüdamerikaWindow();
            App.ApplyFullscreenMode(suedamerikaWindow);
            this.Hide();   
            suedamerikaWindow.Show();
        }
    }
}
