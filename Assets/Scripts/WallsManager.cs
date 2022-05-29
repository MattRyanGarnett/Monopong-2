using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsManager : MonoBehaviour
{
    [SerializeField] private Wall[] _walls;

    void Start()
    {
        // At start of game - Iterate through walls, leaving only the first in the list activated.
        for (int i = 0; i < _walls.Length; i++)
        {
            if (i == 0) continue;
            _walls[i].ToggleActive(false);
        }
    }

    // Int to keep track of which wall is currently active
    private int _activeWall = 0;

    private void Update()
    {
        // Detect any and all inputs (Incl. Gamepad/Mobile)
        if(Input.anyKeyDown)
        {
            // Disable currently activated wall
            _walls[_activeWall].ToggleActive(false);

            // Iterate activated wall variable, then wrap it around if it goes past the end of the list
            _activeWall++;
            if (_activeWall > _walls.Length-1) _activeWall = 0;

            // Activate new wall
            _walls[_activeWall].ToggleActive(true);
        }
    }
}
