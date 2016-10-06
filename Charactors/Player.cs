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

namespace mazai_700.Charactors
{
    class Player : Charactor
    {
        public Player()
        {
            Position = new asd.Vector2DF(320, 240);
            AddGraph(new Graph(new asd.Color(0, 0, 255),
                "  |  ",
                "  | ",
                " + + "));
            AddGraph(new Graph(new asd.Color(0, 50, 255),
                "     ",
                " [ ] ",
                "/ o \\"));
        }
        protected override void OnUpdate()
        {
            var diff = new asd.Vector2DF();
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
                diff.Y -= 4;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
                diff.Y += 4;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
                diff.X -= 4;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
                diff.X += 4;
            var pos = Position += diff;
            if (pos.X < 0)
                pos.X = 0;
            if (pos.X > Consts.Window.Width)
                pos.X = Consts.Window.Width;
            if (pos.Y < 0)
                pos.Y = 0;
            if (pos.Y > Consts.Window.Height)
                pos.Y = Consts.Window.Height;
            Position = pos;
            base.OnUpdate();
        }

        public int Hp { get; set; } = 3;
    }
}
