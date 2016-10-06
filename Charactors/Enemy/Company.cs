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
            Charactors.Bullet.Company bulletCompany,
            Charactors.Shot.Company shotCompany,
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
            Enemies.Add(enemy);
            layer.AddObject(enemy);
        }

        public void Update()
        {
            if (counter % 32 == 0 && counter/32 < enemyData.Height)
            {
                for (int x = 0; x < enemyData.Width; x++)
                {
                    var r = enemyData.GetPixel(x, counter / 32).R;
                    if (r == 255)
                    {
                        Add(new RedBird(new asd.Vector2DF(
                            Consts.Window.Width * x / enemyData.Width,
                            0), bulletCompany));
                    }
                    else if (r == 200)
                    {
                        Add(new Mosquit(
                            new asd.Vector2DF(Consts.Window.Width * x / enemyData.Width, 0),
                            bulletCompany, player));
                    }
                    else if (r == 150)
                    {
                        Add(new Baasi(
                            new asd.Vector2DF(Consts.Window.Width / 2, 0),
                            bulletCompany, player));
                    }
                }
            }
            counter++;

            Enemies.RemoveAll(e => !e.IsAlive);
        }
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();

        private asd.Layer2D layer;
        private Charactors.Bullet.Company bulletCompany;
        private Charactors.Shot.Company shotCompany;
        private Player player;
        private System.Drawing.Bitmap enemyData;
        int counter = 0;
    }
}
