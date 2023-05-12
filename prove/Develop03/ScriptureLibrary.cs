using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03
{
    public class ScriptureLibrary
    {
        private List<Scripture> scriptures;
        private Random random;

        public ScriptureLibrary()
        {
            this.scriptures = new List<Scripture>();
            this.random = new Random();
        }

        public void LoadScripturesFromFiles(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 2)
                {
                    string reference = parts[0].Trim();
                    string text = parts[1].Trim();
                    scriptures.Add(new Scripture(reference, text));
                }
            }
        }

        public Scripture GetRandomScripture()
        {
            if (scriptures.Count == 0)
                throw new InvalidOperationException("No scriptures loaded in the library.");

            int index = random.Next(scriptures.Count);
            return scriptures[index];
        }
    }
}
