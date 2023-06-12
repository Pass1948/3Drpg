using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDir;
    private float ySpeed;
    private Animator animator;
    private bool walk;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    private float curSpeed;
    [SerializeField] float JumpSpeed;
    

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Fall();
    }

    private void Move()
    {
        if (moveDir.magnitude == 0)
        {
            curSpeed = Mathf.Lerp(curSpeed, 0, 0.1f);
            animator.SetFloat("MoveSpeed", curSpeed);
            return;
        }

        Vector3 vecFor = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 vecRig = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        if (walk)
        {
            curSpeed = Mathf.Lerp(curSpeed, walkSpeed, 0.1f);
        }

        else
        {
            curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.1f);
        }

        controller.Move(vecFor * moveDir.z * curSpeed * Time.deltaTime);
        controller.Move(vecRig * moveDir.x * curSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", curSpeed);

        Quaternion lookRotation = Quaternion.LookRotation(vecFor * moveDir.z + vecRig * moveDir.x);
        transform.rotation = Quaternion.Lerp( lookRotation, transform.rotation, 0.1f);
    }

    private void OnMove(InputValue value) 
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void Fall()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded && ySpeed < 0)
        {
            ySpeed = 0;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void Jump() 
    {
        ySpeed = JumpSpeed;
    }

    private void OnJump (InputValue value)
    {
        Jump();
    }

    private void OnWalk(InputValue value)
    {
        walk = value.isPressed;
    }
}
