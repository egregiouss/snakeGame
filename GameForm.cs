using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameForm : Form
    {
        public PictureBox fruit;
        public Label scorebox;
        public int currScore;
        public const int WIDTH = 700;
        public const int HEIGHT = 600;
        public const int SIDE_SIZE = 30;
        public int dirX = 1;
        public int dirY = 0;
        public int speed = 100;

        public PictureBox[] snake = new PictureBox[400];
        public GameForm()
        {
            InitializeComponent();
            snake[0] = player;
            snake[0].Location = new Point(1, 1);
            snake[0].Size = new Size(SIDE_SIZE-1,SIDE_SIZE-1);
            label1.Location = new Point(650, 5);
            this.Width = 700;
            this.Height = 700;
            GenerateMap();
            scorebox = new Label();
            scorebox.Text = "Score: 0";
            scorebox.Location = new Point(HEIGHT, 3*SIDE_SIZE);
            this.Controls.Add(scorebox);
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(SIDE_SIZE, SIDE_SIZE);
            GenerateFruit();
            timer.Tick += new EventHandler(Update);
            timer.Interval = speed;
            timer.Start();
            timer1.Tick += new EventHandler(CheckBorders);
            timer1.Interval = 20;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OnKeyPressed);           
        }
   
        private void GenerateFruit()
        {
            int fX, fY;
            Random rnd = new Random();
            var rand = rnd.Next(HEIGHT);
            var tmp = rand % SIDE_SIZE;
            fX = rand - tmp;
            var rand2 = rnd.Next(HEIGHT);
            var tmp2 = rand2 % SIDE_SIZE;
            fY = rand2 - tmp2;
            fruit.Location = new Point(fX+1, fY+1); 
            this.Controls.Add(fruit);
        }
        private new void Move()
        {
     
                for (int i = currScore; i >= 1; i--)
                {
                    snake[i].Location = snake[i - 1].Location;
                }
                snake[0].Location = new Point(player.Location.X + dirX * SIDE_SIZE, player.Location.Y + dirY * SIDE_SIZE);
            EatMyself();
        }

        private void CheckBorders(object myObject, EventArgs eventArgs)
        {
            if (player.Location.X >= HEIGHT)
            {
                player.Location = new Point(1, 1);
                dirX = 1;
                dirY = 0;
            }
            if (player.Location.Y >= HEIGHT)
            {
                player.Location = new Point(1, 1);
                dirX = 1;
                dirY = 0;
            }
            if (player.Location.X < 0)
            {
                player.Location = new Point(1, 1);
                dirX = 1;
                dirY = 0;
            }
            if (player.Location.Y < 0)
            {
                player.Location = new Point(1, 1);
                dirX = 1;
                dirY = 0;
            }
        }
        private void Update(object myObject, EventArgs eventArgs)
        {
            Move();
            EatFruit();

        }
        private void EatMyself()
        {
            for (int i = 1; i <=currScore; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    timer.Stop();
                    timer1.Stop();
                    MessageBox.Show("You lose");
                    for (int j = 1; j <= currScore; j++)
                    {
                        this.Controls.Remove(snake[j]);
                    }
                    RestartGame();
                }
            }
        }

        private void RestartGame()
        {
            currScore = 0;
            snake[0].Location = new Point(1, 1);
            dirX = 1;
            dirY = 0;
            timer.Start();
            timer1.Start();
        }

        private void EatFruit()
        {
            if (snake[0].Location == fruit.Location)
            {
                scorebox.Text = "Score:"+ ++currScore;
                snake[currScore] = new PictureBox();
                snake[currScore].Location = new Point(snake[currScore - 1].Location.X - dirX * SIDE_SIZE, snake[currScore - 1].Location.Y - dirY * SIDE_SIZE);
                snake[currScore].BackColor = Color.Red; 
                snake[currScore].Size = new Size(SIDE_SIZE-1, SIDE_SIZE-1);
                this.Controls.Add(snake[currScore]);
                this.Controls.Remove(fruit);
                GenerateFruit();
            }
        }

        private void GenerateMap()
        {
            for (var i = 0; i<=HEIGHT/SIDE_SIZE; i++)
            {
                PictureBox el = new PictureBox();
                el.BackColor = Color.LightGray;
                el.Location = new Point(0, i * SIDE_SIZE);
                el.Size = new Size(WIDTH-100, 1);
                this.Controls.Add(el);
            }

            for (var i = 0; i <= HEIGHT/ SIDE_SIZE; i++)
            {
                PictureBox el = new PictureBox();
                el.BackColor = Color.LightGray;
                el.Location = new Point(i * SIDE_SIZE, 0);
                el.Size = new Size(1, HEIGHT);
                this.Controls.Add(el);
            }
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
    
            switch (e.KeyCode.ToString())
            {
                case "D":
                    if (dirX != -1)
                    {
                        dirX = 1;
                        dirY = 0;
                    }
                    break;
                case "A":
                    if (dirX != 1)
                    {
                        dirX = -1;
                        dirY = 0;
                    }
                    break;
                case "S":
                    if (dirY != -1)
                    {
                        dirX = 0;
                        dirY = 1;
                    }
                    break;
                case "W":
                    if (dirY != 1)
                    {
                        dirX = 0;
                        dirY = -1;
                    }
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            {
                Application.Exit();
            }
        }
    }
}
