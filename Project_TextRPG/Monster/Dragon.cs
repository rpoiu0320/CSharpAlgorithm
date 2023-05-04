using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_TextRPG.Util;

namespace Project_TextRPG
{
    internal class Dragon : Monster
    {
        private int moveCount;
        public override void MoveAction()
        {
            if (moveCount++ % 2 != 0)
                return;

            List<Point> path;
            bool result = AStar.PathFinding(Data.map, new Point(pos.x, pos.y),
                new Point(Data.player.pos.x, Data.player.pos.y), out path);
            
            if (!result)
                return;


            if (path[1].y == pos.y - 1)
                Move(Direction.Up);
            else if(path[1].y == pos.y + 1)
                Move(Direction.Down);
            else if (path[1].x == pos.x - 1)
                Move(Direction.Left);
            else if (path[1].x == pos.x + 1)
                Move(Direction.Right);


        }
    }
}
