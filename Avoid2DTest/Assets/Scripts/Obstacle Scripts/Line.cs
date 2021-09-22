using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject damageEffect;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Point")
        {
            Instantiate(damageEffect, target.transform.position, Quaternion.identity);
            Destroy(target.gameObject);
            StartCoroutine(ObstacleSpawner.instance.SpawnAtPoint());
        }
    }
}