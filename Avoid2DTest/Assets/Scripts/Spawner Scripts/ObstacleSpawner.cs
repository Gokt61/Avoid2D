using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Obstacle point;
    public Obstacle horizontalObstacle;
    public Obstacle verticalObstacle;

    private bool left, up;

    private void Start()
    {
        StartCoroutine(SpawnAtPoint());

        RandomSpawnerChance();

        SpawnVertical();
        SpawnHorizontal();
    }

    void RandomSpawnerChance()
    {
        if (Random.value < 0.5)
            left = false;
        else
            left = true;

        if (Random.value < 0.5)
            up = false;
        else
            up = true;
    }

    public IEnumerator SpawnAtPoint()
    {
        yield return new WaitForSeconds(1);
        Vector2 pointPos = new Vector2(Random.Range(-point.xBound, point.xBound), Random.Range(-point.yBound, point.yBound));
        Instantiate(point.obstacle, pointPos, Quaternion.identity);
    }

    public void SpawnVertical()
    {
        if (left)
            Instantiate(verticalObstacle.obstacle, new Vector2(-verticalObstacle.xBound,
                Random.Range(-verticalObstacle.yBound, verticalObstacle.yBound)), Quaternion.identity);
        else
            Instantiate(verticalObstacle.obstacle, new Vector2(verticalObstacle.xBound,
                Random.Range(verticalObstacle.yBound, verticalObstacle.yBound)), Quaternion.identity);
    }

    public void SpawnHorizontal()
    {
        if (up)
            Instantiate(horizontalObstacle.obstacle, new Vector2(Random.Range(-horizontalObstacle.xBound, horizontalObstacle.xBound),
                horizontalObstacle.yBound), Quaternion.Euler(0,0,90));
        else
            Instantiate(horizontalObstacle.obstacle, new Vector2(Random.Range(horizontalObstacle.xBound, horizontalObstacle.xBound),
                -horizontalObstacle.yBound), Quaternion.Euler(0, 0, 90));
    }
}