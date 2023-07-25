using DG.Tweening;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    CanvasGroup canvasGroup;

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
            });
    }
}
