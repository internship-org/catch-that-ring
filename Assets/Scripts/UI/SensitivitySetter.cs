using UnityEngine.UI;
using UnityEngine;
using Lean.Touch;
public class SensitivitySetter : MonoBehaviour
{
    [SerializeField] private GameObject stick;
    [SerializeField] private CustomDrag customDrag;
    [SerializeField] private Slider sensitivitySlider;
    private string savedSense = "sensitivity";
    void Start(){
        if(!PlayerPrefs.HasKey(savedSense)){
            PlayerPrefs.SetFloat(savedSense, 70);
            Load();
        }
        else{
            Load();
        }

    }
    public void SetSensitivity(){
        customDrag.sensitivity = sensitivitySlider.value ;
        Save();
    }
    private void Load(){
        sensitivitySlider.value = PlayerPrefs.GetFloat(savedSense);
    }
    private void Save(){
        PlayerPrefs.SetFloat(savedSense, sensitivitySlider.value);
    }
}
