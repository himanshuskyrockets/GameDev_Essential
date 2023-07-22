using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // Total time limit in seconds
    public Text timerText; // Text component to display the timer
    public float currentTime; // Current time left

    [SerializeField] private GameUI gameOverPanel;
   
    public bool isGameOver;

    [SerializeField] private int lives = 3;
    [SerializeField] private Text livesText;
    [SerializeField] private RectTransform clockHand; // Reference to the clock hand RectTransform

    private float rotationAngle = 15f; // Maximum rotation angle for the clock hand
    private float rotationSpeed = 60f; // Rotation speed in degrees per second

    private float currentRotation; // Current rotation of the clock hand
    private bool isRotatingRight = true; // Flag to track the current rotation direction

    public AudioSource TimerAudio;

    private void Start()
    {
        // Start the timer
        currentTime = timeLimit;
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            enabled = false;
            return; // Don't update the timer if the game is over
      
        }

        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();

            if (currentTime <= 10f)
            {
                
                ClockAlarmRotation(); // Trigger clock rotation when time reaches 10 seconds
                if (!TimerAudio.isPlaying)
                {
                    TimerAudio.Play();
                }
                if (currentTime <= 0f || isGameOver || currentTime > 10f)
                {
                    TimerAudio.mute = true;
                    TimerAudio.Stop();

                }
                else
                {
                    
                    TimerAudio.mute = false;
                }
            }
            else if(currentTime > 10f)
            {
                clockHand.rotation = Quaternion.Euler(0f, 0f, 0f);
                return;
            }

        }
        else
        {
            lives--;
            if (lives == 0)
            {
                GameOver();
            }
            else
            {
                ResetTimer();
            }
            livesText.text = lives.ToString();
        }
    }

    private void UpdateTimerDisplay()
    {
        // Update the timer display text
        int seconds = Mathf.CeilToInt(currentTime);
        timerText.text = seconds.ToString();
    }

    private void GameOver()
    {
        gameOverPanel.GameOver();

        isGameOver = true;
        Debug.Log("Game Over");
      

        // Disable any input or gameplay elements here
    }

    public void ResetTimer()
    {
        currentTime = timeLimit;
        isGameOver = false;
    }

    public void ClockAlarmRotation()
    {
        // Calculate the target rotation based on the current rotation direction
        float targetRotation = isRotatingRight ? rotationAngle : -rotationAngle;

        // Smoothly rotate the clock hand towards the target rotation
        float step = rotationSpeed * Time.deltaTime;
        currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, step);
        clockHand.rotation = Quaternion.Euler(0f, 0f, currentRotation);

        // Reverse the rotation direction when reaching the maximum rotation angle
        if (currentRotation == rotationAngle || currentRotation == -rotationAngle)
        {
            isRotatingRight = !isRotatingRight;
        }
   
    }
}
