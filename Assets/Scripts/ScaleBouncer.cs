using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBouncer : MonoBehaviour
{
    public float startTime = 0.0f;
    public float inflectionTime = 1.5f;
    public float endTime = 3.0f;

    private float localTime = 0.0f;
    private float easeInTime = 0.0f;
    private float easeOutTime = 0.0f;
    private float ease = 0.0f;

    void Start()
    {
        // Ease-inの時間
        easeInTime = (inflectionTime - startTime) / (endTime - startTime);
        // Ease-outの時間
        easeOutTime = 1.0f - easeInTime;
    }

    void Update()
    {
        // 時間を正規化
        localTime = startTime <= Time.time && Time.time <= endTime
                ? (Time.time - startTime) / (endTime - startTime) : localTime;
    
        // Easing関数の結果を係数化
        float easeIn = easeInTime * Mathf.Pow(localTime / easeInTime, 3.0f);
        float easeOut = easeOutTime * Mathf.Pow((localTime - 1.0f) / easeOutTime, 3.0f) + 1.0f;
        ease = localTime < easeInTime ? easeIn : easeOut;

        // 計算結果を反映
        transform.localScale = Vector3.one * ease;
    }

}
