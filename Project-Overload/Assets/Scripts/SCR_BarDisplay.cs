using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_BarDisplay : MonoBehaviour{

    [SerializeField] Image barImg;
    [SerializeField] float current,max;
    [SerializeField] float lerpStrength;
    [SerializeField] Transform empty,full;
    float targetFill,currentFill = 0f;
    bool moveMode = false;

    void Start(){
        if ((empty != null) && (full != null)){
            moveMode = true;
        }
    }

    void Update(){
        UpdateTarget();
        UpdateBar();
    }

    public void SetBar(float value, float total){
        current = value;
        max = total;
        ClampValue();
        UpdateTarget();
    }

    public void SetBar(float value){
        SetBar(value,max);
    }

    void ClampValue(){
        if (current < 0)
            current = 0;
        else if (current > max)
            current = max;
    }
    
    void UpdateTarget(){
        if (barImg != null){
            float _currentHp = (float)current;
            float fillImage = _currentHp / max;
            targetFill = fillImage;
        }
    }

    void UpdateBar(){
        /*Debug.Log(currentFill);
        Debug.Log(targetFill);
        Debug.Log(lerpStrength);*/
        currentFill = Mathf.Lerp(currentFill , targetFill , lerpStrength);
        if (float.IsNaN(currentFill)){
            currentFill = 0f;
        }
        if (!moveMode){
            barImg.fillAmount = currentFill;
        }else{
            barImg.transform.position = Vector3.Lerp(empty.position,full.position,currentFill);
        }
    }

    public void ChangeColor(Color color){
        barImg.color = color;
    }
}
