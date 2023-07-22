using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    public GameObject[] UIPanel; 
    

    private void Start()
    {  
        UIPanel[0].SetActive(false); // 0 index is the game over pannel
        UIPanel[1].SetActive(true);//1 index is the game play pannel
        UIPanel[2].SetActive(false);//2 index is the Hint pannel
        UIPanel[3].SetActive(false);//3 index is the game menu pannel
    }

  public void RestartGame()
    {
        UIPanel[1].SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void SetActivePanel(GameObject panel)
    {
        UIPanel[0].SetActive(false);
        UIPanel[1].SetActive(false);

        panel.SetActive(true);
    }
    public void LoadHintPanel()
    {
        UIPanel[2].SetActive(true);
    }
    public void CancelCommand()
    {
        UIPanel[2].SetActive(false);
        UIPanel[1].SetActive(true);
    }

    
    public void BackLevel()
    {
        SceneManager.LoadScene("LevelManager");
    }
    public void LoadMenuPanel()
    {
        UIPanel[3].SetActive(true);
    }
    public void CancelMenu()
    {
        UIPanel[3].SetActive(false);
        UIPanel[1].SetActive(true);
    }

    public void GameOver()
    {
        UIPanel[0].SetActive(true);
        UIPanel[1].SetActive(false);
        UIPanel[2].SetActive(false);
        UIPanel[3].SetActive(false);
    }
    
    public void loadstartMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
