using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BombSpawner : MonoBehaviour
{
	[SerializeField] private GameObject bombPrefab;
	[SerializeField] Transform[] spawnPoints;

	[SerializeField] private float minDelay = .6f;
	[SerializeField] private float maxDelay = 2f;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);
			// Spawn Friut
			int spawnIndex = Random.Range(0, spawnPoints.Length);

			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 5f);
		}
	}
}
