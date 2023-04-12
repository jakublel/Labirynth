using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup
{
    protected override void OnPicked()
    {
        Debug.Log("Podniesiono Diament");
        GameManager.Instance.AddDiamond();
    }
}
