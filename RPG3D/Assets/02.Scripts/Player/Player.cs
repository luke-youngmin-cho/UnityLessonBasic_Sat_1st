using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public PlayerStateMachineManager stateMachineManager;

    [SerializeField] private Transform weapon1Point;

    public void EquipWeapon1(GameObject weapon1Prefab)
    {
        Weapon1 weapon1 = Instantiate(weapon1Prefab, weapon1Point).GetComponent<Weapon1>();
        if (stateMachineManager.TryGetMachine(PlayerState.Attack, out PlayerStateMachine machine))
        {
            (machine as PlayerStateMachine_Attack).weapon1 = weapon1;
        }
    }


    private void Awake()
    {
        instance = this;
        stateMachineManager = GetComponent<PlayerStateMachineManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ItemTrigger"))
        {
            if (Input.GetKey(KeyCode.Z))
                other.gameObject.GetComponentInParent<ItemController>().PickUp(this);
        }
    }
}
