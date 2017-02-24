using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        void RemoveButtons(Button[,] buttons)
        {
            this.Controls.Remove(buttons[0, 0]);
            this.Controls.Remove(buttons[0, 1]);
            this.Controls.Remove(buttons[0, 2]);
            this.Controls.Remove(buttons[0, 3]);
            this.Controls.Remove(buttons[0, 4]);
            this.Controls.Remove(buttons[0, 5]);
            this.Controls.Remove(buttons[0, 6]);
            this.Controls.Remove(buttons[0, 7]);

            this.Controls.Remove(buttons[1, 0]);
            this.Controls.Remove(buttons[1, 1]);
            this.Controls.Remove(buttons[1, 2]);
            this.Controls.Remove(buttons[1, 3]);
            this.Controls.Remove(buttons[1, 4]);
            this.Controls.Remove(buttons[1, 5]);
            this.Controls.Remove(buttons[1, 6]);
            this.Controls.Remove(buttons[1, 7]);

            this.Controls.Remove(buttons[2, 0]);
            this.Controls.Remove(buttons[2, 1]);
            this.Controls.Remove(buttons[2, 2]);
            this.Controls.Remove(buttons[2, 3]);
            this.Controls.Remove(buttons[2, 4]);
            this.Controls.Remove(buttons[2, 5]);
            this.Controls.Remove(buttons[2, 6]);
            this.Controls.Remove(buttons[2, 7]);

            this.Controls.Remove(buttons[3, 0]);
            this.Controls.Remove(buttons[3, 1]);
            this.Controls.Remove(buttons[3, 2]);
            this.Controls.Remove(buttons[3, 3]);
            this.Controls.Remove(buttons[3, 4]);
            this.Controls.Remove(buttons[3, 5]);
            this.Controls.Remove(buttons[3, 6]);
            this.Controls.Remove(buttons[3, 7]);

            this.Controls.Remove(buttons[4, 0]);
            this.Controls.Remove(buttons[4, 1]);
            this.Controls.Remove(buttons[4, 2]);
            this.Controls.Remove(buttons[4, 3]);
            this.Controls.Remove(buttons[4, 4]);
            this.Controls.Remove(buttons[4, 5]);
            this.Controls.Remove(buttons[4, 6]);
            this.Controls.Remove(buttons[4, 7]);

            this.Controls.Remove(buttons[5, 0]);
            this.Controls.Remove(buttons[5, 1]);
            this.Controls.Remove(buttons[5, 2]);
            this.Controls.Remove(buttons[5, 3]);
            this.Controls.Remove(buttons[5, 4]);
            this.Controls.Remove(buttons[5, 5]);
            this.Controls.Remove(buttons[5, 6]);
            this.Controls.Remove(buttons[5, 7]);

            this.Controls.Remove(buttons[6, 0]);
            this.Controls.Remove(buttons[6, 1]);
            this.Controls.Remove(buttons[6, 2]);
            this.Controls.Remove(buttons[6, 3]);
            this.Controls.Remove(buttons[6, 4]);
            this.Controls.Remove(buttons[6, 5]);
            this.Controls.Remove(buttons[6, 6]);
            this.Controls.Remove(buttons[6, 7]);

            this.Controls.Remove(buttons[7, 0]);
            this.Controls.Remove(buttons[7, 1]);
            this.Controls.Remove(buttons[7, 2]);
            this.Controls.Remove(buttons[7, 3]);
            this.Controls.Remove(buttons[7, 4]);
            this.Controls.Remove(buttons[7, 5]);
            this.Controls.Remove(buttons[7, 6]);
            this.Controls.Remove(buttons[7, 7]);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            button1.Hide();
            Button[,] buttons = new Button[8, 8];
            bool[,] bars = new bool[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    bars[i, j] = false;

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
                            bars[i, j] = true;
                        }
                        else if (j > 4 && j < 8)
                        {
                            button.Tag = "trump";
                            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                            trumps[i, j] = true;
                            bars[i, j] = true;
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

                            if (prev == 't' && cur == 'n' && (curi == previ - 1 || curi == previ + 1) && (curj == prevj - 1))
                            {
                                buttons[previ, prevj].BackgroundImage = null;
                                buttons[previ, prevj].Tag = string.Empty;
                                bars[previ, prevj] = false;
                                bars[curi, curj] = true;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                button.Tag = "trump";
                                trumps[previ, prevj] = false;
                                trumps[curi, curj] = true;
                            }


                            if (prev == 't' && cur == 'n' &&
                            ((curi == previ - 2 && curj == prevj + 2 && clintons[previ - 1, prevj + 1] == true)
                            || (curi == previ - 2 && curj == prevj - 2 && clintons[previ - 1, prevj - 1] == true)
                            || (curi == previ + 2 && curj == prevj + 2 && clintons[previ + 1, prevj + 1] == true)
                            || (curi == previ + 2 && curj == prevj - 2 && clintons[previ + 1, prevj - 1] == true))
                            )
                            {
                                buttons[previ, prevj].BackgroundImage = null;
                                buttons[previ, prevj].Tag = string.Empty;
                                bars[previ, prevj] = false;
                                bars[curi, curj] = true;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                button.Tag = "trump";
                                trumps[previ, prevj] = false;
                                trumps[curi, curj] = true;

                                clintons[(previ + curi) / 2, (prevj + curj) / 2] = false;
                                bars[(previ + curi) / 2, (prevj + curj) / 2] = false;
                                buttons[(previ + curi) / 2, (prevj + curj) / 2].Tag = string.Empty;
                                buttons[(previ + curi) / 2, (prevj + curj) / 2].BackgroundImage = null;
                            }



                            if (prev == 'c' && cur == 'n' && (curi == previ - 1 || curi == previ + 1) && (curj == prevj + 1))
                            {
                                buttons[previ, prevj].BackgroundImage = null;
                                buttons[previ, prevj].Tag = string.Empty;
                                bars[previ, prevj] = false;
                                bars[curi, curj] = true;
                                clintons[previ, prevj] = false;
                                clintons[curi, curj] = true;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                button.Tag = "clinton";

                                clintons[curi, curj] = true;

                            }
                            if (prev == 'c' && cur == 'n' &&
                            ((curi == previ - 2 && curj == prevj + 2 && trumps[previ - 1, prevj + 1] == true)
                            || (curi == previ - 2 && curj == prevj - 2 && trumps[previ - 1, prevj - 1] == true)
                            || (curi == previ + 2 && curj == prevj + 2 && trumps[previ + 1, prevj + 1] == true)
                            || (curi == previ + 2 && curj == prevj - 2 && trumps[previ + 1, prevj - 1] == true)))
                            {
                                buttons[previ, prevj].BackgroundImage = null;
                                buttons[previ, prevj].Tag = string.Empty;
                                bars[previ, prevj] = false;
                                bars[curi, curj] = true;
                                clintons[previ, prevj] = false;
                                clintons[curi, curj] = true;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                button.Tag = "clinton";

                                trumps[(previ + curi) / 2, (prevj + curj) / 2] = false;
                                bars[(previ + curi) / 2, (prevj + curj) / 2] = false;
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
