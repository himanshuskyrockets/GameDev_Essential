using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Analytics;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Pannels;
    [SerializeField] private float sceneTransitionDelay = 2f;

 
    private void Start()
    {

        for (int i = 0; i < Pannels.Length; i++)
        {
            Pannels[i].SetActive(false);
        }
       
       //if the player is new
        if (PlayerPrefs.GetInt("newPlayer" + SystemInfo.deviceUniqueIdentifier) == 0)
        {
            PlayerPrefs.SetInt("newPlayer " + SystemInfo.deviceUniqueIdentifier, 1);
            PlayerPrefs.Save();
           
        }
        
    }
    private void SceneTransitionOn()
    {
        Pannels[0].SetActive(true); // 0 index is the scene transition pannel
    }


    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneWithTransition(sceneName));
        Analytics.CustomEvent("LoadScene: "  + sceneName);
    }

    private IEnumerator LoadSceneWithTransition(string sceneName)
    {
        SceneTransitionOn();

        yield return new WaitForSeconds(sceneTransitionDelay);

        SceneManager.LoadScene(sceneName);
    }

    public void FollowMe()
    {
       Application.OpenURL("https://www.youtube.com/@ExplorerArts");
       Analytics.CustomEvent("FollowMe");     
    }

    public void QuitGame()
    {
        Application.Quit();
        Analytics.CustomEvent("QuitGame");
    }

    public void RateUs()
    {
        Application.OpenURL("www.playstore.com");
    }

    public void LoadQuitPannel()
    {
        // GameObject
        Pannels[1].SetActive(true);
    }
    public void HideQuitPannel()
    {
        Pannels[1].SetActive(false);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    
}
