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
        private int minAge = 5;
        private int maxAge = 10;
        private int countLifes = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void StartGame()
        {
            if (timer1.Enabled)
                return;
            
            countLifes = 0;
            currentGeneration = 0;

            Text = $"Generation {currentGeneration}";
            SetStatusControls(false);         

            resolution = (int)nudResolution.Value;

            minAge = (int)nudMinAge.Value;
            maxAge = (int)nudMaxAge.Value;

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
                    if (field[x, y]) countLifes++;
                    fieldColor[x, y] = PickBrush(9);
                    lifeTime[x, y] = GetNewLifeTime();
                }
            }

            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);

            timer1.Start();
        }

        private void SetStatusControls(bool status)
        {
            nudResolution.Enabled = status;
            nudDensity.Enabled = status;
            checkBoxDiesByAge.Enabled = status;
            nudMinAge.Enabled = status && checkBoxDiesByAge.Checked;
            nudMaxAge.Enabled = status && checkBoxDiesByAge.Checked;
        }

        private int GetNewLifeTime()
        {
            Random random = new Random();
            return random.Next(minAge, maxAge);
        }

        private Brush PickBrush(int i)
        {
            if (i > 9) i = 9;
            if (i < 0) i = 0;
            Brush[] brushes = new Brush[] {
                Brushes.DarkViolet,
                Brushes.Violet,
                Brushes.Red,
                Brushes.Orange,
                Brushes.Yellow,
                Brushes.LightYellow,
                Brushes.Green,
                Brushes.LightGreen,
                Brushes.Blue,
                Brushes.LightBlue
                };

            return brushes[i];
        }

        private void NextGeneration()
        {
            countLifes = 0;
            graphics.Clear(Color.Black);

            var newField = new bool[cols, rows];
            var newFieldColor = new Brush[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighboursCount = CountNeighbours(x, y);
                    var hasLife = field[x, y];
                    // birth of a new life
                    if (!hasLife && neighboursCount == 3)
                    {
                        newField[x, y] = true;
                        newFieldColor[x, y] = PickBrush(9);
                        lifeTime[x, y] = GetNewLifeTime();
                    }
                    // life dies
                    else if (hasLife && (neighboursCount < 2 || neighboursCount > 3))
                    {
                        newField[x, y] = false;
                        newFieldColor[x, y] = PickBrush(0);
                        lifeTime[x, y] = 0;
                    }
                    // life continues to live
                    else
                    {
                        newField[x, y] = field[x, y];
                        // life dies by age
                        if (--lifeTime[x, y] <= 0)
                        {
                            if (checkBoxDiesByAge.Checked)
                            {
                                newField[x, y] = false;
                                newFieldColor[x, y] = PickBrush(0);
                            }
                            lifeTime[x, y] = 0;
                        }
                        newFieldColor[x, y] = PickBrush(lifeTime[x, y]);                
                    }

                    if (hasLife)
                    {
                        countLifes++;
                        graphics.FillRectangle(fieldColor[x, y], x * resolution, y * resolution, resolution, resolution);
                    };
                }
            }

            field = newField;
            fieldColor = newFieldColor;

            pictureBox.Refresh();
            ShowStatistic();
        }

        private void ShowStatistic()
        {
            Text = $"Generation {++currentGeneration}, Lifes {countLifes}";

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
            SetStatusControls(true);
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
            ShowStatistic();
        }

        private void checkBoxDiesByAge_CheckedChanged(object sender, EventArgs e)
        {
            nudMinAge.Enabled = checkBoxDiesByAge.Checked;
            nudMaxAge.Enabled = checkBoxDiesByAge.Checked;
        }
    }
}
