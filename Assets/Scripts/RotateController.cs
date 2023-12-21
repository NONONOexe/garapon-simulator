using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaraponRotator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("抽選機の回転速度")]
    private float rotateSpeed = 20.0f;

    // ガラポンのオブジェクト
    private GameObject garapon;
    // 回転／停止ボタンのオブジェクト
    private GameObject rotateButton;
    // 回転／停止ボタンのオブジェクト
    private GameObject mixButton;
    // ガラポンの回転／停止状態
    private bool isRotate = false;
    // 回転方向
    private float rotateDir = -1.0f;

    private void Start()
    {
        // 抽選機のオブジェクトを取得
        garapon = GameObject.Find("Garapon");
        // 回転ボタンのオブジェクトを取得
        rotateButton = GameObject.Find("RotateButton");
        // まぜるボタンのオブジェクトを取得
        mixButton = GameObject.Find("MixButton");
    }

    private void Update()
    {
        // 回転方向への力
        Vector3 power = new Vector3(0.0f, 0.0f, isRotate ? rotateDir * rotateSpeed : 0.0f);
        // 抽選機の回転
        garapon.transform.Rotate(power * Time.deltaTime);
    }

    public void SwitchRotateState()
    {
        // 回転／停止の切り替え
        isRotate = !isRotate;
        // 回転方向の設定
        rotateDir = isRotate ? -1.0f : rotateDir;
        // 回転制御ボタンのテキストの変更
        rotateButton.GetComponentInChildren<UnityEngine.UI.Text>().text = isRotate ? "とめる" : "まわす";
        mixButton.GetComponentInChildren<UnityEngine.UI.Text>().text = isRotate ? "とめる" : "まぜる";
    }

    public void MixBalls()
    {
        // 回転／停止の切り替え
        isRotate = !isRotate;
        // 回転方向の設定
        rotateDir = isRotate ? 1.0f : rotateDir;
        // 回転制御ボタンのテキストの変更
        rotateButton.GetComponentInChildren<UnityEngine.UI.Text>().text = isRotate ? "とめる" : "まわす";
        mixButton.GetComponentInChildren<UnityEngine.UI.Text>().text = isRotate ? "とめる" : "まぜる";
    }
}
