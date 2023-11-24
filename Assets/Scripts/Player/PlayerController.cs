using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController chController;

    [SerializeField] private float moveSpeed, gravity;
    private float fallVelocity, jumpForce;

    private Vector3 axis, movePlayer;

    void Awake()
    {
        chController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting input
        axis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (axis.magnitude > 1) axis = transform.TransformDirection(axis).normalized;
        else axis = transform.TransformDirection(axis);

        //Gravity factor
        if (chController.isGrounded) fallVelocity = -gravity * Time.deltaTime;
        else fallVelocity -= gravity * Time.deltaTime;

        movePlayer.y = fallVelocity;
        movePlayer.x = axis.x;
        movePlayer.z = axis.z;


        chController.Move(movePlayer * moveSpeed * Time.deltaTime);
    }
}
