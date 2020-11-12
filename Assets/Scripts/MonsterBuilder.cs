using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.StyleSheets;
using UnityEngine;

public class MonsterBuilder : MonoBehaviour
{
    [Header("Leg Mounts")] [Tooltip("If the monster has an odd number of legs, this mount is used")] [SerializeField]
    private GameObject _oddLegMount;

    [SerializeField] private GameObject[] _legMounts;

    [Header("Eye Mounts")] [Tooltip("If the monster has an odd number of eyes, this mount is used")] [SerializeField]
    private GameObject _oddEyeMount;

    [SerializeField] private GameObject[] _eyeMounts;
    [SerializeField] private GameObject[] _headPropMounts;

    // The reference object that holds the body shape
    private GameObject _monsterBodyRef;

    private GameObject _legObj;
    private int _numLegs;
    private Material _bodyPatternMat;
    private Color _color1, _color2;
    private GameObject _eyeObj;
    private Material _eyeMat;
    private int _numEyes;
    private GameObject _headPropObj;

    // Monster Non-Physical Attributes - also TODO be inherited from parents
    private float _maxHp = 0, _currentHp = 0;
    private float _endurance = 0;
    private float _strength = 0;
    private float _speed = 0;
    private float _accuracy = 0;
    private float _luck = 0;
    private float _intelligence = 0;


    // Construct a monster using the provided parameters
    /**
     * NB monsterBodyRef doesn't do anything, is stored as a reference for creating child monstors
     */
    public void BuildMonster(GameObject monsterBodyRef, GameObject legPrefab, int numLegs, Material bodyPatternMat,
        Color color1, Color color2, GameObject eyePrefab, Material eyeMat, int numEyes, GameObject headPropPrefab)
    {
        _monsterBodyRef = monsterBodyRef;

        _legObj = legPrefab;
        _numLegs = numLegs;
        _bodyPatternMat = Instantiate(bodyPatternMat as Material);
        _color1 = color1;
        _color2 = color2;
        _eyeObj = eyePrefab;
        _eyeMat = eyeMat;
        _numEyes = numEyes;
        _headPropObj = headPropPrefab;

        _bodyPatternMat.SetColor("Color_FAF1895F", color1);
        _bodyPatternMat.SetColor("Color_524C8774", color2);

        GetComponent<MeshRenderer>().material = this._bodyPatternMat;
        createLegs(legPrefab, numLegs, this._bodyPatternMat);
        createEyes(eyePrefab, eyeMat, numEyes, this._bodyPatternMat);
        createHeadProps(headPropPrefab);
    }

    public void SetNewMonsterAttributes(float maxHp, float endurance, float strength, float speed, float accuracy,
        float luck, float intelligence)
    {
        _maxHp = maxHp;
        _currentHp = maxHp;
        _endurance = endurance;
        _strength = strength;
        _speed = speed;
        _accuracy = accuracy;
        _luck = luck;
        _intelligence = intelligence;
    }

    // Instantiate legs on the monster
    // TODO make legs use bodyMat
    private void createLegs(GameObject legPrefab, int numLegs, Material bodyMat)
    {
        if (numLegs % 2 == 1)
        {
            var leg = Instantiate(legPrefab, _oddLegMount.transform);
        }

        for (int i = 0; i < (numLegs - (numLegs % 2)); i++)
        {
            var leg = Instantiate(legPrefab, _legMounts[i].transform);
        }
    }

    // Instantiate eyes on the monster
    private void createEyes(GameObject eyePrefab, Material eyeMat, int numEyes, Material bodyMat)
    {
        if (numEyes % 2 == 1)
        {
            var eye = Instantiate(eyePrefab, _oddEyeMount.transform);
            eye.GetComponent<EyeBuilder>().SetMaterials(bodyMat, eyeMat);
        }

        for (int i = 0; i < (numEyes - (numEyes % 2)); i++)
        {
            var eye = Instantiate(eyePrefab, _eyeMounts[i].transform);
            eye.GetComponent<EyeBuilder>().SetMaterials(bodyMat, eyeMat);
        }
    }

    // Instantiate head props (horns, hats etc.) on the monster
    private void createHeadProps(GameObject headPropPrefab)
    {
        for (int i = 0; i < _headPropMounts.Length; i++)
        {
            Instantiate(headPropPrefab, _headPropMounts[i].transform);
        }
    }


    // Getters for private
    // monster attributes

    public GameObject getBodyObj()
    {
        return _monsterBodyRef;
    }

    public GameObject getLegObj()
    {
        return _legObj;
    }

    public int getNumLegs()
    {
        return _numLegs;
    }

    public Material getBodyPatternMat()
    {
        return _bodyPatternMat;
    }

    public Color getColor1()
    {
        return _color1;
    }

    public Color getColor2()
    {
        return _color2;
    }

    public GameObject getEyeObj()
    {
        return _eyeObj;
    }

    public Material getEyeMat()
    {
        return _eyeMat;
    }

    public int getNumEyes()
    {
        return _numEyes;
    }

    public GameObject getHeadPropObj()
    {
        return _headPropObj;
    }


    // Getters for non-physical attributes
    public float getHp()
    {
        return _currentHp;
    }

    public float getEndurance()
    {
        return _endurance;
    }

    public float getStrength()
    {
        return _strength;
    }

    public float getSpeed()
    {
        return _speed;
    }

    public float getAccuracy()
    {
        return _accuracy;
    }

    public float getLuck()
    {
        return _luck;
    }

    public float getIntelligence()
    {
        return _intelligence;
    }
}