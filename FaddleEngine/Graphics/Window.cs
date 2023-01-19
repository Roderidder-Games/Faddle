using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace FaddleEngine.Graphics
{
    internal class Window : GameWindow
    {
        private static Window window;

        private WindowSettings settings;

        public Window(WindowSettings settings) : base(
            new GameWindowSettings { RenderFrequency = 60f, UpdateFrequency = 60f },
            new NativeWindowSettings
            {
                WindowState = settings.Fullscreen ? OpenTK.Windowing.Common.WindowState.Fullscreen : OpenTK.Windowing.Common.WindowState.Normal,
                Title = settings.Title,
                Size = settings.Size
            })
        {
            this.settings = settings;
            window = this;
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(settings.BackgroundColor);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            Context.SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            Input.Update(KeyboardState);

            Application.Instance.Update();
        }

        public static void Quit() => window.Close();
    }
}
