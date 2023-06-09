﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03
{
    public class ScriptureLibrary
    {
        private List<Scripture> _scriptures;
        private Random _random;

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>();
            _random = new Random();
        }

        public void LoadScripturesFromFiles(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 2)
                {
                    string referenceString = parts[0].Trim();
                    string text = parts[1].Trim();

                    ScriptureReference reference = ParseScriptureReference(referenceString);
                    _scriptures.Add(new Scripture(reference, text));
                }
            }
        }

        private ScriptureReference ParseScriptureReference(string referenceString)
        {
            string[] parts = referenceString.Split(' ');
            if (parts.Length == 2)
            {
                string book = parts[0].Trim();
                string[] chapterVerse = parts[1].Split(':');
                if (chapterVerse.Length == 2 && int.TryParse(chapterVerse[0].Trim(), out int chapter) && int.TryParse(chapterVerse[1].Trim(), out int verse))
                {
                    return new ScriptureReference(book, chapter, verse);
                }
            }

            throw new ArgumentException("Invalid scripture reference format: " + referenceString);
        }

        public Scripture GetRandomScripture()
        {
            if (_scriptures.Count == 0)
                throw new InvalidOperationException("No scriptures loaded in the library.");

            int index = _random.Next(_scriptures.Count);
            return _scriptures[index];
        }
    }
}
