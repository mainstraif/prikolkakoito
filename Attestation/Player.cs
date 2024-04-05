using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : Mob
{
    [Header("Рекорд")]
    public int Score;

    [Header("Деньги")]
    public int Money;

    [Header("Скорость поворота")]
    public float RotationSpeed;

    [Header("Сила прыжка")]
    public float jumpForce = 8.0f;

    [Header("Камера")]
    public Transform cameraTransform;

    private bool 
        isGrounded; 
    public LayerMask 
        groundLayer;

    private void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        OnMove();
        OnJump();
    }

    public Player()
    {

    }

    public Player(Transform transform)
    {
        this.transform = transform;
    }

    public override void OnAttack()
    {
        base.OnAttack();
    }

    public override void OnJump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public override void OnMove()
    {
        if (cameraTransform == null)
        {
            return;
        }

        Vector3 
            camForward = cameraTransform.forward;

        camForward.y = 0; // Убираем компонент Y, чтобы двигаться только по горизонтали

        float
            horInput = Input.GetAxis("Horizontal"),
            verInput = Input.GetAxis("Vertical");

        Vector3 
            direction = camForward.normalized * verInput + cameraTransform.right.normalized * horInput;

        if (direction.magnitude >= 0.1f)
        {
            float 
                targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg,
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref RotationSpeed, 0.1f);

            transform.rotation = Quaternion.Euler(0, angle, 0);
            transform.Translate(direction * Speed * Time.deltaTime, Space.World);
        }
    }
}
