using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Skill
{
    Confidence,
    ExerciseI,
    PublicSpeakerI,
    ElevatingConfidence,
    EverpresentConfidence,
    ExerciseII,
    PublicSpeakerII,
    PositiveReinforcementI,
    PositiveReinforcementII
}

public class SkillTree : MonoBehaviour
{
    [SerializeField]
    Text skillTitle;
    [SerializeField]
    Text skillDescription;
    [SerializeField]
    Image skillIcon;
    [SerializeField]
    Text skillCost;
    [SerializeField]
    GameObject skillUnavailablePanel;
    [SerializeField]
    Text skillUnavailableReason;
    [SerializeField]
    Text currentCharismaText;

    [SerializeField]
    Sprite[] skillIcons;

    PlayerSkill selectedSkill;

    private void Start()
    {
        DisplaySkillInfo(0);
    }

    public void DisplaySkillInfo(int skillID)
    {
        selectedSkill = PlayerStats.current.playerSkills[skillID];
        int requiredSkillID = selectedSkill.requiredSkillID;

        skillUnavailablePanel.SetActive(false);
        skillTitle.text = selectedSkill.skillName;
        skillDescription.text = selectedSkill.description;
        skillCost.text = "Cost: " + selectedSkill.cost.ToString();
        skillIcon.sprite = skillIcons[skillID];

        if (selectedSkill.purchased)
        {
            skillUnavailablePanel.SetActive(true);
            skillUnavailableReason.text = "Skill already learned";
        }
        else if (selectedSkill.cost > PlayerStats.current.currentCharisma)
        {
            skillUnavailablePanel.SetActive(true);
            skillUnavailableReason.text = "Not enough charisma";
        }
        else if (requiredSkillID != -1
            && !PlayerStats.current.playerSkills[requiredSkillID].purchased)
        {
            skillUnavailablePanel.SetActive(true);
            skillUnavailableReason.text = "Previous skill not learned";
        }
    }

    public void LearnSkill()
    {
        selectedSkill.purchased = true;
        PlayerStats.current.currentCharisma -= selectedSkill.cost;
        DisplaySkillInfo(selectedSkill.skillID);
    }

    private void Update()
    {
        currentCharismaText.text = "You have: " + PlayerStats.current.currentCharisma.ToString() + " charisma";
    }

}
