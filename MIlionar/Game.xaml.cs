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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Diagnostics;


namespace MIlionar
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {

        private MusicControler mc = new MusicControler();
        private GameControler GC = new GameControler();
        private Frame mainFrame;
        private int rightAnswer;
        private List<string> buttons = new List<string>() { "answerA", "answerB", "answerC", "answerD" };
        private List<string> questionsList;
        private bool loss = false;

        public Game()
        {
            InitializeComponent();
            mc.player = new MediaPlayer();
            mc.playGameOpen();
            


            Timer t = new Timer(12000);
            t.Elapsed += showQuestion;
            t.AutoReset = false;
            t.Enabled = true;

            var items = new List<props.Prize>();
            items = GC.prizes;
            items.Reverse();

            vyhry.ItemsSource = items;
           
        }
        public Game(Frame mainFrame) : this()
        {
            this.mainFrame = mainFrame;
        }

        private void showQuestion(Object source, ElapsedEventArgs e)
        {

            props.Question actual = GC.GetQuestion();
            this.Dispatcher.Invoke(() =>
            {
                ActualPrize.Text = "0 Kc";
                query.Text = actual.Query;
            });

            questionsList = new List<string>(GC.ShuffleAnswers(GC.GetQuestion().answers));
            rightAnswer = questionsList.IndexOf(actual.answers[0]);
            this.Dispatcher.Invoke(() =>
            {
                for(int i = 0; i < 4;i++)
                {
                    switch(i)
                    {
                        case 0: answerAText.Text = "A: " + questionsList[i]; break;
                        case 1: answerBText.Text = "B: " + questionsList[i]; break;
                        case 2: answerCText.Text = "C: " + questionsList[i]; break;
                        case 3: answerDText.Text = "D: " + questionsList[i]; break;
                    }
                }

                
            });
            
            this.Dispatcher.Invoke(() =>
            {
                mc.playQuestionBG(GC.Level);
                ListViewItem item = vyhry.ItemContainerGenerator.ContainerFromIndex(15 - GC.Level) as ListViewItem;
                item.Focus();
            });
           
        }
        public void ShowQuestion()
        {
            props.Question actual = GC.GetQuestion();
            ActualPrize.Text = GC.prizes[16 - GC.Level].Value;
            query.Text = actual.Query;

            ListViewItem item = vyhry.ItemContainerGenerator.ContainerFromIndex(15 - GC.Level) as ListViewItem;
            item.Focus();


            questionsList = new List<string>(GC.ShuffleAnswers(GC.GetQuestion().answers));
            rightAnswer = questionsList.IndexOf(actual.answers[0]);

            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0: answerAText.Text = "A: " + questionsList[i]; break;
                    case 1: answerBText.Text = "B: " + questionsList[i]; break;
                    case 2: answerCText.Text = "C: " + questionsList[i]; break;
                    case 3: answerDText.Text = "D: " + questionsList[i]; break;
                }
            }
            
            this.Dispatcher.Invoke(() =>
            {
                mc.stop();
            });
            this.Dispatcher.Invoke(() =>
            {
                mc.playQuestionBG(GC.Level);
            });
            
        }


       
        private void answer_Click(object sender, RoutedEventArgs e)
        {
            
            Button btn = sender as Button;


            query.Dispatcher.Invoke(() =>
            {
                selectAnswer(btn.Name, 1);
                MessageBox.Show("Zvolil jste " + (buttons.IndexOf(btn.Name) + 1));


            });
            this.Dispatcher.Invoke(() =>
            {
                mc.stop();
                mc.playNapinani();
                System.Threading.Thread.Sleep(8000);
                
            });


            if (buttons.IndexOf(btn.Name) == rightAnswer)
            {
                this.Dispatcher.Invoke(() =>
                {
                    mc.stop();
                    selectAnswer(btn.Name, 2);
                    mc.playQuestionCorrect(GC.Level);
                    MessageBox.Show("RightAnswer");

                });
               
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    mc.stop();
                    selectAnswer(buttons[rightAnswer], 2);
                    mc.playQuestionWrong(GC.Level);
                    MessageBox.Show("WrongAnswer");
                    mainFrame.Navigate(new loss(mainFrame, GC, false));
                    loss = true;

                });
                

            }
            if (GC.Level == 15 && loss != true)
            {
                mainFrame.Navigate(new loss(mainFrame, GC, true));
                return;
            }
            else if(!loss){
                GC.Level++;
                resetBtns();
                ShowQuestion();
            }

            
        }


        private void resetBtns()
        {
            for(int i = 0;i<4;i++)
            {
                visiblityOfButton(i, Visibility.Visible, true);
                selectAnswer(buttons[i]);
            }
        }

        private void fiftyUnused_Click(object sender, RoutedEventArgs e)
        {
            fiftyUnused.Visibility = Visibility.Hidden;
            fiftyUsed.Visibility = Visibility.Visible;

            Random r = new Random();
            int num1 = rightAnswer;
            int num2 = rightAnswer;
            while (num1 == rightAnswer || num2 == rightAnswer || num1 == num2)
            {
                num1 = r.Next(0, 4);
                num2 = r.Next(0, 4);
            }
            visiblityOfButton(num1, Visibility.Hidden);
            visiblityOfButton(num2, Visibility.Hidden);
        }


        private void selectAnswer(string name, int state = 0)
        {

            //1 = selected
            //2 = right
            //other = unselected
            Rect left = default(Rect);
            Rect right = default(Rect);
            switch (state)
            {
                case 1:
                    left = new Rect(0, 144, 308, 40);
                    right = new Rect(303, 144, 308, 40);
                    break;
                case 2:
                    left = new Rect(0, 183, 308, 40);
                    right = new Rect(303, 183, 308, 40);
                    break;
                default:
                    left = new Rect(0, 105, 308, 40);
                    right = new Rect(303, 105, 308, 40);
                    break;
            }



            switch(name)
            {
                case "answerA":
                    answerAVB.Viewbox = left;
                    break;
                case "answerB":
                    answerBVB.Viewbox = right;
                    break;
                case "answerC":
                    answerCVB.Viewbox = left;
                    break;
                case "answerD":
                    answerDVB.Viewbox = right;
                    break;

            }
        }

        private void visiblityOfButton(int index, Visibility visible, bool textDel = false)
        {
            switch(index)
            {
                case 0:
                    answerA.Visibility = visible;
                    if(textDel) answerAText.Text = "A: ";
                    break;
                case 1:
                    answerB.Visibility = visible;
                    if (textDel) answerBText.Text = "B: ";
                    break;
                case 2:
                    answerC.Visibility = visible;
                    if (textDel) answerCText.Text = "C: ";
                    break;
                case 3: answerD.Visibility = visible;
                    if (textDel) answerDText.Text = "D: ";
                    break;
            }
        }

        private void telUnused_Click(object sender, RoutedEventArgs e)
        {
            telUnused.Visibility = Visibility.Hidden;
            telActive.Visibility = Visibility.Visible;

            int returnValue;

            Random r = new Random();
            int range = r.Next(1, 11);
            if (range < 9) returnValue = rightAnswer;
            else returnValue = (rightAnswer == 3) ? rightAnswer-- : rightAnswer++;

            MessageBox.Show("Your friend thinks its number " + returnValue++ + ", do you trust him?");
            telActive.Visibility = Visibility.Hidden;
            telUsed.Visibility = Visibility.Visible;
        }

        private void audienceUnused_Click(object sender, RoutedEventArgs e)
        {
            audienceActive.Visibility = Visibility.Visible;
            audienceUnused.Visibility = Visibility.Hidden;

            Random r = new Random();

            List<int> numbers = new List<int>();


            numbers.Add(r.Next(0, 97));
            numbers.Add(r.Next(0, 100 - numbers[0]));
            numbers.Add(r.Next(0, 100 - numbers[0] - numbers[1]));
            numbers.Add(100 - numbers[0] - numbers[1] - numbers[2]);

            int max = numbers.Max();
            numbers.Remove(max);
            string msg = "";

            char[] chars = new char[4]{ 'A','B','C','D'};
            for(int i = 0;i<4;i++)
            {
                msg += chars[i] + ": ";
                if(rightAnswer == i) msg += max;
                else
                {
                    msg += numbers[numbers.Count() - 1];
                    numbers.RemoveAt(numbers.Count() - 1);
                }
                msg += "%" + "\n";
            }

            MessageBox.Show(msg);

            audienceActive.Visibility = Visibility.Hidden;
            audienceUsed.Visibility = Visibility.Visible;

        }

        private void GiveUp_Click(object sender, RoutedEventArgs e)
        {
            mc.stop();
            mc.playGiveUp();
            mainFrame.Navigate(new loss(mainFrame, GC, false) { GiveUp = true});
        }
    }
}
