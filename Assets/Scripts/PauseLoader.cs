using UnityEngine;

public class PauseLoader : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private static bool _isGamePaused;

    public void LoadStart()
    {
        Resume();
        StartManager.LoadStart();
    }

    public void Quit() => Application.Quit();

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
        CameraMovement.CanMove = true;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (_isGamePaused)
            Resume();
        else
            Pause();
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
        CameraMovement.CanMove = false;
    }
}