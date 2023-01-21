using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace FaddleEngine.Graphics
{
    internal class Window : GameWindow
    {
        private static Window window;

        private WindowSettings settings;

        private VertexBuffer vbo;
        private IndexBuffer ebo;
        private VertexArrayObject vao;

        private Texture texture;

        public Window(WindowSettings settings) : base(
            new GameWindowSettings { RenderFrequency = 60f, UpdateFrequency = 60f },
            new NativeWindowSettings
            {
                WindowState = settings.Fullscreen ? OpenTK.Windowing.Common.WindowState.Fullscreen : OpenTK.Windowing.Common.WindowState.Normal,
                Title = settings.Title,
                Size = settings.Size,
                APIVersion = new System.Version(4, 0),
                StartVisible = false
            })
        {
            this.settings = settings;
            CenterWindow();
            Application.WindowSize = Size;
            window = this;
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            IsVisible = true;

            CursorState = settings.CursorVisible ? CursorState.Normal : CursorState.Hidden;

            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);

            Vertex[] vertices = new Vertex[]
            {
                new Vertex(new Vector3(-0.5f, -0.5f, 0f), new Vector2(0f, 0f)),
                new Vertex(new Vector3(-0.5f, 0.5f, 0f), new Vector2(0f, 1f)),
                new Vertex(new Vector3(0.5f, -0.5f, 0f), new Vector2(1f, 0f)),
                new Vertex(new Vector3(0.5f, 0.5f, 0f), new Vector2(1f, 1f))
            };

            vbo = new VertexBuffer(Vertex.VertexInfo, 4, true);
            vbo.SetData(vertices, vertices.Length);

            vao = new VertexArrayObject(vbo);

            int[] indices = new int[]
            {
                0, 1, 3,
                0, 3, 2
            };

            ebo = new IndexBuffer(6, true);
            ebo.SetData(indices, indices.Length);

            texture = new Texture("Textures/HIVE.png");
            texture.Use(TextureUnit.Texture0);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.ClearColor(settings.BackgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            vao.Use();

            Matrix4 transform = Matrix4.Identity;

            transform *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(20f));

            transform *= Matrix4.CreateScale(1.1f);

            transform *= Matrix4.CreateTranslation(0.1f, 0.1f, 0f);

            Shader.DEFAULT.Use();

            texture.Use(TextureUnit.Texture0);
            Shader.DEFAULT.SetUniform("transform", transform);

            ebo.Use();

            Application.Instance.Render();

            Context.SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                CursorState = CursorState.Normal;
            }

            Input.Update(KeyboardState);

            Application.Instance.Update();

            Input.Clear();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (!settings.CursorVisible && e.Button == MouseButton.Left)
            {
                CursorState = CursorState.Hidden;
            }

            Input.MouseButtonDown(e.Button);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            Input.MouseButtonUp(e.Button);
        }

        protected override void OnFocusedChanged(FocusedChangedEventArgs e)
        {
            base.OnFocusedChanged(e);

            if (!settings.CursorVisible && e.IsFocused)
            {
                CursorState = CursorState.Hidden;
            }
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            Shader.DEFAULT.Dispose();

            vbo.Dispose();
            vao.Dispose();
            ebo.Dispose();

            texture.Dispose();
        }

        public static Vector2Int GetSize() => new Vector2Int(window.Size.X, window.Size.Y);

        public static void Quit() => window.Close();
    }
}
