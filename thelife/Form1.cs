using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace thelife
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int currentGeneration = 0;
        private int resolution;
        private bool[,] field;
        private Brush[,] fieldColor;
        private int[,] lifeTime;
        private int rows;
        private int cols;
        private const int minAge = 5;
        private const int maxAge = 25;

        public Form1()
        {
            InitializeComponent();
        }
        private void StartGame()
        {
            if (timer1.Enabled)
                return;

            currentGeneration = 0;
            Text = $"Generation {currentGeneration}";
            nudResolution.Enabled = false;
            nudDensity.Enabled = false;

            resolution = (int)nudResolution.Value;

            rows = pictureBox.Height / resolution;
            cols = pictureBox.Width / resolution;
            field = new bool[cols, rows];
            fieldColor = new Brush[cols, rows];
            lifeTime = new int[cols, rows];
            Random random = new Random();

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next((int)nudDensity.Value) == 0;
                    fieldColor[x, y] = Brushes.Green;
                    lifeTime[x, y] = getNewLifeTime();
                }
            }

            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);

            timer1.Start();
        }

        private int getNewLifeTime()
        {
            Random random = new Random();
            return random.Next(minAge, maxAge);
        }

        private Brush PickBrush()
        {
            Brush[] brushes = new Brush[] {
                Brushes.Red,
                Brushes.Green,
                Brushes.Blue
                };

            Random rnd = new Random();

            return brushes[rnd.Next(brushes.Length)];
        }

        private void NextGeneration()
        {
            graphics.Clear(Color.Black);

            var newField = new bool[cols, rows];
            var newFieldColor = new Brush[cols, rows];


            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighboursCount = CountNeighbours(x, y);
                    var hasLife = field[x, y];

                    if (!hasLife && neighboursCount == 3)
                    {
                        newField[x, y] = true;
                        newFieldColor[x, y] = Brushes.Green;
                        lifeTime[x, y] = getNewLifeTime();
                    }
                    else if (hasLife && (neighboursCount < 2 || neighboursCount > 3))
                    {
                        newField[x, y] = false;
                        newFieldColor[x, y] = Brushes.Gray;
                        lifeTime[x, y] = 0;
                    }
                    else
                    {
                        newField[x, y] = field[x, y];

                        if (--lifeTime[x, y] <= 0)
                        {
                            newField[x, y] = false;
                            newFieldColor[x, y] = Brushes.Gray;
                            lifeTime[x, y] = 0;
                        }
                        if (fieldColor[x, y] == Brushes.Green)
                        {
                            newFieldColor[x, y] = Brushes.Yellow;
                        }
                        else if (fieldColor[x, y] == Brushes.Yellow)
                        {
                            newFieldColor[x, y] = Brushes.Blue;
                        }
                        else
                        {
                            newFieldColor[x, y] = Brushes.Red;
                        }
                    }

                    if (hasLife)
                    {
                        graphics.FillRectangle(fieldColor[x, y], x * resolution, y * resolution, resolution, resolution);
                    };
                }
            }

            field = newField;
            fieldColor = newFieldColor;

            pictureBox.Refresh();
            Text = $"Generation {++currentGeneration}";

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

        private bool isThereLife()
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (field[x,y]) { return true; }
                }
            }

            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isThereLife()) 
            {
                NextGeneration();
            }
            else
            {
                Text = $"Generation {currentGeneration} - a Life is DEAD!";
                StopGame();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;

            timer1.Stop();
            nudResolution.Enabled = true;
            nudDensity.Enabled = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
                return;

            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validationPassed = ValidateMousePosition(x, y);
                if (validationPassed)
                {
                    field[x, y] = true;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validationPassed = ValidateMousePosition(x, y);
                if (validationPassed)
                    field[x, y] = false;
            }
        }

        private bool ValidateMousePosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"Generation {currentGeneration}";
        }
    }
}
