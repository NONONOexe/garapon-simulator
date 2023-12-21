using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    // 生成するボールオブジェクトの元となるプレハブ
    public GameObject ballBase;
    // 生成数
    public int maxCount;
    // 生成円の中心
    public Vector3 centerPosition;
    // 生成円の半径
    public float radius;
    // 一周で生成するオブジェクトの数
    public int countPerRound;
    // 生成時間のインターバル（秒）
    public float intervalSecond;

    // 現在の生成数
    private int count = 1;

    void Start()
    {
        StartCoroutine(GenerateBall());
    }

    private IEnumerator GenerateBall()
    {
        while(count < maxCount + 1)
        {
            // 生成位置を算出
            Vector3 vec = Vector3.zero;
            float freq = 1.0f / countPerRound;
            float rad = freq * 2 * Mathf.PI * count;
            vec.x = Mathf.Cos(rad);
            vec.z = Mathf.Sin(rad);
            vec *= radius;
            vec += centerPosition;
            
            // ボールオブジェクトを生成
            GameObject ball = Instantiate(ballBase, vec, Quaternion.identity);

            // レンダラを取得
            Renderer renderer = ball.GetComponent<Renderer>();
            // ボールのテクスチャファイル名を生成
            String textureFileName = String.Format("Textures/Ball/ball-{0:00}-bingo", count);
            // テクスチャファイルをロード
            Texture[] textures = Resources.LoadAll<Texture>(textureFileName);
            // 生成したボールオブジェクトにテクスチャを設定
            renderer.material.mainTexture = textures[0];
            // オブジェクト名にボールの番号を設定
            ball.name = String.Format("{0}", count);

            // 生成数をカウント
            count++;

            // 次の生成まで待機
            yield return new WaitForSeconds(intervalSecond);
        }

        // このオブジェクトを破壊
        Destroy(gameObject);
    }
}
