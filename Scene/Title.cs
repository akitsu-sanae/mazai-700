using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700.Scene
{
    class Title : asd.Scene
    {
        public Title()
        {
            var layer = new asd.Layer2D();
            layer.AddObject(new Charactors.Player());

            var title = new Charactors.Charactor();
            title.Position = new asd.Vector2DF(50, 100);
            title.AddGraph(new Charactors.Charactor.Graph(
                new asd.Color(255, 255, 255),
                "#\\ /#    ####/    ####/ #### ####",
                "# V #      /         #  #  # #  #",
                "#   # A  /#### AI   #   #### ####"));
            layer.AddObject(title);
            layer.AddObject(new Charactors.Charactor());
            AddLayer(layer);
        }
    }
}
