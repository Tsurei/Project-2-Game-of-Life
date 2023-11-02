using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject settings;

    public void OnSettingsClick()
    {
        // Check if the settings GameObject is not active
        if (!settings.activeSelf)
        {
            // If it's not active, set it to active (show settings)
            settings.SetActive(true);
        }
        else
        {
            // If it's active, set it to inactive (hide settings)
            settings.SetActive(false);
        }
    }
}

