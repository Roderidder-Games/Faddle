﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FaddleEngine
{
    [LogName("Application")]
    public abstract partial class Application
    {
        [LibraryImport("kernel32.dll")]
        private static partial IntPtr GetConsoleWindow();

        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;

        public static Vector2Int WindowSize { get; internal set; }

        internal static Application _instance;
        internal static Application Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                throw new Exception("Could not find instance of application.");
            }
            private set
            {
                if (_instance == null)
                {
                    _instance = value;
                    return;
                }
                throw new Exception("Application already exists, cannot create a second instance.");
            }
        }

        /// <summary>
        /// Creates a new application.
        /// </summary>
        /// <param name="windowSettings">The settings for the window.</param>
        public Application(WindowSettings windowSettings)
        {
            TriggerConsole();

            Instance = this;

            using (Window window = new(windowSettings))
            {
                OnStart();
                window.Run();
            };
        }

        [Conditional("RELEASE")]
        private static void TriggerConsole()
        {
            ShowWindow(GetConsoleWindow(), SW_HIDE);
        }

        /// <summary>
        /// Executes before the first frame.
        /// </summary>
        protected abstract void OnStart();

        internal void Update()
        {
            ObjectManager.Update();
            OnUpdate();
        }

        /// <summary>
        /// Executes every frame.
        /// </summary>
        protected abstract void OnUpdate();

        internal void Render()
        {
            ObjectManager.OnRender();
            OnRender();
        }

        protected virtual void OnRender()
        {

        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public static void Quit()
        {
            Window.Quit();
            Environment.Exit(0);
        }
    }
}
