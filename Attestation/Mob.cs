using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mob : MonoBehaviour, IMove, IAttack
{
    [Header("Здоровье")]
    public float Health;

    [Header("Броня")]
    public float Armor;

    [Header("Скорость")]
    public float Speed;

    [Header("Урон")]
    public float Attack;

    [Header("Игрок")]
    public new Transform
        transform;
    [Header("Физика")]
    public new Rigidbody
        rigidbody;

    public virtual void OnAttack()
    {
        Debug.Log("Атака...");
    }

    public virtual void OnDefence()
    {
        Debug.Log("Защита...");
    }

    public virtual void OnMove()
    {
        Debug.Log("Движение...");
    }

    public virtual void OnJump()
    {
        Debug.Log("Прыжок...");
    }
}
