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

namespace mazai_700.Charactors.Shot
{
    class Company
    {
        public Company(asd.Layer2D layer, Player player)
        {
            this.layer = layer;
            this.player = player;
        }

        public void Update()
        {
            counter = (counter + 1) % 60;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Hold && counter % 6 == 0)
            {
                var angle = Math.Cos(2 * Math.PI * counter / 60) * Math.PI / 3.0 + Math.PI / 2;
                var d = new asd.Vector2DF((float)Math.Cos(angle), (float)Math.Sin(angle)) * 64;
                d.Y *= -1;
                var shot1 = new Shot(player.Position + d);
                d.X *= -1;
                var shot2 = new Shot(player.Position + d);
                layer.AddObject(shot1);
                layer.AddObject(shot2);
                Add(shot1);
                Add(shot2);
            }

            Shots.RemoveAll(s => !s.IsAlive);
        }

        private void Add(Shot shot)
        {
            Shots.Add(shot);
            Shots.Add(shot);
        }
        public List<Shot> Shots { get; set; } = new List<Shot>();
        private asd.Layer2D layer;
        private Player player;
        int counter = 0;
    }
}
