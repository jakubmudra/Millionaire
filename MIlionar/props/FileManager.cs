using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MIlionar.props
{
    class FileManager
    {
        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };

        public List<Question> questions = new List<Question>();

        public FileManager()
        {
            string jsonString = String.Empty;

           /* List<props.Question> listToSave = new List<props.Question>() {
            new props.Question() {
                Query = "Co spadlo podle povesti na hlavu Newtenovi a pomohlo mu formulovat jeho slavny zakon?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 2,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 3,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 4,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 5,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 6,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },new props.Question() {
                Level = 7,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 8,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 9,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 10,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level =11,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 12,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 13,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 14,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            },
            new props.Question() {
                Level = 15,
                Query = "Kolik je 1+1?",
                answers = new List<string>(){"Jablko","trakar","kroupa","veverka"}
            }
        };



            jsonString = JsonConvert.SerializeObject(listToSave, JsonSettings);
            File.WriteAllText("questions.json", jsonString); */

             jsonString = File.ReadAllText("questions.json");
            questions = JsonConvert.DeserializeObject<List<Question>>(jsonString, JsonSettings);
        }

        public List<Score> GetScoresData()
        {
            List<Score> data = new List<Score>();

            // in case of clearing score table/file
            // SaveScoresData(data);

            string jsonString = File.ReadAllText("scores.json");
            data = JsonConvert.DeserializeObject<List<Score>>(jsonString, JsonSettings);

            return data;
        }

        public void SaveScoresData(List<Score> data)
        {
            string jsonString = JsonConvert.SerializeObject(data, JsonSettings);
            File.WriteAllText("scores.json", jsonString);
        }
    }
}
