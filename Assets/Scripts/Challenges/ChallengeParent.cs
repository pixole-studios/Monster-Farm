using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ChallengeParent
{
    private int numCompetitors; //including own monster
    private static string challengeSceneName;


    public static GameObject body, leg, eye, headProps;
    public static int numLegs, numEyes;
    public static Material bodyPatternMat, eyeMat;
    public static Color col1, col2;

    public static float health, endurance, strength, speed, luck, intelligence, accuracy;

    public ChallengeParent(int numCompetitors, string sceneName)
    {
        this.numCompetitors = numCompetitors;
        challengeSceneName = sceneName;
    }   
    
    public void LoadChallenge(MonsterController competitor)
    {
        body = competitor.GetComponentInChildren<MonsterBuilder>().getBodyObj();
        leg = competitor.GetComponentInChildren<MonsterBuilder>().getLegObj();
        eye = competitor.GetComponentInChildren<MonsterBuilder>().getEyeObj();
        headProps = competitor.GetComponentInChildren<MonsterBuilder>().getHeadPropObj();
        numLegs = competitor.GetComponentInChildren<MonsterBuilder>().getNumLegs();
        numEyes = competitor.GetComponentInChildren<MonsterBuilder>().getNumEyes();
        bodyPatternMat = competitor.GetComponentInChildren<MonsterBuilder>().getBodyPatternMat();
        eyeMat = competitor.GetComponentInChildren<MonsterBuilder>().getEyeMat();
        col1 = competitor.GetComponentInChildren<MonsterBuilder>().getColor1();
        col2 = competitor.GetComponentInChildren<MonsterBuilder>().getColor2();

        health = competitor.GetComponentInChildren<MonsterBuilder>().getHp();
        endurance = competitor.GetComponentInChildren<MonsterBuilder>().getEndurance();
        strength = competitor.GetComponentInChildren<MonsterBuilder>().getStrength();
        speed = competitor.GetComponentInChildren<MonsterBuilder>().getSpeed();
        luck = competitor.GetComponentInChildren<MonsterBuilder>().getLuck();
        intelligence = competitor.GetComponentInChildren<MonsterBuilder>().getIntelligence();
        accuracy = competitor.GetComponentInChildren<MonsterBuilder>().getAccuracy();
            
        SceneManager.LoadSceneAsync(challengeSceneName);
    }

    public string GetSceneName()
    {
        return challengeSceneName;
    }
}
