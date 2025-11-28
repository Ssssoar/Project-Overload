using UnityEngine;
using UnityEngine.Events;

public class SCR_OverLoad : SCR_Vitals{
    [Header("References")]
    [SerializeField] SCR_PlayerCharge chargeScript;

    [Header("Parameters")]
    [SerializeField] float increaseRate;
    [SerializeField] float decreaseRate;
    [SerializeField] float overloadTime;

    [Header("Events")]
    public UnityEvent onOverLoadStart;
    public UnityEvent onOverLoadEnd;

    [Header("Variables")]
    float timer = 0f;
    bool overloaded = false;

    internal override void Start(){
        current = 0f;
        bar.SetBar(current, max);
    }

    internal override void FixedUpdate(){
        if (!overloaded){
            if (current == max){
                onOverLoadStart.Invoke();
                SCR_AudioPlayer.Instance.playOverLoad();
                overloaded = true;
                current = 0f;
                fillSpeed = 0f;
                timer = overloadTime;
            }else if (chargeScript.current == chargeScript.max){
                fillSpeed = increaseRate;
            }else{
                fillSpeed = -decreaseRate;
            }
            base.FixedUpdate();
        }else{
            timer -= Time.deltaTime;
            if (timer <= 0f){
                onOverLoadEnd.Invoke();
                SCR_AudioPlayer.Instance.resumePlayingCharge();
                overloaded = false;
                timer = 0f;
            }
        }
    }

    public void ChangeIncreaseRate(float newRate){
        increaseRate = newRate;
    }
}
