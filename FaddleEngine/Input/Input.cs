using OpenTK.Windowing.GraphicsLibraryFramework;

namespace FaddleEngine
{
    public static class Input
    {
        private static KeyboardState keyboard;

        internal static void Update(KeyboardState keyboard)
        {
            Input.keyboard = keyboard;
        }

        /// <summary>
        /// Checks if a key is held down this frame.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns></returns>
        public static bool GetKey(Key key) => keyboard.IsKeyDown((Keys)key);
        /// <summary>
        /// Checks if a key was started being held down this frame.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns></returns>
        public static bool GetKeyDown(Key key) => keyboard.IsKeyPressed((Keys)key);
        /// <summary>
        /// Checks if a key was released this frame.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns></returns>
        public static bool GetKeyUp(Key key) => keyboard.IsKeyReleased((Keys)key);
    }
}
