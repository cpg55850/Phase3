using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/UpCube")]
public class UpCube : Item
{
    public override void Use()
    {
        PlayerManager.instance.player.GetComponent<ThirdPersonCharacterController>().MakeCube();
    }
}
