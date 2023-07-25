using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button marketButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("StartGame");
        marketButton = root.Q<Button>("Market");
        startButton.clicked += StartButtonPressed;
        marketButton.clicked += MarketButtonPressed;
    }

    // Update is called once per frame
    void StartButtonPressed()
    {
        SceneManager.LoadScene("Level");
    }

    void MarketButtonPressed()
    {
        SceneManager.LoadScene("STest");
    }
}
