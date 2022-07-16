using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemControllerUsable : ItemController, IUsable
{
    public abstract void Use();
}
