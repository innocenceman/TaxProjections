using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class ChangeTipsCircleContext : MonoBehaviour
{
    private Text tipsCircle;

    private RecieveTipsMessage recieveTipsMessage;
    // Use this for initialization
    void Start()
    {
        recieveTipsMessage = GameObject.Find("UIManager").GetComponent<RecieveTipsMessage>();
        tipsCircle = GameObject.Find("Tips").GetComponent<Text>();
    }

    public void SetMessage(string msg)
    {
        //更改提示框的信息
        tipsCircle.text = msg;
        Debug.Log("tipsCircle.text:" + msg);
    }
}