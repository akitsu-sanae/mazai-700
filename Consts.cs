﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700
{
    static class Consts
    {
        static public class Window
        {
            public const int Width = 640;
            public const int Height = 480;
            static public asd.Vector2DI Size { get; } = new asd.Vector2DI(Width, Height);
        }
        static public readonly asd.Vector2DF FontSize = new asd.Vector2DF(8, 8);
        static public readonly asd.Vector2DF CharSize = new asd.Vector2DF(
            Window.Width / Row,
            Window.Height / Col);
        public const int Row = 40;
        public const int Col = 25;
    }
}
