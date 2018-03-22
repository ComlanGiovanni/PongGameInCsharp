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
        const int mouvementBarSpeed = 8, topMap = 1, bottomMap = 659;
        bool isUpPressedForPlayer1, isDowPressedForPlayer1, isUpPressedForPlayer2, isDowPressedForPlayer2;

        public Form1()
        {
            InitializeComponent();
        }

        private void theTimer_Tick(object sender, EventArgs e)
        {
            //bool? Mean that no value is not an option : 0 1 or bull            
            //barPlayer1.Location = new Point(barPlayer1.Location.X, barPlayer1.Location.Y + mouvementBarSpeed);

            mvmtForbothPlayer(barPlayer1, isUpPressedForPlayer1, isDowPressedForPlayer1);
            mvmtForbothPlayer(barPlayer2, isUpPressedForPlayer2, isDowPressedForPlayer2);
        }

        private void mvmtForbothPlayer(PictureBox barplayer, bool isUpPressed, bool isDownPressed)
        {
            bool? goingUpOrDown = null;

            if (isUpPressed)
            {//True is Up
                goingUpOrDown = true;
            }
            else if (isDownPressed)
            {//!goingUp.HasValue || !goingUp.Valu
                if (goingUpOrDown != null)
                {//goingUpOrDow.HasValue lol
                    goingUpOrDown = null;
                }
                else
                {
                    goingUpOrDown = false;
                }
            }

            barMovement(barplayer, goingUpOrDown);
        }

        private void barMovement(PictureBox barDeJeux, bool? goingUpOrDown)
        {
            if (goingUpOrDown.HasValue)
            {
                var speed = mouvementBarSpeed;//var auto signed
                if (goingUpOrDown.Value){
                    speed *= -1;
                }

                barDeJeux.Location = new Point(barDeJeux.Location.X,
                    Math.Max(topMap, Math.Min(bottomMap, barDeJeux.Location.Y + speed)));
            }      
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
                    isUpPressedForPlayer1 = isDownAndUpBoolVar;
                    break;

                case Keys.S:
                    isDowPressedForPlayer1 = isDownAndUpBoolVar;
                    break;

                case Keys.O:
                    isUpPressedForPlayer2 = isDownAndUpBoolVar;
                    break;

                case Keys.L:
                    isDowPressedForPlayer2 = isDownAndUpBoolVar;
                    break;
                    
                //case Keys.Down:
            }
        }

    }
}
