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
	class Sprite4 : ISprite
	{
		private int delayFrame;
		private int totalDelay;
		private int currentFrame;
		private int totalFrames;
		private int xPos;
		
		private Game1 myGame;
		public Sprite4(Game1 game)
		{
			myGame = game;
			currentFrame = 0;
			totalFrames = 5;
			delayFrame = 0;
			totalDelay = 8;
			xPos = myGame.graphics.PreferredBackBufferWidth / 2 - (myGame.spriteWidth * myGame.spriteScale) / 2;
		}
		public void Update()
		{
			delayFrame++;
			if (delayFrame == totalDelay)
			{
				currentFrame = (currentFrame + 1) % totalFrames;
				delayFrame = 0;
			}
			xPos = (xPos - 1);
			if (xPos == -(myGame.spriteWidth * myGame.spriteScale)) {
				xPos = myGame.graphics.PreferredBackBufferWidth;
			}
		}
		public void Draw()
		{
			Rectangle source = new Rectangle(myGame.offsetx + currentFrame * (myGame.space + myGame.spriteWidth), myGame.offsety, myGame.spriteWidth, myGame.spriteHeight);
			Rectangle destination = new Rectangle(xPos, myGame.graphics.PreferredBackBufferHeight / 2 - (myGame.spriteHeight * myGame.spriteScale) / 2, myGame.spriteWidth * myGame.spriteScale, myGame.spriteHeight * myGame.spriteScale);

			myGame.spriteBatch.Begin(SpriteSortMode.Deferred,
				BlendState.AlphaBlend, SamplerState.PointClamp,
				null, null, null, null);
			myGame.spriteBatch.Draw(myGame.spriteSheet, destination, source, Color.White);
			myGame.spriteBatch.End();
		}
	}
}
