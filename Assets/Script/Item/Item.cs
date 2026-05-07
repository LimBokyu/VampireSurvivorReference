using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private int itemLevel = 0;
    private int maxItemLevel = 5;
    private int currentLevel = 0;


    public void LevelUp()
    {
        if(currentLevel < maxItemLevel)
        {
            itemLevel += 1;
        }
    }
}
