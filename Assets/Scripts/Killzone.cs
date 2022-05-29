using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameManager = GetComponentInParent<GameManager>();
        _gameManager.EndGame();
    }
}
