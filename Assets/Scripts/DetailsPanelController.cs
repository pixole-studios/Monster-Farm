using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsPanelController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text name;
    [SerializeField] private Image primaryColorPanel, secondaryColorPanel;
    [SerializeField] private Text pageSelectedText;
    [SerializeField] private Text numEyesText, numLegsText;
    
    [Header("Health Objects")]
    [SerializeField] private Text hpAmountText;
    [SerializeField] private Slider hpSlider;
    
    [Header("Endurance Objects")]
    [SerializeField] private Text enduranceAmountText;
    [SerializeField] private Slider enduranceSlider;
    
    [Header("Strength Objects")]
    [SerializeField] private Text strengthAmountText;
    [SerializeField] private Slider strengthSlider;

    [Header("Speed Objects")]
    [SerializeField] private Text speedAmountText;
    [SerializeField] private Slider speedSlider;
    
    [Header("Accuracy Objects")]
    [SerializeField] private Text accuracyAmountText;
    [SerializeField] private Slider accuracySlider;
    
    [Header("Luck Objects")]
    [SerializeField] private Text luckAmountText;
    [SerializeField] private Slider luckSlider;
    
    [Header("Intelligence Objects")]
    [SerializeField] private Text intelligenceAmountText;
    [SerializeField] private Slider intelligenceSlider;
    
    private int numMonsters;
    private int currentlySelected = 0;


    //TODO fix bug where deselecting the monster whilst tab is on it causes error
    private void Update()
    {
        numMonsters = GameData.GetNumMonstersSelected();
        if (numMonsters != 0)
        {
            panel.SetActive(true);
            pageSelectedText.text = (currentlySelected + 1) + "/" + numMonsters;
            UpdateDetails(GameData.GetBuilderFromController(GameData.GetMonsterByIndex(currentlySelected)));
        }
        else
        {
            panel.SetActive(false);
        }
    }

    private void UpdateDetails(MonsterBuilder monster)
    {
        var c1 = monster.getColor1();
        c1.a = 255;
        var c2 = monster.getColor2();
        c2.a = 255;
        primaryColorPanel.color = c1;
        secondaryColorPanel.color = c2;

        var numEyes = monster.getNumEyes();
        numEyesText.text = numEyes + " eyes";

        var numLegs = monster.getNumLegs();
        numLegsText.text = numLegs + " legs";
        
        
        var hp = monster.getHp();
        hpAmountText.text = hp.ToString();
        hpSlider.value = hp;
        
        var endurance = monster.getEndurance();
        enduranceAmountText.text = endurance.ToString();
        enduranceSlider.value = endurance;

        var strength = monster.getStrength();
        strengthAmountText.text = strength.ToString();
        strengthSlider.value = strength;

        var speed = monster.getSpeed();
        speedAmountText.text = speed.ToString();
        speedSlider.value = speed;

        var accuracy = monster.getAccuracy();
        accuracyAmountText.text = accuracy.ToString();
        accuracySlider.value = accuracy;

        var luck = monster.getLuck();
        luckAmountText.text = luck.ToString();
        luckSlider.value = luck;

        var intelligence = monster.getIntelligence();
        intelligenceAmountText.text = intelligence.ToString();
        intelligenceSlider.value = intelligence;
    }

    public void NextPage()
    {
        currentlySelected = (currentlySelected + 1) % numMonsters;
        UpdateDetails(GameData.GetBuilderFromController(GameData.GetMonsterByIndex(currentlySelected)));
    }

    public void PrevPage()
    {
        currentlySelected = (currentlySelected + (numMonsters - 1)) % numMonsters;
        UpdateDetails(GameData.GetBuilderFromController(GameData.GetMonsterByIndex(currentlySelected)));
    }
    
    //TODO refactor how challenges are started - as a temp measure, starting a rtace with a button click
    public void StartRace()
    {
        var race = new RaceOne();
        Debug.Log(race.GetSceneName());
        race.LoadChallenge(GameData.GetMonsterByIndex(currentlySelected));
    }
}