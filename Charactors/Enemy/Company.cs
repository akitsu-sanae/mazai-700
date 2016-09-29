﻿using System;
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

            enemyData = new System.Drawing.Bitmap("Resource/enemy.bmp");
        }

        public void Add(Enemy enemy)
        {
            enemies.Add(enemy);
            layer.AddObject(enemy);
        }

        public void Update()
        {
            if (counter % 32 == 0 && counter/32 < enemyData.Height)
            {
                for (int x = 0; x < enemyData.Width; x++)
                {
                    if (enemyData.GetPixel(x, counter / 32).R == 255)
                    {
                        Add(new Enemy(new asd.Vector2DF(
    Consts.Window.Width * x / enemyData.Width,
    0), bulletCompany));
                    }
                }
            }
            counter++;
        }
        private asd.Layer2D layer;
        private List<Charactors.Bullet.Bullet> bulletCompany;
        private List<Enemy> enemies = new List<Enemy>();
        private System.Drawing.Bitmap enemyData;
        int counter = 0;
    }
}
