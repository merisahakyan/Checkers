using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Checkers : Form
    {

        public Checkers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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

            char turn = 'c';
            button1.Hide();
            Button[,] buttons = new Button[8, 8];
            int[] point = new int[2];


            char prev = 'n', cur = 'n';
            Clinton clintons = new Clinton();
            Trump trumps = new Trump();

            int previ = 0, prevj = 0;
            int curi, curj;
            ClientSize = new Size(550, 400);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Height = 50;
                    button.Width = 50;
                    button.Location = new Point(50 * i, 50 * j);
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
                            curi = button.Location.X / 50;
                            curj = button.Location.Y / 50;

                            switch ((string)button.Tag)
                            {
                                case "trump": cur = 't'; break;
                                case "clinton": cur = 'c'; break;
                                default: cur = 'n'; break;
                            }

                            if (((prev == 'n' || prev == 't') && cur == 't') || (prev == 'c' && cur == 't') || (prev == 't' && cur == 'c') || ((prev == 'n' || prev == 'c') && cur == 'c'))
                            {
                                previ = button.Location.X / 50;
                                prevj = button.Location.Y / 50;

                            }


                            //Trump's step
                            if (trumps.Step(turn, prev, cur, curi, curj, previ, prevj))
                            {
                                point = trumps.Huff<Clinton>(clintons);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 'c';
                                    buttons[previ, prevj].BackgroundImage = null;
                                    buttons[previ, prevj].Tag = string.Empty;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                    button.Tag = "trump";
                                    trumps[previ, prevj] = false;
                                    trumps[curi, curj] = true;
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
                            if (trumps.Eating<Clinton>(prev, cur, curi, curj, previ, prevj, clintons))
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


                            //Clinton's step
                            if (clintons.Step(turn, prev, cur, curi, curj, previ, prevj))
                            {
                                point = clintons.Huff<Trump>(trumps);
                                if (point[0] == -1 && point[1] == -1)
                                {
                                    turn = 't';
                                    buttons[previ, prevj].BackgroundImage = null;
                                    buttons[previ, prevj].Tag = string.Empty;
                                    clintons[previ, prevj] = false;
                                    clintons[curi, curj] = true;
                                    button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                    button.Tag = "clinton";

                                    clintons[curi, curj] = true;
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
                            if (clintons.Eating<Trump>(prev, cur, curi, curj, previ, prevj, trumps))
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




                            prev = cur;
                            if (Calculations.CoinsCount<Trump>(trumps) == 0)
                            {
                                RemoveButtons(buttons);
                                button1.Location = new Point(420, 100);
                                button1.Show();
                            }
                            else
                            if (Calculations.CoinsCount<Clinton>(clintons) == 0)
                            {
                                RemoveButtons(buttons);
                                button1.Location = new Point(420, 100);
                                button1.Show();
                            }
                        };
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }
    }
}
