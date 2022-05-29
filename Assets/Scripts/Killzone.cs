using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    private GameManager _gameManager;

    // Get Game manager reference and ask it to end the game upon collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure that the colliding object is a ball
        if (!other.gameObject.TryGetComponent(out Ball ball)) return;

        _gameManager = GetComponentInParent<GameManager>();
        _gameManager.EndGame();
    }
}
