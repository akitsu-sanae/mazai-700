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
    class Bullet : Charactor
    {
        public Bullet(asd.Vector2DF pos)
        {
            Position = pos;
            AddGraph(new Graph(new asd.Color(0, 255, 0),
                "|"));

            base.OnUpdate();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Position += new asd.Vector2DF(0, 5);
            if (Position.X < -32 || Consts.Window.Width < Position.X + 32 ||
                Position.Y < -32 || Consts.Window.Height < Position.Y + 32)
                Dispose();
        }
    }
}
