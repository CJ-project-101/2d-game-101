using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Assign prefabs in Inspector
    public GameObject coinPrefab;
    public Transform player;

    public float spawnDistance = 20f;  // how far ahead to spawn
    public float minGap = 2f;          // minimum gap between obstacles
    public float maxGap = 5f;          // maximum gap

    private float lastSpawnX;

    void Start()
    {
        lastSpawnX = player.position.x + 10f;
    }

    void Update()
    {
        if (player.position.x + spawnDistance > lastSpawnX)
        {
            SpawnPattern();
        }
    }

    void SpawnPattern()
    {
        float gap = Random.Range(minGap, maxGap);
        lastSpawnX += gap;

        int index = Random.Range(0, obstacles.Length);

        Vector3 obstaclePos = new Vector3(lastSpawnX, 0, 0);
        Instantiate(obstacles[index], obstaclePos, Quaternion.identity);

        if (Random.value > 0.5f)
        {
            Vector3 coinPos = new Vector3(lastSpawnX, 1.5f, 0);
            Instantiate(coinPrefab, coinPos, Quaternion.identity);
        }
    }
}