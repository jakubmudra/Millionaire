using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlionar
{
    public class GameControler
    {
        public int Level = 1;
        public List<props.Prize> prizes = new List<props.Prize>() {new props.Prize(1,"1.000 Kč"),new props.Prize(2, "2.000 Kč"), new props.Prize(3, "3.000 Kč"), new props.Prize(4, "5.000 Kč"), new props.Prize(5, "10.000 Kč"), new props.Prize(6, "20.000 Kč"), new props.Prize(7, "40.000 Kč"), new props.Prize(8, "80.000 Kč"), new props.Prize(9, "160.000 Kč"), new props.Prize(10, "320.000 Kč"), new props.Prize(11, "640.000 Kč"), new props.Prize(12, "1,250.000 Kč"), new props.Prize(13, "2,500.000 Kč"), new props.Prize(14, "5,000.000 Kč"), new props.Prize(15, "10,000.000 Kč"), };
        public List<props.Question> questions = new List<props.Question>();
        private props.FileManager fm;

        public GameControler()
        {
            this.fm= new props.FileManager();
            questions = fm.questions;
        }

        public string GetPrize(int level = 1)
        {
            return prizes[level - 1].Value;
        }

        public props.Question GetQuestion()
        {
            return questions.Where(single => single.Level == Level).FirstOrDefault();
        }

        public void SaveScore(string name, string prize)
        {
            List<props.Score> score = fm.GetScoresData();
            if(score == null)
            {
                score = new List<props.Score>();
            }
            score.Add(new props.Score() { Name = name, Prize = prize });
            fm.SaveScoresData(score);
        }

        public List<string> ShuffleAnswers(List<string> alph)
        {
            Random rng = new Random();

            List<string> list = new List<string>(alph);

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                String value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }


    
    }
}
