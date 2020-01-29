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
	class MouseController : IController
	{
		private GraphicsDeviceManager graphics;
		private ICommand[] commands;
		public MouseController(GraphicsDeviceManager myGraphics) {
			graphics = myGraphics;
			commands = new ICommand[5];
		}
		public void mapMouse(ICommand[] newCommands) {
			commands = newCommands;
		}
		private int getQuad(Point mousePos) {
			int val1 = 2, val2 = 2;
			if (mousePos.X < graphics.PreferredBackBufferWidth / 2) {
				val1 = 1;
			}
			if (mousePos.Y < graphics.PreferredBackBufferHeight / 2) {
				val2 = 0;
			}
			return val1 + val2;
		}
		public void Update() {
			MouseState currentState = Mouse.GetState();
			if (currentState.RightButton == ButtonState.Pressed) {
				commands[0].Execute();
			}else if (currentState.LeftButton == ButtonState.Pressed) {
				commands[getQuad(currentState.Position)].Execute();
			}
		}
	}
}
