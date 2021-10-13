﻿using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.Controllers;
using Project1.Enemy;
using Project1.NPC;
using Project1.Interfaces;
using Project1.Sprites;
using Project1.Objects;

namespace Project1
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public GameObjectManager gameObjectManager;

        // These objects are only for sprint 2 
        public CyclableBlock cyclableBlock;
        public CyclableItem cyclableItem;
        public CyclableEnemy cyclableEnemy;
       
        private Vector2 position;
        private Vector2 enemyPosition;
        private List<IEnemy> enemyList;

        private ArrayList controllerList;

        private Viewport ViewPort => graphics.GraphicsDevice.Viewport;
        public int SCREEN_WIDTH => ViewPort.Width;
        public int SCREEN_HEIGHT => ViewPort.Height;

        public Texture2D spriteSheet;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            position = new Vector2(SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2);
            enemyPosition = new Vector2(SCREEN_WIDTH / 4 * 3, SCREEN_HEIGHT / 4 * 3);
            controllerList = new ArrayList
            {
                new KeyboardController(this),
                new MouseController(this)
            };

            base.Initialize();
        }

        void Setup()
        {
            // SPECIFIC TO SPRINT 2
            GameObjectManager.Instance.Add(new Player(position));
            
            enemyList = new List<IEnemy> { new Stalfos(enemyPosition), new RedGloriya(enemyPosition), 
                        new BlueGel(enemyPosition), new BlueBat(enemyPosition), new Aquamentus(enemyPosition),
                        new OldMan(enemyPosition)};

            cyclableEnemy = new CyclableEnemy(enemyList);
            cyclableBlock = new CyclableBlock(new Vector2(position.X - 100, position.Y));
            cyclableItem = new CyclableItem(new Vector2(position.X - 200, position.Y));

            GameObjectManager.Instance.Add(cyclableEnemy);
            GameObjectManager.Instance.Add(cyclableBlock);
            GameObjectManager.Instance.Add(cyclableItem);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFactory.Instance.LoadAllFonts(Content);

            Setup();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            GameObjectManager.Instance.UpdateObjects();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            GameObjectManager.Instance.DrawObjects(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reset() 
        {
            Setup();
        }
    }
}
