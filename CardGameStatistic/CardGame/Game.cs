using System.Collections.Generic;
using System;

namespace CardGameStatistic.CardGame
{
    public class Game
    {
        public int kolichestvoIgrokov { get; private set; }
        public List<Player> players { get; private set; }

        public Game(int kolichestvoIgrokov)
        {
            this.kolichestvoIgrokov = kolichestvoIgrokov;
            players = new List<Player>();
            for (int i = 0; i < kolichestvoIgrokov; i++)
            {
                players.Add(new Player());
            }
        }

        public List<Karta> Deck()
        {
            List<Karta> deka = new List<Karta>();
            string[] masty = { "Черви", "Бубны", "Крести", "Пики" };
            string[] tipy = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
            foreach (var mast in masty)
            {
                foreach (string val in tipy)
                {
                    deka.Add(new Karta(mast, val));
                }
            }
            return deka;
        }

        public void TossCards(List<Karta> deka)
        {
            Random random = new Random();
            int n = deka.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Karta value = deka[k];
                deka[k] = deka[n];
                deka[n] = value;
            }
        }

        public void RazdatKarty(List<Karta> deka)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("Ошибка: отсутствуют игроки.");
                return;
            }

            int currentPlayerIndex = 0;
            foreach (var karta in deka)
            {
                if (players[currentPlayerIndex].kartas == null)
                {
                    players[currentPlayerIndex].kartas = new List<Karta>();
                }

                players[currentPlayerIndex].kartas.Add(karta);
                currentPlayerIndex = (currentPlayerIndex + 1) % kolichestvoIgrokov;
            }
        }

        public void DetermineRoundWinner()
        {
            Karta winningCard = players[0].kartas[0];
            int winningPlayerIndex = 0;

            for (int i = 1; i < kolichestvoIgrokov; i++)
            {
                if (players[i].kartas == null || players[i].kartas.Count == 0)
                {
                    Console.WriteLine($"Ошибка: игрок {i + 1} не имеет карт.");
                    return;
                }

                Karta currentCard = players[i].kartas[0];
                if (currentCard.CompareTo(winningCard) > 0)
                {
                    winningCard = currentCard;
                    winningPlayerIndex = i;
                }
            }

            if (winningPlayerIndex >= 0 && winningPlayerIndex < players.Count)
            {
                Console.WriteLine($"Игрок {winningPlayerIndex + 1} выигрывает раунд!");
                foreach (var player in players)
                {
                    if (player.kartiNaStole == null)
                    {
                        player.kartiNaStole = new List<Karta>();
                    }

                    player.kartiNaStole.Add(player.kartas[0]);
                    player.kartas.RemoveAt(0);
                }
                if (winningPlayerIndex >= 0 && winningPlayerIndex < players.Count)
                {
                    if (players[winningPlayerIndex].kartas != null && players[winningPlayerIndex].kartiNaStole != null)
                    {
                        players[winningPlayerIndex].kartas.AddRange(players[winningPlayerIndex].kartiNaStole);
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: невозможно добавить карты игрока {winningPlayerIndex + 1}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Ошибка: неверный индекс победителя раунда.");
                }

                foreach (var player in players)
                {
                    if (player.kartiNaStole != null)
                    {
                        player.kartiNaStole.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Ошибка: неверный индекс победителя раунда.");
            }
        }

        public bool GameOver()
        {
            foreach (var player in players)
            {
                if (player.kartas.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void GameOn()
        {
            List<Karta> kartas = Deck();
            TossCards(kartas);
            RazdatKarty(kartas);

            Console.WriteLine("Игра начинается!");

            while (!GameOver())
            {
                Console.WriteLine("Новый раунд:");
                DetermineRoundWinner();
                ShowGameStatus();
            }

            ShowGameWinner();
        }

        private void ShowGameStatus()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"Игрок {i + 1} имеет {players[i].kartas.Count} карт.");
            }
            Console.WriteLine("-------------------");
        }

        private void ShowGameWinner()
        {
            Player winner = players[0];
            for (int i = 1; i < kolichestvoIgrokov; i++)
            {
                if (players[i].kartas.Count > winner.kartas.Count)
                {
                    winner = players[i];
                }
            }

            Console.WriteLine($"Победил игрок {players.IndexOf(winner) + 1}!");
        }
    }
}
