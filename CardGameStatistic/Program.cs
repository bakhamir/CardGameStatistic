using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameStatistic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //карточная игра:
            CardGame.Game game = new CardGame.Game(2);
            game.GameOn();
            //статистика слов в тексте
            Statictics.Statistics.Stats();
        }
        
    }
}
