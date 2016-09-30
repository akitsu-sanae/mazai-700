﻿/*=============================================================================
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
            enemyCompany = new Charactors.Enemy.Company(gameLayer, bulletCompany, player);

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
            enemyCompany.Update();
        }

        asd.Layer2D gameLayer = new asd.Layer2D();
        Charactors.Player player = new Charactors.Player();
        Charactors.Enemy.Company enemyCompany;
        List<Charactors.Bullet.Bullet> bulletCompany = new List<Charactors.Bullet.Bullet>();

    }
}
