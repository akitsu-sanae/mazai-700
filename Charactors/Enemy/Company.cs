/*=============================================================================
  Copyright (c) 2016 akitsu sanae
  https://github.com/akitsu-sanae/mazai-700
  Distributed under the Boost Software License, Version 1.0. (See accompanying
  file LICENSE_1_0.txt or copy at http://www.boost.org/LICENSE_1_0.txt)
=============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700.Charactors.Enemy
{
    class Company
    {
        public Company(
            asd.Layer2D layer,
            List<Bullet.Bullet> bulletCompany,
            List<Shot> shotCompany,
            Player player)
        {
            this.layer = layer;
            this.bulletCompany = bulletCompany;
            this.shotCompany = shotCompany;
            this.player = player;

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
                        Add(new RedBird(new asd.Vector2DF(
                            Consts.Window.Width * x / enemyData.Width,
                            0), bulletCompany));
                    }
                }
            }
            counter++;

            foreach (var shot in shotCompany)
            {
                foreach (var enemy in enemies)
                {
                    if (enemy == null || shot == null)
                        continue;
                    if ((shot.Position - enemy.Position).Length < 32)
                    {
                        enemy.Hp--;
                        shot.Dispose();
                    }
                    if (enemy.Hp <= 0)
                        enemy.Dispose();
                }
            }
            enemies.RemoveAll(e => !e.IsAlive);
            shotCompany.RemoveAll(s => !s.IsAlive);
        }

        private asd.Layer2D layer;
        private List<Bullet.Bullet> bulletCompany;
        private List<Shot> shotCompany;
        private List<Enemy> enemies { get; set; } = new List<Enemy>();
        private Player player;
        private System.Drawing.Bitmap enemyData;
        int counter = 0;
    }
}
