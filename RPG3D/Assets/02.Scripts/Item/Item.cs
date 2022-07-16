using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Spend,
    ETC
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public string tag;
    public string description;
    public int num;
    public Sprite icon;
}
