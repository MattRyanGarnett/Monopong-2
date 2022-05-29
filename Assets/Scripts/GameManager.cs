using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // TMP: Freezes game upon end for now - replace with real functionality later
    public void EndGame()
    {
        Time.timeScale = 0f;
    }
}
