using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlBowl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Alimetos alimetos = other.GetComponent<Alimetos>();
        if (alimetos != null)
        {
            ControlH14.singleton.CambiarAlimento(alimetos.tipo);
            if (alimetos.tipo == TipoAlimento.cuchara)
            {
                return;
            }
            else if (alimetos.tipo == TipoAlimento.tomate && !ControlH14.singleton.tomateCortado)
            {
                alimetos.ReiniciarPosicion();
                return;
            }
        }

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

        //if (alimetos.tipo == TipoAlimento.pepino)
        //{
        //    numPepino++;
        //}
    }
}
