using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Slime : Mob
{
    public float
        rotationSpeed = 2.0f,
        detectionRadius = 10.0f;

    public LayerMask 
        obstacleLayer,
        playerLayer;

    private Transform 
        player;
    private bool 
        isChasingPlayer;

    public Slime()
    {

    }

    public Slime(Transform transform)
    {
        this.transform = transform;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(UpdateMovement());
    }

    IEnumerator UpdateMovement()
    {
        while (true)
        {
            if (Physics.CheckSphere(transform.position, detectionRadius, playerLayer))
            {
                isChasingPlayer = true;
            }
            else
            {
                isChasingPlayer = false;
            }

            if (isChasingPlayer)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
            }

            yield return null;
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    void Patrol()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 5.0f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 5.0f, 1);
        Vector3 finalPosition = hit.position;

        if (!Physics.Linecast(transform.position, finalPosition, obstacleLayer))
        {
            Vector3 direction = (finalPosition - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
    }
}
