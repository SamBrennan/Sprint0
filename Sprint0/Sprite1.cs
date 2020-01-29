using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
	class Sprite1 : ISprite
	{
		private int currentFrame;
		private int totalFrames;
		private Game1 myGame;
		public Sprite1(Game1 game)
		{
			myGame = game;
			currentFrame = 0;
			totalFrames = 1;
		}
		public void Update()
		{
			currentFrame = (currentFrame + 1)%totalFrames;
		}
		public void Draw() {
			Rectangle source = new Rectangle(myGame.offsetx, myGame.offsety, myGame.spriteWidth, myGame.spriteHeight);
			Rectangle destination = new Rectangle(myGame.graphics.PreferredBackBufferWidth/2 - (myGame.spriteWidth * myGame.spriteScale)/2, myGame.graphics.PreferredBackBufferHeight / 2 - (myGame.spriteHeight * myGame.spriteScale) / 2, myGame.spriteWidth * myGame.spriteScale, myGame.spriteHeight * myGame.spriteScale);

			myGame.spriteBatch.Begin(SpriteSortMode.Deferred,
				BlendState.AlphaBlend, SamplerState.PointClamp,
				null, null, null, null);
			myGame.spriteBatch.Draw(myGame.spriteSheet, destination, source, Color.White);
			myGame.spriteBatch.End();
		}
	}
}
