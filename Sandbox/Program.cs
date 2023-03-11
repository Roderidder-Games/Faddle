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
        public Game() : base(new WindowSettings { Title = "PolCompBall Fighters", Size = new Vector2Int(500, 500), Fullscreen = false, BackgroundColor = Color.Black, CursorVisible = false })
        {

        }

        protected override void OnStart()
        {
            _ = new Camera(Vector3.UnitZ * 3, WindowSize.x / (float)WindowSize.y)
            {
                Yaw = -90f
            };

            GameObject gO = new(Vector3.Zero, Vector3.Zero, new Vector3(5, 1, 0));
            gO.AddComponent(new MeshRenderer(Mesh.Square, Shader.DEFAULT));
            gO.AddComponent(new TextRenderer("G'day", Font.CASCADIA));
        }

        protected override void OnUpdate()
        {
        }
    }
}
