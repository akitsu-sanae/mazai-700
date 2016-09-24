using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazai_700
{
    static class Resource
    {
        static public asd.Texture2D Font { get; set; }

        static public void Init()
        {
            Font = asd.Engine.Graphics.CreateTexture2D("Resource/font.png");
        }
    }
}
