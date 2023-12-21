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
    // ボールの画像の一覧
    private GameObject ballImages;

    void Start()
    {
        int maxBallNumber = 75;
        ballImages = GameObject.Find("BallImages");
        for (int ballNumber = 1; ballNumber <= maxBallNumber; ballNumber++)
        {
            // ボールの画像オブジェクトを生成
            GameObject ballImage = Instantiate(ballImagePrefab);
            ballImage.transform.SetParent(ballImages.transform);
            ballImage.name = String.Format("BallImage{0:00}", ballNumber);

            // ボールのスプライト画像を設定
            String spriteFileName = String.Format("UI/ball-gray-{0:00}-bingo", ballNumber);
            Image image = ballImage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(spriteFileName);
        }
    }

    void Update()
    {    
    }
}
