﻿using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class FlashingRuby : IItem, ICollidable
    {
        public Vector2 Position { get; set; }

        ISprite sprite;
        public bool isMover => false;

        public FlashingRuby(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("flashingRuby");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 16);
        }
    }
}