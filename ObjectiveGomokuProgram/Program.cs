using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveGomokuProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Gomokunarabe();
            Console.WriteLine("五目並べを始めます。");
            Print(game);
            while (game.Condition==Condition.Default)
            {
                switch (game.Turn)
                {
                    case Color.Black:
                        Console.WriteLine("黒番です。");
                        break;
                    case Color.White:
                        Console.WriteLine("白番です。");
                        break;
                }
                try
                {
                    Console.Write("行 --->");
                    int i = int.Parse(Console.ReadLine());
                    Console.Write("列 --->");
                    int j = int.Parse(Console.ReadLine());
                    game.Put(i, j);
                }
                catch (Exception) {
                    Console.WriteLine("無効な入力です。");
                    continue; }
                Print(game);
            }
            switch (game.Condition)
            {
                case Condition.Black:
                    Console.WriteLine("黒手の勝ちです。");
                    break;
                case Condition.White:
                    Console.WriteLine("白手の勝ちです。");
                    break;
                case Condition.Draw:
                    Console.WriteLine("引き分けです。");
                    break;
            }
            Console.WriteLine("何かキーを入力してください...");
            Console.ReadLine();
            Main(new string[0]);
        }

        private static void Print(Gomokunarabe game)
        {
            for (int i = 0; i < game.Board.Length; i++)
            {
                for (int j = 0; j < game.Board[i].Length; j++)
                {
                    switch (game.Board[i][j])
                    {
                        case Color.Empty:
                            Console.Write("‐");
                            break;
                        case Color.Black:
                            Console.Write("×");
                            break;
                        case Color.White:
                            Console.Write("○");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
