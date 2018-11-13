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

namespace MIlionar
{
    /// <summary>
    /// Interaction logic for HighScore.xaml
    /// </summary>
    public partial class HighScore : Page
    {

        private Frame mainFrame;
        
        public HighScore()
        {
            InitializeComponent();

            props.FileManager fm = new props.FileManager();

            List<props.Score> scoreList = fm.GetScoresData();

            if(scoreList == null)
            {
                MessageBox.Show("Nothing found");
            }
            else
            {
                highScore.ItemsSource = scoreList;
            }
        }

        public HighScore(Frame mainFrame) : this()
        {
            this.mainFrame = mainFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new HomeScreen(mainFrame));
        }
    }
}
