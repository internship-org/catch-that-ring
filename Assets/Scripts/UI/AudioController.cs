using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private string savedMusic = "musicVolume";
    
    void Start(){
        if(!PlayerPrefs.HasKey(savedMusic)){
            PlayerPrefs.SetFloat(savedMusic, 1);
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
        volumeSlider.value = PlayerPrefs.GetFloat(savedMusic);
    }
    private void Save(){
        PlayerPrefs.SetFloat(savedMusic, volumeSlider.value);
    }
}
