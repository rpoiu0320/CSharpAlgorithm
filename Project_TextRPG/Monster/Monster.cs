using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public abstract class Monster
    {
        public char icom = '▼';
        public Position pos;

        public abstract void MoveAction();

        public void Move(Direction dir)
        {
            {
                Position prevPos = pos;
                // 플레이어 이동
                switch (dir)
                {
                    case Direction.Up:
                        pos.y--;
                        break;
                    case Direction.Down:
                        pos.y++;
                        break;
                    case Direction.Left:
                        pos.x--;
                        break;
                    case Direction.Right:
                        pos.x++;
                        break;
                }

                // 이동한 자리가 벽일 경우
                if (!Data.map[pos.y, pos.x])
                {
                    // 원위치 시키기
                    pos = prevPos;
                }
            }
        }
    }
}
