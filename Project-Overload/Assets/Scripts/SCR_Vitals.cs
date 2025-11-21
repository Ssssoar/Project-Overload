using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCR_Vitals : MonoBehaviour{ //base class for anything that is a number, constantly in flux during the gameplay
    [Header("References")]
    [SerializeField] internal SCR_BarDisplay bar;

    [Header("Parameters")]
    [SerializeField] public float max;

    [Header("Variables")]
    [HideInInspector] public float current {get; internal set;}
    [SerializeField] internal float defaultFillSpeed = 0f;
    [SerializeField] internal float fillSpeed = 0f; //in units per second; can be negative
    bool wasEmptyLastFrame = false;

    [Header("Events")]
    [SerializeField] UnityEvent onDeplete; 

    internal virtual void Start(){
        current = max;
        bar.SetBar(current, max);
        ResetFillSpeed();
    }

    internal virtual void FixedUpdate(){
        UpdateCurrent(fillSpeed);
        bar.SetBar(current);
    }

    void UpdateCurrent(float fillSpeed){
        current += fillSpeed * Time.deltaTime;
        current = Clamp(current);
        if (current == 0f){
            if (!wasEmptyLastFrame){
                onDeplete.Invoke();
            }
            wasEmptyLastFrame = true;
        }else{
            wasEmptyLastFrame = false;
        }
    }

    public void ChangeDefaultFillSpeed(float newSpeed){
        defaultFillSpeed = newSpeed;
        ResetFillSpeed();
    }

    internal virtual void ResetFillSpeed(){
        fillSpeed = defaultFillSpeed;
    }

    float Clamp(float toClamp){
        if (toClamp <= 0f) return 0f;
        if (toClamp >= max) return max;
        return toClamp;
    }

    public float GetRatio(){
        return current / max;
    }

    public void InstantChange(float changeAmmount){
        current += changeAmmount;
        current = Clamp(current);
        if ((current == 0f) && (!wasEmptyLastFrame)){
            onDeplete.Invoke();
        }
        if (current != 0f){
            wasEmptyLastFrame = false;
        }
    }
}
