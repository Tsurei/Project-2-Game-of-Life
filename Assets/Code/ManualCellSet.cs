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
        gameOfLife = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameOfLife>();
    }

    public void ToggleManualCellSet(Toggle isManualSetEnabled)
    {
        if (isManualSetEnabled.isOn)
        {
            gameOfLife.EnableManualCellSetting();
        }
        else
        {
            gameOfLife.DisableManualCellSetting();
        }
        Debug.Log(isManualSetEnabled.isOn);
    }
}
