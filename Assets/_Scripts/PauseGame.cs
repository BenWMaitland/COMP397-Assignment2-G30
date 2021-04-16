using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public QuestGiver questGiver;

    // Start is called before the first frame update
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(y);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        questGiver.SetQuestsInactive();
        questGiver.quest = questGiver.questList[0];
        questGiver.OpenQuestWindow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TogglePaused()
    {
        if (GameIsPaused)
        {
            ResumeGame();
        }
        else
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            Pause();
        }
    }

    public void OnPauseButtonPressed()
    {
        TogglePaused();
    }
}
