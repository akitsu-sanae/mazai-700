using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700.Charactors.Enemy
{
    class Company
    {
        public Company(asd.Layer2D layer, List<Charactors.Bullet.Bullet> bulletCompany)
        {
            this.layer = layer;
            this.bulletCompany = bulletCompany;
        }

        public void Add(Enemy enemy)
        {
            enemies.Add(enemy);
            layer.AddObject(enemy);
        }

        public void Update()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.X) == asd.KeyState.Push)
            {
                Add(new Charactors.Enemy.Enemy(new asd.Vector2DF(100, 100), bulletCompany));
            }
        }
        private asd.Layer2D layer;
        private List<Charactors.Bullet.Bullet> bulletCompany;
        private List<Enemy> enemies = new List<Enemy>();
    }
}
