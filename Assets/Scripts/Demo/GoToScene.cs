using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
    public void GoToMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToChapter3() {
        SceneManager.LoadScene("Chapter 3");
    }

    public void GoToTemplate() {
        SceneManager.LoadScene("Template Scene");
    }

    public void GoToSeek() {
        SceneManager.LoadScene("Seek Scene");
    }
}
