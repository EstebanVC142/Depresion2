using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlH14 : MonoBehaviour
{
    public AudioClip[] audios;
    public AudioSource pasoReceta;
    public Transform mano;
    public Transform lechuga;
    public bool grabLechuga;
    public static ControlH14 singleton;
    [Header("booleanos")]
    public bool lechugaEnBowl;
    public bool tomateEnBowl;
    public bool pepinoEnBowl;
    public bool cucharaEnBowl;
    public bool aceitunaEnBowl;

    public void IniciarReceta()
    {
        StartCoroutine(Instrucciones());
    }

    public void CambiarAlimento(TipoAlimento tipo)
    {
        switch (tipo)
        {
            case TipoAlimento.tomate:
                tomateEnBowl = true;
                break;
            case TipoAlimento.pepino:
                pepinoEnBowl = true;
                break;
            case TipoAlimento.aceitunas:
                aceitunaEnBowl = true;
                break;
            case TipoAlimento.cuchara:
                cucharaEnBowl = true;
                break;
            default:
                break;
        }
    }

    public void CambiarLechuga(bool cambiar)
    {
        grabLechuga = cambiar;
    }
    IEnumerator Instrucciones()
    {
        pasoReceta.clip = audios[0]; // Tomar lechuga
        pasoReceta.Play();
        float t = 0;
        while (t < 1)
        {
            if (grabLechuga)
            {
                t += 0.25f;
            }
            else
            {
                t = 0;
            }
            yield return new WaitForSeconds(0.25f);
        }
        pasoReceta.clip = audios[1]; // Lechuga al Bowl
        pasoReceta.Play();

        yield return new WaitUntil(() => lechugaEnBowl);

        pasoReceta.clip = audios[0]; // Tomar tomate
        pasoReceta.Play();

    }

    private void Awake()
    {
        singleton = this;
    }
}
