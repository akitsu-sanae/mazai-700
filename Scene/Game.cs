using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            gameLayer.AddObject(player);
            AddLayer(gameLayer);
        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                gameLayer.AddObject(new Charactors.Shot(player.Position + new asd.Vector2DF(24, 0)));
                gameLayer.AddObject(new Charactors.Shot(player.Position + new asd.Vector2DF(-24, 0)));
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.X) == asd.KeyState.Push)
            {
                gameLayer.AddObject(new Charactors.Enemy.Enemy(new asd.Vector2DF(100, 100), bulletCompany));
            }

        }

        asd.Layer2D gameLayer = new asd.Layer2D();
        Charactors.Player player = new Charactors.Player();
        List<Charactors.Bullet.Bullet> bulletCompany = new List<Charactors.Bullet.Bullet>();

    }
}
