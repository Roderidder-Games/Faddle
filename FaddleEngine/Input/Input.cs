using OpenTK.Windowing.GraphicsLibraryFramework;

namespace FaddleEngine
{
    public static class Input
    {
        private static KeyboardState keyboard;

        public static Vector2 MousePos { get; private set; }

        private static FaddleEvent<Mouse> _onMouseButtonDown = new();
        public static FaddleEvent<Mouse> OnMouseButtonDown
        {
            get => _onMouseButtonDown;
            private set => _onMouseButtonDown = value;
        }
        private static FaddleEvent<Mouse> _onMouseButtonUp = new();
        public static FaddleEvent<Mouse> OnMouseButtonUp
        {
            get => _onMouseButtonUp;
            private set => _onMouseButtonUp = value;
        }

        private readonly static bool[] mouseButtonsHeld = new bool[5];
        private readonly static bool[] mouseButtonsDown = new bool[5];
        private readonly static bool[] mouseButtonsUp = new bool[5];

        internal static void Clear()
        {
            for (int i = 0; i < mouseButtonsDown.Length; i++)
            {
                mouseButtonsDown[i] = mouseButtonsUp[i] = false;
            }
        }

        internal static void Update(KeyboardState keyboard)
        {
            Input.keyboard = keyboard;
        }

        internal static void UpdateMousePos(Vector2 mousePos)
        {
            MousePos = mousePos;
        }

        internal static void MouseButtonDown(MouseButton button)
        {
            mouseButtonsHeld[(int)button] = mouseButtonsDown[(int)button] = true;
            _onMouseButtonDown.Fire((Mouse)button);
        }

        internal static void MouseButtonUp(MouseButton button)
        {
            mouseButtonsHeld[(int)button] = false;
            mouseButtonsUp[(int)button] = true;
            _onMouseButtonUp.Fire((Mouse)button);
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

        /// <summary>
        /// Checks if a mouse button is held down this frame.
        /// </summary>
        /// <param name="button">The mouse button to check for.</param>
        /// <returns></returns>
        public static bool GetMouseButton(Mouse button) => mouseButtonsHeld[(int)button];
        /// <summary>
        /// Checks if a mouse button was started being held down this frame.
        /// </summary>
        /// <param name="button">The mouse button to check for.</param>
        /// <returns></returns>
        public static bool GetMouseButtonDown(Mouse button) => mouseButtonsDown[(int)button];
        /// <summary>
        /// Checks if a mouse button was released this frame.
        /// </summary>
        /// <param name="button">The mouse button to check for.</param>
        /// <returns></returns>
        public static bool GetMouseButtonUp(Mouse button) => mouseButtonsUp[(int)button];
    }
}
