using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private string musicSave = "musicVolume";
    
    void Start(){
        if(!PlayerPrefs.HasKey(musicSave)){
            PlayerPrefs.SetFloat(musicSave, 1);
            Load();
        }
        else{
            Load();
        }

    }
    
    public void SetVolume(){
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat(musicSave);
    }
    private void Save(){
        PlayerPrefs.SetFloat(musicSave, volumeSlider.value);
    }
}
