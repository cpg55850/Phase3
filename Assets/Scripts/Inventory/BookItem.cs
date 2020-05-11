using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Book")]
public class BookItem : Item
{
    public override void Use()
    {
        PlayerManager.instance.player.GetComponent<ThirdPersonCharacterController>().GetBook();
    }
}
