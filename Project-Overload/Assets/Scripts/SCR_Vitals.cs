using System.Collections.Generic;
using UnityEngine;

public class SCR_Vitals : MonoBehaviour{ //base class for anything that is a number, constantly in flux during the gameplay
    [Header("References")]
    [SerializeField] SCR_BarDisplay bar;

    [Header("Parameters")]
    [SerializeField] float max = 100f;

    [Header("Variables")]
    float current;
    [SerializeField] protected float fillSpeed = 0f; //in units per second; can be negative

    void Start(){
        current = max;
        bar.SetBar(current, max);
    }

    void FixedUpdate(){
        UpdateCurrent(fillSpeed);
        bar.SetBar(current);
    }

    void UpdateCurrent(float fillSpeed){
        current += fillSpeed * Time.deltaTime;
        current = Clamp(current);
    }

    float Clamp(float toClamp){
        if (toClamp <= 0f) return 0f;
        if (toClamp >= max) return max;
        return toClamp;
    }

    public float GetRatio(){
        return current / max;
    }
}
