using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Corte : MonoBehaviour
{
    public bool enMano;
    public XRGrabInteractable gameObjectInteractuable;
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
            gameObjectInteractuable = gameObject.GetComponent<XRGrabInteractable>();
            gameObjectInteractuable.colliders.Add(GetComponent<MeshCollider>());
            //rb.isKinematic = true;
            StartCoroutine(PosPoner());

            //Destroy(this);
        }
    }

    IEnumerator PosPoner()
	{
        yield return null;
        gameObjectInteractuable = gameObject.GetComponent<XRGrabInteractable>();
        gameObjectInteractuable.hoverEntered.AddListener(ActivarXR);
        gameObjectInteractuable.hoverExited.AddListener(DesactivarXR);
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
