using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadGameScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadGameScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
