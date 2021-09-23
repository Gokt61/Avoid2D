using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float xBound, yBound;

    public GameObject damageEffect;

    private float deltaX, deltaY;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            Vector3 target = Camera.main.ScreenToWorldPoint(touch.position);

            target.z = transform.position.z;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = target.x - transform.position.x;
                    deltaY = target.y - transform.position.y;
                    break;
                case TouchPhase.Moved:
                    transform.position = new Vector2(target.x - deltaX, target.y - deltaY);
                    break;
                case TouchPhase.Ended:
                    transform.position = new Vector2(transform.position.x, transform.position.y);
                    break;
            }
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBound, xBound), Mathf.Clamp(transform.position.y, -yBound, yBound));
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Point"))
        {
            GameManager.instance.IncreseScore();
            Destroy(target.gameObject);
            StartCoroutine(GameObject.FindObjectOfType<ObstacleSpawner>().SpawnAtPoint());
        }

        if (target.tag == "Obstacle" || target.tag == "Enemy")
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
            GameManager.instance.isDead = true;
            gameObject.SetActive(false);
        }
    }
}