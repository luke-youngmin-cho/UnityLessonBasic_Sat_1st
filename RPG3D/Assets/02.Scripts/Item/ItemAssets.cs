using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    private static ItemAssets _instance;
    public static ItemAssets instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<ItemAssets>("ItemAssets"));
            return _instance;
        }
    }

    [SerializeField] private List<ItemController> itemControllers;
    [SerializeField] private List<Item> items;

    public bool TryGetItemController(Item item, out ItemController itemController)
    {
        itemController = itemControllers.Find(x => x.item.tag == item.tag);
        return itemController != null;
    }

    public bool TryGetItem(InventoryItemData itemData, out Item item)
    {
        item = items.Find(x => x.tag == itemData.itemTag);
        return item != null;
    }
}
