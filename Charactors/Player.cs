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
            Position += diff;
            base.OnUpdate();
        }
    }
}
