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

namespace mazai_700.Charactors.Shot
{
    class Shot : Charactor
    {
        public Shot(asd.Vector2DF pos)
        {
            Position = pos;
            AddGraph(new Graph(new asd.Color(255, 255, 255), ":"));
            base.OnUpdate();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Position += Speed;
            Position += new asd.Vector2DF(0, -5);
            if (Position.X < -32 || Consts.Window.Width < Position.X + 32 ||
                Position.Y < -32 || Consts.Window.Height < Position.Y + 32)
                Dispose();
        }

        public asd.Vector2DF Speed { get; set; } = new asd.Vector2DF();
    }
}
