using System.Configuration;
using System.Data;
using System.Windows;

namespace Geography_Games_42;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static void ApplyFullscreenMode(Window window)
    {
        if (Settings.IsFullscreen)
        {
            window.WindowStyle = WindowStyle.None;
            window.WindowState = WindowState.Maximized;
        }
        else
        {
            window.WindowStyle = WindowStyle.SingleBorderWindow;
            window.WindowState = WindowState.Normal;
        }
    }

}

