using System;
using System.Drawing;
using System.Windows.Forms;

namespace pongGame
{
    public class Player
    {
        //CAPS
        const int MVMT_BAR_SPEED = 8;

        private PictureBox barPlayer;

        public bool isUpPressed, isDownPressed;//can be acces in other file    

        bool? accelerationPlayer;
        int nbrTickAccSameDir;
        

        //constructeur
        public Player(PictureBox barPlayer1)
        {
            this.barPlayer = barPlayer1;
        }

        internal void mvmtForPlayer()
        { //throw new NotImplementedException();
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

            if (accelerationPlayer.HasValue)
            {
                if (!goingUpOrDown.HasValue)
                {
                    accelerationPlayer = null;
                    nbrTickAccSameDir = 0;
                }
                else if (accelerationPlayer.Value == goingUpOrDown.Value)
                {
                    nbrTickAccSameDir++;
                }
                else
                {
                    accelerationPlayer = goingUpOrDown;
                    nbrTickAccSameDir = 1;
                }
            }
            else if (goingUpOrDown.HasValue)
            {
                accelerationPlayer = goingUpOrDown;
                nbrTickAccSameDir = 1;
            }

            barMovement(goingUpOrDown);
        }

        private void barMovement(bool? goingUpOrDown)
        {
            if (goingUpOrDown.HasValue)
            {

                //var speed = mouvementBarSpeed * (nbrTickAccPlayer / 10);//var auto signed
                var speed = (int)Math.Round(MVMT_BAR_SPEED * ((float)nbrTickAccSameDir / 10));
                if (goingUpOrDown.Value)
                {
                    speed *= -1;
                }

                barPlayer.Location = new Point(barPlayer.Location.X,
                    Math.Max(MapInfo.TOP_MAP, Math.Min(MapInfo.BOTTOM_MAP - barPlayer.Height, barPlayer.Location.Y + speed)));
            }
        }

    }
}
