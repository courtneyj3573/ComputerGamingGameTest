using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceBar : MonoBehaviour
{
    public Slider experienceSlider;

    public int maxExperience = 100;
    private int currentExperience = 0;

    void Start() {
        UpdateExperienceBar();
    }
}
