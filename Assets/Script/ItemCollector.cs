using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int totalScore;
    private int coins = 0;

    [SerializeField] Text CoinsCount;
    [SerializeField] private AudioClip pickSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            coins++;
            AudioSource.PlayClipAtPoint(pickSound, collision.transform.position);
            CoinsCount.text = "Coins: " + coins;
        }
    }
}
