using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] Slider slider;

    [Tooltip("Length of the level in seconds")]
    [SerializeField] int levelDurationInSeconds = 60;

    public Action HasTerminated = null; 


    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelDurationInSeconds;

        if (Time.timeSinceLevelLoad >= levelDurationInSeconds)
        {
            HasTerminated?.Invoke();
        }
    }
}
