using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;
        float turn = horizontal * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, turn, 0.0f);

        rb.MovePosition(rb.position + movement);
        rb.MoveRotation(rb.rotation*turnRotation);
    }
}
