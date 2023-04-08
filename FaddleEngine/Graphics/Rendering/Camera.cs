using OpenTK.Mathematics;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FaddleEngine
{
    public sealed class Camera
    {
        private static Camera _main;
        public static Camera Main
        {
            get
            {
                if (_main == null)
                {
                    Log.Error("No active Camera, please instantiate a camera in the OnStart method.");
                }
                return _main;
            }
            private set
            {
                _main = value;
            }
        }

        private static Camera _ui;
        public static Camera UI
        {
            get
            {
                if (_ui == null)
                {
                    Log.Error("No active UI Camera, please instantiate a camera in the OnStart method.");
                }
                return _ui;
            }
            private set
            {
                _ui = value;
            }
        }

        public Vector3 Position { get; set; }
        public float AspectRatio { get; set; }
        public Vector3 Front => front;
        public Vector3 Up => up;
        public Vector3 Right => right;

        private Vector3 front = Vector3.UnitZ;
        private Vector3 up = Vector3.UnitY;
        private Vector3 right = Vector3.UnitX;

        private float pitch;
        private float yaw = -MathHelper.PiOver2;
        private float fov = MathHelper.PiOver2;

        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(pitch);
            set
            {
                float angle = MathHelper.Clamp(value, -89f, 89f);
                pitch = MathHelper.DegreesToRadians(angle);
                UpdateVectors();
            }
        }

        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(yaw);
            set
            {
                yaw = MathHelper.DegreesToRadians(value);
                UpdateVectors();
            }
        }

        public float Fov
        {
            get => MathHelper.RadiansToDegrees(fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 90f);
                fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public Camera(Vector3 position, float aspectRatio)
        {
            Position = position;
            AspectRatio = aspectRatio;

            _main ??= this;
        }

        public static void SetMain(Camera camera)
        {
            if (camera == null)
            {
                Log.Warn("Attempted to pass null into Camera.SetMain.");
                return;
            }

            _main = camera;
        }

        internal static void SetUI(Camera camera)
        {
            if (camera == null)
            {
                Log.Warn("Attempted to pass null into Camera.SetUI.");
                return;
            }

            _ui = camera;
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + front, up);
        }
        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(fov, AspectRatio, 0.01f, 100f);
        }

        private void UpdateVectors()
        {
            front.x = MathF.Cos(pitch) * MathF.Cos(yaw);
            front.y = MathF.Sin(pitch);
            front.z = MathF.Cos(pitch) * MathF.Sin(yaw);

            front = Vector3.Normalize(front);

            right = Vector3.Normalize(Vector3.Cross(front, Vector3.UnitY));
            up = Vector3.Normalize(Vector3.Cross(right, front));
        }
    }
}
