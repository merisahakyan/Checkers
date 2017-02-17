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

            Clinton clintons = new Clinton();
            Trump trumps = new Trump();


            //bool[,] trumps = new bool[8, 8];
            //bool[,] clintons = new bool[8, 8];
            
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
                            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.clinton));
                            clintons[i, j] = true;
                        }
                        if (j > 4 && j < 8)
                        {
                            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.trump1));
                            trumps[i, j] = true;
                        }
                    }
                    button.Click += (s, ea) =>
                    {

                    };
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }
    }
}
