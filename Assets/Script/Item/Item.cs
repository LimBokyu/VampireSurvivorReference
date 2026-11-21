using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected int itemLevel = 0;
    private int maxItemLevel = 5;
    
    [SerializeField]
    private string itemName;

    private void Update()
    {
        if (itemLevel == 0)
            return;


    }

    virtual public void UpdateAutoAttack()
    {

    }

    virtual public void AutoAttack()
    {

    }

    virtual public void StartAutoAttack()
    {

    }

    public void LevelUp()
    {
        if(itemLevel < maxItemLevel)
        {
            itemLevel += 1;
        }
    }

    public string GetItemName()
    { return itemName; }

    public int GetItemLevel()
    { return itemLevel; }
}
