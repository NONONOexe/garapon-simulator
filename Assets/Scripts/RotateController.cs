using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("抽選機の回転速度")]
    private float rotateSpeed = 20.0f;

    // ガラポンのオブジェクト
    private GameObject garapon;
    // 回転／停止ボタンのオブジェクト
    private GameObject rotateControlButton;
    // ガラポンの回転／停止状態
    private bool isRotate = false;

    private void Start()
    {
    }

    private void Update()
    {
        // 抽選機のオブジェクトを取得
        if (garapon == null)
        {
            garapon = GameObject.Find("Garapon");
        }
        // 抽選機のオブジェクトを取得
        if (rotateControlButton == null)
        {
            rotateControlButton = GameObject.Find("RotateControlButton");
        }
        // 回転方向への力
        Vector3 power = new Vector3(0.0f, 0.0f, isRotate ? -rotateSpeed : 0.0f);
        // 抽選機の回転
        garapon.transform.Rotate(power * Time.deltaTime);
    }

    public void SwitchRotateState()
    {
        // 回転／停止の切り替え
        isRotate = !isRotate;
        // 回転制御ボタンのテキストの変更
        rotateControlButton.GetComponentInChildren<UnityEngine.UI.Text>().text = isRotate ? "とめる" : "まわす";
    }
}
