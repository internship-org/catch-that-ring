// using UnityEngine.UI;
// using UnityEngine;

// public class SensitivitySetter : MonoBehaviour
// {
//     [SerializeField] private Slider sensitivitySlider;
//     private string savedSave = "sensitivity";
//     void Start(){
//         if(!PlayerPrefs.HasKey(savedSense)){
//             PlayerPrefs.SetFloat(savedSense, 1);
//             Load();
//         }
//         else{
//             Load();
//         }

//     }
//     public void SetSensitivity(){
        
//         Save();
//     }
//     private void Load(){
//         volumeSlider.value = PlayerPrefs.GetFloat(savedSense);
//     }
//     private void Save(){
//         PlayerPrefs.SetFloat(savedSense, volumeSlider.value);
//     }
// }
