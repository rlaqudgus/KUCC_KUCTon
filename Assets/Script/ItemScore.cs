using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore : MonoBehaviour
{
    [SerializeField] float scoreValue = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player" && other.TryGetComponent<PlayerManager>(out var playerManager))
        {
            playerManager.IncreaseScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
