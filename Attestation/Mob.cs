using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mob : MonoBehaviour, IMove, IAttack
{
    [Header("��������")]
    public float Health;

    [Header("�����")]
    public float Armor;

    [Header("��������")]
    public float Speed;

    [Header("����")]
    public float Attack;

    [Header("�����")]
    public new Transform
        transform;
    [Header("������")]
    public new Rigidbody
        rigidbody;

    public virtual void OnAttack()
    {
        Debug.Log("�����...");
    }

    public virtual void OnDefence()
    {
        Debug.Log("������...");
    }

    public virtual void OnMove()
    {
        Debug.Log("��������...");
    }

    public virtual void OnJump()
    {
        Debug.Log("������...");
    }
}
