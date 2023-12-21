using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallObserver : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ボールの画像のプレハブ")]
    private GameObject ballImagePrefab;
    
    [SerializeField]
    [Tooltip("画面のテキスト")]
    private GameObject displayText;

    // ボールの一覧のUI
    private GameObject ballImagesUI;
    // ボールの画像
    private GameObject[] ballImages;
    // ボールが排出されているかどうか
    private bool[] isReleased;

    void Start()
    {
        int maxBallNumber = 75;

        // 変数の初期化
        ballImages = new GameObject[maxBallNumber];
        isReleased = new bool[maxBallNumber];
        // ボールの画像の一覧を取得
        ballImagesUI = GameObject.Find("BallImagesUI");

        for (int i = 0; i < maxBallNumber; i++)
        {
            // 初期状態でボールは排出されていない
            isReleased[i] = false;

            // ボールの画像オブジェクトを生成
            GameObject ballImage = Instantiate(ballImagePrefab);
            ballImages[i] = ballImage;
            ballImage.transform.SetParent(ballImagesUI.transform);
            ballImage.name = String.Format("BallImage{0:00}", i + 1);

            // ボールのスプライト画像を設定
            String spriteFileName = String.Format("UI/ball-gray-{0:00}-bingo", i + 1);
            Image image = ballImage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(spriteFileName);
        }
    }

    void Update()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            // ボールの番号を取得
            int ballNumber = int.Parse(ball.name);
            int i = ballNumber - 1;

            if (!isReleased[i] && ball.transform.position.y < -12.0f)
            {
                // ボールのスプライト画像をカラーのもの変更
                GameObject ballImage = ballImages[i];
                Image image = ballImage.GetComponent<Image>();
                String spriteFileName = String.Format("UI/ball-{0:00}-bingo", ballNumber);
                image.sprite = Resources.Load<Sprite>(spriteFileName);

                // 画面にボールの番号を表示
                displayText.GetComponent<Text>().text = ballNumber.ToString();

                // 排出されたことを記録
                isReleased[i] = true;
            }
        }
    }
}
