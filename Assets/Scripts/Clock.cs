using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    public int time = 10;

    protected override void OnPicked()
    {
        Debug.Log("Podniesiono zegarek");
        GameManager.Instance.AddTime(time);
    }
}
