using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameStatistic.CardGame
{
    public class Karta
    {
        public string Mast { get; set; }
        public string Value { get; set; }
        public Karta(string Mast, string Value) 
        {
            this.Mast = Mast;
            this.Value = Value;
        }
        public int CompareTo(Karta other)
        {

            if (this.Value == "Туз" && other.Value != "Туз")
                return 1;
            if (this.Value != "Туз" && other.Value == "Туз")
                return -1;

            int thisValue = ParseCardValue(this.Value);
            int otherValue = ParseCardValue(other.Value);

  
            return thisValue.CompareTo(otherValue);
        }

        private int ParseCardValue(string Value)
        {
            switch (Value)
            {
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "Валет":
                    return 11;
                case "Дама":
                    return 12;
                case "Король":
                    return 13;
                case "Туз":
                    return 14;
                default:
                    throw new ArgumentException("Неверное значение карты.");
            }
        }
    }
}
