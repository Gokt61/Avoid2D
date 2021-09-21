using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}