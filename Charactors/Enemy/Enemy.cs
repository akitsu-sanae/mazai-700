using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700.Charactors.Enemy
{
    class Enemy : Charactor
    {
        public Enemy(asd.Vector2DF pos)
        {
            Position = pos;
            AddGraph(new Graph(new asd.Color(255, 0, 0), 
                "<+>",
                "^T^"));
             
            base.OnUpdate();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Position += new asd.Vector2DF(0, 1);
            if (Position.X < -32 || Consts.Window.Width < Position.X + 32 ||
                Position.Y < -32 || Consts.Window.Height < Position.Y + 32)
                Dispose();
        }
    }
}
