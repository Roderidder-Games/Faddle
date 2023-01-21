using FaddleEngine;

namespace Sandbox
{
    class Program
    {
        static void Main()
        {
            new Game();
        }
    }

    public class Game : Application
    {
        public Game() : base(new WindowSettings { Title = "Test Window", Size = new Vector2Int(500, 500), Fullscreen = false, BackgroundColor = Color.White, CursorVisible = true })
        {

        }

        protected override void OnStart()
        {
        }

        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(Key.Escape))
            {
                Quit();
            }
        }
    }
}
