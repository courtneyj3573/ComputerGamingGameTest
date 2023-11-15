using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPEditor : MonoBehaviour
{
    [SerializeField]
    int currentExperience, maxExperience,
        currentLevel;

    private void OnEnable() {
        //subscribe to event
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }

    private void OnDisable() {
        //unsubscribe to event
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }

    private void HandleExperienceChange(int newExperience) {
        currentExperience += maxExperience;
        if(currentExperience >= maxExperience) {
            LevelUp();
            //add UI change
        }
    }

    private void LevelUp() {
        //Adds 1 level
        currentLevel++;
        //Starts bar at 0 so there is no carry over experience
        currentExperience = 0;
        //increases the amount of experience needed to level up by 100
        maxExperience += 100;
    }
}
