using FaddleEngine;
using Sandbox;
using Vector3 = FaddleEngine.Vector3;

_ = new Game();

namespace Sandbox
{
    public class Game : Application
    {
        public Game() : base(new WindowSettings { Title = "Sandbox", Size = new Vector2Int(500, 500), Fullscreen = true, BackgroundColor = Color.White, CursorVisible = false })
        {

        }

        private Camera cam;
        private Vector2 lastMousePos = Vector2.Zero;

        private GameObject gO;

        private Rigidbody rb;

        protected override void OnStart()
        {
            cam = new Camera(Vector3.UnitZ * 3, WindowSize.x / (float)WindowSize.y)
            {
                Yaw = -90f
            };
            Camera.SetMain(cam);

            Mesh mesh = Mesh.Cube;
            mesh.texture = new("Textures/FrankiaFlag.png");
            gO = new(Vector3.Zero, Vector3.Zero, Vector3.One);
            gO.AddComponent(new MeshRenderer(mesh, Shader.TEXTURE));
            gO.AddComponent(rb = new Rigidbody(new Shape() { type = ShapeType.Box, size = new Vector3(1f, 1f, 1f) }));
        }

        protected override void OnUpdate()
        {
            if (Input.GetKey(Key.W))
            {
                Vector3 position = cam.Position;
                position += cam.Front * 10f * Time.DeltaTime;
                cam.Position = position;
            }

            if (Input.GetKey(Key.S))
            {
                Vector3 position = cam.Position;
                position -= cam.Front * 10f * Time.DeltaTime;
                cam.Position = position;
            }

            if (Input.GetKey(Key.A))
            {
                Vector3 position = cam.Position;
                position -= cam.Right * 10f * Time.DeltaTime;
                cam.Position = position;
            }

            if (Input.GetKey(Key.D))
            {
                Vector3 position = cam.Position;
                position += cam.Right * 10f * Time.DeltaTime;
                cam.Position = position;
            }

            Vector2 mouseDelta = Input.MousePos - lastMousePos;
            lastMousePos = Input.MousePos;

            cam.Yaw += mouseDelta.x * 5f * Time.DeltaTime;
            cam.Pitch -= mouseDelta.y * 5f * Time.DeltaTime;
        }
    }
}
