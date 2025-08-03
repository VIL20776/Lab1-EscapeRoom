using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioClip _pauseSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
            AudioManager.instance.PlaySound(_pauseSound);
        }
    }
    public void MainMenuSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueSelect()
    {
        Pause();
    }

    public void Pause()
    {
        if (Time.timeScale == 0)
        {
            _pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            _player.GetComponentInChildren<FirstPersonLook>().enabled = true;
            Time.timeScale = 1;
        }
        else
        {
            _pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            _player.GetComponentInChildren<FirstPersonLook>().enabled = false;
            Time.timeScale = 0;
        }
    }
}
