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
    /// Interaction logic for loss.xaml
    /// </summary>
    public partial class loss : Page
    {
        private Frame mainFrame;
        private GameControler GC;
        private MusicControler mc = new MusicControler();
        private bool Win;
        private string prize;
        public bool GiveUp = false;

        public loss()
        {
            InitializeComponent();
        }
        public loss(Frame mainFrame, GameControler gc, bool win) : this()
        {
            this.mainFrame = mainFrame;
            this.GC = gc;
            this.Win = win;
            mc.player = new MediaPlayer();

            if (Win) winText.Text = "You win!";
            else winText.Text = "You lost!";


            if (!Win)
            {
                if (GC.Level < 5)
                {
                    prize = "0 kc";
                }
                else if (GC.Level >= 5 && GC.Level < 10)
                {
                    prize = "10,000 Kc";
                }
                else
                {
                    prize = "320,000 Kc";
                }
            }
            else
            {
                prize = (GiveUp) ?  prize = GC.prizes[14 - GC.Level].Value : prize = GC.prizes[15 - GC.Level].Value;
            }


            winPrize.Text = prize;

            mc.playLast();

        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            string nam = UserName.Text;
            string prize = winPrize.Text;
            GC.SaveScore(nam, prize);
            System.Windows.Application.Current.Shutdown();
        }

        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            string nam = UserName.Text;
            string prize = winPrize.Text;
            GC.SaveScore(nam, prize);
            mainFrame.Navigate(new HomeScreen(mainFrame));
        }
    }
}
