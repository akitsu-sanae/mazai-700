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
    class Charactor : asd.MapObject2D
    {
        public void AddGraph(Graph graph)
        {
            graphs.Add(graph);
            graph.Parent = this;
            foreach (var chip in graph.Charas)
                AddChip(chip.Value);
        }

        protected override void OnUpdate()
        {
            foreach (var graph in graphs)
                graph.Update();
        }

        List<Graph> graphs = new List<Graph>();
        public new asd.Vector2DF Position { get; set; } = new asd.Vector2DF();

        public class Graph
        {
            public Graph(asd.Color color, params string[] lines)
            {
                for (int y = 0; y < lines.Length; y++)
                {
                    var line = lines[y];
                    for (int x = 0; x < line.Length; x++)
                        AddChip(x, y, color, line[x]);
                }
            }
            public Graph(asd.Color color, int[,] lines)
            {
                for (int y = 0; y < lines.GetLength(0); y++)
                {
                    for (int x = 0; x < lines.GetLength(1); x++)
                        AddChip(x, y, color, lines[y, x]);
                }
            }
            public void Update()
            {
                var pos = new asd.Vector2DF(
                    (int)(Parent.Position.X / Consts.CharSize.X ) * Consts.CharSize.X,
                    (int)(Parent.Position.Y / Consts.CharSize.Y)  * Consts.CharSize.Y);

                var size = new asd.Vector2DI();
                foreach (var chara in Charas)
                {
                    size.X = Math.Max(size.X, chara.Key.Item1);
                    size.Y = Math.Max(size.Y, chara.Key.Item2);
                }
                pos -= new asd.Vector2DF(
                    Consts.CharSize.X * size.X,
                    Consts.CharSize.Y * size.Y) / 2;

                foreach(var c in Charas)
                {
                    c.Value.Position = new asd.Vector2DF(
                        pos.X + c.Key.Item1 * Consts.CharSize.X,
                        pos.Y + c.Key.Item2 * Consts.CharSize.Y
                        );
                }
            }
            public Dictionary<Tuple<int, int>, asd.Chip2D> Charas { get; set; } = new Dictionary<Tuple<int, int>, asd.Chip2D>();
            public Charactor Parent { get; set; }

            private void AddChip(int x, int y, asd.Color color, int c)
            {
                var chip = new asd.Chip2D();
                chip.Texture = Resource.Font;
                chip.Scale = new asd.Vector2DF(
                    Consts.CharSize.X / Consts.FontSize.X,
                    Consts.CharSize.Y / Consts.FontSize.Y);
                chip.Color = color;
                chip.Position = new asd.Vector2DF(x * Consts.CharSize.X, y * Consts.CharSize.Y);
                c -= ' ';
                float diffX = (c % 16) * Consts.FontSize.X;
                float diffY = (c / 16) * Consts.FontSize.Y;
                chip.Src = new asd.RectF(diffX, diffY, Consts.FontSize.X, Consts.FontSize.Y);
                Charas.Add(new Tuple<int, int>(x, y), chip);
            }
        }

        public enum Char :int
        {
            Triangle1 = '~' + 2,
            Triangle2,
            Block,
            Block2,
            BlockRight1,
            BlockRight2,
            BlockRight3,
            BlockLeft1,
            BlockLeft2,
            BlockLeft3,
            BlockUp1,
            BlockUp2,
            BlockUp3,
            BlockDown1,
            BlockDown2,
            BlockDown3,
            Triangle3,
            Triangle4,
            BigFrameLeftTop,
            BigFrameTop,
            BigFrameRightTop,
            Cross,
            Slash1,
            Slash2,
            Ball,
            UFO,
            Bullet1,
            Bullet2,
            Sword,
            Shield,
            Gun,
            Heart,
            Reserved1,
            Reserved2,
            BigFrameLeft,
            SmallFrame,
            BigFrameRight,
            BoxTopLeft,
            BoxTopRight,
            BoxBottomRight,
            BoxBottomLeft,
            ArrowUp,
            ArrowDown,
            ArrowLeft,
            ArrowRight
        }
    }
}
