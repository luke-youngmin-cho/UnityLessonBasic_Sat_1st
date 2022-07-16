using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController_HPPosion : ItemControllerUsable
{
    public override void Use()
    {
        Debug.Log("플레이어의 체력이 회복되었다!");
        Item removingItem = Instantiate(item);
        removingItem.num = 1;
        InventoryModel.instance.RemoveItemData(removingItem);
    }
}
