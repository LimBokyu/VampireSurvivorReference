using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void SetTimeScale(bool stopTime)
    {
        Time.timeScale = stopTime ? 0f : 1f;
    }

}
