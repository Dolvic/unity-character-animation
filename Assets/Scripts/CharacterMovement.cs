using System;
using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;
    private float moveSpeed;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        moveSpeed = 0;
    }

    public void Update()
    {
        SetSpeed();
        var vertical = Input.GetAxis("Vertical");

        var isMoving = vertical > 0;
        anim.SetBool("IsMoving", isMoving);
        anim.SetFloat("MoveSpeed", moveSpeed);
    }

    private void SetSpeed()
    {
        KeyCode[] speedKeys = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0};
        var speed = moveSpeed;

        for (var i = 0; i < speedKeys.Length; i++)
        {
            var speedKey = speedKeys[i];
            if (Input.GetKeyUp(speedKey))
            {
                speed = (float) Math.Round(i / 9.0, 2);
                break;
            }
        }
        moveSpeed = speed;
    }
}
