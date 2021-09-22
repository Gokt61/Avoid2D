using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float xBound, yBound;

    void Start()
    {
        
    }

    void Update()
    {

        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBound, xBound), Mathf.Clamp(transform.position.y, -yBound, yBound));
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Point"))
        {
            Destroy(target.gameObject);
            StartCoroutine(GameObject.FindObjectOfType<ObstacleSpawner>().SpawnAtPoint());
        }
    }
}