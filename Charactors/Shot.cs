using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700.Charactors
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
            Position += new asd.Vector2DF(0, -5);
            if (Position.X < -32 || Consts.Window.Width < Position.X + 32 ||
                Position.Y < -32 || Consts.Window.Height < Position.Y + 32)
                Dispose();
        }
    }
}
