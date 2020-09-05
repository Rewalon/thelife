using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thelife
{
    public class GameEngine
    {
        public uint CurrentGeneration { get; private set; }
        private readonly int rows;
        private readonly int cols;
        private readonly int minAge;
        private readonly int maxAge;
        private readonly bool useLifeAge;
        private bool[,] field;
        private int[,] lifeTime;
        private int[,] ageLife;

        public GameEngine(int cols, int rows, int density) : this(cols, rows, density, 0, 0) { } 

        public GameEngine( int cols, int rows, int density, int minAge, int maxAge)
        {
            this.cols = cols;
            this.rows = rows;
            this.minAge = minAge;
            this.maxAge = maxAge;
            useLifeAge = !(minAge == 0 && maxAge == 0);
            field = new bool[cols, rows];
            lifeTime = new int[cols, rows];
            ageLife = new int[cols, rows];
            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(density) == 0;
                    ageLife[x, y] = 0;
                    if (field[x, y])
                    {
                        lifeTime[x, y] = getNewLifeTime();
                    }
                    else lifeTime[x, y] = 0;
                }
            }
        }

        private int getNewLifeTime()
        {
            Random random = new Random();
            return random.Next(minAge, maxAge);
        }

        public void NextGeneration()
        {
            var newField = new bool[cols, rows];
            
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighboursCount = CountNeighbours(x, y);
                    var hasLife = field[x, y];

                    if (!hasLife && neighboursCount == 3)
                    {
                        newField[x, y] = true;
                        lifeTime[x, y] = getNewLifeTime();
                        ageLife[x, y] = 0;
                    }
                    else if (hasLife && (neighboursCount < 2 || neighboursCount > 3))
                    {
                        newField[x, y] = false;
                    }
                    else
                    {
                        newField[x, y] = field[x, y];
                        if (useLifeAge)
                        {
                            if(++ageLife[x,y] > lifeTime[x, y])
                            {
                                newField[x, y] = false;
                            }
                        }
                    }
                }
            }
            field = newField;
            CurrentGeneration++;
        }

        public bool[,] GetCurrentGeneration()
        {
            var result = new bool[cols, rows];
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    result[x, y] = field[x, y];
                }
            }
            return result;
        }
        private int CountNeighbours(int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var col = (x + i + cols) % cols;
                    var row = (y + j + rows) % rows;
                    var isSelfCheking = col == x && row == y;
                    var hasLife = field[col, row];
                    if (hasLife && !isSelfCheking)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private bool ValidateCellPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }

        private void UpdateCell(int x, int y, bool state)
        {
            if (ValidateCellPosition(x, y))
                field[x, y] = state;
        }

        public void AddCell(int x, int y)
        {
            UpdateCell(x, y, state: true);
        }

        public void RemoveCell(int x, int y)
        {
            UpdateCell(x, y, state: false);
        }

    }
}
