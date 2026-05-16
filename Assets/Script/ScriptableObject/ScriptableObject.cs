using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;

    public Sprite icon;

    public int maxLevel;

    public float value;
}
