using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    [SerializeField] private GameObject darkenScreenObject;

    private void OnEnable()
    {
        GameManager.DisplayTryAgain += DisplayOptions;
    }

    private void OnDisable()
    {
        GameManager.DisplayTryAgain -= DisplayOptions;
    }

    //This method displays the try again screen and pauses the game.
    private void DisplayOptions()
    {
        darkenScreenObject.SetActive(true);
        Time.timeScale = 0;
    }

    //This method restarts the level (called from pressing yes)
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    //This method quit the game (called from pressing No)
    public void QuitGame()
    {
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}