using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SplitCircle : MonoBehaviour {

    HTTPtext httpText;

    private GameObject marker;
    private GameObject tipsCircle;
    private Vector3 markerPos;
    private static int value;

    Random random;
    private float range_x = 0.0f;
    private float range_y = 0.0f;
    private float width;
    private float height;

    private float UIWidth;
    private float UIHeight;


    // Use this for initialization
    void Start () {
        marker = GameObject.Find("Marker").gameObject;
        tipsCircle = GameObject.Find("TipsCircle").gameObject;
        random = new Random();

        UIWidth = GameObject.Find("MarkedUI").GetComponent<RectTransform>().rect.width;
        UIHeight = GameObject.Find("MarkedUI").GetComponent<RectTransform>().rect.height;
        //Debug.Log("UIWidth:" + UIWidth);
        //Debug.Log("UIHeight:" + UIHeight);

        httpText = GameObject.Find("UIManager").GetComponent<HTTPtext>();
        httpText.changeTipsPosition += DistributeTipsPosition;
    }
	
	// Update is called once per frame
	void Update () {
        markerPos = marker.transform.localPosition;
        //Debug.Log("markerPos:" + markerPos);
        DistinguishBlock();
        Debug.Log("value="+value);
    }


    private void DistributeTipsPosition()
    {
        Random sideDecision = new Random();
        width = tipsCircle.GetComponent<RectTransform>().rect.width;
        height = tipsCircle.GetComponent<RectTransform>().rect.height;
        int resultSide = sideDecision.Next(0, 1);
        switch (value)
        {
            #region 上左
            case 1:
                //左边
                if (resultSide == 0)
                {
                    range_x = random.Next(-(int)(UIWidth / 2) - (int)(width / 2) - 40, -(int)(UIWidth / 2) - (int)(width / 2) - 20);
                    range_y = random.Next((int)(UIHeight / 6) + (int)(height / 2), (int)(UIHeight / 6) + (int)(height / 2) + 120);
                    Debug.Log("上左-左边");
                }
                //上边
                if (resultSide == 1)
                {
                    range_x = random.Next(-(int)(UIWidth / 6) - (int)(width / 2) - 40, -(int)(UIWidth / 6) - (int)(width / 2) - 20);
                    range_y = random.Next((int)(UIHeight / 2) + (int)(height / 2) + 4, (int)(UIHeight / 2) + (int)(height / 2) + 24);
                    Debug.Log("上左-上边");
                }
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                break;
            #endregion
            #region 上中
            case 2:
                range_x = random.Next(-(int)(UIWidth / 6) + (int)(width / 2) + 5, (int)(UIWidth / 6) - (int)(width / 2) - 5);
                range_y = random.Next((int)(UIHeight / 2) + (int)(height / 2) + 4, (int)(UIHeight / 2) + (int)(height / 2) + 24);
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                Debug.Log("上中");
                break;
            #endregion
            #region 上右
            case 3:
                //右边
                if (resultSide == 0)
                {
                    range_x = random.Next((int)(UIWidth / 2) + (int)(width / 2) + 20, (int)(UIWidth / 2) + (int)(width / 2) + 40);
                    range_y = random.Next((int)(UIHeight / 6) + (int)(height / 2), (int)(UIHeight / 6) + (int)(height / 2) + 120);
                    Debug.Log("上右-右边");
                }
                //上边
                if (resultSide == 1)
                {
                    range_x = random.Next(-(int)(UIWidth / 2) + (int)(width / 2) - 20, -(int)(UIWidth / 2) + (int)(width / 2) - 40);
                    range_y = random.Next((int)(UIHeight / 2) + (int)(height / 2) + 4, (int)(UIHeight / 2) + (int)(height / 2) + 24);
                    Debug.Log("上右-上边");
                }
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                break;
            #endregion
            #region 中左
            case 4:
                range_x = random.Next(-(int)(UIWidth / 2) - (int)(width / 2) - 40, -(int)(UIWidth / 2) - (int)(width / 2) - 20);
                range_y = random.Next(-(int)(UIHeight / 6) + (int)(height / 2) + 5, (int)(UIHeight / 6) - (int)(height / 2) - 5);
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                Debug.Log("中左");
                break;
            #endregion
            #region 中间
            case 5:
                //上边
                if (resultSide == 0)
                {
                    range_x = random.Next(-(int)(UIWidth / 6) + (int)(width / 2) + 5, (int)(UIWidth / 6) - (int)(width / 2) - 5);
                    range_y = random.Next((int)(UIHeight / 2) + (int)(height / 2) + 4, (int)(UIHeight / 2) + (int)(height / 2) + 24);
                    Debug.Log("中间-上边");
                }
                //下边
                if (resultSide == 1)
                {
                    range_x = random.Next(-(int)(UIWidth / 6) + (int)(width / 2) + 5, (int)(UIWidth / 6) - (int)(width / 2) - 5);
                    range_y = random.Next(-(int)(UIHeight / 2) - (int)(height / 2) - 24, -(int)(UIHeight / 2) - (int)(height / 2) - 4);
                    Debug.Log("中间-下边");
                }
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                break;
            #endregion
            #region 中右
            case 6:
                range_x = random.Next((int)(UIWidth / 2) + (int)(width / 2) + 20, (int)(UIWidth / 2) + (int)(width / 2) + 40);
                range_y = random.Next(-(int)(UIHeight / 6) + 5, -(int)(UIHeight / 6) - 5);
                Debug.Log("中右");
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                break;
            #endregion
            #region 下左
            case 7:
                //左边
                if (resultSide == 0)
                {
                    range_x = random.Next(-(int)(UIWidth / 2) - (int)(width / 2) - 40, -(int)(UIWidth / 2) - (int)(width / 2) - 20);
                    range_y = random.Next(-(int)(UIHeight / 6) - (int)(height / 2) - 120, -(int)(UIHeight / 6) - (int)(height / 2) - 5);
                    Debug.Log("下左-左边");
                }
                //下边
                if (resultSide == 1)
                {
                    range_x = random.Next(-(int)(UIWidth / 2) - (int)(width / 2) - 40, -(int)(UIWidth / 6) - (int)(width / 2) - 20);
                    range_y = random.Next(-(int)(UIHeight / 2) + (int)(height / 2) - 24, -(int)(UIHeight / 2) - (int)(height / 2) - 4);
                    Debug.Log("下左-下边");
                }
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                break;
            #endregion
            #region 下中
            case 8:
                range_x = random.Next(-(int)(UIWidth / 6) + (int)(width / 2) + 5, (int)(UIWidth / 6) - (int)(width / 2) - 5);
                range_y = random.Next(-(int)(UIHeight / 2) - (int)(height / 2) - 24, -(int)(UIHeight / 2) - (int)(height / 2) - 4);
                Debug.Log("下中");
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                break;
            #endregion
            #region 下右
            case 9:
                //右边
                if (resultSide == 0)
                {
                    range_x = random.Next((int)(UIWidth / 2) + (int)(width / 2) + 20, (int)(UIWidth / 2) + (int)(width / 2) + 40);
                    range_y = random.Next(-(int)(UIHeight / 6) - (int)(height / 2) - 120, -(int)(UIHeight / 6) - (int)(height / 2) - 5);
                    Debug.Log("下右-右边");
                }
                //下边
                if (resultSide == 1)
                {
                    range_x = random.Next(-(int)(UIWidth / 2) + (int)(width / 2) - 20, -(int)(UIWidth / 2) + (int)(width / 2) - 40);
                    range_y = random.Next(-(int)(UIHeight / 2) - (int)(height / 2) - 24, -(int)(UIHeight / 2) - (int)(height / 2) - 4);
                    Debug.Log("下右-下边");
                }
                tipsCircle.transform.localPosition = new Vector3(range_x, range_y, 0);
                break;
                #endregion
        }
    }
    //判断标注框是属于哪个区域
    private void DistinguishBlock()
    {
        //左上
        if ((markerPos.x > -255.0f && markerPos.x < -85.0f) && (markerPos.y > 48.3333f && markerPos.y < 145.0f))
        {
            value = 1;
            Debug.Log("1");
        }

        //中上
        if ((markerPos.x > -85.0f && markerPos.x < 85.0f) && (markerPos.y > 48.3333f && markerPos.y < 145.0f))
        {
            value = 2;
            Debug.Log("2");
        }

        //右上
        if ((markerPos.x > 85.0f && markerPos.x < 255.0f) && (markerPos.y > 48.3333f && markerPos.y < 145.0f))
        {
            value = 3;
            Debug.Log("3");
        }

        //中左
        if ((markerPos.x > -255.0f && markerPos.x < -85.0f) && (markerPos.y > -48.3333f && markerPos.y < 48.3333f))
        {
            value = 4;
            Debug.Log("4");
        }

        //中
        if ((markerPos.x > -85.0f && markerPos.x < 85.0f) && (markerPos.y > -48.3333f && markerPos.y < 48.3333f))
        {
            value = 5;
            Debug.Log("5");
        }

        //中右
        if ((markerPos.x > 85.0f && markerPos.x < 255.0f) && (markerPos.y > -48.3333f && markerPos.y < 48.3333f))
        {
            value = 6;
            Debug.Log("6");
        }

        //左下
        if ((markerPos.x > -255.0f && markerPos.x < -85.0f) && (markerPos.y > -145.0f && markerPos.y < -48.3333f))
        {
            value = 7;
            Debug.Log("7");
        }

        //中下
        if ((markerPos.x > -85.0f && markerPos.x < 85.0f) && (markerPos.y > -145.0f && markerPos.y < -48.3333f))
        {
            value = 8;
            Debug.Log("8");
        }

        //右下
        if ((markerPos.x > 85.0f && markerPos.x < 255.0f) && (markerPos.y > -145.0f && markerPos.y < -48.3333f))
        {
            value = 9;
            Debug.Log("9");
        }
    }
}
