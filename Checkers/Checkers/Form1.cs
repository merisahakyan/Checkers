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
            Player clintons = new Player();
            // Trump trumps = new Trump();
            Player trumps = new Player();
            int previ = 0, prevj = 0;
            int curi, curj;


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
                            button.Tag = "clinton";
                            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                            clintons[i, j] = true;
                        }
                        else if (j > 4 && j < 8)
                        {
                            button.Tag = "trump";
                            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                            trumps[i, j] = true;
                        }
                        else
                        {
                            button.Tag = "none";
                            button.BackgroundImage = null;
                        }
                    }

                    if ((i + j) % 2 == 1)
                        button.Click += (s, ea) =>
                        {
                            curi = (button.Location.X - 200) / 50;
                            curj = button.Location.Y / 50;

                            switch ((string)button.Tag)
                            {
                                case "trump": cur = 't'; break;
                                case "clinton": cur = 'c'; break;
                                default: cur = 'n'; break;
                            }

                            //Trump's step
                            if (turn == 't' && trumps.Step(turn, prev, cur, curi, curj, previ, prevj) && !trumps.isdama[previ, prevj])
                            {
                                point = trumps.Huff<Player>(clintons);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 'c';
                                    buttons[previ, prevj].BackgroundImage = null;
                                    buttons[previ, prevj].Tag = string.Empty;
                                    button.Tag = "trump";
                                    trumps[previ, prevj] = false;
                                    trumps[curi, curj] = true;

                                    if (curj == 0)
                                    {
                                        trumps.isdama[curi, curj] = true;
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                                    }
                                    else
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));

                                }
                                else
                                {
                                    int x = point[0];
                                    int y = point[1];
                                    turn = 'c';
                                    buttons[x, y].BackgroundImage = null;
                                    buttons[x, y].Tag = string.Empty;
                                    trumps[x, y] = false;
                                }
                            }

                            //Trump's eat
                            if (prev == 't' && trumps.Eating<Player>(cur, curi, curj, previ, prevj, clintons))
                            {
                                turn = 'c';
                                buttons[previ, prevj].BackgroundImage = null;
                                buttons[previ, prevj].Tag = string.Empty;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                button.Tag = "trump";
                                trumps[previ, prevj] = false;
                                trumps[curi, curj] = true;

                                clintons[(previ + curi) / 2, (prevj + curj) / 2] = false;
                                buttons[(previ + curi) / 2, (prevj + curj) / 2].Tag = string.Empty;
                                buttons[(previ + curi) / 2, (prevj + curj) / 2].BackgroundImage = null;
                            }
                            //Trump's dama step
                            if (turn == 't' && prev == 't' && cur == 'n' && trumps.Clean<Player>(clintons, curi, curj, previ, prevj) && trumps.isdama[previ, prevj])
                            {
                                point = trumps.Huff<Player>(clintons);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 'c';
                                    buttons[previ, prevj].BackgroundImage = null;
                                    buttons[previ, prevj].Tag = string.Empty;
                                    trumps[previ, prevj] = false;
                                    trumps[curi, curj] = true;
                                    trumps.isdama[previ, prevj] = false;
                                    trumps.isdama[curi, curj] = true;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damatrump));
                                    button.Tag = "trump";
                                }
                                else
                                {
                                    int x = point[0];
                                    int y = point[1];
                                    turn = 'c';
                                    buttons[x, y].BackgroundImage = null;
                                    buttons[x, y].Tag = string.Empty;
                                    trumps[x, y] = false;
                                }
                            }

                            //Clinton's step
                            if (turn == 'c' && clintons.Step(turn, prev, cur, curi, curj, previ, prevj) && !clintons.isdama[previ, prevj])
                            {
                                point = clintons.Huff<Player>(trumps);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 't';
                                    buttons[previ, prevj].BackgroundImage = null;
                                    buttons[previ, prevj].Tag = string.Empty;
                                    clintons[previ, prevj] = false;
                                    clintons[curi, curj] = true;
                                    button.Tag = "clinton";

                                    if (curj == 7)
                                    {
                                        clintons.isdama[curi, curj] = true;
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                                    }
                                    else
                                        button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                }
                                else
                                {
                                    int x = point[0];
                                    int y = point[1];
                                    turn = 't';
                                    buttons[x, y].BackgroundImage = null;
                                    buttons[x, y].Tag = string.Empty;
                                    clintons[x, y] = false;
                                }

                            }

                            //Clintons's eat
                            if (prev == 'c' && clintons.Eating<Player>(cur, curi, curj, previ, prevj, trumps))
                            {
                                turn = 't';
                                buttons[previ, prevj].BackgroundImage = null;
                                buttons[previ, prevj].Tag = string.Empty;
                                clintons[previ, prevj] = false;
                                clintons[curi, curj] = true;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                button.Tag = "clinton";

                                trumps[(previ + curi) / 2, (prevj + curj) / 2] = false;
                                buttons[(previ + curi) / 2, (prevj + curj) / 2].Tag = string.Empty;
                                buttons[(previ + curi) / 2, (prevj + curj) / 2].BackgroundImage = null;

                            }

                            //Clinton Dama step
                            if (turn == 'c' && prev == 'c' && cur == 'n' && clintons.Clean<Player>(trumps, curi, curj, previ, prevj) && clintons.isdama[previ, prevj])
                            {
                                point = clintons.Huff<Player>(trumps);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 't';
                                    buttons[previ, prevj].BackgroundImage = null;
                                    buttons[previ, prevj].Tag = string.Empty;
                                    clintons[previ, prevj] = false;
                                    clintons[curi, curj] = true;
                                    clintons.isdama[previ, prevj] = false;
                                    clintons.isdama[curi, curj] = true;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.damaclinton));
                                    button.Tag = "clinton";
                                }
                                else
                                {
                                    int x = point[0];
                                    int y = point[1];
                                    turn = 't';
                                    buttons[x, y].BackgroundImage = null;
                                    buttons[x, y].Tag = string.Empty;
                                    clintons[x, y] = false;
                                }
                            }


                            prev = cur;
                            previ = curi;
                            prevj = curj;
                            if (Calculations.CoinsCount<Player>(trumps) == 0)
                            {
                                RemoveButtons(buttons);
                                button1.Show();
                                choosestart.Show();
                                startCombo.Show();
                                MessageBox.Show("Congratulations! The winner is Hillary Clinton.");
                            }
                            else
                            if (Calculations.CoinsCount<Player>(clintons) == 0)
                            {
                                RemoveButtons(buttons);
                                button1.Show();
                                choosestart.Show();
                                startCombo.Show();
                                MessageBox.Show("Congratulations! The winner is Donald Trump.");
                            }
                        };
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }
    }
}
