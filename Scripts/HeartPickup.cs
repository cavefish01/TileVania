using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    [SerializeField] AudioClip heartPickupSFX;
    [SerializeField] int livesForHeart = 1;
    bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered)
        {
            AudioSource.PlayClipAtPoint(heartPickupSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToLives(livesForHeart);
            Destroy(gameObject);
            hasTriggered = true;
        }
    }
}
