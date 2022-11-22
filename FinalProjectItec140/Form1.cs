using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FinalProjectItec140
{
    public partial class Form1 : Form
    {
        public bool modeEasy, modeMedium, modeHard;                     //Variables for the different game modes.

        int screenWidth = Screen.PrimaryScreen.Bounds.Width;            //Finds resolution of screen
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        int bvertical = 0;                                              //Blues initial Settings
        int bhorizontal = -10;
        int rvertical = 0;                                              //Reds initial Settings
        int rhorizontal = 10;
        int RedLastTop, RedLastLeft, BlueLastTop, BlueLastLeft;         //Variables to store previous position

        ListBox lstRedTop = new ListBox();                              //Listboxes to store location values
        ListBox lstRedLeft = new ListBox();
        ListBox lstBlueTop = new ListBox();
        ListBox lstBlueLeft = new ListBox();
        
        PictureBox CreateBlueLine()                                     //Function to spawn a picture box for Blue
        {
            PictureBox Blue = new PictureBox()
            {
                Size = new Size(10, 10),                                //Properties of the picturebox
                BackColor = Color.Blue,
                Top = BlueLastTop,
                Left = BlueLastLeft,
            };
            return Blue;
        }
        PictureBox CreateRedLine()                                      //Function to spawn a picture box for Blue
        {
            PictureBox Red = new PictureBox()
            {
                Size = new Size(10, 10),                                //Properties of the picturebox
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
            WindowState = FormWindowState.Maximized;                    //Sets window to fullscreen
            picRed.Top = startLocationTop / 2;                          //Sets starting locations based on screen resolution                
            picRed.Left = (startLocationLeft / 8);
            picBlue.Top = startLocationTop / 2;
            picBlue.Left = (startLocationLeft / 8) * 7;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (modeEasy == true)                       
                
            //Depending on the radio that is checked in form2, changes timer interval to make the game more difficult.

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
               
            void Game()                                                 
                //Gameplay functionality
            {
                //Draw conditions (if both players leave the map at the same time or collide)

                if ((picRed.Top == picBlue.Top) && (picRed.Left == picBlue.Left) ||
                    (picRed.Top > (screenHeight - 50) && picBlue.Top > (screenHeight - 50)) || 
                    (picRed.Left > (screenWidth - 15) && picBlue.Left > (screenWidth - 15)) || 
                    (picRed.Top == 0 && picBlue.Top == 0) || 
                    (picRed.Left == 0 && picBlue.Left == 0))

                

                {
                    timer1.Stop();
                    MessageBox.Show("Draw!");                          
                    this.Close();
                }
                else
                {
                    if (picRed.Top < 0 || picRed.Left < 0 || picRed.Top > (screenHeight - 50) || picRed.Left > (screenWidth - 15))

                    //Win condition for Blue if red leaves the map

                    {
                        timer1.Stop();
                        MessageBox.Show("Red left the map! Blue wins!");            
                        this.Close();
                    }

                    if (picBlue.Top < 0 || picBlue.Left < 0 || picBlue.Top > (screenHeight - 50) || picBlue.Left > (screenWidth - 15))

                    //Win condition for Red if blue leaves the map

                    {
                        timer1.Stop();
                        MessageBox.Show("Blue left the map! Red wins!");            
                        this.Close();
                    }

                    //Sets previous location variables to red/blues current position.

                    RedLastTop = picRed.Top;               
                    RedLastLeft = picRed.Left;
                    BlueLastTop = picBlue.Top;
                    BlueLastLeft = picBlue.Left;

                    //Creates lines at picRed/picBlues previous position

                    Controls.Add(CreateRedLine());          
                    Controls.Add(CreateBlueLine());

                    //Adds previous location of picRed/Blue to list boxes

                    lstRedTop.Items.Add(RedLastTop);        
                    lstRedLeft.Items.Add(RedLastLeft);
                    lstBlueTop.Items.Add(BlueLastTop);
                    lstBlueLeft.Items.Add(BlueLastLeft);

                    //Moves picRed/Blue based on current direction variables

                    picBlue.Top += bvertical;               
                    picBlue.Left += bhorizontal;
                    picRed.Top += rvertical;
                    picRed.Left += rhorizontal;

                    for (int k = 0; k < lstRedTop.Items.Count; k++)

                    //uses a for loop to check previous locations and whether picRed or picBlue are in game ending areas at the same time.

                    {
                        string btop = lstBlueTop.Items[k].ToString();
                        string rtop = lstRedTop.Items[k].ToString();
                        string bleft = lstBlueLeft.Items[k].ToString();
                        string rleft = lstRedLeft.Items[k].ToString();                  
                        string b2top = picBlue.Top.ToString();
                        string r2top = picRed.Top.ToString();
                        string b2left = picBlue.Left.ToString();
                        string r2left = picRed.Left.ToString();

                        if (((r2top == btop && r2left == bleft) && (b2top == rtop && b2left == rleft)))    
                        
                        //Checks to see if red and blue have collided into their tails at the same time

                        {
                            timer1.Stop();
                            Controls.Add(CreateBlueLine());
                            Controls.Add(CreateRedLine());
                            MessageBox.Show("Draw!");
                            this.Close();
                        }
                        else if ((b2top == rtop && b2left == rleft) || (b2top == btop && b2left == bleft))

                        //Checks to see if blue has collided with reds tail or blue has collided with own tail

                        {
                            timer1.Stop();
                            Controls.Add(CreateBlueLine());
                            MessageBox.Show("Game Over! Red Wins!");
                            this.Close();
                        }
                        else if((r2top == btop && r2left == bleft) || (rtop == r2top && rleft == r2left))

                        //Checks to see if red has collided with blues tail or if red has collided with own tail

                        {
                            timer1.Stop();
                            Controls.Add(CreateRedLine());
                            MessageBox.Show("Game Over! Blue Wins!");
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
            //Player 1 Controls

            if (e.KeyCode == Keys.A)
            {
                if (rhorizontal == 10)
                {

                //if one player tries to invert their tron, do nothing

                }
                else

                //Otherwise change to selected direction.

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

            //Player 2 Controls

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