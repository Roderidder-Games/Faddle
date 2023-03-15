using FaddleEngine;
using Sandbox;
using Vector3 = FaddleEngine.Vector3;

_ = new Game();

namespace Sandbox
{
    public class Game : Application
    {
        public Game() : base(new WindowSettings { Title = "Sandbox", Size = new Vector2Int(500, 500), Fullscreen = true, BackgroundColor = Color.White, CursorVisible = true })
        {

        }

        private Camera cam;

        protected override void OnStart()
        {
            cam = new Camera(Vector3.UnitZ * 3, WindowSize.x / (float)WindowSize.y)
            {
                Yaw = -90f
            };
        }

        protected override void OnUpdate()
        {
            if (Input.GetKey(Key.W))
            {
                Vector3 position = cam.Position;
                position.z -= 10f * Time.DeltaTime;
                cam.Position = position;
            }

            if (Input.GetKey(Key.S))
            {
                Vector3 position = cam.Position;
                position.z += 10f * Time.DeltaTime;
                cam.Position = position;
            }
        }
    }
}
