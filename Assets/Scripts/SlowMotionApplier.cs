using System.Collections;
using UnityEngine;
public class SlowMotionApplier : MonoBehaviour
{
    private string targetTag = "Ring";
    private float SlowmotionValue = 0.5f;
    private float normaltimeScale = 1f;
    private bool isSlowMo = false;
    public void ApplySlowMo()
    {
        if (gameObject.CompareTag(targetTag))
        {
            Time.timeScale = SlowmotionValue;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            if(!isSlowMo) {
                isSlowMo = true;
                StartCoroutine(ResetSlowMo());
            }
            
        }
        else
        {
            Time.timeScale = normaltimeScale;
        }
    }

    private IEnumerator ResetSlowMo() {
        yield return new WaitForSeconds(1f);
        Time.timeScale = normaltimeScale;
        isSlowMo = false;
    }
}