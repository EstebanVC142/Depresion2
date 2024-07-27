using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioInicio : MonoBehaviour
{

    public EventoAudioInicio[] eventos;


    void Start()
    {
        Reproducir(0);
    }

    public void Reproducir(int cual)
    {
        eventos[cual].Iniciar(this);
    }
  
}

[System.Serializable]
public class EventoAudioInicio
{
    public AudioSource fuenteSonido;
    public AudioClip clip;
    public Animator animaciones;
    public UnityEvent eventoFinal;

    public void Iniciar(MonoBehaviour m)
    {
        m.StartCoroutine(Reproducir());
    }

    private IEnumerator Reproducir()
    {
        fuenteSonido.clip = clip;
        fuenteSonido.Play();
        animaciones.SetBool("hablando", true);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !fuenteSonido.isPlaying);
        animaciones.SetBool("hablando", false);
        eventoFinal.Invoke();
    }

}