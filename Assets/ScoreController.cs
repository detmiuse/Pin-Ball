using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    //合計得点
    public int Score;
    //獲得得点
    private int GetPoint;
    //ScoreTextのstring型
    private string ScoreStr;
    //得点判定用
    private int Get;

    //それぞれの獲得点数
    private int SmallStarPoint = 10;
    private int LargeStarPoint = 20;
    private int smallCloudPoint = 30;
    private int LargeCloudPoint = 50;

    //得点を表示するテキスト
    private GameObject ScoreText;

    // Use this for initialization
    void Start()
    {
        Score = 0;
        GetPoint = 0;
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //衝突時に実行
        if (this.Get > 0)
        {
            //得点を加算
            Score += this.GetPoint;
            //得点判定を0にする
            this.Get = 0;
            //Scoreをstring型に変換したのちに、ScoreTextに表示
            this.ScoreStr = (Score).ToString();
            this.ScoreText.GetComponent<Text>().text = this.ScoreStr;
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision col)
    {
        //衝突時に1に
        Get = 1;

        if (col.gameObject.CompareTag("SmallStarTag"))
        {
            this.GetPoint = SmallStarPoint;
        }
        else if (col.gameObject.CompareTag("LargeStarTag"))
        {
            this.GetPoint = LargeStarPoint;
        }
        else if (col.gameObject.CompareTag("SmallCloudTag"))
        {
            this.GetPoint = smallCloudPoint;

        }
        else {
            this.GetPoint = 0;
        }
    }
}

        
