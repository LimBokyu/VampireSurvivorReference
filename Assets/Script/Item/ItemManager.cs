using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    private List<Item> itemList;
    private int listSize = 6;

    private void Awake()
    {
        //GameManager.Instance.GetItemManager();
    }

    private void LevelUpItem(Item item)
    {
        for(int index =0; index<listSize; index++)
        {
            if(itemList[index] == item)
            {
                item.LevelUp();
            }
        }    
    }
}
