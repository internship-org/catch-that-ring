using DG.Tweening;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    CanvasGroup canvasGroup;

    //make this singleton
    public static SceneTransition Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void AnimateTransition()
    {
        canvasGroup
            .DOFade(1, 0.5f)
            .OnComplete(() =>
            {
                SceneController.Instance.LoadGameScene();
                canvasGroup.DOFade(0, 0.5f);
            });
    }
}
