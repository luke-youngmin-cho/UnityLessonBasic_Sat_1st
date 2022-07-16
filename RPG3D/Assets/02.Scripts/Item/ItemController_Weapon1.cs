using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController_Weapon1 : ItemController_Equipment
{
    public override void Use()
    {
        Player.instance.EquipWeapon1(equipmentPrefab);
    }
}
