using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper
{
    class SapperGame
    {
        public int[,] Area { get; private set; }
        public int N { get; private set; }
        public int MinesCount { get; private set; }
        public bool IsEnd { get; set; }
        public SapperGame()
        {
            N = 10;
            MinesCount = 10;
            Area = new int[N, N];
            IsEnd = false;
            GenerateArea();
        }
        public SapperGame(int N, int MinesCount)
        {
            this.N = Math.Abs(N);
            this.MinesCount = Math.Abs(MinesCount);
            IsEnd = false;
            if (MinesCount >= N * N)
            {
                this.MinesCount = N;
            }
            Area = new int[N, N];
            GenerateArea();
        }
        private void GenerateArea()
        {
            Random random = new Random();
            for (int i = 0; i < MinesCount;)
            {
                int x = random.Next(N);
                int y = random.Next(N);
                if (Area[x, y] < 10)
                {
                    Area[x, y] = 50;
                    i++;

                    if (x > 0) Area[x - 1, y]++;
                    if (x < N - 1) Area[x + 1, y]++;

                    if (x > 0 && y > 0) Area[x - 1, y - 1]++;
                    if (y > 0 && x < N - 1) Area[x + 1, y - 1]++;
                    if (y > 0) Area[x, y - 1]++;

                    if (x > 0 && y < N - 1) Area[x - 1, y + 1]++;
                    if (x < N - 1 && y < N - 1) Area[x + 1, y + 1]++;
                    if (y < N - 1) Area[x, y + 1]++;
                }
            }
        }
    }
}
