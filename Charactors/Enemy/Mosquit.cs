using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700.Charactors.Enemy
{
    class Mosquit : Enemy
    {
        public Mosquit(asd.Vector2DF pos, Bullet.Company bulletCompany, Player player) :
            base(pos, bulletCompany)
        {
            this.player = player;
            AddGraph(new Graph(new asd.Color(200, 100, 0),
                "[+]",
                " |"));
            base.OnUpdate();
        }

        protected override void OnUpdate()
        {
            counter++;
            if (counter < 100)
                speed = (player.Position - Position).Normal * 2;
            Position += speed;
            base.OnUpdate();
        }
        Player player;
        asd.Vector2DF speed = new asd.Vector2DF();
        int counter = 0;
    }
}
