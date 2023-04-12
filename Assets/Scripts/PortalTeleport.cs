using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    public Transform player;
    public Transform receiver;
    private bool PlayerIsOverlapping = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        Teleportation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            PlayerIsOverlapping = true;
            Debug.Log("PLayer entered the portal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            PlayerIsOverlapping = false;
            Debug.Log("Player left the portal");
        }
    }

    private void Teleportation()
    {
        if (!PlayerIsOverlapping) return;

        Vector3 portalToPlayer = player.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

        if (dotProduct < 0f)
        {
            float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
            rotationDiff += 180f;

            Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
            player.position = receiver.position + positionOffset;

            PlayerIsOverlapping = false;
        }
    }
}
