using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlH31 : MonoBehaviour
{
    public AudioSource fuenteSonido;
    public AudioClip[] listaAudios;
    public GameObject[] botones;
    public Animator senora;
    public bool[] botonesUsados;
    public int iteraciones;

    private void Start()
    {
        botonesUsados = new bool[botones.Length];
        StartCoroutine(ReproduccionInicial());
    }
    private IEnumerator Reproducir()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].SetActive(false);
        }
        fuenteSonido.Play();
        senora.SetBool("hablando", true);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !fuenteSonido.isPlaying);
        senora.SetBool("hablando", false);
        yield return new WaitForSeconds(1.5f);

        fuenteSonido.clip = listaAudios[11 + iteraciones];
        fuenteSonido.Play();
        senora.SetBool("hablando", true);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !fuenteSonido.isPlaying);


        senora.SetBool("hablando", false);
        for (int i = 0; i < botones.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            botones[i].SetActive(!botonesUsados[i]);
        }

        if (iteraciones == 5)
        {
            senora.SetBool("hablando", true);
            fuenteSonido.clip = listaAudios[17];
            fuenteSonido.Play();
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => !fuenteSonido.isPlaying);
            senora.SetBool("hablando", false);
        }

    }    
    
    private IEnumerator ReproduccionInicial()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].SetActive(false);
        }
        yield return new WaitForSeconds(3f);
        senora.SetBool("hablando", true);
        fuenteSonido.clip = listaAudios[5];
        fuenteSonido.Play();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !fuenteSonido.isPlaying);
        yield return new WaitForSeconds(1f);
        fuenteSonido.clip = listaAudios[6];
        fuenteSonido.Play();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !fuenteSonido.isPlaying);
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 5; i++)
        {

            fuenteSonido.clip = listaAudios[7+i];
            fuenteSonido.Play();
            yield return new WaitForSeconds(1f);
            botones[i].SetActive(true);
            yield return new WaitUntil(() => !fuenteSonido.isPlaying);
            yield return new WaitForSeconds(1f);
        }

        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponentInChildren<UnityEngine.UI.Button>().interactable = true;
        }
        senora.SetBool("hablando", false);
    }

    public void ReproducirAudio(int indice)
    {
        iteraciones++;
        botonesUsados[indice] = true;
        fuenteSonido.clip = listaAudios[indice];
        StartCoroutine(Reproducir());
    }
}
