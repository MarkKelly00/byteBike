using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("PowerUp Prefabs")]
    public GameObject nitroCanPrefab;
    public GameObject shieldStarPrefab;
    public GameObject doubleJumpTokenPrefab;
    
    [Header("Spawn Settings")]
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 7f;
    public float spawnXPosition = 12f;
    public float groundYPosition = -2.5f;
    public float maxAirYPosition = 0f;
    
    private float nextSpawnTime;
    
    void Start()
    {
        SetNextSpawnTime();
    }
    
    void Update()
    {
        if (Time.time >= nextSpawnTime && GameManager.Instance.IsGameActive())
        {
            SpawnRandomPowerUp();
            SetNextSpawnTime();
        }
    }
    
    void SpawnRandomPowerUp()
    {
        GameObject[] powerUps = { nitroCanPrefab, shieldStarPrefab, doubleJumpTokenPrefab };
        GameObject selectedPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        
        if (selectedPowerUp != null)
        {
            float randomY = Random.Range(groundYPosition, maxAirYPosition);
            Vector3 spawnPosition = new Vector3(spawnXPosition, randomY, 0);
            GameObject spawnedPowerUp = Instantiate(selectedPowerUp, spawnPosition, Quaternion.identity);
            
            // Ensure power-up has MoveLeft script
            if (!spawnedPowerUp.GetComponent<MoveLeft>())
            {
                spawnedPowerUp.AddComponent<MoveLeft>();
            }
            
            // Ensure power-up has DestroyOnLeftExit script
            if (!spawnedPowerUp.GetComponent<DestroyOnLeftExit>())
            {
                spawnedPowerUp.AddComponent<DestroyOnLeftExit>();
            }
        }
    }
    
    void SetNextSpawnTime()
    {
        float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        nextSpawnTime = Time.time + randomInterval;
    }
    
    public void SetSpawnRate(float minInterval, float maxInterval)
    {
        minSpawnInterval = minInterval;
        maxSpawnInterval = maxInterval;
    }
} 