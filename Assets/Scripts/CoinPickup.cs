using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX = default;
    [SerializeField] [Range(0f,1f)] float volumeSFX = 0.5f;
    [SerializeField] int points = 1;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();
        if (player)
        {
            if (collider == player.GetComponent<CapsuleCollider2D>())
                PickupCoin();
        }
    }

    private void PickupCoin()
    {
        FindObjectOfType<GameSession>().AddToScore(points);
        Destroy(gameObject);
        if (pickupSFX)
            AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position, volumeSFX);
    }
}
