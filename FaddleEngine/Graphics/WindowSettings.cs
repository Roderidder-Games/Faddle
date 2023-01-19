namespace FaddleEngine
{
    /// <summary>
    /// The settings for window creation.
    /// </summary>
    public struct WindowSettings
    {
        /// <summary>
        /// The name of the window.
        /// </summary>
        public string Title;
        /// <summary>
        /// The default size of the window.
        /// </summary>
        public Vector2Int Size;
        /// <summary>
        /// Is the window fullscreen?
        /// </summary>
        public bool Fullscreen;
        /// <summary>
        /// The background color of the window.
        /// </summary>
        public Color BackgroundColor;
    }
}
