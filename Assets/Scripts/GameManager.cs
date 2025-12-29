using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
    public bool isPaused = false;
    public bool isStarted = false;
    public GameObject pauseImg;
    public GameObject finishedImg;
    public GameObject startImg;

    void Start() {
        StartMenu();
        if (finishedImg.activeSelf) finishedImg.SetActive(false);
        if (pauseImg.activeSelf) pauseImg.SetActive(false);
    }


    void Update() {
        CallPauseResume();
    }

    public void CallMainMenu() {
        SceneManager.LoadScene(0);
    }
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CallPauseResume() {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            if (isPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }

    }

    public void Pause() {
        Time.timeScale = 0f;
        isPaused = true;
        pauseImg.SetActive(true);

    }

    public void Resume() {
        Time.timeScale = 1f;
        isPaused = false;
        pauseImg.SetActive(false);
        if(startImg.activeSelf) startImg.SetActive(false);
        if(!isStarted) isStarted = true;
    }

    public void LevelFinished() {
        
        Time.timeScale = 0f;
        finishedImg.SetActive(true);
    }

    public void StartMenu() {
        Time.timeScale = 0f;
        isStarted = false;
        isPaused = true;
        startImg.SetActive(true);
    }
}
