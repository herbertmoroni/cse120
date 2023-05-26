using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03
{
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = ParseWords(text);
            _random = new Random();
        }

        private List<Word> ParseWords(string text)
        {
            List<Word> words = new List<Word>();
            string[] wordArray = text.Split(' ');
            foreach (string wordText in wordArray)
            {
                words.Add(new Word(wordText));
            }
            return words;
        }

        public string GetDisplayText()
        {
            string displayText = _reference + "\n\n";
            foreach (Word word in _words)
            {
                displayText += word.GetVisibleText() + " ";
            }
            return displayText;
        }

        public void HideRandomWords()
        {
            List<Word> visibleWords = GetVisibleWords();
            if (visibleWords.Count > 0)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
            }
        }

        public bool AllWordsHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                    return false;
            }
            return true;
        }

        private List<Word> GetVisibleWords()
        {
            List<Word> visibleWords = new List<Word>();
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                    visibleWords.Add(word);
            }
            return visibleWords;
        }
    }

}
