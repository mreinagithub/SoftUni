﻿

namespace TrifonsQuest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hero
    {
        public long Health { get; set; }
        public long Turns { get; set; }
        public Cell Position { get; set; }
    }

    public class Cell
    {
        public long row { get; set; }
        public long col { get; set; }
    }

    public class Start
    {
        static void Main()
        {
            Cell startCell = new Cell() { row = 0, col = 0 };
            long health = ReadHealth();

            Hero trifon = new Hero()
            {
                Health = health,
                Turns = 0,
                Position = startCell
            };

            char[,] matrix = ReadMatrix();
            bool success = true;
            while (true)
            {
                bool isAlive = CurrentCellAction(matrix,trifon);
                if (!isAlive)
                {
                    trifon.Turns++;
                    success = false;
                    break;
                }

                trifon.Position = MoveNext(matrix,trifon.Position);
                if (trifon.Position.col == matrix.GetLength(1))
                {
                    trifon.Turns++;
                    success = true;
                    break;
                }
                trifon.Turns++;
            }

            if (success)
            {
                Console.WriteLine("Quest completed!");
                Console.WriteLine($"Health: {trifon.Health}");
                Console.WriteLine($"Turns: {trifon.Turns}");
            }
            else
            {
                Console.WriteLine($"Died at: [{trifon.Position.row}, {trifon.Position.col}]");
            }
        }

        private static bool CurrentCellAction(char[,] matrix, Hero trifon)
        {
            bool isAlive = true;
            long row = trifon.Position.row;
            long col = trifon.Position.col;
            char obstacle = matrix[row,col];

            if (obstacle == 'F')
            {
                long lostHealth = trifon.Turns / 2;
                trifon.Health = Math.Max(trifon.Health - lostHealth,0);
                if (trifon.Health==0)
                {
                    isAlive = false;
                }
            }
            else if (obstacle == 'H')
            {
                long restoredHealth = trifon.Turns / 3;
                trifon.Health = trifon.Health + restoredHealth;
            }
            else if (obstacle == 'T')
            {
                trifon.Turns += 2;
            }
            else if (obstacle == 'E')
            {
                //nothing happens
            }
            return isAlive;
        }

        private static Cell MoveNext(char[,] matrix, Cell position)
        {
            Cell nextCell = new Cell();

            if (position.col%2 !=0)
            {
                nextCell = MoveUp(matrix, position);
            }
            else
            {
                nextCell = MoveDown(matrix, position);
            }
            return nextCell;
        }

        private static Cell MoveUp(char[,] matrix, Cell position)
        {
            long row = position.row;
            long rows = matrix.GetLength(0);
            long col = position.col;
            long cols = matrix.GetLength(1);
            Cell nextCell = new Cell();

            if (row == 0)
            {
                col++;
            }
            else
            {
                row--;
            }
            nextCell.row = row;
            nextCell.col = col;
            return nextCell;
        }

        private static Cell MoveDown(char[,] matrix, Cell position)
        {
            long row = position.row;
            long rows = matrix.GetLength(0);
            long col = position.col;
            long cols = matrix.GetLength(1);
            Cell nextCell = new Cell();

            if (row == rows-1)
            {
                col++;
            }
            else
            {
                row++;
            }
            nextCell.row = row;
            nextCell.col = col;
            return nextCell;
        }

        private static long ReadHealth()
        {
            return long.Parse(Console.ReadLine());
        }

        private static char[,] ReadMatrix()
        {
            long[] args = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long rows = args[0];
            long cols = args[1];
            char[,] matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            return matrix;
        }
    }
}
