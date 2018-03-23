using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pongGame
{
    public partial class Form1 : Form
    {
        Player player1, player2;
        Ball ball;

        public Form1()
        {

            InitializeComponent();
            //object
            player1 = new Player(barPlayer1);
            player2 = new Player(barPlayer2);
            ball = new Ball(theBall);

           
        }

        private void theTimer_Tick(object sender, EventArgs e)
        {
            //bool? Mean that no value is not an option : 0 1 or bull            
            //barPlayer1.Location = new Point(barPlayer1.Location.X, barPlayer1.Location.Y + mouvementBarSpeed);
            // ref : pointer to mofication at long term
            player1.mvmtForPlayer();
            player2.mvmtForPlayer();
            ball.mvmtForBall();
        }
        
        //press
        private void Form1_KeyDown(object sender, KeyEventArgs e){
            checkDownAndUpkeys(e, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)//no more pressing
        {
            checkDownAndUpkeys(e, false);
        }

        private void checkDownAndUpkeys(KeyEventArgs e, bool isDownAndUpBoolVar)
        {
            switch (e.KeyCode)
            {
                //case Keys.Oemcomma:/?, <- touch 
                //case Keys.Up:
                case Keys.Z:
                    player1.isUpPressed = isDownAndUpBoolVar;
                    break;

                case Keys.S:
                    player1.isDownPressed = isDownAndUpBoolVar;
                    break;

                case Keys.O:
                    player2.isUpPressed = isDownAndUpBoolVar;
                    break;

                case Keys.L:
                    player2.isDownPressed = isDownAndUpBoolVar;
                    break;
                    
                //case Keys.Down:
            }
        }

    }
}
