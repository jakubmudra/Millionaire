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

namespace MIlionar
{
    class MusicControler
    {
        public MediaPlayer player;

        public void playMedley()
        {
            
            player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };
            player.Open(new Uri("../../sound/medley.mp3", UriKind.RelativeOrAbsolute));
            player.Play();
        }
        public void playNapinani()
        {

            player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };
            player.Open(new Uri("../../sound/napinani.mp3", UriKind.RelativeOrAbsolute));
            player.Play();
        }
        public void playGameOpen()
        {
           
            player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };
          
            player.Open(new Uri("../../sound/gameopen.mp3", UriKind.RelativeOrAbsolute));
            player.Play();
        }

        public void playQuestionBG(int level)
        {

            player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };

            player.Open(new Uri("../../sound/level1_5_waiting.mp3", UriKind.RelativeOrAbsolute));


            player.Play();
        }
        public void playGiveUp()
        {

            player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };

            player.Open(new Uri("../../sound/takemoney.mp3", UriKind.RelativeOrAbsolute));


            player.Play();
        }
        public void playLast()
        {

            player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };

            player.Open(new Uri("../../sound/closing.mp3", UriKind.RelativeOrAbsolute));


            player.Play();
        }

        public void playQuestionCorrect(int level)
        {
            
            
            player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };
            if (level > 0 && level < 15 && level != 5 && level != 10)
            {
                player.Open(new Uri("../../sound/level1_4_correct.mp3", UriKind.RelativeOrAbsolute));
            }
            else if(level == 15)
            {
                player.Open(new Uri("../../sound/last_correct.mp3", UriKind.RelativeOrAbsolute));
            }
            else
            {
                player.Open(new Uri("../../sound/checkpoint_correct.mp3", UriKind.RelativeOrAbsolute));
            }

            player.Play();
        }
        public void playQuestionWrong(int level)
        {
            
            
            player.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };
            if (level > 0 && level < 15)
            {
                player.Open(new Uri("../../sound/level1_5_wrong.mp3", UriKind.RelativeOrAbsolute));
            }
            else
            {
                player.Open(new Uri("../../sound/last_wrong.mp3", UriKind.RelativeOrAbsolute));
            }

            player.Play();
        }

        public void stop()
        {
         
            player.Stop();

            
        }
    }
}
