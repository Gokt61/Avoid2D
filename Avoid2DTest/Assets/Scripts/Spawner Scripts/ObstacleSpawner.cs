using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Obstacle point;

    private void Start()
    {
        StartCoroutine(SpawnAtPoint());
    }

    public IEnumerator SpawnAtPoint()
    {
        yield return new WaitForSeconds(1);
        Vector2 pointPos = new Vector2(Random.Range(-point.xBound, point.xBound), Random.Range(-point.yBound, point.yBound));
        Instantiate(point.obstacle, pointPos, Quaternion.identity);
    }
}
