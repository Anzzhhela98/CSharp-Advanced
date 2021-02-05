using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class Player
    {
        public Player(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }

        public void  CollectStarsToTopRighttDiagonal()
        {
            this.Row--;
            this.Col++;
        }

        public void MakeZerosToTopLefDiagonal()
        {
            this.Row--;
            this.Col--;
        }
    }
}
