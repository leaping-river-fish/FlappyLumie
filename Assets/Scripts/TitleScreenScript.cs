using UnityEngine;
using  UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour
{
    public Text highscoreText;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    // function that starts the game
    public void StartGame()
    {
        SceneManager.LoadScene("Game Screen");
    }

    public void Quit()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}
