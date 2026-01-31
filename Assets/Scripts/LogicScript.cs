using UnityEngine;
using UnityEngine.UI; // ADD FOR UI 
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highscoreText; 
    public GameObject gameOverScreen;
    public LumieScript lumie;
    public AudioSource dingSFX;
    public AudioSource gameOverSFX;
    private bool gameOverTriggered = false;

    void Start()
    {
        lumie = GameObject.FindGameObjectWithTag("Player").GetComponent<LumieScript>();
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        UpdateHighscoreUI();
    }

    [ContextMenu("Increase Score")]
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
        Debug.Log("Quit button pressed (only works in build)");
        Application.Quit();
    }

}
