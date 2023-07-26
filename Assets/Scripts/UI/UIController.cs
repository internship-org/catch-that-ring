using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void StartGamePressed(string startButton){
        SceneManager.LoadScene(startButton);
    }
    public void QuitGamePressed(){
        Application.Quit();
        Debug.Log("Application has quit.");
    }
    public void SettingsButtonPressed(){
        
    }
}
