using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float spawnRangeMax = 8f;
    private float spawnRangeMin = -8f;

    public float spawnTimeMax = 2f;
    public float spawnTimeMin = 1f;

    private float spawnInterval;
    private float spawnTime;

    public GameObject obstacle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = 0f;
        spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > spawnInterval)
        {
			float posX = Random.Range(spawnRangeMin, spawnRangeMax);
			float posZ = Random.Range(spawnRangeMin, spawnRangeMax);

			Vector3 spawnPos = new Vector3(posX, 10f, posZ);

            Instantiate(obstacle, spawnPos, Quaternion.identity);

            spawnTime = 0f;
            spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
		}
    }
}
