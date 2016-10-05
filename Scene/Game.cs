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
            enemyCompany = new Charactors.Enemy.Company(gameLayer, bulletCompany, shotCompany, player);

            gameLayer.AddObject(player);
            AddLayer(gameLayer);
        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Hold)
            {
                var shot1 = new Charactors.Shot(player.Position + new asd.Vector2DF(24, 0));
                var shot2 = new Charactors.Shot(player.Position + new asd.Vector2DF(-24, 0));
                gameLayer.AddObject(shot1);
                gameLayer.AddObject(shot2);
                shotCompany.Add(shot1);
                shotCompany.Add(shot2);
            }
            enemyCompany.Update();
        }

        asd.Layer2D gameLayer = new asd.Layer2D();
        Charactors.Player player = new Charactors.Player();
        Charactors.Enemy.Company enemyCompany;
        List<Charactors.Shot> shotCompany = new List<Charactors.Shot>();
        List<Charactors.Bullet.Bullet> bulletCompany = new List<Charactors.Bullet.Bullet>();

    }
}
