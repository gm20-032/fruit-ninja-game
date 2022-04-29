using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Fruit : MonoBehaviour
{
	[SerializeField] private GameObject fruitSlicedPrefab;

    [SerializeField] private float startForce = 15f;

    Rigidbody2D rb;


	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		//scoreText = GetComponent<TextMeshProUGUI>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Blade")
		{
			Messenger.Broadcast(GameEvent.FRUIT_SLICED);
			//Blade blade = col.GetComponent<Blade>();
			//Vector3 direction = ((blade != null) ? blade.velocity : col.transform.position - transform.position).normalized;
			//Debug.Log("HiT");
			//Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
			//Destroy(gameObject);
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);	

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
			Destroy(slicedFruit, 3f);
			Destroy(gameObject);
		}
	}
}
