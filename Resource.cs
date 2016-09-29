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
