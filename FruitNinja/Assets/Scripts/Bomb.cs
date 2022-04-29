using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Bomb : MonoBehaviour
{

    [SerializeField] private float startForce2 = 15f;

    Rigidbody2D rb2;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        //scoreText = GetComponent<TextMeshProUGUI>();
        rb2.AddForce(transform.up * startForce2, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Messenger.Broadcast(GameEvent.BOMB_SLICED);
            //explosionParticle.Play();
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            Destroy(gameObject);
        }
    }
}
