namespace TestOnline
{
    public class Test20
    {
        private int QUEST_NUM;
        private Question[] questions;
        private int countQuestion;
        private string category;

        internal Question[] Questions { get => questions; set => questions = value; }
        public string Category { get => category; set => category = value; }

        // domyślny konstruktor ustawiający numer pytania na 0;
        public Test20()
        {
            countQuestion = 0;
        }

        // metoda tworząca tablicę pytań o rozmiarze podanym w parametrze (standardowo będzie to 20 lub ilość pytań w bazie)
        public void CreateQuestionsArray(int questionsValue)
        {
            QUEST_NUM = questionsValue;
            questions = new Question[QUEST_NUM];
        }

        // metoda sprawdza czy pytanie o danym Id znajduje się już w tablicy
        public bool FindQuestionById(int id)
        {
            for(int i=0; i<QUEST_NUM; i++)
            {
                if (questions[i] != null)
                {
                    if (questions[i].Id.Equals(id)) return true;
                }
                else return false;
            }
            return false;
        }

        // metoda zwraca ilość poprawnych odpowiedzi
        public int GetCorrectAnswers()
        {
            int value = 0;
            for (int i = 0; i < QUEST_NUM; i++)
            {
                if (questions[i].CompareAnswerWithSelected()) value++;
            }
            return value;
        }

    }

    // klasa opisująca pytanie z całą zawartością
    class Question
    {
        private int id;
        private string content;
        private string ans1;
        private string ans2;
        private string ans3;
        private string ans4;
        private int corAns;
        private int selectedAnswer;
        private string URLImage;

        public Question()
        {

        }

        // konstruktor przyjmujący wszystkie parametry pytania
        public Question(int id, string content, string ans1, string ans2, string ans3, string ans4, int corAns)
        {
            this.id = id;
            this.content = content;
            this.ans1 = ans1;
            this.ans2 = ans2;
            this.ans3 = ans3;
            this.ans4 = ans4;
            this.corAns = corAns;
        }

        // GETTERY I SETTERY
        public int Id { get => id; set => id = value; }
        public string Content { get => content; set => content = value; }
        public string Ans1 { get => ans1; set => ans1 = value; }
        public string Ans2 { get => ans2; set => ans2 = value; }
        public string Ans3 { get => ans3; set => ans3 = value; }
        public string Ans4 { get => ans4; set => ans4 = value; }
        public int CorAns { get => corAns; set => corAns = value; }
        public int SelectedAnswer { get => selectedAnswer; set => selectedAnswer = value; }
        public string URLImage1 { get => URLImage; set => URLImage = value; }

        // metoda sprawdzająca czy w pytaniu pojawia się obrazek
        public bool IsImage() { if (URLImage == null) return false; else return true; }

        // metoda porównuje poprawną odpowiedź z zaznaczoną i zwraca true jeśli są takie same lub false jeżeli różne
        public bool CompareAnswerWithSelected()
        {
            return corAns.Equals(selectedAnswer);
        }
    }
}