using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTweening : MonoBehaviour
{
    public TMP_Text gameTitleText;
    public float fadeDuration;

    private void Start()
    {
        StartCoroutine(FadeInGameTitle());
    }

    private IEnumerator FadeInGameTitle()
    {
        // Set initial alpha to zero
        gameTitleText.color = new Color(gameTitleText.color.r, gameTitleText.color.g, gameTitleText.color.b, 0f);

        // Perform fade-in animation
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            gameTitleText.color = new Color(gameTitleText.color.r, gameTitleText.color.g, gameTitleText.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha is set to 1
        gameTitleText.color = new Color(gameTitleText.color.r, gameTitleText.color.g, gameTitleText.color.b, 1f);
    }
}
