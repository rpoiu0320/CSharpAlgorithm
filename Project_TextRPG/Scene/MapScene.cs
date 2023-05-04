using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {

        }

        public override void Render()
        {
            PritnMap();
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
            }

            // 플레이어 몬스터 접근
            Monster monsterInPos = Data.MonsterInPos(Data.player.pos);
            if(monsterInPos != null)
            {
                // 전투 시작
                game.BattleStart(monsterInPos);
                return;
            }


            // 몬스터 이동
            foreach (Monster monster in Data.monsters)
            {
                monster.MoveAction();
                if (monster.pos.x == Data.player.pos.x &&
                    monster.pos.y == Data.player.pos.y)
                {
                    // 전투시작
                    return;
                }
            }
        }
        private void PritnMap()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Data.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append(' ');
                    else
                        sb.Append('X');

                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Monster monster in Data.monsters)
            {
                Console.SetCursorPosition(monster.pos.x, monster.pos.y);
                Console.Write(monster);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.pos.x, Data.player.pos.y);
            Console.WriteLine(Data.player.icon);
        }
    }
}
