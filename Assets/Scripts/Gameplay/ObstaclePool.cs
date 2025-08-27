using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private int poolSize;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float timeBetweenSpawn;
    private float spawnTime;
    private List<GameObject> obstacles;

    private void Start()
    {
        obstacles = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            var obstacle = Instantiate(obstaclePrefab,
                transform.position,
                Quaternion.Euler(0f, 0f, Random.Range(10f, 180f)), parentTransform);
            obstacle.SetActive(false);
            obstacles.Add(obstacle);
            obstacle.GetComponent<Obstacle>().obstaclePool = this;
        }
    }

    private void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    private void Spawn()
    {
        foreach (var obstacle in obstacles)
        {
            if (!obstacle.activeInHierarchy)
            {
                float randomX = SetRandomPositionX();
                float randomY = SetRandomPositionY();
                obstacle.transform.position = transform.position + new Vector3(randomX, randomY, 0f);
                obstacle.SetActive(true);
                return;
            }
        }

    }

    public float SetRandomPositionX()
    {
        return Random.Range(minX, maxX);
    }
    public float SetRandomPositionY()
    {
        return Random.Range(minY, maxY);
    }
    public Vector3 SetRandomPosition()
    {
        return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
    }

}
