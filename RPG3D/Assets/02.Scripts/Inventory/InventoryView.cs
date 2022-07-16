using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryView : MonoBehaviour
{
    public static InventoryView instance;
    [SerializeField] private GameObject equipmentView;
    [SerializeField] private GameObject spendView;
    [SerializeField] private GameObject etcView;
    [SerializeField] private Transform equipmentContent;
    [SerializeField] private Transform spendContent;
    [SerializeField] private Transform etcContent;
    private List<InventorySlot> equipmentSlots = new List<InventorySlot>();
    private List<InventorySlot> spendSlots = new List<InventorySlot>();
    private List<InventorySlot> etcSlots = new List<InventorySlot> ();

    public void Refresh(ItemType type, List<Item> items)
    {
        List<InventorySlot> tmpSlots = null;
        switch (type)
        {
            case ItemType.Equipment:
                tmpSlots = equipmentSlots;
                break;
            case ItemType.Spend:
                tmpSlots = spendSlots;
                break;
            case ItemType.ETC:
                tmpSlots = etcSlots;
                break;
            default:
                throw new System.Exception("InventoryView.Refresh() : 잘못된 아이템 타입");
        }

        foreach (var slot in tmpSlots)
            slot.Item = null;

        Queue<Item> queue = new Queue<Item>();
        foreach (var item in items)
            queue.Enqueue(item);

        foreach (var slot in tmpSlots)
        {
            if (queue.Count > 0)
                slot.Item = queue.Dequeue();
            else
                break;
        }   
    }


    public void OnEquipmentButtonClick()
    {
        equipmentView.SetActive(true);
        spendView.SetActive(false);
        etcView.SetActive(false);
    }

    public void OnSpendButtonClick()
    {
        equipmentView.SetActive(false);
        spendView.SetActive(true);
        etcView.SetActive(false);
    }

    public void OnEtcButtonClick()
    {
        equipmentView.SetActive(false);
        spendView.SetActive(false);
        etcView.SetActive(true);
    }

    private void Awake()
    {
        instance = this;
        equipmentSlots = equipmentContent.GetComponentsInChildren<InventorySlot>().ToList();
        spendSlots = spendContent.GetComponentsInChildren<InventorySlot>().ToList();
        etcSlots = etcContent.GetComponentsInChildren<InventorySlot>().ToList();
                
        OnSpendButtonClick();
        OnEtcButtonClick();
        OnEquipmentButtonClick();
    }

    private void Start()
    {
        InventoryModel.instance.LoadInventoryDataFile();
        InventoryModel.instance.RefreshAllItems();
    }
}
