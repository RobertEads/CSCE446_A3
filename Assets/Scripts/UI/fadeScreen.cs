using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2f;
    public Color fadeColor;
    private Renderer rend;

    private Canvas winnerCanvas;
    private Canvas loserCanvas;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        Fade(1, 0, false);
    }

    public void FadeOut()
    {
        Fade(0, 1, true);
    }

    public void Fade(float alphaIn, float alphaOut, bool reload)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut, reload));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut, bool reload)
    {
        float timer = 0;
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer/fadeDuration);

            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);

        if (reload)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
