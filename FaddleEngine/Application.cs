using FaddleEngine.Graphics;

namespace FaddleEngine
{
    [LogName("Application")]
    public abstract class Application
    {
        public static Vector2Int WindowSize { get; internal set; }

        internal static Application _instance;
        internal static Application Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                throw new System.Exception("Could not find instance of application.");
            }
            private set
            {
                if (_instance == null)
                {
                    _instance = value;
                    return;
                }
                throw new System.Exception("Application already exists, cannot create a second instance.");
            }
        }

        internal ObjectManager objectManager;

        /// <summary>
        /// Creates a new application.
        /// </summary>
        /// <param name="windowSettings">The settings for the window.</param>
        public Application(WindowSettings windowSettings)
        {
            Instance = this;

            objectManager = new ObjectManager();

            using (Window window = new Window(windowSettings))
            {
                OnStart();
                window.Run();
            };
        }

        /// <summary>
        /// Executes before the first frame.
        /// </summary>
        protected abstract void OnStart();

        internal void Update()
        {
            objectManager.Update();
            OnUpdate();
        }

        /// <summary>
        /// Executes every frame.
        /// </summary>
        protected abstract void OnUpdate();

        internal void Render()
        {
            objectManager.OnRender();
            OnRender();
        }

        protected virtual void OnRender()
        {

        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public static void Quit()
        {
            Window.Quit();
        }
    }
}
