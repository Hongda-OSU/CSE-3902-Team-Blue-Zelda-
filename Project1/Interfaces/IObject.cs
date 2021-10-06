﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Interfaces
{
    public interface IObject
    {
        public void Draw(SpriteBatch spriteBatch) { }

        public void Update() { }

    }
}
