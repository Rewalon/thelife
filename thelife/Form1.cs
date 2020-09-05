using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace thelife
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int resolution;
        private GameEngine gameEngine;

        public Form1()
        {
            InitializeComponent();
        }
        private void StartGame()
        {
            if (timer1.Enabled)
                return;

            SetStatusControls(false);

            resolution = (int)nudResolution.Value;

            if (checkBoxDiesByAge.Checked)
            {
                gameEngine = new GameEngine
                (
                    rows: pictureBox.Height / resolution,
                    cols: pictureBox.Width / resolution,
                    density: /*(int)(nudResolution.Minimum) + (int)(nudResolution.Maximum) -*/ (int)(nudResolution.Value),
                    minAge: (int)nudMinAge.Value,
                    maxAge: (int)nudMaxAge.Value
                );

            }
            else
            {
                gameEngine = new GameEngine
                (
                    rows: pictureBox.Height / resolution,
                    cols: pictureBox.Width / resolution,
                    density: /*(int)(nudResolution.Minimum) + (int)(nudResolution.Maximum) -*/ (int)(nudResolution.Value)
                );

            }

            Text = $"Generation {gameEngine.CurrentGeneration}";
            
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);
            timer1.Start();
        }

        private void SetStatusControls(bool status)
        {
            nudResolution.Enabled = status;
            nudDensity.Enabled = status;
            nudMinAge.Enabled = status;
            nudMaxAge.Enabled = status;
        }

        private void DrawNextGeneration()
        {
            graphics.Clear(Color.Black);
            var field = gameEngine.GetCurrentGeneration();
            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[x,y])
                        graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution - 1, resolution - 1);
                }
            }
            pictureBox.Refresh();
            Text = $"Generation {gameEngine.CurrentGeneration}";
            gameEngine.NextGeneration();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawNextGeneration();
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
                gameEngine.AddCell(x, y);
            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                gameEngine.RemoveCell(x, y);
            }
        }
    }
}
