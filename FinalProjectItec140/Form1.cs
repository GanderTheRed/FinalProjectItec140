namespace FinalProjectItec140
{
    public partial class Form1 : Form
    {
        int bvertical = 0;                      //Blues Settings
        int bhorizontal = 0;
        int rvertical = 0;                      //Reds Settings
        int rhorizontal = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            picBlue.Top += bvertical;
            picBlue.Left += bhorizontal;
            picRed.Top += rvertical;
            picRed.Left += rhorizontal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
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
    }
}