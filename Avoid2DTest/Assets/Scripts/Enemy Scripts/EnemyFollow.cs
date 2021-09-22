using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private float speed = 2f;

    private Transform playerPos;

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }
}
