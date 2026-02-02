using UnityEngine;
using UnityEngine.UI; // ADD FOR UI 
using UnityEngine.SceneManagement; // Tools to access scenes

// MAIN GAME LOGIC

public class LogicScript : MonoBehaviour
{

    // UI
    public int playerScore;
    public Text scoreText;
    public Text highscoreText; 

    // alternate screen
    public GameObject gameOverScreen;

    // imported script
    public LumieScript lumie;

    // SFX
    public AudioSource dingSFX;
    public AudioSource gameOverSFX;

    // check state
    private bool gameOverTriggered = false;

    void Start()
    {
        lumie = GameObject.FindGameObjectWithTag("Player").GetComponent<LumieScript>();
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        UpdateHighscoreUI();
    }

    [ContextMenu("Increase Score")]

    // Logic to increase score
    public void AddScore(int scoreToAdd)
    {
        if (lumie.lumieAlive == true)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString(); 

            int savedHighscore = PlayerPrefs.GetInt("Highscore", 0);
            if (playerScore > savedHighscore)
            {
                PlayerPrefs.SetInt("Highscore", playerScore);
                PlayerPrefs.Save();
            }

            UpdateHighscoreUI();
            dingSFX.Play();  
        }
    } 

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restarts the scene
    }

    public void GameOver()
    {
        if (gameOverTriggered) return;

        gameOverTriggered = true;
        
        gameOverScreen.SetActive(true);
        gameOverSFX.Play();
    }

    public void UpdateHighscoreUI()
    {
        int savedHighscore = PlayerPrefs.GetInt("Highscore", 0);
        if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + savedHighscore.ToString();
        }
    }

    public void Quit()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }

}
