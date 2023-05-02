using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class QuitButton : MonoBehaviour
{
    void Start()
    {
        // Get the Button component of the GameObject this script is attached to
        Button quitButton = GetComponent<Button>();

        // Add an onClick listener to the button that calls the QuitGame function
        quitButton.onClick.AddListener(QuitGame);
    }

     public void QuitGame()
    {
        // Quit the game
        UnityEngine.Application.Quit();
    }
}
