using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualCellSetController : MonoBehaviour
{
    private GameOfLife gameOfLife;
    public Toggle manualCellSetToggle;

    void Start()
    {
        // Find and reference the GameOfLife component
        gameOfLife = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameOfLife>();
    }

    public void ToggleManualCellSet(Toggle isManualSetEnabled)
    {
        if (isManualSetEnabled.isOn)
        {
            // Enable manual cell setting in the GameOfLife component
            gameOfLife.EnableManualCellSetting();
        }
        else
        {
            // Disable manual cell setting in the GameOfLife component
            gameOfLife.DisableManualCellSetting();
        }
        Debug.Log(isManualSetEnabled.isOn);
    }
}
