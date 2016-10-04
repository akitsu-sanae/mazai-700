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
using C = mazai_700.Charactors.Charactor.Char;
namespace mazai_700.Scene
{
    class Title : asd.Scene
    {
        public Title()
        {
            var layer = new asd.Layer2D();

            var title = new Charactors.Charactor();
            title.Position = new asd.Vector2DF(160, 100);

            var line0 = new Charactors.Charactor.Graph(
                new asd.Color(255, 255, 255), new int[,] { {
                        (int)C.Triangle2, ' ', ' ', (int)C.Triangle1, ' ',
                        (int)C.Triangle1, (int)C.Block, (int)C.Block, ' ',
                        (int)C.Triangle1, (int)C.Block, (int)C.Block, (int)C.Triangle4, ' ',
                        (int)C.Triangle1, (int)C.Block, (int)C.Block, ' ',
                        (int)C.Triangle1, (int)C.Block, (int)C.Block
                }});
            line0.Position = new asd.Vector2DF(100, 0);
            title.AddGraph(line0);
            var line1 = new Charactors.Charactor.Graph(
                new asd.Color(120, 120, 120), new int[,] {{
                        (int)C.Block, (int)C.Triangle3, (int)C.Triangle4, (int)C.Block, ' ',
                        (int)C.Block, ' ', (int)C.Block, ' ',
                        ' ', ' ', (int)C.Triangle1, ' ', ' ',
                        (int)C.Block, ' ', (int)C.Block, ' ',
                        ' ', (int)C.Block, ' '
                    }});
            line1.Position = new asd.Vector2DF(100, Consts.CharSize.Y);
            title.AddGraph(line1);
            var line2 = new Charactors.Charactor.Graph(
                new asd.Color(255, 255, 255), new int[,] {{ ' ',
                        (int)C.Block, ' ', ' ', (int)C.Block, ' ',
                        (int)C.Block, (int)C.Triangle3, (int)C.Block, ' ',
                        ' ', (int)C.Triangle4, ' ', ' ', ' ',
                        (int)C.Block, (int)C.Triangle3, (int)C.Block, ' ',
                        ' ', (int)C.Block, ' ', ' '
                    }});
            line2.Position = new asd.Vector2DF(100, 2 * Consts.CharSize.Y);
            title.AddGraph(line2);
            var line3 = new Charactors.Charactor.Graph(
                new asd.Color(255, 255, 255), new int[,] { {
                        (int)C.Block, ' ', ' ', (int)C.Block, ' ',
                        (int)C.Block, ' ', (int)C.Block, ' ',
                        (int)C.Triangle1, (int)C.Block, (int)C.Block, (int)C.Triangle2, ' ',
                        (int)C.Block, ' ', (int)C.Block, ' ',
                        (int)C.Block, (int)C.Block, (int)C.Block
                    }});
            line3.Position = new asd.Vector2DF(100, 3 * Consts.CharSize.Y);
            title.AddGraph(line3);

            var seven = new Charactors.Charactor.Graph(
                new asd.Color(255, 255, 255), new int[,] {
                    { (int)C.Block, (int)C.Block, (int)C.Block, (int)C.Triangle4},
                    { ' ', ' ', (int)C.Triangle1, ' ' },
                    { ' ', ' ', (int)C.Block, ' '},
                    { ' ', ' ', (int)C.Triangle4, ' '}
                });
            seven.Position = new asd.Vector2DF(9 * Consts.CharSize.X, 8 * Consts.CharSize.Y);
            title.AddGraph(seven);

            var zero = new Charactors.Charactor.Graph(
                new asd.Color(255, 255, 255), new int[,] {
                    { (int)C.Triangle1, (int)C.Block, (int)C.Block},
                    { (int)C.Block, ' ', (int)C.Block},
                    { (int)C.Block, ' ', (int)C.Block},
                    { (int)C.Block, (int)C.Block, (int)C.Block}
                });
            zero.Position = new asd.Vector2DF(13 * Consts.CharSize.X, 8 * Consts.CharSize.Y);
            title.AddGraph(zero);

            var zero_ = new Charactors.Charactor.Graph(zero);
            zero_.Position = new asd.Vector2DF(17 * Consts.CharSize.X, 8 * Consts.CharSize.Y);
            title.AddGraph(zero_);

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
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                asd.Engine.ChangeScene(new Scene.Game());
        }
    }
}
