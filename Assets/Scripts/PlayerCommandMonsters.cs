using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class controlling the players commands to the monsters
/// including moving, breeding etc
/// </summary>
public class PlayerCommandMonsters : MonoBehaviour
{
    [SerializeField] private MonsterGenerator _monsterGen;

    void Update()
    {
        MoveMonsters();
        BreedMonsters();
    }

    private void BreedMonsters()
    {
        // If player presses B, and only 2 monsters selected, breed them
        if (Input.GetKeyDown(KeyCode.B))
        {
            var selectedM = GameData.GetSelectedMonsters();
            if (selectedM.Count == 2)
            {
                _monsterGen.StartBreeding(selectedM[0], selectedM[1]);
            }
            else
            {
                Debug.Log("Can't breed with more than 2 monsters selected");
            }
        }
    }

    private void MoveMonsters()
    {
        // If player presses M, move all selected monsters towards cursor
        if (Input.GetKeyDown(KeyCode.M))
        {
            var selectedM = GameData.GetSelectedMonsters();
            foreach (var monster in selectedM)
            {
                monster.MoveMonsterTo(GetComponent<PlayerCurser>().getCurserPos().position);
            }
        }
    }
}