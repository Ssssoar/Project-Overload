using UnityEngine;

public class SCR_AudioPlayer : MonoBehaviour{
    
    //SINGLETON START
    public static SCR_AudioPlayer Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END

    [SerializeField] AudioSource sourceComp;
    [SerializeField] AudioSource chargeSource;
    [SerializeField] AudioClip overLoadClip;
    [SerializeField] float minVolume;
    [SerializeField] float minPitch;
    [SerializeField] float maxVolume;
    [SerializeField] float maxPitch;
    bool chargeBlocked = false;
    float lastChargeAmmount;

    public void UpdateVolume(float newVolume){
        AdjustChargeSound(lastChargeAmmount);
    }

    public void playOverLoad(){
        float volume = SCR_SettingsManager.Instance.GetSFXVolume();
        if (volume == 0f) return;
        sourceComp.volume = volume;
        sourceComp.PlayOneShot(overLoadClip,volume);
        BlockChargeSound();
    }

    public void resumePlayingCharge(){
        float volume = SCR_SettingsManager.Instance.GetSFXVolume();
        UnblockChargeSound();
    }

    public void AdjustChargeSound(float chargeAmmount){
        lastChargeAmmount = chargeAmmount;
        if (chargeBlocked) return;
        float globalVolume = SCR_SettingsManager.Instance.GetSFXVolume();
        float volume = Mathf.Lerp(minVolume,maxVolume,chargeAmmount) * globalVolume;
        float pitch = Mathf.Lerp(minPitch,maxPitch,chargeAmmount);
        chargeSource.volume = volume;
        chargeSource.pitch = pitch;
    }

    public void BlockChargeSound(){
        chargeSource.volume = 0f;
        chargeBlocked = true;

    }

    public void UnblockChargeSound(){
        chargeBlocked = false;
    }
}
