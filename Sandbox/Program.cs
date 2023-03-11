using FaddleEngine;

namespace Sandbox
{
    class Program
    {
        static void Main()
        {
            _ = new Game();
        }
    }

    public class Game : Application
    {
        public Game() : base(new WindowSettings { Title = "Sandbox", Size = new Vector2Int(500, 500), Fullscreen = false, BackgroundColor = Color.White, CursorVisible = true })
        {

        }

        protected override void OnStart()
        {
            _ = new Camera(Vector3.UnitZ * 3, WindowSize.x / (float)WindowSize.y)
            {
                Yaw = -90f
            };

            GameObject gO = new(Vector3.Zero, Vector3.Zero, new Vector3(4f, 0.5f, 0));
            Texture texture = new(new Color[] { Color.Black }, 1);
            Button button = new("Hi Guys!", Font.CASCADIA, texture);
            button.OnLeftMouseButtonDown.AddListener(() => Log.Info("Hello"));
            gO.AddComponent(button);
        }

        protected override void OnUpdate()
        {
        }
    }
}
