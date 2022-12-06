using UnityEngine;

namespace TankGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Values")]
        [SerializeField] float speed;
        [SerializeField] float turnSpeed;

        Rigidbody rb;

        float horizontal;
        float vertical;
        public float stability = 0.3f;
        public float stabilizationSpeed = 2.0f;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        private void FixedUpdate()
        {
            Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;
            float turn = horizontal * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0.0f, turn, 0.0f);

            rb.MovePosition(rb.position + movement);
            rb.MoveRotation(rb.rotation * turnRotation);

            Vector3 predictedUp = Quaternion.AngleAxis(rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / stabilizationSpeed, rb.angularVelocity) * transform.up;
            Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
            rb.AddTorque(torqueVector * stabilizationSpeed * stabilizationSpeed);

        }
    }
}