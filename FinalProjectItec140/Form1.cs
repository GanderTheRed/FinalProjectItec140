using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FinalProjectItec140
{



    public partial class Form1 : Form
    {
        int bvertical = 0;                      //Blues Settings
        int bhorizontal = -10;
        int rvertical = 0;                      //Reds Settings
        int rhorizontal = 10;
        int RedLastTop, RedLastLeft, BlueLastTop, BlueLastLeft;

        ListBox lstRedTop = new ListBox();
        ListBox lstRedLeft = new ListBox();
        ListBox lstBlueTop = new ListBox();
        ListBox lstBlueLeft = new ListBox();

        
        PictureBox CreateBlueLine()
        {
            PictureBox Blue = new PictureBox()
            {
                Size = new Size(10, 10),
                BackColor = Color.Blue,
                Top = BlueLastTop,
                Left = BlueLastLeft,
            };

            return Blue;
            
        }
        PictureBox CreateRedLine()
        {
            PictureBox Red = new PictureBox()
            {
                Size = new Size(10, 10),
                BackColor = Color.Red,
                Top = RedLastTop,
                Left = RedLastLeft,
            };

            return Red;
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((picRed.Top == 0 && picBlue.Top == 0) || (picRed.Left == 0 && picBlue.Left == 0) || (picRed.Top > 550 && picBlue.Top > 550) || (picRed.Left > 1180 && picBlue.Left > 1180))
            {
                timer1.Stop();
                MessageBox.Show("Draw!");
            }
            else
            {
                if (picRed.Top == 0 || picRed.Left == 0 || picRed.Top > 550 || picRed.Left > 1180)
                {
                    timer1.Stop();
                    MessageBox.Show("Red left the map! Blue wins!");
                }

                if (picBlue.Top == 0 || picBlue.Left == 0 || picBlue.Top > 550 || picBlue.Left > 1180)
                {
                    timer1.Stop();
                    MessageBox.Show("Blue left the map! Red wins!");
                }

                if(picRed.Top == picBlue.Top && picRed.Left == picBlue.Left)
                {
                    timer1.Stop();
                    MessageBox.Show("Draw!");
                }
                Controls.Add(CreateRedLine());
                Controls.Add(CreateBlueLine());

                RedLastTop = picRed.Top;
                RedLastLeft = picRed.Left;
                BlueLastTop = picBlue.Top;
                BlueLastLeft = picBlue.Left;

                lstRedTop.Items.Add(RedLastTop);
                lstRedLeft.Items.Add(RedLastLeft);
                lstBlueTop.Items.Add(BlueLastTop);
                lstBlueLeft.Items.Add(BlueLastLeft);

                picBlue.Top += bvertical;
                picBlue.Left += bhorizontal;
                picRed.Top += rvertical;
                picRed.Left += rhorizontal;

                for (int i = 0; i < lstRedTop.Items.Count; i++)
                {
                    string btop = picBlue.Top.ToString();
                    string rtop = lstRedTop.Items[i].ToString();
                    string bleft = picBlue.Left.ToString();
                    string rleft = lstRedLeft.Items[i].ToString();

                    if (rtop == btop && rleft == bleft)
                    {
                        timer1.Stop();
                        Controls.Add(CreateBlueLine());
                        MessageBox.Show("Game Over! Red Wins!");
                    }
                }

                for (int j = 0; j < lstBlueTop.Items.Count; j++)
                {
                    string rtop = picRed.Top.ToString();
                    string btop = lstBlueTop.Items[j].ToString();
                    string bleft = picRed.Left.ToString();
                    string rleft = lstBlueLeft.Items[j].ToString();

                    if (rtop == btop && rleft == bleft)
                    {
                        timer1.Stop();
                        Controls.Add(CreateRedLine());
                        MessageBox.Show("Game Over! Blue Wins!");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (rhorizontal == 10)
                {

                }
                else
                {
                    rhorizontal = -10;
                    rvertical = 0;
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                if (rhorizontal == -10)
                {

                }
                else
                {
                    rhorizontal = 10;
                    rvertical = 0;
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if (rvertical == -10)
                {

                }
                else
                {
                    rhorizontal = 0;
                    rvertical = 10;
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                if (rvertical == 10)
                {

                }
                else
                {
                    rhorizontal = 0;
                    rvertical = -10;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (bhorizontal == 10)
                {

                }
                else
                {
                    bhorizontal = -10;
                    bvertical = 0;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (bhorizontal == -10)
                {

                }
                else
                {
                    bhorizontal = 10;
                    bvertical = 0;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (bvertical == -10)
                {

                }
                else
                {
                    bhorizontal = 0;
                    bvertical = 10;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (bvertical == 10)
                {

                }
                else
                {
                    bhorizontal = 0;
                    bvertical = -10;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            
            
        }

        private void picRed_Click(object sender, EventArgs e)
        {

        }
    }
}