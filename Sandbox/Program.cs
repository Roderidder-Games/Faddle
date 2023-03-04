using FaddleEngine;
using FaddleEngine.Graphics;
using PolcompballFighter.Player;

namespace Sandbox
{
    class Program
    {
        static void Main()
        {
            _ = new Game();
        }
    }

    public class TestScene : Scene
    {

    }

    public class Game : Application
    {
        public Game() : base(new WindowSettings { Title = "PolCompBall Fighters", Size = new Vector2Int(500, 500), Fullscreen = false, BackgroundColor = Color.White, CursorVisible = false })
        {

        }

        protected override void OnStart()
        {
            _ = new Camera(Vector3.UnitZ * 3, WindowSize.x / (float)WindowSize.y)
            {
                Yaw = -90f
            };
        }

        protected override void OnUpdate()
        {
        }
    }
}
