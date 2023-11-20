using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeed: MonoBehaviour
{
    public float speedModifier = 2.0f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"&& other.TryGetComponent<PlayerControl>(out var playerControl))
        {
            Vector2 vector2 = playerControl.transform.localScale;
            vector2.y*=-1;
            playerControl.transform.localScale = vector2;
            playerControl.ModifySpeed(speedModifier);
            Destroy(gameObject);
        }
    }
}