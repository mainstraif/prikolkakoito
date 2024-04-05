using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float height = 2.0f;
    public float distance = 5.0f;
    public float rotationSpeed = 3.0f;

    private float mouseX;

    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;

        Quaternion rotation = Quaternion.Euler(0, mouseX, 0);

        Vector3 offset = rotation * new Vector3(0, height, -distance);

        transform.position = player.position + offset;
        transform.LookAt(player);
    }
}
