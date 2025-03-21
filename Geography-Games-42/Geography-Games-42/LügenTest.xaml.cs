using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Geography_Games_42
{
    public partial class LügenTest : Window
    {
        private Frage aktuelleFrage;
        private Random random = new Random();
        private List<Frage> Fragen;
        public int Score = 0;

        public LügenTest()
        {
            this.Loaded += (s, e) => App.ApplyFullscreenMode(this);
            InitializeComponent();
            LadeFragen();
            NeueFrage();
            this.KeyDown += LügenTest_KeyDown;
        }
        private void LügenTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Settings.IsFullscreen = false;
                App.ApplyFullscreenMode(this);
            }
        }

        public class Frage
        {
            public string Text { get; set; }
            public bool IstWahr { get; set; }
        }

        private void LadeFragen()
        {
            Fragen = new List<Frage>
            {
                new Frage { Text = "Der Amazonas ist der wasserreichste Fluss der Welt.", IstWahr = true },
                new Frage { Text = "Kanada hat mehr Seen als jedes andere Land der Welt.", IstWahr = true },
                new Frage { Text = "Die Sahara ist die größte heiße Wüste der Erde.", IstWahr = true },
                new Frage { Text = "Der Marianengraben ist die tiefste Stelle im Ozean.", IstWahr = true },
                new Frage { Text = "Australien ist gleichzeitig ein Land und ein Kontinent.", IstWahr = true },
                new Frage { Text = "Russland ist das flächenmäßig größte Land der Welt.", IstWahr = true },
                new Frage { Text = "Der Kilimandscharo ist der höchste Berg Afrikas.", IstWahr = true },
                new Frage { Text = "Der Äquator verläuft durch 13 Länder.", IstWahr = true },
                new Frage { Text = "Grönland ist die größte Insel der Welt.", IstWahr = true },
                new Frage { Text = "Der Mississippi ist der längste Fluss in Nordamerika.", IstWahr = true },
                new Frage { Text = "Der Bodensee grenzt an Deutschland, Österreich und die Schweiz.", IstWahr = true },
                new Frage { Text = "Der Viktoriasee ist der größte See Afrikas.", IstWahr = true },
                new Frage { Text = "Der Nil ist der längste Fluss der Welt.", IstWahr = true },
                new Frage { Text = "Der Titicacasee ist der höchstgelegene schiffbare See der Welt.", IstWahr = true },
                new Frage { Text = "Island liegt auf zwei tektonischen Platten.", IstWahr = true },
                new Frage { Text = "Der Himalaya wächst jedes Jahr einige Millimeter.", IstWahr = true },
                new Frage { Text = "Der Grand Canyon befindet sich in den USA.", IstWahr = true },
                new Frage { Text = "Die Antarktis ist der kälteste Kontinent.", IstWahr = true },
                new Frage { Text = "Die Atacama-Wüste in Chile ist eine der trockensten Regionen der Erde.", IstWahr = true },
                new Frage { Text = "Der Baikalsee ist der tiefste Süßwassersee der Welt.", IstWahr = true },
                new Frage { Text = "Der Mount Everest wächst jedes Jahr ein wenig.", IstWahr = true },
                new Frage { Text = "Der Ural trennt Europa von Asien.", IstWahr = true },
                new Frage { Text = "Die Anden sind die längste Gebirgskette der Welt.", IstWahr = true },
                new Frage { Text = "Der höchste Wasserfall der Welt ist der Salto Ángel in Venezuela.", IstWahr = true },
                new Frage { Text = "Die Philippinen bestehen aus mehr als 7.000 Inseln.", IstWahr = true },
                new Frage { Text = "Der Pazifik ist der größte Ozean der Welt.", IstWahr = true },
                new Frage { Text = "Madagaskar ist die viertgrößte Insel der Welt.", IstWahr = true },
                new Frage { Text = "Der Jangtse ist der längste Fluss Asiens.", IstWahr = true },
                new Frage { Text = "Brasilien hat die meisten Nachbarländer in Südamerika.", IstWahr = true },
                new Frage { Text = "Der Kilimandscharo hat drei erloschene Vulkane.", IstWahr = true },
                new Frage { Text = "Kanada hat die längste Küstenlinie der Welt.", IstWahr = true },
                new Frage { Text = "Der Rhein mündet in die Nordsee.", IstWahr = true },
                new Frage { Text = "Venedig besteht aus über 100 Inseln.", IstWahr = true },
                new Frage { Text = "Der Nil fließt von Süden nach Norden.", IstWahr = true },
                new Frage { Text = "Australien hat mehr Kamele als Ägypten.", IstWahr = true },
                new Frage { Text = "Die Mongolei ist das am dünnsten besiedelte Land der Welt.", IstWahr = true },
                new Frage { Text = "Der Kruger-Nationalpark liegt in Südafrika.", IstWahr = true },
                new Frage { Text = "Der Titicacasee liegt zwischen Peru und Bolivien.", IstWahr = true },
                new Frage { Text = "Der Viktoriafall liegt an der Grenze zwischen Simbabwe und Sambia.", IstWahr = true },
                new Frage { Text = "Der Himalaya enthält den höchsten Berg der Welt.", IstWahr = true },
                new Frage { Text = "Der Amazonas-Regenwald ist das größte Regenwaldgebiet der Erde.", IstWahr = true },
                new Frage { Text = "Die Stadt Istanbul liegt auf zwei Kontinenten.", IstWahr = true },
                new Frage { Text = "Der Baikalsee enthält etwa 20% des nicht gefrorenen Süßwassers der Erde.", IstWahr = true },
                new Frage { Text = "Die Victoriafälle wurden nach einer britischen Königin benannt.", IstWahr = true },
    
                new Frage { Text = "Der Mount Everest ist ein Vulkan.", IstWahr = false },
                new Frage { Text = "Der Amazonas fließt durch Südafrika.", IstWahr = false },
                new Frage { Text = "Grönland ist ein eigenständiger Staat.", IstWahr = false },
                new Frage { Text = "Der Pazifik ist kleiner als der Atlantik.", IstWahr = false },
                new Frage { Text = "Die Alpen sind die längste Gebirgskette der Welt.", IstWahr = false },
                new Frage { Text = "Der Mississippi ist der längste Fluss der Welt.", IstWahr = false },
                new Frage { Text = "Der Baikalsee liegt in Kanada.", IstWahr = false },
                new Frage { Text = "China ist flächenmäßig das größte Land der Welt.", IstWahr = false },
                new Frage { Text = "Der Grand Canyon befindet sich in Mexiko.", IstWahr = false },
                new Frage { Text = "Der Bosporus trennt Afrika und Europa.", IstWahr = false },
                new Frage { Text = "Der Himalaya ist das älteste Gebirge der Welt.", IstWahr = false },
                new Frage { Text = "Die Sahara ist kälter als die Antarktis.", IstWahr = false },
                new Frage { Text = "Italien grenzt an mehr Länder als Deutschland.", IstWahr = false },
                new Frage { Text = "Der Mount Everest befindet sich in Südamerika.", IstWahr = false },
                new Frage { Text = "Der Nil mündet in den Pazifik.", IstWahr = false },
                new Frage { Text = "Island hat eine tropische Vegetation.", IstWahr = false },
                new Frage { Text = "Japan ist das größte Land der Welt.", IstWahr = false },
                new Frage { Text = "Der Eiffelturm ist das höchste Gebäude der Welt.", IstWahr = false },
                new Frage { Text = "Die Sahara besteht hauptsächlich aus Dschungel.", IstWahr = false },
                new Frage { Text = "Deutschland hat die meisten Inseln weltweit.", IstWahr = false },
                new Frage { Text = "Der Atlantik ist der tiefste Ozean.", IstWahr = false },
                new Frage { Text = "Afrika hat keine Wüsten.", IstWahr = false },
                new Frage { Text = "Russland hat das heißeste Klima der Welt.", IstWahr = false },
                new Frage { Text = "Der Viktoriasee ist größer als der Pazifik.", IstWahr = false },
                new Frage { Text = "Europa hat die meisten Einwohner aller Kontinente.", IstWahr = false },
                new Frage { Text = "Der Nordpol gehört zu Kanada.", IstWahr = false },
                new Frage { Text = "Die Donau fließt durch Portugal.", IstWahr = false },
                new Frage { Text = "Der Kaspische See ist ein Ozean.", IstWahr = false },
                new Frage { Text = "Neuseeland grenzt an Australien.", IstWahr = false },
                new Frage { Text = "Afrika ist ein Land.", IstWahr = false },
                new Frage { Text = "Grönland ist wärmer als Deutschland.", IstWahr = false }
            };
        }

        private void NeueFrage()
        {
            int index = random.Next(Fragen.Count);
            aktuelleFrage = Fragen[index];
            FrageText.Text = aktuelleFrage.Text;
        }

        private void Wahrheit_Click(object sender, RoutedEventArgs e)
        {
            ÜberprüfeAntwort(true);
        }

        private void Lüge_Click(object sender, RoutedEventArgs e)
        {
            ÜberprüfeAntwort(false);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            App.ApplyFullscreenMode(mainWindow);
            mainWindow.Show();
            this.Close();
        }

        private void UpdateScore(int score)
        {
            ScoreText.Text = ($"Score: {score}");
        }


        private async void ÜberprüfeAntwort(bool antwort)
        {
            if (antwort == aktuelleFrage.IstWahr)
            {
                FrageText.Text = "Richtig!";
                FrageText.Foreground = Brushes.LimeGreen;
                Score++;
            }
            else
            {
                FrageText.Text = "Falsch!";
                FrageText.Foreground = Brushes.Red;
                Score = 0;
            }

            UpdateScore(Score);

            await Task.Delay(1000);

            FrageText.Foreground = Brushes.White;
            NeueFrage();
        }

    }
}
