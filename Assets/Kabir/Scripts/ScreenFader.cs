using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        Color color = fadeImage.color;

        float timer = fadeDuration;
        while (timer > 0f)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            color.a = alpha;
            fadeImage.color = color;

            timer -= Time.deltaTime;
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }
}