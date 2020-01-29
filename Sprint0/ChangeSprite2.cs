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
	class ChangeSprite2 : ICommand
	{
		private Game1 myGame;
		public ChangeSprite2(Game1 game) {
			myGame = game;
		}
		public void Execute() {
			myGame.sprite = new Sprite2(myGame);
		}
	}
}
