using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSystem : MonoBehaviour
{
    public int AttributePoints = 0;
    public int level = 1;
    public float expNeeded;
    [SerializeField]public float experience {get; private set;}
    
    BaseStats baseStatsScript;
void Start()
{
    baseStatsScript = FindObjectOfType<BaseStats>();

}
public static int ExpNeedToLvlUp(int level)
{
    if (level == 0 )
    {
        level = 1;
        return 50;
    }
    //return (currentLevel *currentLevel + currentLevel) * 5;

    return (50 * (level));

}

public void SetExperience(float exp)
{
    experience += exp;

    expNeeded = ExpNeedToLvlUp(level);
    //float previousExperience = ExpNeedToLvlUp(level - 1);

//level up with Exp
    if(experience >= expNeeded)
    {
        LevelUp();
        expNeeded = ExpNeedToLvlUp(level);
        //previousExperience = ExpNeedToLvlUp(level - 1);
    }

}

public void LevelUp()
{
    level += 1;
    AttributePoints += 1;
    experience = 0;
    baseStatsScript.increaseStats();
    Debug.Log($"{baseStatsScript.maxHealth}" + "&&&" + $"{baseStatsScript.currentHealth}");
}






















}
