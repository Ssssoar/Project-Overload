using UnityEngine;

public class SCR_SettingsManager : MonoBehaviour{
    //SINGLETON START
    public static SCR_SettingsManager Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
        //Persistency
        DontDestroyOnLoad(this.gameObject);
    }
    //SINGLETON END

    float SFXVolume = 1;

    public void SetSFXVolume(float newValue){
        SFXVolume = newValue;
        SCR_AudioPlayer.Instance.UpdateVolume(newValue);
    }

    public float GetSFXVolume(){
        return SFXVolume;
    }
}
