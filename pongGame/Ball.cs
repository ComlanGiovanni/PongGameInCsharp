using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pongGame
{
    class Ball
    {
        //constructor
        private PictureBox theBall;
        Player playerSideLeft, playerSideRight;

        int xSpeed , ySpeed;

        // the player object
        public Ball(PictureBox theBall, Player playerSideLeft, Player playerSideRight)
        {
            this.theBall = theBall;
            this.playerSideLeft = playerSideLeft;
            this.playerSideRight = playerSideRight;
            xSpeed = 3;
            ySpeed = 3;
        }
        
        //Method
        internal void mvmtForBall()
        {
            var bottomMap = MapInfo.BOTTOM_MAP - theBall.Height;
            //throw new NotImplementedException();
            theBall.Location = new Point(theBall.Location.X + xSpeed,
                    Math.Max(MapInfo.TOP_MAP, Math.Min(bottomMap, theBall.Location.Y + ySpeed)));

            if (theBall.Location.Y == bottomMap || theBall.Location.Y  == MapInfo.TOP_MAP)// | always check the second one
            {
                ySpeed *= -1;
            }

            // if(theBall.Location.X ==  MapInfo.leftMap || theBall.Location.Y == MapInfo.rigthMap - theBall.Width)
            if (theBall.Location.X ==  MapInfo.leftMap)
            {
                //Method
                score(playerSideLeft);
            } else if (theBall.Location.Y == MapInfo.rigthMap - theBall.Width) {
                score(playerSideRight);
            }

        }

        private void score(Player playerLeftorRightWin)
        {
            playerLeftorRightWin.score++;
            theBall.Location = new Point((MapInfo.leftMap + MapInfo.rigthMap) / 2, (MapInfo.BOTTOM_MAP + MapInfo.TOP_MAP) / 2);
           // throw new NotImplementedException();
        }
    }
}
