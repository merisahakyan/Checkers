using System.Drawing;
using System.Threading;
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
            char turn = 't';
            char previous = 'n', current = 'n';
            //char turn;
            //if (startCombo.SelectedIndex == 1)
            //    turn = 't';
            //else
            //    turn = 'c';

            button1.Hide();
            startCombo.Hide();
            choosestart.Hide();
            Button[,] buttons = new Button[8, 8];
            int[,] point = new int[2, 2];
            

            GameBoard gameboard = new GameBoard();
            //Player clintons = new Player();
            AutoPlayer clintons = new AutoPlayer();
            Player trumps = new Player();

            int previous_i = 0, previous_j = 0;
            int current_i, current_j;
            byte count1, count2;
            bool message=false;

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

                            //current_i = (button.Location.X - 200) / 50;
                            //current_j = button.Location.Y / 50;

                            //switch (gameboard[current_i, current_j])
                            //{
                            //    case 2:
                            //    case 20: current = 't'; break;
                            //    case 1:
                            //    case 10: current = 'c'; break;
                            //    case 0: current = 'n'; break;
                            //}



                            current_i = (button.Location.X - 200) / 50;
                            current_j = button.Location.Y / 50;
                            switch (gameboard[current_i, current_j])
                            {
                                case 2:
                                case 20: current = 't'; break;
                                case 0: current = 'n'; break;
                            }
                            //Trump's step
                            if (turn == 't' && trumps.Step(turn, previous, current, current_i, current_j, previous_i, previous_j) && gameboard[previous_i, previous_j] == 2)
                            {
                                point = trumps.Huff(gameboard, 2, 1);
                                if (point[0, 0] == -1 && point[0, 1] == -1)
                                {
                                    turn = 'c';
                                    buttons[previous_i, previous_j].BackgroundImage = null;

                                    if (current_j == 0 && gameboard[previous_i, previous_j] == 2)
                                    {
                                        gameboard[previous_i, previous_j] = 0;
                                        gameboard[current_i, current_j] = 20;
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                                    }
                                    else
                                    {
                                        gameboard[previous_i, previous_j] = 0;
                                        gameboard[current_i, current_j] = 2;
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                    }
                                }
                                else
                                {
                                    int x = point[0, 0];
                                    int y = point[0, 1];
                                    turn = 'c';
                                    buttons[x, y].BackgroundImage = null;
                                    gameboard[x, y] = 0;
                                }
                                Thread.Sleep(500);
                                clintons.AutoStep(clintons, point, ref turn, ref gameboard, ref buttons,out message);
                            }

                            //Trump's eat
                            if (previous == 't' && trumps.Eating(current, current_i, current_j, previous_i, previous_j, gameboard, 1) && gameboard[previous_i, previous_j] == 2)
                            {
                                turn = 'c';
                                buttons[previous_i, previous_j].BackgroundImage = null;

                                if (current_j == 0 && gameboard[previous_i, previous_j] == 2)
                                {
                                    gameboard[previous_i, previous_j] = 0;
                                    gameboard[current_i, current_j] = 20;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                                }
                                else
                                {
                                    gameboard[previous_i, previous_j] = 0;
                                    gameboard[current_i, current_j] = 2;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                }
                                gameboard[(previous_i + current_i) / 2, (previous_j + current_j) / 2] = 0;
                                buttons[(previous_i + current_i) / 2, (previous_j + current_j) / 2].BackgroundImage = null;


                                Thread.Sleep(500);
                                clintons.AutoStep(clintons, point, ref turn, ref gameboard, ref buttons,out message);
                            }

                            //Trump's dama step
                            if (turn == 't' && previous == 't' && current == 'n' && trumps.Clean(current_i, current_j, previous_i, previous_j, gameboard) && gameboard[previous_i, previous_j] == 20)
                            {
                                point = trumps.Huff(gameboard, 2, 1);
                                if (point[0, 0] == -1 && point[0, 1] == -1)
                                {
                                    turn = 'c';
                                    buttons[previous_i, previous_j].BackgroundImage = null;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                                    gameboard[previous_i, previous_j] = 0;
                                    gameboard[current_i, current_j] = 20;
                                }
                                else
                                {
                                    int x = point[0, 0];
                                    int y = point[0, 1];
                                    turn = 'c';
                                    buttons[x, y].BackgroundImage = null;
                                    gameboard[x, y] = 0;
                                }
                            }

                            //Trump dama eat
                            if (previous == 't' && current == 'n' && trumps.DamaEat(current_i, current_j, previous_i, previous_j, gameboard, 2, 1) && gameboard[previous_i, previous_j] == 20)
                            {
                                turn = 'c';
                                trumps.RemoveCoin(gameboard, ref buttons);
                                gameboard[previous_i, previous_j] = 0;
                                gameboard[current_i, current_j] = 20;
                                buttons[previous_i, previous_j].BackgroundImage = null;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                            }
                            previous = current;
                            previous_i = current_i;
                            previous_j = current_j;

                            ////Clinton's step
                            //if (turn == 'c' && clintons.Step(turn, previous, current, current_i, current_j, previous_i, previous_j) && gameboard[previous_i, previous_j] == 1)
                            //{
                            //    point = clintons.Huff(gameboard, 1, 2);
                            //    if (point[0] == -1 && point[1] == -1)
                            //    {
                            //        turn = 't';
                            //        buttons[previous_i, previous_j].BackgroundImage = null;

                            //        if (current_j == 7 && gameboard[previous_i, previous_j] == 1)
                            //        {
                            //            gameboard[previous_i, previous_j] = 0;
                            //            gameboard[current_i, current_j] = 10;
                            //            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                            //        }
                            //        else
                            //        {
                            //            gameboard[previous_i, previous_j] = 0;
                            //            gameboard[current_i, current_j] = 1;
                            //            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                            //        }
                            //    }
                            //    else
                            //    {
                            //        int x = point[0];
                            //        int y = point[1];
                            //        turn = 't';
                            //        buttons[x, y].BackgroundImage = null;
                            //        gameboard[x, y] = 0;
                            //    }

                            //}

                            ////Clintons's eat
                            //if (previous == 'c' && clintons.Eating(current, current_i, current_j, previous_i, previous_j, gameboard, 2) && gameboard[previous_i, previous_j] == 1)
                            //{
                            //    turn = 't';
                            //    buttons[previous_i, previous_j].BackgroundImage = null;

                            //    if (current_j == 7 && gameboard[previous_i, previous_j] == 1)
                            //    {
                            //        gameboard[previous_i, previous_j] = 0;
                            //        gameboard[current_i, current_j] = 10;
                            //        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                            //    }
                            //    else
                            //    {
                            //        gameboard[previous_i, previous_j] = 0;
                            //        gameboard[current_i, current_j] = 1;
                            //        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                            //    }
                            //    gameboard[(previous_i + current_i) / 2, (previous_j + current_j) / 2] = 0;
                            //    buttons[(previous_i + current_i) / 2, (previous_j + current_j) / 2].BackgroundImage = null;

                            //}

                            ////Clinton Dama step
                            //if (turn == 'c' && previous == 'c' && current == 'n' && clintons.Clean(current_i, current_j, previous_i, previous_j, gameboard) && gameboard[previous_i, previous_j] == 10)
                            //{
                            //    point = clintons.Huff(gameboard, 1, 2);
                            //    if (point[0] == -1 && point[1] == -1)
                            //    {
                            //        turn = 't';
                            //        buttons[previous_i, previous_j].BackgroundImage = null;
                            //        gameboard[previous_i, previous_j] = 0;
                            //        gameboard[current_i, current_j] = 10;
                            //        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                            //    }
                            //    else
                            //    {
                            //        int x = point[0];
                            //        int y = point[1];
                            //        turn = 't';
                            //        buttons[x, y].BackgroundImage = null;
                            //        gameboard[x, y] = 0;
                            //    }
                            //}

                            ////Clinton Dama eat
                            //if (previous == 'c' && current == 'n' && clintons.DamaEat(current_i, current_j, previous_i, previous_j, gameboard, 1, 2) && gameboard[previous_i, previous_j] == 10)
                            //{
                            //    turn = 't';
                            //    clintons.RemoveCoin(gameboard, ref buttons);
                            //    gameboard[previous_i, previous_j] = 0;
                            //    gameboard[current_i, current_j] = 10;
                            //    buttons[previous_i, previous_j].BackgroundImage = null;
                            //    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                            //}


                            //previous = current;
                            //previous_i = current_i;
                            //previous_j = current_j;
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
                            if (count1 == 0||message)
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
