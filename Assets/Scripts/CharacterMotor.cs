using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Character/Character Motor")]

public class CharacterMotor : MonoBehaviour
{
    //Declares boolean variable
    public bool checkAutoWalk = false;
    //this declares a variable for the head in google cardboard
    private CardboardHead head;
    private Vector3 direction;
    public float gravity = 20f;
    public float speed = 3f;
    [HideInInspector]
    public float walkDeaccelerationVolx;
    [HideInInspector]
    public float walkDeaccelerationVolz;
    public float maxWalkSpeed = 20f;
    [HideInInspector]
    public Vector2 horizontalMovement;
    private Rigidbody rb;
    private CharacterController controller;
    // Use this for initialization
    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction);
        horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);
        if (horizontalMovement.magnitude > maxWalkSpeed)
        {
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement *= maxWalkSpeed;
        }
        rb.velocity = new Vector3(horizontalMovement.x, 0, horizontalMovement.y);

        if (!checkAutoWalk)
        {
            float temp1x = Mathf.SmoothDamp(rb.velocity.x, 0, ref walkDeaccelerationVolx, 0);
            float temp2z = Mathf.SmoothDamp(rb.velocity.z, 0, ref walkDeaccelerationVolz, 0);
            direction = new Vector3(temp1x, rb.velocity.y, temp2z);
            rb.AddRelativeForce(direction);
        }
        if (checkAutoWalk)
        {
            direction = new Vector3(head.transform.forward.x * speed * Time.deltaTime, 0, head.transform.forward.z * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
            rb.AddRelativeForce(direction);
        }
    }
}