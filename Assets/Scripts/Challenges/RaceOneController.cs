using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceOneController : MonoBehaviour
{
    
    [SerializeField] private MonsterController _competitor;

    [SerializeField] private GameObject player1Empty;
    [SerializeField] private GameObject player2Empty;
    [SerializeField] private GameObject player3Empty;
    [SerializeField] private GameObject player4Empty;
    
    // Start is called before the first frame update
    void Start()
    {
        buildCompetitor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadSceneAsync("MainScene");
        }
    }

    void buildCompetitor()
    {
        // Build the players monster
        var monsterBase = Instantiate(_competitor, player1Empty.transform);
        var monster = Instantiate(RaceOne.body, monsterBase.transform);
        monster.GetComponent<MonsterBuilder>().BuildMonster(RaceOne.body, RaceOne.leg, RaceOne.numLegs, RaceOne.bodyPatternMat, RaceOne.col1, RaceOne.col2, RaceOne.eye, RaceOne.eyeMat, RaceOne.numEyes, RaceOne.headProps);
        monster.GetComponent<MonsterBuilder>().SetNewMonsterAttributes(RaceOne.health, RaceOne.endurance, RaceOne.strength, RaceOne.speed, RaceOne.accuracy, RaceOne.luck, RaceOne.intelligence);
        
        var competitors = new List<Dictionary<string, object>>();
        for (int i = 0; i <= 3; i++) {
            competitors.Add(this.GetComponent<MonsterGenerator>().GetRandomMonsterDictionary());
        }
        // Build the competitors
        // player 2
        var player2MonsterBase = Instantiate(_competitor, player2Empty.transform);
        var player2Monster = Instantiate((GameObject)competitors[0]["body"], player2MonsterBase.transform);
        player2Monster.GetComponent<MonsterBuilder>().BuildMonster((GameObject)competitors[0]["body"], (GameObject)competitors[0]["leg"], (int)competitors[0]["numLegs"], (Material)competitors[0]["bodyPatternMat"], (Color)competitors[0]["col1"], (Color)competitors[0]["col2"], (GameObject)competitors[0]["eye"], (Material)competitors[0]["eyeMat"], (int)competitors[0]["numEyes"], (GameObject)competitors[0]["headProps"]);
        player2Monster.GetComponent<MonsterBuilder>().SetNewMonsterAttributes((int)competitors[0]["health"], (int)competitors[0]["endurance"], (int)competitors[0]["strength"], (int)competitors[0]["speed"], (int)competitors[0]["accuracy"], (int)competitors[0]["luck"], (int)competitors[0]["intelligence"]);
        // player 3
        var player3MonsterBase = Instantiate(_competitor, player3Empty.transform);
        var player3Monster = Instantiate((GameObject)competitors[1]["body"], player3MonsterBase.transform);
        player3Monster.GetComponent<MonsterBuilder>().BuildMonster((GameObject)competitors[1]["body"], (GameObject)competitors[1]["leg"], (int)competitors[1]["numLegs"], (Material)competitors[1]["bodyPatternMat"], (Color)competitors[1]["col1"], (Color)competitors[1]["col2"], (GameObject)competitors[1]["eye"], (Material)competitors[1]["eyeMat"], (int)competitors[1]["numEyes"], (GameObject)competitors[1]["headProps"]);
        player3Monster.GetComponent<MonsterBuilder>().SetNewMonsterAttributes((int)competitors[1]["health"], (int)competitors[1]["endurance"], (int)competitors[1]["strength"], (int)competitors[1]["speed"], (int)competitors[1]["accuracy"], (int)competitors[1]["luck"], (int)competitors[1]["intelligence"]);
        // player 4
        var player4MonsterBase = Instantiate(_competitor, player4Empty.transform);
        var player4Monster = Instantiate((GameObject)competitors[2]["body"], player4MonsterBase.transform);
        player4Monster.GetComponent<MonsterBuilder>().BuildMonster((GameObject)competitors[2]["body"], (GameObject)competitors[2]["leg"], (int)competitors[2]["numLegs"], (Material)competitors[2]["bodyPatternMat"], (Color)competitors[2]["col1"], (Color)competitors[2]["col2"], (GameObject)competitors[2]["eye"], (Material)competitors[2]["eyeMat"], (int)competitors[2]["numEyes"], (GameObject)competitors[2]["headProps"]);
        player4Monster.GetComponent<MonsterBuilder>().SetNewMonsterAttributes((int)competitors[2]["health"], (int)competitors[2]["endurance"], (int)competitors[2]["strength"], (int)competitors[2]["speed"], (int)competitors[2]["accuracy"], (int)competitors[2]["luck"], (int)competitors[2]["intelligence"]);
    }
}
