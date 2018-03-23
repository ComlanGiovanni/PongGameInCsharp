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
        int xSpeed = 3;
        int ySpeed = 3;

        public Ball(PictureBox theBall)
        {
            this.theBall = theBall;
        }
        
        //Method
        internal void mvmtForBall()
        {
            //throw new NotImplementedException();
            theBall.Location = new Point(theBall.Location.X + xSpeed, Math.Max(MapInfo.TOP_MAP, Math.Min(MapInfo.BOTTOM_MAP, barPlayer.Location.Y + speed)));
        }
    }
}
