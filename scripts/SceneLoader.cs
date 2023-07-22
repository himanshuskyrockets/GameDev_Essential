using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
   public SceneTransition sceneTransition;
    
     
    private void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

 public void LoadA(string scenename)
    {
     //    Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }

 public void QuitGamec()
  {
       Application.Quit();   
       
      #if UNITY_EDITOR
       Debug.Log("exit..");
      #endif
  }
  
}//Class
