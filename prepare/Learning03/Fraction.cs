using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning03
{
    public class Fraction
    {
        private int _top;
        public int GetTop()
        {
            return _top;
        }
        public void SetTop(int top)
        {
            _top = top;
        }

        private int _bottom;
        public int GetBottom()
        {
            return _bottom;
        }
        public void SetBottom(int bottom)
        {
            _bottom = bottom;
        }


        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        public Fraction(int wholeNumber)
        {
            _top= wholeNumber;
            _bottom = 1;
        }

        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        public string GetFractionString()
        {
            return _top.ToString() + "/" + _bottom.ToString();
        }

        public double GetDecimalValue()
        {
            return (double)_top / (double)_bottom;
        }

    }
}
