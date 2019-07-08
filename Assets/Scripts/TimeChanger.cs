using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeChanger : MonoBehaviour
{
    public Text timeText;

    static List<float> timeSteps = new List<float>()
    {
        0.25f,
        0.5f,
        1.0f,
        2.0f,
        5.0f,
        10.0f,
        15.0f,
        25.0f,
        50.0f,
        100.0f,
        200.0f,
        500.0f,
    };

    private int currentIndex = 2;

    public float GetCurrentModifier()
    {
        return timeSteps[currentIndex];
    }

    private void UpdateSpeed()
    {
        timeText.text = GetCurrentModifier().ToString();
        Time.timeScale = timeSteps[currentIndex];
    }

    public void AddStep()
    {
        if (currentIndex + 1 != timeSteps.Count)
            ++currentIndex;
        this.UpdateSpeed();
    }

    public void MinusStep()
    {
        if (currentIndex > 0)
            --currentIndex;
        this.UpdateSpeed();
    }

}
