using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop03
{
    public class Word
    {
        private string text;
        private bool hidden;

        public Word(string text)
        {
            this.text = text;
            this.hidden = false;
        }

        public string GetVisibleText()
        {
            if (hidden)
                return new string('_', text.Length);
            else
                return text;
        }

        public void Hide()
        {
            hidden = true;
        }

        public bool IsHidden()
        {
            return hidden;
        }
    }
}
