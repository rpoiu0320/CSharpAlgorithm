using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Game
    {
        private bool isRunning = true;

        private Scene           curScene;
        // private Dictionary<string, Scene> sceneDic;
        private MainMenuScene   mainMenuScene;
        private MapScene        mapScene;
        private InventoryScene  inventoryScene;
        private BattleScene     battleScene;

        public void Run()
        {
            // 초기화
            Init();

            // 게임 루프
            while(isRunning)
            {
                // 랜더링
                Render();

                // 갱신
                Update();
            }

            // 마무리
            Release();
        }

        private void Init()
        {
            Console.CursorVisible = false;
            Data.Init();
            /*sceneDic.Add("메인메뉴", new MainMenuScene(this));
            sceneDic.Add("맵", new MapScene(this));
            sceneDic.Add("인벤토리", new InventoryScene(this));
            sceneDic.Add("배틀", new BattleScene(this));*/

            mainMenuScene =     new MainMenuScene(this);
            mapScene =          new MapScene(this);
            inventoryScene =    new InventoryScene(this);
            battleScene =       new BattleScene(this);

            curScene = mainMenuScene;
        }

        public void GameStart()
        {
            Data.LodeLevel();
            curScene = mapScene;
        }

        public void GameOver()
        {
            isRunning = false;
        }

        public void BattleStart(Monster monster) 
        {
            curScene = battleScene;
        }

        private void Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            curScene.Render();
        }

        private void Update()
        {
            curScene.Update();
        }

        private void Release()
        {
      
        }
    }
}
