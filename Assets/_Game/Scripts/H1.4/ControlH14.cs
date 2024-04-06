using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlH14 : MonoBehaviour
{
    public AudioClip[] audios;
    public AudioSource pasoReceta;
    public Transform mano;
    public Transform lechuga;

    public void IniciarReceta()
    {
        StartCoroutine(Instrucciones());
    }

    IEnumerator Instrucciones()
    {
        pasoReceta.clip = audios[0];
        pasoReceta.Play();
        float t = 0;
        while (t < 1)
        {
            if (lechuga.parent != null)
            {
                t += 0.25f;
            }
            else
            {
                t = 0;
            }
            yield return new WaitForSeconds(0.25f);
        }
        pasoReceta.clip = audios[1];
        pasoReceta.Play();


    }
}
