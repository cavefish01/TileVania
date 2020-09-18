using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoin = 100;
    bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasTriggered)
        {
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToScore(pointsForCoin);
            hasTriggered = true;
            Destroy(gameObject);
        }

    }

}
