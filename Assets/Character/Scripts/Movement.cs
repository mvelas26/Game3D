using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float speed = 10f;
    private float jump_force = 8f;
    private float gravity = 30f;
    private Vector3 moveDir = Vector3.zero;
    private float horizontalSpeed = 2.0F;
    private float verticalSpeed = 2.0F;

    void Start()
    {

    }




    void FixedUpdate()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;


            if (Input.GetButton("Jump"))
            {
                moveDir.y = jump_force;
            }
        }
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        // float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    }
}
