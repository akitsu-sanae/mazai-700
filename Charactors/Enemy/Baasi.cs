using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700.Charactors.Enemy
{
    class Baasi : Enemy
    {
        public Baasi(asd.Vector2DF pos, Bullet.Company bulletCompany, Player player) :
            base(pos, bulletCompany)
        {
            this.player = player;
            AddGraph(new Graph(new asd.Color(200, 50, 100),
                "==-=;          _--[+]         [+]  |+   ",
                "      [_+_]~~^^    |           |   +==--",
                "-----   |     -----------               ",
                "     \\-=|===-/           \\-=|=----=|=---"));
            base.OnUpdate();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Position = new asd.Vector2DF(Consts.Window.Width / 2, Consts.CharSize.Y * 3) * 0.01f + this.Position * 0.99f;
        }
        Player player;
    }
}
