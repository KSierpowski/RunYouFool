using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour
{

    public GameObject[] levels;
    public int selectedLevel = 0;
    public void NextLevel()
    {
        levels[selectedLevel].SetActive(false);
        selectedLevel = (selectedLevel + 1) % levels.Length;
        levels[selectedLevel].SetActive(true);
    }
    public void PreviousLevel()
    {
        levels[selectedLevel].SetActive(false);
        selectedLevel--;
        if (selectedLevel < 0)
        {
            selectedLevel += levels.Length;
        }
        levels[selectedLevel].SetActive(true);
    }
}
