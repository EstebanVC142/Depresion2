using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlEscena : MonoBehaviour
{
    public Transicion transicion;
    public static ControlEscena singleton;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void GoToScene(string sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(string sceneIndex)
    {
        transicion.FadeOut();
        yield return new WaitForSeconds(transicion.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
        
        
        

    }
    
}
