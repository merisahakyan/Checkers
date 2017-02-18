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

            Clinton clintons = new Clinton();
            Trump trumps = new Trump();

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
                        if (j > 4 && j < 8)
                        {
                            button.Tag = "trump";
                            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                            trumps[i, j] = true;
                            bars[i, j] = true;
                        }
                    }
                    if ((i + j) % 2 == 1)
                        button.Click += (s, ea) =>
                        {
                            int i1 = button.Location.X / 50,
                                j1 = button.Location.Y / 50;




                            if ((string)button.Tag == "clinton")
                            {
                                button.BackgroundImage = null;
                                button.Tag = string.Empty;
                                bars[i1, j1] = false;
                                clintons[i1, j1] = false;
                            }
                            else
                              if (button.BackgroundImage == null && Calculations.CoinsCount<Clinton>(clintons) < 12)
                            {
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                                button.Tag = "clinton";
                                bars[i1, j1] = true;
                                clintons[i1, j1] = true;
                            }




                            if ((string)button.Tag == "trump")
                            {
                                button.BackgroundImage = null;
                                button.Tag = string.Empty;
                                bars[i1, j1] = false;
                                trumps[i1, j1] = false;
                            }
                            else
                              if (button.BackgroundImage == null && Calculations.CoinsCount<Trump>(trumps) < 12)
                            {
                                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                                button.Tag = "trump";
                                trumps[i1, j1] = true;
                                clintons[i1, j1] = true;
                            }




                        };
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }
    }
}
