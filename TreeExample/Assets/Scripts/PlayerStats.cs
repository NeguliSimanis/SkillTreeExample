using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill
{
    public string skillName;
    public int skillID;
    public int cost;
    public bool purchased = false;
    public bool availableForPurchase;
    public string description;
    public int requiredSkillID;

    public PlayerSkill(string name, int ID, int skilCost, bool available, string skillDescription, int requiredSkill)
    {
        skillID = ID;
        skillName = name;
        cost = skilCost;
        availableForPurchase = available;
        description = skillDescription;
        requiredSkillID = requiredSkill;
    }
}

public class PlayerStats
{
    public static PlayerStats current;

    public int maxLives = 3;
    public int currentLives;

    public int currentFriends;
    public int currentCharisma = 0; //calculated from friends

    public int friendRecord = 0;

    #region SKILLS
    // CONFIDENCE ON JUMP
    public bool gainConfidenceOnJump = false;
    public int currentJumpID = 0;
    public int jumpConfidenceGainFrequency = 3;

    // AoE FRIEND GAIN
    public bool gainMultipleFriendsOnButtonPress = false;
    public float gainMultipleFriendsChance = 0.2f;
    public bool multipleFriendsGainEnabled = false;

    // chance to gain life on friend
    public bool canGainLifeOnFriend = false;
    public float gainLifeFromFriendChance = 0.1f;

    public List<PlayerSkill> playerSkills = new List<PlayerSkill>();
    public int selectedSkillID = 0;
    public Sprite selectedSkillSprite;
    #endregion

    public PlayerStats()
    {
        playerSkills.Add(new PlayerSkill("Confidence", 0, 3, true, "Increase your max confidence by 1", -1));
        playerSkills.Add(new PlayerSkill("Exercise I", 1, 10, false, "Gain 1 confidence on every eighth jump", 0));
        playerSkills.Add(new PlayerSkill("Public Speaker I", 2, 8, false, "10% chance to gain an additional friend", 0));
        playerSkills.Add(new PlayerSkill("Elevating Confidence", 3, 15, false, "Increase your max confidence by 1", 1));
        playerSkills.Add(new PlayerSkill("Everpresent Confidence", 4, 15, false, "Increase your max confidence by 1", 2));
        playerSkills.Add(new PlayerSkill("Exercise II", 5, 30, false, "Gain 1 confidence on every fifth jump", 3));
        playerSkills.Add(new PlayerSkill("Public Speaker II", 6, 30, false, "30% additional chance to gain an additional friend", 4));

        playerSkills.Add(new PlayerSkill("Positive Reinforcement I", 7, 20, false, "10% chance to gain 1 confidence when you find a friend", 2));
        playerSkills.Add(new PlayerSkill("Positive Reinforcement II", 8, 40, false, "20% additional chance to gain 1 confidence when you find a friend", 7));
    }

    public void Reset()
    {
        currentLives = maxLives;
        currentFriends = 0;
        currentJumpID = -1;
    }

    public void SetEndGameStats()
    {
        currentCharisma += currentFriends;
        if (currentFriends > friendRecord)
            friendRecord = currentFriends;
    }
}
