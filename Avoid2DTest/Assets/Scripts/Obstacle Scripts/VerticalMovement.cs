using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = Random.Range(0.15f, 0.17f);
    }

    void Update()
    {
        if (Time.timeScale == 0) return;

        if (GameObject.FindObjectOfType<ObstacleSpawner>().left)
        {
            transform.Translate(new Vector2(speed * 0.10f,0f));

            if (transform.position.x >= 4)
            {
                ObstacleSpawner.instance.left = false;
                ObstacleSpawner.instance.SpawnVertical();
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(new Vector2(-speed * 0.10f, 0f));

            if (transform.position.x <= -4)
            {
                ObstacleSpawner.instance.left = true;
                ObstacleSpawner.instance.SpawnVertical();
                Destroy(gameObject);
            }
        }
    }
}