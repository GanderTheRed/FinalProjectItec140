using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FinalProjectItec140
{
    public partial class Form1 : Form
    {
        public bool modeEasy, modeMedium, modeHard;     //Variables for the different game modes.


        //TO DO

        /*
         *     
         */



        

        int screenWidth = Screen.PrimaryScreen.Bounds.Width;                  //Finds resolution of screen
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        int bvertical = 0;                      //Blues initial Settings
        int bhorizontal = -10;
        int rvertical = 0;                      //Reds initial Settings
        int rhorizontal = 10;
        int RedLastTop, RedLastLeft, BlueLastTop, BlueLastLeft;     //Variables to store previous position

        ListBox lstRedTop = new ListBox();                  //Listboxes to store location values
        ListBox lstRedLeft = new ListBox();
        ListBox lstBlueTop = new ListBox();
        ListBox lstBlueLeft = new ListBox();
        
        PictureBox CreateBlueLine()                     //Function to spawn a picture box for Blue
        {
            PictureBox Blue = new PictureBox()
            {
                Size = new Size(10, 10),                //Properties of the picturebox
                BackColor = Color.Blue,
                Top = BlueLastTop,
                Left = BlueLastLeft,
            };
            return Blue;
        }
        PictureBox CreateRedLine()                      //Function to spawn a picture box for Blue
        {
            PictureBox Red = new PictureBox()
            {
                Size = new Size(10, 10),                //Properties of the picturebox
                BackColor = Color.Red,
                Top = RedLastTop,
                Left = RedLastLeft,
            };
            return Red;
        }

        public Form1()
        {
            int startLocationTop = screenHeight;
            int startLocationLeft = screenWidth;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;            //Sets window to fullscreen
            picRed.Top = startLocationTop / 2;                  //Sets starting locations based on screen resolution                
            picRed.Left = (startLocationLeft / 8);
            picBlue.Top = startLocationTop / 2;
            picBlue.Left = (startLocationLeft / 8) * 7;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (modeEasy == true)                       //Depending on the radio that is checked in form2, changes timer interval.
            {
                timer1.Interval = 100;
                Game();
            }
            else if (modeMedium == true)
            {
                timer1.Interval = 50;
                Game();
            }
            else if (modeHard == true)
            {
                timer1.Interval = 25;               
                Game();
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Please select a game mode!");
                this.Close();
            }
                


            void Game()                         //gameplay functionality
            {
                if ((picRed.Top == picBlue.Top) && (picRed.Left == picBlue.Left) || (picRed.Top > (screenHeight - 50) && picBlue.Top > (screenHeight - 50)) || (picRed.Left > (screenWidth - 15) && picBlue.Left > (screenWidth - 15)) || (picRed.Top == 0 && picBlue.Top == 0) || (picRed.Left == 0 && picBlue.Left == 0))
                {
                    timer1.Stop();
                    MessageBox.Show("Draw!");               //Draw conditions (if both players leave the map at the same time or collide)
                    this.Close();
                }
                else
                {
                    if (picRed.Top == 0 || picRed.Left == 0 || picRed.Top > (screenHeight - 50) || picRed.Left > (screenWidth - 15))
                    {
                        timer1.Stop();
                        MessageBox.Show("Red left the map! Blue wins!");            //Win condition for Blue if red leaves the map
                        this.Close();
                    }

                    if (picBlue.Top == 0 || picBlue.Left == 0 || picBlue.Top > (screenHeight - 50) || picBlue.Left > (screenWidth - 15))
                    {
                        timer1.Stop();
                        MessageBox.Show("Blue left the map! Red wins!");            //Win condition for Red if blue leaves the map
                        this.Close();
                    }

                    RedLastTop = picRed.Top;                //Sets previous location variables to red/blues current position.
                    RedLastLeft = picRed.Left;
                    BlueLastTop = picBlue.Top;
                    BlueLastLeft = picBlue.Left;

                    Controls.Add(CreateRedLine());          //Creates lines at picRed/picBlues previous position
                    Controls.Add(CreateBlueLine());

                    lstRedTop.Items.Add(RedLastTop);        //Adds previous location of picRed/Blue to list boxes
                    lstRedLeft.Items.Add(RedLastLeft);
                    lstBlueTop.Items.Add(BlueLastTop);
                    lstBlueLeft.Items.Add(BlueLastLeft);

                    picBlue.Top += bvertical;               //Moves picRed/Blue based on current direction variables
                    picBlue.Left += bhorizontal;
                    picRed.Top += rvertical;
                    picRed.Left += rhorizontal;

                    for (int k = 0; k < lstRedTop.Items.Count; k++)             //uses a loop to check previous locations and whether picRed or picBlue are in game ending areas at the same time
                    {
                        string btop = lstBlueTop.Items[k].ToString();
                        string rtop = lstRedTop.Items[k].ToString();
                        string bleft = lstBlueLeft.Items[k].ToString();
                        string rleft = lstRedLeft.Items[k].ToString();

                        if (rtop == btop && rleft == bleft)
                        {
                            timer1.Stop();
                            Controls.Add(CreateBlueLine());
                            MessageBox.Show("Draw!");
                            this.Close();
                        }
                    }

                    for (int i = 0; i < lstRedTop.Items.Count; i++)             //uses a loop to check previous locations of blue and whether blue is in a game ending area
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
                            this.Close();
                        }
                    }

                    for (int j = 0; j < lstBlueTop.Items.Count; j++)            //uses a loop to check previous locations of red and whether red is in a game ending area
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
                            this.Close();
                        }
                    }

                    for (int k = 0; k < lstRedTop.Items.Count; k++)             //uses a loop to check previous locations and whether picBlue self collided
                    {
                        string btop = picBlue.Top.ToString();
                        string rtop = lstBlueTop.Items[k].ToString();
                        string bleft = lstBlueLeft.Items[k].ToString();
                        string rleft = picBlue.Left.ToString();

                        if (rtop == btop && rleft == bleft)
                        {
                            timer1.Stop();
                            Controls.Add(CreateBlueLine());
                            MessageBox.Show("Red wins!");
                            this.Close();
                        }
                    }

                    for (int k = 0; k < lstRedTop.Items.Count; k++)             //uses a loop to check previous locations and whether picRed self collided
                    {
                        string btop = picRed.Top.ToString();
                        string rtop = lstRedTop.Items[k].ToString();
                        string bleft = lstRedLeft.Items[k].ToString();
                        string rleft = picRed.Left.ToString();

                        if (rtop == btop && rleft == bleft)
                        {
                            timer1.Stop();
                            Controls.Add(CreateRedLine());
                            MessageBox.Show("Blue wins!");
                            this.Close();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)           //Keypress events
        {
            if (e.KeyCode == Keys.A)
            {
                if (rhorizontal == 10)
                {
                    //if one player tries to invert their tron, do nothing
                }
                else
                {   
                    rhorizontal = -10;      //Otherwise change to selected direction.
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