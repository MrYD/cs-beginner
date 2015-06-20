using System;

namespace ObjectiveGomokuProgram
{
    enum Color
    {
        Empty = 0,
        Black = 1,
        White = -1
    };

    enum Condition
    {
        Default,
        Black,
        White,
        Draw
    }


    class Gomokunarabe
    {
        //コンストラクタ
        public Gomokunarabe()
        {
            Board = new Color[8][];
            for (var i = 0; i < Board.Length; i++)
            {
                Board[i] = new Color[8];
            }
            Reset();
            Turn = Color.Black;
        }
        //フィールド
        public Color[][] Board;
        public Color Turn;
        public Condition Condition
        {
            get
            {
                int[] xs = { 1, 1, 1, 0 };
                int[] ys = { 1, -1, 0, 1 };
                var count = 0;
                for (var i = 0; i < Board.Length; i++)
                {
                    for (var j = 0; j < Board[i].Length; j++)
                    {
                        if (Board[i][j] == Color.Empty) continue;
                        count++;
                        var color = Board[i][j]; //　i行j列の色を保持
                        for (var k = 0; k < 4; k++) // 4方向走査
                        {
                            for (var l = 1; ; l++)
                            {
                                var myi = i + l * xs[k];
                                var myj = j + l * ys[k];
                                if (myi >= 0 && myi < Board.Length && myj >= 0 && myj < Board[0].Length) // マスの範疇である
                                {
                                    if (Board[myi][myj] != color) break; //　同じ色でない
                                }
                                else break;
                                if (l != 4) continue;
                                switch (color)
                                {
                                    case Color.Black:
                                        return Condition.Black;
                                    case Color.White:
                                        return Condition.White;
                                }
                            }
                        }
                    }
                }
                return count == Board.Length * Board[0].Length ? Condition.Draw : Condition.Default;
            }
        }

        //メソッド
        public void Reset()
        {
            for (var i = 0; i < Board.Length; i++)
            {
                for (var j = 0; j < Board[i].Length; j++)
                {
                    Board[i][j] = Color.Empty;
                }
            }
        }

        public void Put(int x, int y)
        {

            if (Board[x - 1][y - 1] == Color.Empty)
                Board[x - 1][y - 1] = Turn;
            else
            {
                throw new Exception();
            }
            ChangeTurn();
        }

        private void ChangeTurn()
        {
            Turn = (Color)(-(int)Turn);
        }
    }
}
