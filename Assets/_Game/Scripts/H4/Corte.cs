using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Corte : MonoBehaviour
{
    public bool enMano;
    public void ActivarXR(HoverEnterEventArgs a)
    {
        enMano = true;
    }
    public void DesactivarXR(HoverExitEventArgs b)
    {
        enMano = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("dentro"+other.tag);
        if (other.CompareTag("cuchillo"))
        {
            transform.SetParent(null);
            print("separo");
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            XRGrabInteractable gameObjectInteractuable= gameObject.AddComponent<XRGrabInteractable>();
            //rb.isKinematic = true;
            gameObjectInteractuable.hoverEntered.AddListener(ActivarXR);
            gameObjectInteractuable.hoverExited.AddListener(DesactivarXR);
            gameObjectInteractuable.colliders.Add(GetComponent<MeshCollider>());
            //Destroy(this);
        }
    }

    void casa(HoverEnterEventArgs a)
    {
        
    }
}
