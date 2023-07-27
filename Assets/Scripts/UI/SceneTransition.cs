using DG.Tweening;
using UniRx;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    private SceneController sceneController;
    CanvasGroup canvasGroup;

    Tween fadeTween;

    public static SceneTransition Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        sceneController = GetComponentInChildren<SceneController>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 0.5f);

        Observable
            .EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Escape))
            .Subscribe(_ => AnimateToScene(0));
    }

    public void AnimateToScene(int index)
    {
        canvasGroup
            .DOFade(1, 0.5f)
            .OnComplete(() =>
            {
                sceneController.LoadGameScene(index);
            });
    }

    public void AnimateToScene(string name)
    {
        fadeTween = canvasGroup
            .DOFade(1, 0.5f)
            .OnComplete(() =>
            {
                sceneController.LoadGameScene(name);
            });
    }

    private void OnDisable()
    {
        fadeTween.Kill();
    }
}
