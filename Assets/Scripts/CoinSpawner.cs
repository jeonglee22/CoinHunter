using UnityEngine;
using UnityEngine.UIElements;

public class CoinSpawner : MonoBehaviour
{
	private float spawnRangeMax = 7f;
	private float spawnRangeMin = -7f;

	public GameObject coin;

	public float spawnTimeMax = 1f;
	public float spawnTimeMin = 0.5f;

	private float spawnInterval;
	private float spawnTime;

	private void Update()
	{
		spawnTime += Time.deltaTime;
		if(spawnTime > spawnInterval)
		{
			float posX = Random.Range(spawnRangeMin, spawnRangeMax);
			float posZ = Random.Range(spawnRangeMin, spawnRangeMax);
			Vector3 localPos = new Vector3(posX, 0, posZ);
			Vector3 spawnPos = transform.position + localPos;
			Instantiate(coin);

			spawnTime = 0f;
		}
	}
}
