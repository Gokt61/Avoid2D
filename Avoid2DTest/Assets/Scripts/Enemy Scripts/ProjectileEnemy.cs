using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public float force = 200f;

    private Rigidbody2D rb;

    private Vector2 playerPos;

    public GameObject damageEffect;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(ShootAtThePlayer());
    }

    IEnumerator ShootAtThePlayer()
    {
        yield return new WaitForSeconds(0.5f);
        playerPos = GameObject.Find("Player").transform.position;

        Vector2 heading = (playerPos - (Vector2)transform.position).normalized;
        float dist = heading.magnitude;
        Vector2 dir = heading / dist;

        rb.AddForce(dir * force);

        Destroy(gameObject, 4);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
            Destroy(target.gameObject);
        }
    }
}
