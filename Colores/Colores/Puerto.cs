using System;

namespace Colores
{
    public class Puerto
    {
        private string number;

        public string _Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string com
        {
            get;

            set;

        }

        public Puerto(String Number)
        {
            this._Number = Number;
        }

        public Puerto()
        {

        }
    }
}
