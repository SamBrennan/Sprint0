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
	class KeyboardController : IController
	{
		private Dictionary<Keys, ICommand> commandMap;
		public KeyboardController() {
			commandMap = new Dictionary<Keys, ICommand>();
		}
		public void mapCommand(Keys key, ICommand command) {
			commandMap.Add(key, command);
		}
		public void Update() {
			Keys[] keysPressed = Keyboard.GetState().GetPressedKeys();
			foreach (Keys key in keysPressed) {
				if (commandMap.Keys.Contains(key)) {
					commandMap[key].Execute();
				}
			}
		}
	}
}
