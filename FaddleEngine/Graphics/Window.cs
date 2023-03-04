﻿using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

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

            CursorState = settings.CursorVisible ? CursorState.Normal : CursorState.Grabbed;
            if (!settings.CursorVisible)
            {
                MousePosition = new Vector2(0, 0);
            }

            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.DepthTest);
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            PackageManager.OnRender();

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

            Application.DeltaTime = (float)args.Time;

            Input.Update(KeyboardState);
            Input.UpdateMousePos(MouseState.Position);

            PackageManager.OnUpdate();

            Application.Instance.Update();

            Input.Clear();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (!settings.CursorVisible && e.Button == MouseButton.Left)
            {
                CursorState = CursorState.Grabbed;
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
                CursorState = CursorState.Grabbed;
            }
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            Shader.DEFAULT.Dispose();

            PackageManager.OnQuit();
        }

        public static Vector2Int GetSize() => new(window.Size.X, window.Size.Y);

        public static void Quit() => window.Close();
    }
}
