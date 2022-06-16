using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public static void LoadGame()
    {
        SceneManager.LoadScene("Game");   
        Player.SetDefaultValues();
    }

    public static void ShowRules() => SceneManager.LoadScene("Rules");

    public static void LoadStart() => SceneManager.LoadScene("Start");
}
