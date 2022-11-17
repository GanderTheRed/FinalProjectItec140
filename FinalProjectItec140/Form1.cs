namespace FinalProjectItec140
{
    public partial class Form1 : Form
    {
        int vertical = 0;
        int horizontal = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            picSnake.Top += vertical;
            picSnake.Left += horizontal;
            if (picSnake.Top < 0 || picSnake.Top == 800 || picSnake.Left < 0 || picSnake.Left == 1200)
            {
                timer1.Stop();
                MessageBox.Show("Game Over!");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                horizontal = -10;
                vertical = 0;
            }
            if (e.KeyCode == Keys.D)
            {
                horizontal = 10;
                vertical = 0;
            }
            if (e.KeyCode == Keys.S)
            {
                horizontal = 0;
                vertical = 10;
            }
            if (e.KeyCode == Keys.W)
            {
                horizontal = 0;
                vertical = -10;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            btnSinglePlayer.Visible = false;
            btnTwoPlayer.Visible = false;
            picSnake.Visible = true;
            
        }
    }
}