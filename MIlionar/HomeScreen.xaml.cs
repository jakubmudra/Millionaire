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
using System.Media;

namespace MIlionar
{
    /// <summary>
    /// Interaction logic for HomeScren.xaml
    /// </summary>
    public partial class HomeScreen : Page
    {
        
        private Frame mainFrame;
        private MusicControler mc = new MusicControler();
        

        public HomeScreen()
        {
            InitializeComponent();
            mc.player = new MediaPlayer();
            mc.playMedley();
            
        }

        public HomeScreen(Frame mainFrame) : this()
        {
            this.mainFrame = mainFrame;
        }


        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            mc.stop();
            mainFrame.Navigate(new Game(mainFrame));
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void highScore_Click(object sender, RoutedEventArgs e)
        {
            mc.stop();
            mainFrame.Navigate(new HighScore(mainFrame));
        }
    }
}
