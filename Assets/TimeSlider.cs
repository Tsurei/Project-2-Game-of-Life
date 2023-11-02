using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlider : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
}
