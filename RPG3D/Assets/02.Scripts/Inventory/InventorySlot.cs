using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IPointerDownHandler
{
    public bool isItemExist;
    private Image _iconImage;
    private Text _numText;

    private Item _item;
    public Item Item
    {
        set
        {
            _item = value;
            if (value != null)
            {
                _iconImage.sprite = value.icon;
                if (value.num > 1)
                    _numText.text = value.num.ToString();
                else
                    _numText.text = string.Empty;

                if (ItemAssets.instance.TryGetItemController(value, out ItemController itemController))
                {
                    IUsable usable = itemController as IUsable;
                    if (usable != null)
                        OnUse = usable.Use;
                }
                isItemExist = true;
            }
            else
            {
                _iconImage.sprite = null;
                _numText.text = string.Empty;
                isItemExist = false;
                OnUse = null;
            }            
        }
    }

    public delegate void OnUseDelegate();
    public event OnUseDelegate OnUse; // event 한정자 : delegate 를 외부에서 직접 호출할 수 없도록 하는 한정자

    private void Awake()
    {
        _iconImage = transform.GetChild(0).GetComponent<Image>();
        _numText = transform.GetChild(1).GetComponent<Text>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isItemExist)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                if (OnUse != null)
                    OnUse();
            }
        }
    }
}
