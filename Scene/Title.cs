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

namespace mazai_700.Scene
{
    class Title : asd.Scene
    {
        public Title()
        {
            var layer = new asd.Layer2D();

            var title = new Charactors.Charactor();
            title.Position = new asd.Vector2DF(320, 180);
            titleGraph = new Charactors.Charactor.Graph(
                new asd.Color(255, 255, 255),
                "#\\ /#    ####/    ####/ #### ####",
                "# V #      /         #  #  # #  #",
                "#   # A  /#### AI   #   #### ####");
            title.AddGraph(titleGraph);
            layer.AddObject(title);

            var label = new Charactors.Charactor();
            label.Position = new asd.Vector2DF(320, 300);
            label.AddGraph(new Charactors.Charactor.Graph(
                new asd.Color(255, 255, 255),
                "Press Z Key to Start Game!"));
            layer.AddObject(label);

            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            counter += 0.3;
            titleGraph.SetColor(new asd.Color((byte)(255/counter), (byte)(255/counter), (byte)(255 - 255/counter)));

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                asd.Engine.ChangeScene(new Scene.Game());
        }

        private double counter = 1;
        Charactors.Charactor.Graph titleGraph;
    }
}
