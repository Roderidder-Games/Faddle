using FaddleEngine;
using System;
using Vector3 = FaddleEngine.Vector3;

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
        public Game() : base(new WindowSettings { Title = "Sandbox", Size = new Vector2Int(500, 500), Fullscreen = false, BackgroundColor = Color.White, CursorVisible = false })
        {

        }

        private Camera cam;

        protected override void OnStart()
        {
            cam = new Camera(Vector3.UnitZ * 3, WindowSize.x / (float)WindowSize.y)
            {
                Yaw = -90f
            };

            Random random = new();

            Color[] noise = new Color[256 * 256];
            for (int i = 0; i < noise.Length; i++)
            {
                int val = random.Next(0, 2);
                noise[i] = new Color(val, val, val, 1f);
            }

            Texture texture = new(noise, 256, true);

            Mesh mesh = Mesh.Square;
            mesh.SetTexture(texture);

            GameObject gO = new(Vector3.Zero, Vector3.Zero, Vector3.One * 2);
            gO.AddComponent(new MeshRenderer(mesh, Shader.DEFAULT));
        }

        protected override void OnUpdate()
        {
            if (Input.GetKey(Key.W))
            {
                cam.Position += cam.Front * 5f * DeltaTime;
            }

            if (Input.GetKey(Key.S))
            {
                cam.Position -= cam.Front * 5f * DeltaTime;
            }

            if (Input.GetKey(Key.D))
            {
                cam.Position += cam.Right * 5f * DeltaTime;
            }

            if (Input.GetKey(Key.A))
            {
                cam.Position -= cam.Right * 5f * DeltaTime;
            }
        }
    }
}
