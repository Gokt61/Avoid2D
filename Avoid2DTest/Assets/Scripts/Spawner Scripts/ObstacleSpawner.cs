using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;

    public Obstacle point;
    public Obstacle horizontalObstacle;
    public Obstacle verticalObstacle;
    public Obstacle enemyFollow;
    public Obstacle projectileSpawner;

    [HideInInspector]
    public bool left, up;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnAtPoint());
        StartCoroutine(SpawnProjectileSpawner());
        StartCoroutine(SpawnEnemyFollow());

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
                horizontalObstacle.yBound), Quaternion.identity);
        else
            Instantiate(horizontalObstacle.obstacle, new Vector2(Random.Range(horizontalObstacle.xBound, horizontalObstacle.xBound),
                -horizontalObstacle.yBound), Quaternion.identity);
    }

    public IEnumerator SpawnProjectileSpawner()
    {
        int timer = Random.Range(5, 10);
        yield return new WaitForSeconds(timer);

        Vector2 enemyShootPos = new Vector2(Random.Range(-point.xBound, point.xBound), Random.Range(-point.yBound, point.yBound));
        Instantiate(projectileSpawner.obstacle, enemyShootPos, Quaternion.identity);

        StartCoroutine(SpawnProjectileSpawner());
    }

    IEnumerator SpawnEnemyFollow()
    {
        int timer = 15;

        yield return new WaitForSeconds(timer);

        Vector2 spawnPoint = GameObject.Find("Player").transform.position;
        spawnPoint += Random.insideUnitCircle * 10;

        if (!GameObject.FindObjectOfType<EnemyFollow>())
        {
            Instantiate(enemyFollow.obstacle, spawnPoint, Quaternion.identity);

            timer = 10;

            StartCoroutine(SpawnEnemyFollow());
        }
    }
}