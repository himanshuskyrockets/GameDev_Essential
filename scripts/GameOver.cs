using UnityEngine;

public class GameOver : MonoBehaviour
{
    private PlayerHud playerHud;
    public  GameObject[] gameObjectsToDisable;

    private void Start()
    {
        playerHud = FindObjectOfType<PlayerHud>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetGameOver();
        }
    }

    public void SetGameOver()
    {
        if (playerHud != null)
        {
            playerHud.GameOver();
            
            foreach (GameObject gameObjectToDisable in gameObjectsToDisable)
            {
                gameObjectToDisable.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("PlayerHud component not found in the scene.");
        }
    }
}//class
