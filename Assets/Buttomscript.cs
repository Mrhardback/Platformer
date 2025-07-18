using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttomscript : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnApplicationQuit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
