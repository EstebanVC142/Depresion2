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
            ControlH14.singleton.lechugaEnBowl = true;
        }

        Alimetos alimetos = other.GetComponent<Alimetos>();
        if (alimetos != null)
        {
            ControlH14.singleton.CambiarAlimento(alimetos.tipo);
        }
    }
}
