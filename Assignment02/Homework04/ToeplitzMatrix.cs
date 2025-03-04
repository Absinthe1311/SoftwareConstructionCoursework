namespace Homework4
{
    internal class ToeplitzMatrix
    {
        static bool IsToeplitzMatrix(int[][] matirx)
        {
            int row = matirx.Length;  // 行
            int col = matirx[0].Length; // 列
            for(int i = 0; i < row; i++)
            {
                int value = matirx[i][0];
                for (int j = 1; j < col && i + j < row; j++)
                {
                    if (matirx[i + j][j] != value)
                    {
                        return false;
                    }
                }
            }
            for(int i = 0; i < col; i++)
            {
                int value = matirx[0][i];
                for (int j = 1; j < row && i + j < col; j++)
                {
                    if (matirx[j][i + j] != value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[][] matirx = {                 
                new int[] {1, 2, 3, 4},
                new int[] {5, 1, 2, 3},
                new int[] {9, 5, 1, 2}
            };
            Console.WriteLine(IsToeplitzMatrix(matirx));
        }
    }
}
