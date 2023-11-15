using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPEditor : MonoBehaviour
{
    [SerializeField]
    int maxExperience;
    //UI slider component
    public Slider experienceSlider;
    //Sets current experience
    private int currentExperience = 0;
    //current level
    public Text levelText;
    private int currentLevel = 1;

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
            //updates UI
            UpdateExperienceBar();
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

    void Start() {
        //Initialize experience bar
        UpdateExperienceBar();
    }

    //Update the UI elements based on current experience value
    void UpdateExperienceBar() {
        float fillAmount = (float)currentExperience / maxExperience;

        //Updates slider
        experienceSlider.value = fillAmount;
        levelText.text = $"Level {currentLevel}";
    }

}
