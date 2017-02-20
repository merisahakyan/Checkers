using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
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
            int i1, j1;
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
                            button.Tag = "none";
                    }
                    if ((i + j) % 2 == 1)
                        button.Click += (s, ea) =>
                        {
                            i1 = button.Location.X / 50;
                            j1 = button.Location.Y / 50;

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

                            if (prev == 't' && cur == 'n')
                            {
                                buttons[previ, prevj].BackgroundImage = null;
                                buttons[previ, prevj].Tag = string.Empty;
                                bars[previ, prevj] = false;
                                bars[i1, j1] = true;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                button.Tag = "trump";
                                trumps[previ, prevj] = false;
                                trumps[i1, j1] = true;

                            }

                            if (prev == 'c' && cur == 'n')
                            {
                                buttons[previ, prevj].BackgroundImage = null;
                                buttons[previ, prevj].Tag = string.Empty;
                                bars[previ, prevj] = false;
                                bars[i1, j1] = true;
                                clintons[previ, prevj] = false;
                                clintons[i1, j1] = true;
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                button.Tag = "clinton";

                                clintons[i1, j1] = true;

                            }
                            prev = cur;
                        };
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }
    }
}
