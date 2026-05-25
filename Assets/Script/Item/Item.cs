using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected int itemLevel = 0;
    private int maxItemLevel = 5;
    private int currentLevel = 0;
    
    [SerializeField]
    private string itemName;

    private void Update()
    {
        if (itemLevel == 0)
            return;


    }

    virtual public void StartAutoAttack()
    {

    }

    public void LevelUp()
    {
        if(currentLevel < maxItemLevel)
        {
            itemLevel += 1;
        }
    }

    public string GetItemName()
    { return itemName; }

    public int GetItemLevel()
    { return itemLevel; }
}
