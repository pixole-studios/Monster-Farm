using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // List of all the currently selected monsters
    private static List<MonsterController> _selectedMonsters;
    
//    // The monster competing in the current challenge
//    private static MonsterController _currentlyCompetingMonster;

    private void Start()
    {
        _selectedMonsters = new List<MonsterController>();
    }

    // Add monster to list of selected monsters
    public static void AddMonsterToSelected(MonsterController monster)
    {
        _selectedMonsters.Add(monster);
    }

    // Remove monster from list of selected monsters
    public static void RemoveMonsterFromSelected(MonsterController monster)
    {
        _selectedMonsters.Remove(monster);
    }

    // Return the list of slected monsters
    public static List<MonsterController> GetSelectedMonsters()
    {
        return _selectedMonsters;
    }

    public static void DeselectAllMonsters()
    {
        _selectedMonsters.Clear();
    }

    public static int GetNumMonstersSelected()
    {
        return _selectedMonsters.Count;
    }

    public static MonsterController GetMonsterByIndex(int i)
    {
        return _selectedMonsters[i];
    }

    public static MonsterBuilder GetBuilderFromController(MonsterController m)
    {
        return m.gameObject.GetComponentInChildren<MonsterBuilder>();
    }
    
    // Return true if the vectors are within the threshold distance of each other
    public static bool CheckDestinationReached(Vector3 start, Vector3 destination, float threshold)
    {
        float distanceToTarget = Vector3.Distance(start, destination);
        return distanceToTarget < threshold;
    }


//    public static void SetCompetingMonster(MonsterController monster)
//    {
//        //DontDestroyOnLoad(monster);
//        _currentlyCompetingMonster = monster;
//    }
//
//    public static MonsterController GetCompetingMonster()
//    {
//        return _currentlyCompetingMonster;
//    }
}