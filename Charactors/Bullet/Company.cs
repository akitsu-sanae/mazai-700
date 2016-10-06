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

namespace mazai_700.Charactors.Bullet
{
    class Company
    {
        public Company(asd.Layer2D layer)
        {
            this.layer = layer;
        }

        public void Update()
        {
            Bullets.RemoveAll(bullet => !bullet.IsAlive);
        }

        public void Add(Bullet bullet)
        {
            Bullets.Add(bullet);
            Bullets.Add(bullet);
        }
        public List<Bullet> Bullets { get; set; } = new List<Bullet>();
        private asd.Layer2D layer;
    }
}
