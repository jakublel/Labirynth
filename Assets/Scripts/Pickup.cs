using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public float speed = 100;

    private void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.unscaledDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnPicked();
        }
    }

    protected virtual void OnPicked()
    {
        Debug.Log("Podniesiono pickup");
    }
}
