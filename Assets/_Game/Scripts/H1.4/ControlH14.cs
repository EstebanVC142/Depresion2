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
    [Header("Booleanos")]
    public bool lechugaEnBowl;
    public bool tomateEnBowl;
    public bool pepinoEnBowl;
    public bool cucharaEnBowl;
    public bool aceitunaEnBowl;
    public bool tomateCortado;
    public bool pepinoCortado;

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
        while (t < 0.5)
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

        pasoReceta.clip = audios[2]; // Tomar y picar tomate
        pasoReceta.Play();

        yield return new WaitUntil(() => tomateCortado);

        pasoReceta.clip = audios[3]; // Tomate al bowl
        pasoReceta.Play();

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitUntil(() => tomateEnBowl);
            tomateEnBowl = false;
            //print("tomate" + i);
        }
        pasoReceta.clip = audios[4]; // Tomar y picar pepino
        pasoReceta.Play();

        yield return new WaitUntil(() => pepinoCortado);

        pasoReceta.clip = audios[5]; // Pepino al bowl
        pasoReceta.Play();

        for (int j = 0; j < 7; j++)
        {
            yield return new WaitUntil(() => pepinoEnBowl);
            pepinoEnBowl = false;
        }

        pasoReceta.clip = audios[6]; // Aceituna al bowl
        pasoReceta.Play();

        for (int k = 0; k < 6; k++)
        {
            yield return new WaitUntil(() => aceitunaEnBowl);
            aceitunaEnBowl = false;
        }

        pasoReceta.clip = audios[7]; // Aplicar sal y aceite

        pasoReceta.Play();

        yield return new WaitForSeconds(10f);

        pasoReceta.clip = audios[8]; // Revolver bowl
        pasoReceta.Play();
    }

    private void Awake()
    {
        singleton = this;
    }
}
