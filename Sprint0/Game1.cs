using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		private SpriteFont font;
		private List<IController> controllerList;
		public GraphicsDeviceManager graphics;
		public SpriteBatch spriteBatch;
		public ISprite sprite;
		public Texture2D spriteSheet;
		public int spriteWidth;
		public int spriteHeight;
		public int spriteScale;
		public int offsetx;
		public int offsety;
		public int space;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			Window.AllowUserResizing = true;
			//graphics.ToggleFullScreen();
			IsMouseVisible = true;
			sprite = new Sprite1(this);
			spriteWidth = 16;
			spriteHeight = 16;
			spriteScale = 6;
			offsetx = 7;
			offsety = 16;
			space = 5;
			//this.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
			//graphics.PreferMultiSampling = false;
			KeyboardController kbcntrl = new KeyboardController();
			MouseController mcntrl = new MouseController(graphics);

			ICommand[] commandlist = { new ExitCommand(this), new ChangeSprite1(this), new ChangeSprite2(this), new ChangeSprite3(this), new ChangeSprite4(this) };

			kbcntrl.mapCommand(Keys.D0, commandlist[0]);
			kbcntrl.mapCommand(Keys.D1, commandlist[1]);
			kbcntrl.mapCommand(Keys.D2, commandlist[2]);
			kbcntrl.mapCommand(Keys.D3, commandlist[3]);
			kbcntrl.mapCommand(Keys.D4, commandlist[4]);
			kbcntrl.mapCommand(Keys.NumPad0, commandlist[0]);
			kbcntrl.mapCommand(Keys.NumPad1, commandlist[1]);
			kbcntrl.mapCommand(Keys.NumPad2, commandlist[2]);
			kbcntrl.mapCommand(Keys.NumPad3, commandlist[3]);
			kbcntrl.mapCommand(Keys.NumPad4, commandlist[4]);

			mcntrl.mapMouse(commandlist);

			controllerList = new List<IController>
			{
				kbcntrl,
				mcntrl
			};

			font = Content.Load<SpriteFont>("Font");

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			spriteSheet = Content.Load<Texture2D>("bubblebobble");

		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			foreach (IController ctrl in controllerList) {
				ctrl.Update();
			}

			sprite.Update();

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			sprite.Draw();

			spriteBatch.Begin();
			spriteBatch.DrawString(font, "Credits:\nProgram Made By: Sam Brennan\nSprites From: https://www.spriters-resource.com/arcade/bublbobl/sheet/14077/", new Vector2(0, graphics.PreferredBackBufferHeight - font.LineSpacing * 3), Color.Black);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
