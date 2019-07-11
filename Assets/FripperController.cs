using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    private Vector3 touchPosition;


    // Use this for initialization
    void Start()
    {

        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //発展課題
        foreach (Touch t in Input.touches)
        {
            //touch型からVector3に変換
            touchPosition = t.position;
            //Z座標がないため、使用しない
            touchPosition.z = 10;

            //ワールド座標に変換
            if (Camera.main.ScreenToWorldPoint(touchPosition).x < 0 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            if (Camera.main.ScreenToWorldPoint(touchPosition).x > 0 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            if (t.phase == TouchPhase.Ended && touchPosition.x < 0)
            {
                SetAngle(this.defaultAngle);
            }
            if (t.phase == TouchPhase.Ended && touchPosition.x > 0)
            {
                SetAngle(this.defaultAngle);
            }
        }
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}