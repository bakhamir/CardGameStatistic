using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameStatistic.CardGame
{
    public class Player
    {
        public List<Karta> kartas { get; set; }
        public List<Karta> kartiNaStole { get; set; }
        public void AddCardToHand(Karta karta)
        {
            kartas.Add(karta);
        }
    }
}
