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

namespace mazai_700.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            shotCompany = new Charactors.Shot.Company(gameLayer, player);
            enemyCompany = new Charactors.Enemy.Company(gameLayer, bulletCompany, shotCompany, player);

            gameLayer.AddObject(player);
            AddLayer(gameLayer);
        }

        protected override void OnUpdated()
        {
            shotCompany.Update();
            enemyCompany.Update();
            CollisionShotsAndEnemies();
            CollisionBulletAndPlayer();

            bulletCompany.RemoveAll(bullet => !bullet.IsAlive);

            if (player.Hp < 0)
                asd.Engine.ChangeScene(new Scene.Title());
        }

        private void CollisionShotsAndEnemies()
        {
            foreach (var shot in shotCompany.Shots)
            {
                foreach (var enemy in enemyCompany.Enemies)
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
        }

        private void CollisionBulletAndPlayer()
        {
            foreach (var bullet in bulletCompany)
            {
                if ((player.Position - bullet.Position).Length < 32)
                {
                    player.Hp--;
                    bullet.Dispose();
                }
            }
        }

        asd.Layer2D gameLayer = new asd.Layer2D();
        Charactors.Player player = new Charactors.Player();
        Charactors.Enemy.Company enemyCompany;
        Charactors.Shot.Company shotCompany;
        List<Charactors.Bullet.Bullet> bulletCompany = new List<Charactors.Bullet.Bullet>();

    }
}
