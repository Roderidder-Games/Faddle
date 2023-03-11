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
            if (!Input.GetKey(Key.A) && !Input.GetKey(Key.D)) 
            {
                Parent.GetComponent<Rigidbody>().linearVelocity.x = 0f;
            }

            if (Input.GetKey(Key.D))
            {
                Parent.GetComponent<Rigidbody>().linearVelocity.x = -(_speed);
            }

            if (Input.GetKey(Key.A))
            {
                Parent.GetComponent<Rigidbody>().linearVelocity.x = _speed;
            }
        }
    }
}
