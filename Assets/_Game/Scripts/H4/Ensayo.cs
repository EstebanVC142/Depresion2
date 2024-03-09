using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Ensayo : MonoBehaviour
{
    private void Start()
    {
        gameObject.AddComponent<XRGrabInteractable>();
    }
}
