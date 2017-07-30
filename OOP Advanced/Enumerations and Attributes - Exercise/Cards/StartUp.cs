﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Cards
{
    public class StartUp
    {
        public static void Main()
        {
            //PrintCardSuit();
            //PrintCardRank();
            //PrintCardPower();
            //PrintCardCompareTo();
            PrintAttribute();
        }

        private static void PrintAttribute()
        {
            var input = Console.ReadLine();
            Type type = null;

            if (input=="Rank")
            {
                type = typeof(Rank);
                var attributes = type.GetCustomAttributes(false);
                Console.WriteLine(attributes[0]);
            }
            else
            {
                type = typeof(Suit);
                var attributes = type.GetCustomAttributes(false);
                Console.WriteLine(attributes[0]);
            }
        }

        private static void PrintCardCompareTo()
        {
            var first = ReadCard();
            var second = ReadCard();

            if (first.CompareTo(second)>0)
            {
                Console.WriteLine(first);
            }
            else
            {
                Console.WriteLine(second);
            }
        }

        private static Card ReadCard()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            return new Card(rank, suit);
        }

        private static void PrintCardPower()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            var card = new Card(rank,suit);
            Console.WriteLine(card.ToString());
        }

        private static void PrintCardRank()
        {
            var input = Console.ReadLine();
            Console.WriteLine($"{input}:");

            foreach (var value in Enum.GetValues(typeof(Rank)))
            {
                Console.WriteLine($"Ordinal value: {(int)value}; Name value: {value}");
            }
        }

        public static void PrintCardSuit()
        {
            var input = Console.ReadLine();

            Console.WriteLine($"{input}:");

            foreach (var value in Enum.GetValues(typeof(Suit)))
            {
                Console.WriteLine($"Ordinal value: {(int)value}; Name value: {value}");
            }
        }
    }
}
