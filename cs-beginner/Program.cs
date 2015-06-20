using System;

namespace cs_beginner
{
    enum Color
    {
        Blank = 0,
        Black = 1,
        White = -1
    };
    class Program
    {
        private static void Main(string[] args)
        {
            /*******コンソール五目並べを作ってみよう********/
            Console.WriteLine("8×8の五目並べを始めます。");
            Console.WriteLine("黒番から始めます。");
            Color[][] board = new Color[8][]; // ゲームボードの生成。
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new Color[8];
            }
            Reset(ref board); // ゲームボードの初期化。
            Color turn = Color.Black; // 先行は黒手である。
            int put = 0; //石が何個置かれたかのカウント
            while (!IsGameOver(board))
            {
                Print(board); // ゲームボードの表示。
                switch (turn)
                {
                    case Color.Black: // 黒番  
                        Console.WriteLine("黒番です。");
                        break;
                    case Color.White: // 白番。
                        Console.WriteLine("白番です。");
                        break;
                }
                while (true)
                {
                    try
                    {
                        Console.Write("行 --->");
                        int i = int.Parse(Console.ReadLine()) - 1;
                        Console.Write("列 --->");
                        int j = int.Parse(Console.ReadLine()) - 1;
                        if (board[i][j] == Color.Blank)
                        {
                            board[i][j] = turn;
                        }
                        else
                        {
                            Console.WriteLine("すでに他の石が置かれています");
                            continue;
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error");
                    }
                }
                turn = (Color)(-(int)turn); 　　// 手番の交代。
            }
        }
        private static void Print(Color[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == Color.Blank)
                    {
                        Console.Write("- ");
                    }
                    else if (board[i][j] == Color.White)
                    {
                        Console.Write("○");
                    }
                    else
                    {
                        Console.Write("×");
                    }
                }
                Console.WriteLine();
            }
        }
        private static void Reset(ref Color[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] = Color.Blank;
                }
            }
        }
        private static bool IsGameOver(Color[][] board)
        {
            int[] X = { 1, 1, 1, 0 };
            int[] Y = { 1, -1, 0, 1 };
            int count = 0;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != Color.Blank) // 全ての置かれているマスにおいて
                    {
                        count++;
                        Color color = board[i][j]; //　i行j列の色を保持
                        for (int k = 0; k < 4; k++) // 4方向走査
                        {
                            for (int l = 1; ; l++)
                            {
                                int myi = i + l * X[k];
                                int myj = j + l * Y[k];
                                if (myi >= 0 && myi < board.Length && myj >= 0 && myj < board[0].Length) // マスの範疇である
                                {
                                    if (board[myi][myj] != color) break; //　同じ色でない
                                }
                                else break;
                                if (l == 4) //4歩先まで進めた場合
                                {
                                    if (color == Color.Black) Console.WriteLine("黒手の勝ちです。");
                                    if (color == Color.White) Console.WriteLine("白手の勝ちです。");
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            if (count == board.Length * board[0].Length) // 全マス置かれた
            {
                Console.WriteLine("引き分けです。");
                return true;
            }
            return false;
        }
    }
}