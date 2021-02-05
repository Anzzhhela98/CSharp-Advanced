
namespace P03_JediGalaxy
{
    public class Matrix
    {
        private int starValue = 0;
        public Matrix(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.MatrixTemplate = new int[row, col];
            this.Initialize();
        }

        public int Row { get; private set; }
        public int Col { get; private set; }
        public int[,] MatrixTemplate { get; set; }

        public void Initialize()
        {
            for (int row = 0; row < this.MatrixTemplate.GetLength(0); row++)
            {
                for (int i = 0; i < this.MatrixTemplate.GetLength(1); i++)
                {
                    this.MatrixTemplate[row, i] = starValue++;
                }
            }
        }
    }
}
