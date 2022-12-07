using UnityEngine;
namespace TankGame
{
    public class Jumper : ITargetBehavior
    {
        private CharacterController _controller;
        private Vector3 velocity;
        private bool grounded;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;

        public Jumper(CharacterController controller)
        {
            _controller = controller;
        }

        public void move()
        {
            grounded = _controller.isGrounded;
            if (grounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            // Changes the height position of the player..
            if (grounded)
            {
                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            velocity.y += gravityValue * Time.deltaTime;
            _controller.Move(velocity * Time.deltaTime);
        }
    }
}