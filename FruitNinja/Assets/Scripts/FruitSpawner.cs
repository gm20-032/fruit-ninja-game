using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// onscreen score
// onscreen lives
// a bad object (a bomb)
// a particle effect (explosion)
// some sound effects (slicing, explosion, music track)
// a game over/restart dialog (show final score on panel)
// a popup that allows you to quit, or continue (and it automatically pauses the game)
// a start the game popup.

public class FruitSpawner : MonoBehaviour
{
	[SerializeField] private GameObject fruitPrefab;
	//[SerializeField] private GameObject bombPrefab;
	[SerializeField] Transform[] spawnPoints;

	[SerializeField] private float minDelay = .1f;
	[SerializeField] private float maxDelay = 1f;

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

			GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 5f);
		}
	}
}
