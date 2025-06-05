using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Prefabs")]
    public GameObject rampPrefab;
    public GameObject mudPitPrefab;
    public GameObject oilSlickPrefab;
    
    [Header("Spawn Settings")]
    public float spawnInterval = 1.3f;
    public float spawnVariance = 0.2f;
    public float spawnXPosition = 12f;
    public float groundYPosition = -2.5f;
    
    private float nextSpawnTime;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
        nextSpawnTime = Time.time + spawnInterval;
    }
    
    void Update()
    {
        if (Time.time >= nextSpawnTime && GameManager.Instance.IsGameActive())
        {
            SpawnRandomObstacle();
            SetNextSpawnTime();
        }
    }
    
    void SpawnRandomObstacle()
    {
        GameObject[] obstacles = { rampPrefab, mudPitPrefab, oilSlickPrefab };
        GameObject selectedObstacle = obstacles[Random.Range(0, obstacles.Length)];
        
        if (selectedObstacle != null)
        {
            Vector3 spawnPosition = new Vector3(spawnXPosition, groundYPosition, 0);
            GameObject spawnedObstacle = Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);
            
            // Ensure obstacle has MoveLeft script
            if (!spawnedObstacle.GetComponent<MoveLeft>())
            {
                spawnedObstacle.AddComponent<MoveLeft>();
            }
        }
    }
    
    void SetNextSpawnTime()
    {
        float variance = Random.Range(-spawnVariance, spawnVariance);
        nextSpawnTime = Time.time + spawnInterval + variance;
    }
    
    public void SetSpawnRate(float newInterval)
    {
        spawnInterval = newInterval;
    }
} 