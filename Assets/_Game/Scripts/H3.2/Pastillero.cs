using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pastillero : MonoBehaviour
{
    public GameObject pastilla;
    public static Pastillero singleton;

    public void CrearPastilla()
    {
        Instantiate(pastilla, transform.position, transform.rotation);
    }

    private void Awake()
    {
        singleton = this;
    }

}
