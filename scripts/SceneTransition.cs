using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public GameObject transitionCanvas;
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;

    private const float TransitionDuration = 2f;

    private void Start()
    {
        loadingBar.value = 0;
        loadingText.text = "Loading... 0%";
        transitionCanvas.SetActive(false);
    }

    public void FadeOut()
    {
        transitionCanvas.SetActive(true);
        LeanTween.alphaCanvas(transitionCanvas.GetComponent<CanvasGroup>(), 1f, 1f).setEaseInCubic();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(TransitionAndLoadAsync(sceneName));
    }

    private IEnumerator TransitionAndLoadAsync(string sceneName)
    {
        transitionCanvas.SetActive(true);
         yield return new WaitForSeconds(1.2f);
        yield return StartCoroutine(FadeInTransitionCanvas());
        yield return StartCoroutine(LoadAsync(sceneName));
        yield return StartCoroutine(FadeOutTransitionCanvas());
    }

    private IEnumerator FadeInTransitionCanvas()
    {
        float timer = 0f;
        while (timer < TransitionDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / TransitionDuration);
            SetTransitionCanvasAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        SetTransitionCanvasAlpha(1f); 
    }

    private IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f) * 100f;
            UpdateLoadingBar(progress);
            yield return null;
        }
        UpdateLoadingBar(100f);
        
    }

    private IEnumerator FadeOutTransitionCanvas()
    {
        float timer = 0f;
        while (timer < TransitionDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / TransitionDuration);
            SetTransitionCanvasAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        SetTransitionCanvasAlpha(0f);
        transitionCanvas.SetActive(false);
    }

    private void SetTransitionCanvasAlpha(float alpha)
    {
        CanvasGroup canvasGroup = transitionCanvas.GetComponent<CanvasGroup>();
        canvasGroup.alpha = alpha;
    }

    private void UpdateLoadingBar(float progress)
    {
        loadingBar.value = progress;
        loadingText.text = $"Loading... {progress}%";
    }
}
