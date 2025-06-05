using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Image boostGauge;
    public GameObject gameOverPanel;
    public Button pauseButton;
    public Button retryButton;
    public Button resumeButton;
    
    [Header("Game Settings")]
    public int baseScorePerSecond = 10;
    public int comboScoreBonus = 50;
    
    // Game State
    private int currentScore = 0;
    private int highScore = 0;
    private int comboMultiplier = 1;
    private float gameTime = 0f;
    private bool isGameActive = true;
    private bool isPaused = false;
    
    // Audio
    private AudioSource audioSource;
    
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LoadHighScore();
        SetupUI();
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if (isGameActive && !isPaused)
        {
            gameTime += Time.deltaTime;
            
            // Add score every second
            currentScore += Mathf.FloorToInt(baseScorePerSecond * Time.deltaTime);
            UpdateScoreUI();
        }
    }
    
    void SetupUI()
    {
        if (pauseButton) pauseButton.onClick.AddListener(PauseGame);
        if (retryButton) retryButton.onClick.AddListener(RestartGame);
        if (resumeButton) resumeButton.onClick.AddListener(ResumeGame);
        
        if (gameOverPanel) gameOverPanel.SetActive(false);
        
        UpdateScoreUI();
        UpdateHighScoreUI();
    }
    
    public void AddComboPoints(int points)
    {
        currentScore += points * comboMultiplier;
        comboMultiplier++;
        UpdateScoreUI();
    }
    
    public void BreakCombo()
    {
        comboMultiplier = 1;
        // Could add visual feedback here
    }
    
    public void UpdateBoostGauge(float chargeAmount)
    {
        if (boostGauge)
        {
            boostGauge.fillAmount = chargeAmount;
        }
    }
    
    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0f;
        
        // Check for high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
            UpdateHighScoreUI();
        }
        
        // Show game over panel
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(true);
        }
        
        // Report score to leaderboard (Google Play Games Services stub)
        ReportScoreToLeaderboard(currentScore);
    }
    
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        // Show pause menu if you have one
    }
    
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        // Hide pause menu if you have one
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void UpdateScoreUI()
    {
        if (scoreText)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
    
    void UpdateHighScoreUI()
    {
        if (highScoreText)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
    
    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    
    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }
    
    void ReportScoreToLeaderboard(int score)
    {
        // Google Play Games Services integration stub
        // Uncomment and configure when ready to integrate
        /*
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, "YOUR_LEADERBOARD_ID", (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Score reported successfully");
                }
                else
                {
                    Debug.Log("Failed to report score");
                }
            });
        }
        */
        
        Debug.Log($"Score {score} would be reported to leaderboard");
    }
    
    // Public getters
    public bool IsGameActive() { return isGameActive; }
    public bool IsPaused() { return isPaused; }
    public int GetCurrentScore() { return currentScore; }
    public int GetHighScore() { return highScore; }
} 