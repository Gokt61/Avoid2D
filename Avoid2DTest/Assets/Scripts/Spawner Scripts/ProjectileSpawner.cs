using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectileEnemy;

    public void SpawnProjectile()
    {
        Instantiate(projectileEnemy, transform.position, Quaternion.identity);
        GetComponent<Animator>().fireEvents = false;
        Destroy(gameObject, 1.5f);
    }
}
