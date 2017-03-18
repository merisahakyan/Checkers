using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Checkers : Form
    {

        public Checkers()
        {
            InitializeComponent();

            ClientSize = new Size(800, 400);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackgroundImage = ((System.Drawing.Image)(Properties.Resources.startcover));
            startCombo.Items.Add("Hillary Clinton");
            startCombo.Items.Add("Donald Trump");
            startCombo.Text = "Hillary Clinton";
        }
        void RemoveButtons(Button[,] buttons)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.Controls.Remove(buttons[i, j]);
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            BackgroundImage = ((System.Drawing.Image)(Properties.Resources.gamecover1));
            //ClientSize = new Size(800, 400);
            char turn;
            if (startCombo.SelectedIndex == 1)
                turn = 't';
            else
                turn = 'c';

            button1.Hide();
            startCombo.Hide();
            choosestart.Hide();
            Button[,] buttons = new Button[8, 8];
            int[] point = new int[2];
            char prev = 'n', cur = 'n';

            GameBoard gameboard = new GameBoard();
            Player clintons = new Player();
            Player trumps = new Player();
            int previ = 0, prevj = 0;
            int curi, curj;
            byte count1, count2;


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Height = 50;
                    button.Width = 50;
                    button.Location = new Point(200 + 50 * i, 50 * j);
                    if ((i + j) % 2 == 1)
                    {
                        button.BackColor = Color.Black;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderColor = Color.Black;
                        if (j < 3)
                        {
                            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                        }
                        else if (j > 4 && j < 8)
                        {
                            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                        }
                        else
                        {
                            button.BackgroundImage = null;
                        }
                    }

                    if ((i + j) % 2 == 1)
                    {
                        button.Click += (s, ea) =>
                        {

                            curi = (button.Location.X - 200) / 50;
                            curj = button.Location.Y / 50;

                            switch (gameboard[curi, curj])
                            {
                                case 2: cur = 't'; break;
                                case 20: cur = 't'; break;
                                case 1: cur = 'c'; break;
                                case 10: cur = 'c'; break;
                                case 0: cur = 'n'; break;
                            }

                            //Trump's step
                            if (turn == 't' && trumps.Step(turn, prev, cur, curi, curj, previ, prevj) && gameboard[previ, prevj] == 2)
                            {
                                point = trumps.Huff<GameBoard>(gameboard, 2, 1);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 'c';
                                    buttons[previ, prevj].BackgroundImage = null;

                                    if (curj == 0 && gameboard[previ, prevj] == 2)
                                    {
                                        gameboard[previ, prevj] = 0;
                                        gameboard[curi, curj] = 20;
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                                    }
                                    else
                                    {
                                        gameboard[previ, prevj] = 0;
                                        gameboard[curi, curj] = 2;
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                    }
                                }
                                else
                                {
                                    int x = point[0];
                                    int y = point[1];
                                    turn = 'c';
                                    buttons[x, y].BackgroundImage = null;
                                    gameboard[x, y] = 0;
                                }
                            }

                            //Trump's eat
                            if (prev == 't' && trumps.Eating<GameBoard>(cur, curi, curj, previ, prevj, gameboard, 1) && gameboard[previ, prevj] == 2)
                            {
                                turn = 'c';
                                buttons[previ, prevj].BackgroundImage = null;

                                if (curj == 0 && gameboard[previ, prevj] == 2)
                                {
                                    gameboard[previ, prevj] = 0;
                                    gameboard[curi, curj] = 20;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                                }
                                else
                                {
                                    gameboard[previ, prevj] = 0;
                                    gameboard[curi, curj] = 2;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                }
                                gameboard[(previ + curi) / 2, (prevj + curj) / 2] = 0;
                                buttons[(previ + curi) / 2, (prevj + curj) / 2].BackgroundImage = null;
                            }

                            //Trump's dama step
                            if (turn == 't' && prev == 't' && cur == 'n' && trumps.Clean<GameBoard>(curi, curj, previ, prevj, gameboard) && gameboard[previ, prevj] == 20)
                            {
                                point = trumps.Huff<GameBoard>(gameboard, 2, 1);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 'c';
                                    buttons[previ, prevj].BackgroundImage = null;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                                    gameboard[previ, prevj] = 0;
                                    gameboard[curi, curj] = 20;
                                }
                                else
                                {
                                    int x = point[0];
                                    int y = point[1];
                                    turn = 'c';
                                    buttons[x, y].BackgroundImage = null;
                                    gameboard[x, y] = 0;
                                }
                            }

                            //Trump dama eat
                            if (prev == 't' && cur == 'n' && trumps.CleanEat<GameBoard>(curi, curj, previ, prevj, gameboard, 2, 1) && gameboard[previ, prevj] == 20)
                            {
                                turn = 'c';
                                trumps.RemoveCoin(gameboard, ref buttons);
                                gameboard[previ, prevj] = 0;
                                gameboard[curi, curj] = 20;
                                buttons[previ, prevj].BackgroundImage = null;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                            }

                            //Clinton's step
                            if (turn == 'c' && clintons.Step(turn, prev, cur, curi, curj, previ, prevj) && gameboard[previ, prevj] == 1)
                            {
                                point = clintons.Huff<GameBoard>(gameboard, 1, 2);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 't';
                                    buttons[previ, prevj].BackgroundImage = null;

                                    if (curj == 7 && gameboard[previ, prevj] == 1)
                                    {
                                        gameboard[previ, prevj] = 0;
                                        gameboard[curi, curj] = 10;
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                                    }
                                    else
                                    {
                                        gameboard[previ, prevj] = 0;
                                        gameboard[curi, curj] = 1;
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                    }
                                }
                                else
                                {
                                    int x = point[0];
                                    int y = point[1];
                                    turn = 't';
                                    buttons[x, y].BackgroundImage = null;
                                    gameboard[x, y] = 0;
                                }

                            }

                            //Clintons's eat
                            if (prev == 'c' && clintons.Eating<GameBoard>(cur, curi, curj, previ, prevj, gameboard, 2) && gameboard[previ, prevj] == 1)
                            {
                                turn = 't';
                                buttons[previ, prevj].BackgroundImage = null;

                                if (curj == 7 && gameboard[previ, prevj] == 1)
                                {
                                    gameboard[previ, prevj] = 0;
                                    gameboard[curi, curj] = 10;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                                }
                                else
                                {
                                    gameboard[previ, prevj] = 0;
                                    gameboard[curi, curj] = 1;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                }
                                gameboard[(previ + curi) / 2, (prevj + curj) / 2] = 0;
                                buttons[(previ + curi) / 2, (prevj + curj) / 2].BackgroundImage = null;

                            }

                            //Clinton Dama step
                            if (turn == 'c' && prev == 'c' && cur == 'n' && clintons.Clean<GameBoard>(curi, curj, previ, prevj, gameboard) && gameboard[previ, prevj] == 10)
                            {
                                point = clintons.Huff<GameBoard>(gameboard, 1, 2);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 't';
                                    buttons[previ, prevj].BackgroundImage = null;
                                    gameboard[previ, prevj] = 0;
                                    gameboard[curi, curj] = 10;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                                }
                                else
                                {
                                    int x = point[0];
                                    int y = point[1];
                                    turn = 't';
                                    buttons[x, y].BackgroundImage = null;
                                    gameboard[x, y] = 0;
                                }
                            }

                            //Clinton Dama eat
                            if (prev == 'c' && cur == 'n' && clintons.CleanEat<GameBoard>(curi, curj, previ, prevj, gameboard, 1, 2) && gameboard[previ, prevj] == 10)
                            {
                                turn = 't';
                                clintons.RemoveCoin(gameboard, ref buttons);
                                gameboard[previ, prevj] = 0;
                                gameboard[curi, curj] = 10;
                                buttons[previ, prevj].BackgroundImage = null;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                            }


                            prev = cur;
                            previ = curi;
                            prevj = curj;
                            Calculations.CoinsCount(gameboard, out count1, out count2);
                            if (count2 == 0)
                            {
                                RemoveButtons(buttons);
                                button1.Show();
                                choosestart.Show();
                                startCombo.Show();
                                MessageBox.Show("Congratulations! The winner is Hillary Clinton.");
                            }
                            else
                            if (count1 == 0)
                            {
                                RemoveButtons(buttons);
                                button1.Show();
                                choosestart.Show();
                                startCombo.Show();
                                MessageBox.Show("Congratulations! The winner is Donald Trump.");
                            }
                            

                        };
                        button.MouseDown += (s, ea) => { button.FlatAppearance.BorderColor = Color.Silver; };
                        button.MouseUp += (s, ea) => { button.FlatAppearance.BorderColor = Color.Black; };

                    }
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }

            }
        }
    }
}
