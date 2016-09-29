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

namespace mazai_700.Charactors.Enemy
{
    class Enemy : Charactor
    {
        public Enemy(asd.Vector2DF pos, List<Bullet.Bullet> bulletCompany)
        {
            Position = pos;
            this.bulletCompany = bulletCompany;
            AddGraph(new Graph(new asd.Color(255, 0, 0), 
                " + ",
                "^T^"));
            AddGraph(new Graph(new asd.Color(50, 0, 0),
                 "< >",
                 "   "));

            base.OnUpdate();
        }

        protected override void OnUpdate()
        {
            counter = (counter + 1) % 30;
            if (counter == 0)
            {
                var bullet = new Bullet.Bullet(Position);
                this.Layer.AddObject(bullet);
                bulletCompany.Add(bullet);
            }
            base.OnUpdate();
            Position += new asd.Vector2DF(0, 1);
            if (Position.X < -32 || Consts.Window.Width < Position.X + 32 ||
                Position.Y < -32 || Consts.Window.Height < Position.Y + 32)
                Dispose();
        }

        private List<Bullet.Bullet> bulletCompany;
        int counter = 0;
    }
}
