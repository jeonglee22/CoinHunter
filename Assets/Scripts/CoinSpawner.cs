using UnityEngine;
using UnityEngine.UIElements;

public class CoinSpawner : MonoBehaviour
{
	private float spawnRangeMax = 7f;
	private float spawnRangeMin = -7f;

	public GameObject coin;

	public float spawnTimeMax = 3f;
	public float spawnTimeMin = 2.5f;

	private float spawnInterval;
	private float spawnTime;

	private void Start()
	{
		spawnTime = 0f;
		spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
	}

	private void Update()
	{
		var go = GameObject.FindWithTag("GameController");
		if (go.GetComponent<GameManager>().IsGameOver())
			return;

		spawnTime += Time.deltaTime;
		if(spawnTime > spawnInterval)
		{
			float posX = Random.Range(spawnRangeMin, spawnRangeMax);
			float posZ = Random.Range(spawnRangeMin, spawnRangeMax);
			Vector3 localPos = new Vector3(posX, 0, posZ);
			Vector3 spawnPos = transform.position + localPos;
			Instantiate(coin, spawnPos, Quaternion.identity);

			spawnTime = 0f;
			spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
		}
	}
}
