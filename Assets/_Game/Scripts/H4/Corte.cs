using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Corte : MonoBehaviour
{
    public bool enMano;
    XRGrabInteractable gameObjectInteractuable;
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
        if (other.CompareTag("cuchillo"))
        {
            transform.SetParent(null);
            print("separo");
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            gameObjectInteractuable = gameObject.AddComponent<XRGrabInteractable>();
            gameObjectInteractuable.colliders.Add(GetComponent<MeshCollider>());
            //rb.isKinematic = true;
            gameObjectInteractuable.hoverEntered.AddListener(ActivarXR);
            gameObjectInteractuable.hoverExited.AddListener(DesactivarXR);
            Invoke("PosPoner", 0.5f);
            
            //Destroy(this);
        }
    }

    void PosPoner()
	{
        gameObjectInteractuable.colliders.Clear();
        MeshCollider c = GetComponent<MeshCollider>();
        MeshCollider c2 = new MeshCollider();
        c2.sharedMesh = c.sharedMesh;
        c2.convex = c.convex;
        Destroy(GetComponent<MeshCollider>());
        gameObject.AddComponent<MeshCollider>();
        c = GetComponent<MeshCollider>();
        c.sharedMesh = c2.sharedMesh;
        c.convex = c2.convex;
        gameObjectInteractuable.colliders.Add(GetComponent<MeshCollider>());

    }

    void casa(HoverEnterEventArgs a)
    {
        
    }
}
