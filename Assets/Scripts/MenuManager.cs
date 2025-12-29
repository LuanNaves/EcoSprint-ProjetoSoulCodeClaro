using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public GameObject menuImg;
    public GameObject howToPlayImg;

    private void Start() {
        if (howToPlayImg.activeSelf) howToPlayImg.SetActive(false);
        if (!menuImg.activeSelf) menuImg.SetActive(true);
    }
    public void LevelsMenu() {
        SceneManager.LoadScene(1);
    }

    public void ShowHowToPlay() {
        menuImg.SetActive(false);
        howToPlayImg.SetActive(true);
    }

    public void ReturnToMenu() {
        menuImg.SetActive(true);
        howToPlayImg.SetActive(false);
    }

    public void ExitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            Application.OpenURL("about:blank");
#else
        Application.Quit();
#endif

    }
}
