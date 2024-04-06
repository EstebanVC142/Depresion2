using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlBowl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable inter = other.GetComponent<XRGrabInteractable>();
        if (inter != null)
        {
            Destroy(inter);
        }

        Lechuga lechuga = other.GetComponent<Lechuga>();
        if (lechuga != null)
        {
            lechuga.DesarmarLechuga();
        }
    }
}
