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

            Texture tex = new("Textures/Balls/HRFBall.png");

            Mesh mesh = Mesh.Square;
            mesh.SetTexture(tex);
            MeshRenderer render = new(mesh, Shader.DEFAULT);

            GameObject gO = new(Vector3.UnitY * 2, Vector3.Zero, (Vector2)tex.size / 1000);

            gO.AddComponent(render);
            gO.AddComponent(new CircleCollider(0.01f));
            gO.AddComponent(new Rigidbody(1f, false));
            gO.AddComponent(new PlayerMovement(10f));

            Mesh mesh2 = Mesh.Square;
            mesh2.SetTexture(new Texture("Textures/FrankiaFlag.png"));
            MeshRenderer render2 = new(mesh2, Shader.DEFAULT);

            GameObject gO2 = new(new Vector3(0, -2f, 0f), Vector3.Zero, new Vector2(10f, 1f));

            gO2.AddComponent(render2);
            gO2.AddComponent(new BoxCollider(new Vector2(100f, 0.01f)));
            gO2.AddComponent(new Rigidbody(1f, true));
        }

        protected override void OnUpdate()
        {
        }
    }
}
