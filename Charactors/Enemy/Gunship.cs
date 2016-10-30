using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = mazai_700.Charactors.Charactor.Char;

namespace mazai_700.Charactors.Enemy
{
    class Gunship : Enemy
    {
        public Gunship(asd.Vector2DF pos, Bullet.Company bulletCompany) :
            base(pos, bulletCompany)
        {
            AddGraph(new Graph(new asd.Color(200, 64, 64), new int[,] {
                { ' ', ' ', (int)C.Triangle1, (int)C.Triangle2, ' ', ' ' },
                { ' ', ' ', (int)C.Triangle3, (int)C.Triangle4, ' ', ' ' },
                { ' ', (int)C.Slash1, '[', ']', (int)C.Slash2, ' ' },
                { (int)C.Slash1, ' ', (int)C.Slash2, (int)C.Slash1, ' ', (int)C.Slash2 },
                { (int)C.Triangle3, (int)C.Triangle3, (int)C.Triangle1, (int)C.Triangle2, (int)C.Triangle4, (int)C.Triangle4 },
                { ' ', (int)C.Triangle2, (int)C.Triangle3, (int)C.Triangle4, (int)C.Triangle1, ' ' },
                { ' ', (int)C.Triangle3, (int)C.Triangle2, (int)C.Triangle1, (int)C.Triangle4, ' ' },
                { ' ', ' ', (int)C.Triangle3, (int)C.Triangle4, ' ', ' ' }
            }));
            base.OnUpdate();
        }

        protected override void OnUpdate()
        {
            counter++;
            Position = Position + new asd.Vector2DF(0.0f, 2.0f);
            base.OnUpdate();
        }
        int counter = 0;
    }
}
