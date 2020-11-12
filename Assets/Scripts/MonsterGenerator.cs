using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    // The player who instantiates the monster
    [SerializeField] private GameObject monsterOwner;
    
    // The monster controller - the object underwhich the monster is instantiated
    [SerializeField] private MonsterController _monsterBase;
    
    // The arrays of possible prefabs for each section of the monster
    [SerializeField] private GameObject[] bodyPrefabs;
    [SerializeField] private GameObject[] legPrefabs;
    [SerializeField] private GameObject[] eyePrefabs;
    [SerializeField] private GameObject[] headPropPrefabs;

    // The arrays of possible materials for each section of the monster
    [SerializeField] private Material[] bodyPatternMaterials;
    [SerializeField] private Color[] primaryBodyColors;
    [SerializeField] private Color[] secondaryBodyColors;
    [SerializeField] private Material[] eyeMaterials;


    private bool _canBreed = true;

    void Start()
    {
        //GenerateRandomMonster();
    }

    private void Update()
    {
        // If player right clicks, spawn a random monster (only for testing/dev purposes)
        if (Input.GetMouseButtonDown(1))
        {
            GenerateRandomMonster(monsterOwner.GetComponent<PlayerCurser>().getCurserPos());
        }
    }

    // Generates a monster with randomised parameters at the transform provided
    public void GenerateRandomMonster(Transform newMonstTransform)
    {
        var monsterDict = GetRandomMonsterDictionary();

        var body = (GameObject) monsterDict["body"];
        var leg = (GameObject)monsterDict["leg"];
        var numLegs = (int) monsterDict["numLegs"];
        var patternMat = (Material) monsterDict["bodyPatternMat"];
        var color1 = (Color) monsterDict["col1"];
        var color2 = (Color) monsterDict["col2"];
        var eye = (GameObject) monsterDict["eye"];
        var eyeMat = (Material) monsterDict["eyeMat"];
        var numEyes = (int) monsterDict["numEyes"];
        var headProps = (GameObject) monsterDict["headProps"];


        var monsterBase = Instantiate(_monsterBase, newMonstTransform.position, newMonstTransform.rotation);
        monsterBase.GetComponent<MonsterController>().SetMonsterOwner(monsterOwner);
        var monster = Instantiate(body, monsterBase.transform);
        monster.GetComponent<MonsterBuilder>().BuildMonster(body, leg, numLegs, patternMat, color1, color2, eye, eyeMat, numEyes, headProps);
        
        //TODO remove temp line
        monster.GetComponent<MonsterBuilder>().SetNewMonsterAttributes(Random.Range(0,100), Random.Range(0,100), Random.Range(0,100), Random.Range(0,100), Random.Range(0,100), Random.Range(0,100), Random.Range(0,100));
    }

    // Moves parent1 and parent2 together and breeds them 
    // TODO: moving functionality may be removed/reworked
    public void StartBreeding(MonsterController parent1, MonsterController parent2)
    {
        if (_canBreed)
        {
            Debug.Log("Breeding...");
            var meetingPoint = (parent1.transform.position + parent2.transform.position) / 2;
            parent1.MoveMonsterTo(meetingPoint);
            parent2.MoveMonsterTo(meetingPoint);
            IEnumerator coroutine = Breed(parent1, parent2, meetingPoint);
            StartCoroutine(coroutine);
        }
        else
        {
            Debug.Log("Breeding still occurring");
        }
    }

    // Once monsters are close enough, calls function to generate child from their attributes
    private IEnumerator Breed(MonsterController parent1, MonsterController parent2, Vector3 meetpos)
    {
        _canBreed = false;
        while (!GameData.CheckDestinationReached(parent1.transform.position, meetpos, 2) ||
               !GameData.CheckDestinationReached(parent2.transform.position, meetpos, 2))
        {
            yield return new WaitForSeconds(1);
            print("Nearly there " + Time.time);
        }

        GenerateChildrenMonsters(parent1, parent2);
        _canBreed = true;
    }

    // Spawns a monster with each attribute randomly inherited from each parent
    //TODO add chance for attribute to mutate
    //TODO implement inheriting non-physical attributes
    public void GenerateChildrenMonsters(MonsterController parent1, MonsterController parent2)
    {
        GameObject childBody = null;
        
        GameObject childLeg = null;
        int childNumLegs = 0;
        Material childPatternMat = null;
        Color childCol1 = Color.white;
        Color childCol2 = Color.white;
        GameObject childEye = null;
        Material childEyeMat = null;
        int childNumEyes = 0;
        GameObject childHeadProp = null;

        // Set body of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childBody = parent1.GetComponentInChildren<MonsterBuilder>().getBodyObj();
        }
        else
        {
            childBody = parent2.GetComponentInChildren<MonsterBuilder>().getBodyObj();
        }
        
        // Set leg of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childLeg = parent1.GetComponentInChildren<MonsterBuilder>().getLegObj();
        }
        else
        {
            childLeg = parent2.GetComponentInChildren<MonsterBuilder>().getLegObj();
        }
        
        // Set num legs of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childNumLegs = parent1.GetComponentInChildren<MonsterBuilder>().getNumLegs();
        }
        else
        {
            childNumLegs = parent2.GetComponentInChildren<MonsterBuilder>().getNumLegs();
        }
        
        // Set pattern of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childPatternMat = parent1.GetComponentInChildren<MonsterBuilder>().getBodyPatternMat();
        }
        else
        {
            childPatternMat = parent2.GetComponentInChildren<MonsterBuilder>().getBodyPatternMat();
        }
        
        // Set color1 of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childCol1 = parent1.GetComponentInChildren<MonsterBuilder>().getColor1();
        }
        else
        {
            childCol1 = parent2.GetComponentInChildren<MonsterBuilder>().getColor1();
        }
        
        // Set color2 of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childCol2 = parent1.GetComponentInChildren<MonsterBuilder>().getColor2();
        }
        else
        {
            childCol2 = parent2.GetComponentInChildren<MonsterBuilder>().getColor2();
        }
        
        // Set eye of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childEye = parent1.GetComponentInChildren<MonsterBuilder>().getEyeObj();
        }
        else
        {
            childEye = parent2.GetComponentInChildren<MonsterBuilder>().getEyeObj();
        }
        
        // Set eyes material of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childEyeMat = parent1.GetComponentInChildren<MonsterBuilder>().getEyeMat();
        }
        else
        {
            childEyeMat = parent2.GetComponentInChildren<MonsterBuilder>().getEyeMat();
        }
        
        // Set num eyes of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childNumEyes = parent1.GetComponentInChildren<MonsterBuilder>().getNumEyes();
        }
        else
        {
            childNumEyes = parent2.GetComponentInChildren<MonsterBuilder>().getNumEyes();
        }
        
        // Set head prop of child
        if (Random.Range(0f, 1f) < 0.5f)
        {
            childHeadProp = parent1.GetComponentInChildren<MonsterBuilder>().getHeadPropObj();
        }
        else
        {
            childHeadProp = parent2.GetComponentInChildren<MonsterBuilder>().getHeadPropObj();
        }
       
        
        
        var monsterBase = Instantiate(_monsterBase, parent1.transform.position, parent1.transform.rotation);
        monsterBase.GetComponent<MonsterController>().SetMonsterOwner(monsterOwner);
        var monster = Instantiate(childBody, monsterBase.transform);
        monster.GetComponent<MonsterBuilder>().BuildMonster(childBody, childLeg, childNumLegs, childPatternMat, childCol1, childCol2, childEye, childEyeMat, childNumEyes, childHeadProp);
    }

    public Dictionary<string, object> GetRandomMonsterDictionary()
    {
        Dictionary<string, object> monsterDict = new Dictionary<string, object>();
        monsterDict.Add("body", bodyPrefabs[Random.Range(0, bodyPrefabs.Length)]);
        monsterDict.Add("leg", legPrefabs[Random.Range(0, legPrefabs.Length)]);
        monsterDict.Add("eye", eyePrefabs[Random.Range(0, eyePrefabs.Length)]);
        monsterDict.Add("headProps", headPropPrefabs[Random.Range(0, headPropPrefabs.Length)]);
        monsterDict.Add("numLegs", Random.Range(1, 8));
        monsterDict.Add("numEyes", Random.Range(1, 8));
        monsterDict.Add("bodyPatternMat", bodyPatternMaterials[Random.Range(0, bodyPatternMaterials.Length)]);
        monsterDict.Add("eyeMat", eyeMaterials[Random.Range(0, eyeMaterials.Length)]);
        monsterDict.Add("col1", primaryBodyColors[Random.Range(0, primaryBodyColors.Length)]);
        monsterDict.Add("col2", secondaryBodyColors[Random.Range(0, secondaryBodyColors.Length)]);

        monsterDict.Add("health", Random.Range(0, 100));
        monsterDict.Add("endurance", Random.Range(0, 100));
        monsterDict.Add("strength", Random.Range(0, 100));
        monsterDict.Add("speed", Random.Range(0, 100));
        monsterDict.Add("luck", Random.Range(0, 100));
        monsterDict.Add("intelligence", Random.Range(0, 100));
        monsterDict.Add("accuracy", Random.Range(0, 100));

        return monsterDict;
    }
}