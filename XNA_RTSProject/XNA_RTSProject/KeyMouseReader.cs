using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

static class KeyMouseReader
{
	public static KeyboardState keyState, oldKeyState = Keyboard.GetState();
	public static MouseState mouseState, oldMouseState = Mouse.GetState();
	public static bool KeyPressed(Keys key) {
		return keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key);
	}

	//Should be called at beginning of Update in Game
	public static void Update() {
		oldKeyState = keyState;
		keyState = Keyboard.GetState();
		oldMouseState = mouseState;
		mouseState = Mouse.GetState();
	}
}