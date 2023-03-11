using OpenTK.Mathematics;

namespace FaddleEngine
{
    public sealed class Transform : Component
    {
        private Vector3 _position;
        public Vector3 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                UpdateTransformation();
            }
        }

        private Quaternion _rotation;
        public Quaternion Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
                UpdateTransformation();
            }
        }

        private Vector3 _scale;
        public Vector3 Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                UpdateTransformation();
            }
        }

        internal Matrix4 Model { get; private set; }

        public static Transform Zero => new(Vector3.Zero, Vector3.Zero, Vector3.Zero);

        public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Position = position;
            Rotation = Quaternion.FromEulerAngles(rotation.ToRadians());
            Scale = scale;
        }

        internal override void OnAdd()
        {
        }

        internal override void OnRemove()
        {
        }

        internal override void OnUpdate()
        {
        }

        private void UpdateTransformation()
        {
            Model = Matrix4.Identity;
            Model *= Matrix4.CreateTranslation(Position);
            Model *= Matrix4.CreateFromQuaternion(Rotation);
            Model *= Matrix4.CreateScale(Scale);
        }
    }
}
