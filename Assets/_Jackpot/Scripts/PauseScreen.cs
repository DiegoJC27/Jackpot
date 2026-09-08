using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    bool paused = false;
    void Start()
    {
        pauseScreen.SetActive(false);
    }
    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Escape key pressed");
            TogglePause();
        }
    }

    public void SetPauseGame(bool setPause)
    {
        paused = setPause;
        pauseScreen.SetActive(setPause);
        Time.timeScale = setPause ? 0f : 1f;
    }
    public void TogglePause()
    {
        SetPauseGame(!paused);
    }
}