using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Geography_Games_42
{
    public partial class WissenWindow : Window
    {
        private List<Question> quiz;
        private int currentQuestionIndex;
        private int score;
        private Random random;

        public WissenWindow()
        {
            InitializeComponent();

            this.KeyDown += WissenWindow_KeyDown;

            this.Loaded += (s, e) => App.ApplyFullscreenMode(this);

            if (Settings.IsFullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }

        

        random = new Random();
            quiz = new List<Question>
            {
                new Question("Welches Land hat die größte Fläche der Welt?", new List<string> { "Kanada", "Russland", "China", "USA" }, "Russland"),
                new Question("In welchem Land liegt die Stadt Timbuktu?", new List<string> { "Ghana", "Sudan", "Mali", "Madagaskar" }, "Mali"),
                new Question("Wie heißt die Hauptstadt von Australien?", new List<string> { "Perth", "Sidney", "Canberra", "Adelaide" }, "Canberra"),
                new Question("Welcher Kontinent hat die meisten Länder?", new List<string> { "Europa", "Asien", "Südamerika", "Afrika" }, "Afrika"),
                new Question("In welchem Land liegt die Stadt Lima?", new List<string> { "Argentinien", "Peru", "Kolumbien", "Chile" }, "Peru"),
                new Question("Welcher Fluss fließt durch Paris?", new List<string> { "Donau", "Rhône", "Seine", "Elbe" }, "Seine"),
                new Question("In welchem Land liegt die Stadt Tokyo?", new List<string> { "Südkorea", "China", "Japan", "Taiwan" }, "Japan"),
                new Question("Welcher Ozean liegt zwischen Afrika und Australien?", new List<string> { "Pazifischer Ozean", "Indischer Ozean", "Atlantischer Ozean", "Arktischer Ozean" }, "Indischer Ozean"),
                new Question("Welche Stadt ist die Hauptstadt von Kanada?", new List<string> { "Montreal", "Toronto", "Ottawa", "Vancouver" }, "Ottawa"),
                new Question("Welcher Fluss fließt durch Paris?", new List<string> { "Donau", "Rhône", "Seine", "Elbe" }, "Seine"),
                new Question("In welchem Land liegt die Stadt Tokyo?", new List<string> { "Südkorea", "China", "Japan", "Taiwan" }, "Japan"),
                new Question("Welche Wüste ist die größte der Welt?", new List<string> { "Kalahari", "Gobi", "Sahara", "Atacama" }, "Sahara"),
                new Question("Welche Inselgruppe gehört zu Frankreich?", new List<string> { "Galápagos-Inseln", "Azoren", "Kanarische Inseln", "Réunion" }, "Réunion"),
                new Question("Welches Land hat die meisten Vulkane?", new List<string> { "Island", "Indonesien", "Japan", "Italien" }, "Indonesien"),
                new Question("In welchem Land liegt die Stadt Barcelona?", new List<string> { "Italien", "Spanien", "Griechenland", "Frankreich" }, "Spanien"),
                new Question("Welches Land ist von fast allen anderen Ländern in Afrika umgeben?", new List<string> { "Südafrika", "Äthiopien", "Lesotho", "Namibia" }, "Lesotho"),
                new Question("Welche Stadt ist die Hauptstadt von Brasilien?", new List<string> { "Rio de Janeiro", "Sao Paulo", "Brasília", "Porto Alegre" }, "Brasília"),
                new Question("Wo liegt der Grand Canyon?", new List<string> { "Kanada", "Mexiko", "USA", "Australien" }, "USA"),
                new Question("Welcher Berg ist der höchste der Welt?", new List<string> { "K2", "Mount Everest", "Kilimandscharo", "Mont Blanc" }, "Mount Everest"),
                new Question("Welcher Fluss ist der längste der Welt?", new List<string> { "Amazonas", "Nil", "Mississippi", "Yangtse" }, "Nil"),
                new Question("In welchem Land liegt die Stadt Nairobi?", new List<string> { "Uganda", "Kenia", "Tansania", "Äthiopien" }, "Kenia"),
                new Question("Welche Insel ist die größte der Welt?", new List<string> { "Australien", "Grönland", "Neuguinea", "Borneo" }, "Grönland"),
                new Question("In welchem Land liegt das Taj Mahal?", new List<string> { "Indien", "Pakistan", "Bangladesch", "Nepal" }, "Indien"),
                new Question("Welche Hauptstadt liegt am Fluss Danube?", new List<string> { "Wien", "Budapest", "Belgrad", "Kiew" }, "Budapest"),
                new Question("In welchem Land liegt der Mount Kilimanjaro?", new List<string> { "Uganda", "Kenia", "Tansania", "Ruanda" }, "Tansania"),
                new Question("Welche Stadt ist die Hauptstadt von Griechenland?", new List<string> { "Athen", "Rom", "Lissabon", "Istanbul" }, "Athen"),
                new Question("Wo befindet sich das berühmte Machu Picchu?", new List<string> { "Mexiko", "Kolumbien", "Peru", "Chile" }, "Peru"),
                new Question("Welches Land hat den meisten Anteil an der Antarktis?", new List<string> { "Australien", "Argentinien", "Norwegen", "Südafrika" }, "Argentinien"),
                new Question("Welche Hauptstadt liegt auf der Insel Island?", new List<string> { "Oslo", "Kopenhagen", "Reykjavik", "Bergen" }, "Reykjavik"),
                new Question("Welche europäische Hauptstadt liegt an der Moldau?", new List<string> { "Prag", "Budapest", "Wien", "Bratislava" }, "Prag"),
                new Question("In welchem Land liegt der berühmte Yellowstone Nationalpark?", new List<string> { "Kanada", "USA", "Mexiko", "Australien" }, "USA"),
                new Question("Welches Land grenzt nicht an China?", new List<string> { "Indien", "Russland", "Nepal", "Japan" }, "Japan"),
                new Question("Welcher Fluss fließt durch London?", new List<string> { "Themse", "Elbe", "Rhône", "Donau" }, "Themse"),
                new Question("In welchem Land liegt das berühmte Naturwunder die \"Victoriafälle\"?", new List<string> { "Kenia", "Südafrika", "Simbabwe", "Zambien" }, "Simbabwe"),
                new Question("In welchem Land liegt der Lake Tahoe?", new List<string> { "USA", "Kanada", "Mexiko", "Australien" }, "USA"),
                new Question("Welches Land ist berühmt für die Pyramiden von Gizeh?", new List<string> { "Marokko", "Ägypten", "Libyen", "Saudi-Arabien" }, "Ägypten"),
                new Question("Welche Inselgruppe gehört zu den USA?", new List<string> { "Hawaii", "Galápagos-Inseln", "Kanarische Inseln", "Azoren" }, "Hawaii"),
                new Question("Welcher Fluss fließt durch Rom?", new List<string> { "Rhein", "Rhône", "Po", "Tiber" }, "Tiber"),
                new Question("Welches Land liegt direkt südlich von Kanada?", new List<string> { "Mexiko", "USA", "Venezuela", "Kuba" }, "USA"),
                new Question("Welches Land hat das größte Staatsgebiet in Südamerika?", new List<string> { "Brasilien", "Argentinien", "Chile", "Kolumbien" }, "Brasilien"),
                new Question("Welches Land liegt an der Grenze zu Indien und hat das höchste Gebirge der Erde?", new List<string> { "Bhutan", "Nepal", "Pakistan", "China" }, "Nepal"),
                new Question("Welche Inselgruppe liegt östlich von Japan?", new List<string> { "Galápagos-Inseln", "Philippinen", "Fidschi-Inseln", "Hawaii" }, "Philippinen"),
                new Question("Welche Wüste befindet sich in Australien?", new List<string> { "Gobi", "Kalahari", "Atacama", "Simpson Desert" }, "Simpson Desert"),
                new Question("In welchem Land liegt die Stadt Casablanca?", new List<string> { "Marokko", "Algerien", "Tunesien", "Libyen" }, "Marokko"),
                new Question("Welcher Fluss fließt durch Ägypten?", new List<string> { "Nil", "Amazonas", "Ganges", "Rhein" }, "Nil"),
                new Question("Welche Stadt ist die Hauptstadt von Südkorea?", new List<string> { "Peking", "Seoul", "Tokio", "Manila" }, "Seoul"),
                new Question("In welchem Land liegt das berühmte Naturwunder die \"Great Barrier Reef\"?", new List<string> { "Australien", "Neuseeland", "Südafrika", "Mexiko" }, "Australien"),
                new Question("Welche Stadt ist die Hauptstadt von Norwegen?", new List<string> { "Oslo", "Stockholm", "Helsinki", "Kopenhagen" }, "Oslo")

            };

            quiz = quiz.OrderBy(q => random.Next()).ToList();

            currentQuestionIndex = 0;
            score = 0;

            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (currentQuestionIndex < quiz.Count)
            {
                var currentQuestion = quiz[currentQuestionIndex];
                Frage.Text = currentQuestion.Text;
                Button1.Content = currentQuestion.Answers[0];
                Button2.Content = currentQuestion.Answers[1];
                Button3.Content = currentQuestion.Answers[2];
                Button4.Content = currentQuestion.Answers[3];
            }
            else
            {
                Frage.Text = "Quiz beendet!";
                Button1.Visibility = Button2.Visibility = Button3.Visibility = Button4.Visibility = Visibility.Collapsed;
            }
        }
        private void WissenWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Settings.IsFullscreen = false;
                App.ApplyFullscreenMode(this);
            }
        }

        private async void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string selectedAnswer = clickedButton.Content.ToString();
            var correctAnswer = quiz[currentQuestionIndex].CorrectAnswer;

            if (selectedAnswer == correctAnswer)
            {
                score++;
                ScoreLabel.Content = "Score: " + score;
                Frage.Foreground = Brushes.Green;
                Frage.Text = "Richtig!";
                
            }
            else
            {
                score = 0;
                ScoreLabel.Content = "Score: " + score;
                Frage.Foreground = Brushes.Red;
                Frage.Text = $"Falsch! Die richtige Antwort ist: {correctAnswer}";
                
            }

            await Task.Delay(1000);
            Frage.Foreground = Brushes.White;
            currentQuestionIndex++;

            if (currentQuestionIndex < quiz.Count)
            {
                LoadQuestion();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            App.ApplyFullscreenMode(mainWindow);
            mainWindow.Show();
            this.Close();
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }

        public Question(string text, List<string> answers, string correctAnswer)
        {
            Text = text;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}
