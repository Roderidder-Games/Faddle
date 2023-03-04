using FaddleEngine;

namespace PolcompballFighter.Player
{
    internal class PlayerMovement : ScriptedBehaviour
    {
        private float _speed;
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public PlayerMovement(float speed)
        {
            _speed = speed;
        }

        public override void OnAdd()
        {
        }

        public override void OnRemove()
        {
        }

        public override void OnUpdate()
        {
            if (Input.GetKey(Key.D))
            {
                Parent.transform.Position = new Vector3(Parent.transform.Position.x + _speed * Application.DeltaTime, Parent.transform.Position.y, Parent.transform.Position.z);
            }

            if (Input.GetKey(Key.A))
            {
                Parent.transform.Position = new Vector3(Parent.transform.Position.x - _speed * Application.DeltaTime, Parent.transform.Position.y, Parent.transform.Position.z);
            }
        }
    }
}
