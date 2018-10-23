using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class HTTPtext : MonoBehaviour,IProcessText
{
    public static string url_1 = "http://10.23.19.18:46668/UnityHandler.ashx";

    //委托：改变提示框的位置
    public delegate void ChangeTipsPosition();
    public event ChangeTipsPosition changeTipsPosition;

    //委托：画线
    public delegate void Draw_line();
    public event Draw_line draw_line;

    private static int oldvalue = 0;
    public static bool IsActionChanged = false;

    private GameObject myCircle;
    private DrawLines drawLines;
    private GameObject myUI;
   

    //当前控件的ID
    private string _cID;
    public string CID
    {
        get
        {
            return _cID;
        }

        set
        {
            _cID = value;
        }
    }

    //当前控件的X轴位置
    private float _xposition;
    public float Xposition
    {
        get
        {
            return _xposition;
        }

        set
        {
            _xposition = value;
        }
    }

    //当前控件的Y轴位置
    private float _yposition;
    public float Yposition
    {
        get
        {
            return _yposition;
        }

        set
        {
            _yposition = value;
        }
    }

    //当前控件的宽度
    private float _width;
    public float Width
    {
        get
        {
            return _width;
        }

        set
        {
            _width = value;
        }
    }

    //当前控件的高度
    private float _height;
    public float Height
    {
        get
        {
            return _height;
        }

        set
        {
            _height = value;
        }
    }

    //提示框信息
    private string _message;
    public string Message
    {
        get
        {
            return _message;
        }

        set
        {
            _message = value;
        }
    }

    //判断用户是否动作更改（如点击其他控件）
    private int _valueOfAction;
    public int ValueOfAction
    {
        get
        {
            return _valueOfAction;
        }

        set
        {
            _valueOfAction = value;
        }
    }
    void Start () {
        myCircle = GameObject.Find("MyCircle").gameObject;
        drawLines = GameObject.Find("UIManager").gameObject.GetComponent<DrawLines>();
        myUI = GameObject.Find("MyUI").gameObject;
        ValueOfAction = 0;
    }

    void Update () {
        processText();
    }

    public void processText()
    {
        StartCoroutine(Getpath());
    }

    private IEnumerator Getpath()
    {
        WWW getData = new WWW(url_1);
        yield return getData;
        string text1 = getData.text.ToString();
        Debug.Log("text1" + text1);
        JsonString(text1);
        
    }

    private void JsonString(string text)
    {
        try
        {
            MyRecievedJson jsonProperty = JsonUtility.FromJson<MyRecievedJson>(text);
            Xposition = jsonProperty.xPosition;
            Yposition = jsonProperty.yPosition;
            Width = jsonProperty.width;
            Height = jsonProperty.height;
            Message = jsonProperty.message;
            ValueOfAction = jsonProperty.valueOfAction;
        }
        catch (Exception)
        {
            return;
        }

        //绘画直线
        draw_line();

        //判断用户是否进行了新的操作
        if (oldvalue != ValueOfAction)
        {
            
            oldvalue = ValueOfAction;
            IsActionChanged = true;

            //当接收到位置信息时，改变其位置
            changeTipsPosition();
        }
        else
        {
            IsActionChanged = false;
        }
    }

}
