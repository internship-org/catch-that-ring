using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void StartGame(string startButton){
        SceneManager.LoadScene(startButton);
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
