using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03
{
    public class Word
    {
        private string _text;
        private bool _hidden;

        public Word(string text)
        {
            _text = text;
            _hidden = false;
        }

        public string GetVisibleText()
        {
            if (_hidden)
                return new string('_', _text.Length);
            else
                return _text;
        }

        public void Hide()
        {
            _hidden = true;
        }

        public bool IsHidden()
        {
            return _hidden;
        }
    }
}
