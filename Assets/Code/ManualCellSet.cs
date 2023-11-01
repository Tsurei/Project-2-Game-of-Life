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
        gameOfLife = GetComponent<GameOfLife>();
    }

    public void ToggleManualCellSet(bool isManualSetEnabled)
    {
        if (isManualSetEnabled)
        {
            gameOfLife.EnableManualCellSetting(); 
        }
        else
        {
            gameOfLife.DisableManualCellSetting();
        }
    }
}
