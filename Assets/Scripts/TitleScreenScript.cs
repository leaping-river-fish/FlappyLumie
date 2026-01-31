using UnityEngine;
using  UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour
{
    public Text highscoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game Screen");
    }

    public void Quit()
    {
        Debug.Log("Quit button pressed (only works in build)");
        Application.Quit();
    }
}
