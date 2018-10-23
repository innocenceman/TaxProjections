using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeMarkerSize : MonoBehaviour
{
    private GameObject Marker;
    private float widgetWidth;   //控件的宽
    private float widgetHeight;  //控件的高
    private float MarkerWidth;   //标注框的宽
    private float MarkerHeight;  //标注框的高

    private float scale_width;   //控件和标注实际宽度比
    private float scale_height;  //控件和标注实际高度比

    [SerializeField]
    public int shrinkValue_1;     //UI(1)在构建是父物体的缩小比例
    [SerializeField]
    public int shrinkValue_2;     //UI(2)在构建是父物体的缩小比例


    private HTTPtext httptext;
    private Matrixcontrol matrix;

    void Start () {
        Marker = GameObject.Find("Marker").gameObject;
        httptext = GameObject.Find("UIManager").GetComponent<HTTPtext>();
        matrix = GameObject.Find("UIManager").GetComponent<Matrixcontrol>();
    }

    void Update () {


        widgetWidth = httptext.Width * matrix.Scale_PhysicToPixel_Width;
        //Debug.Log(widgetWidth);
        widgetHeight = httptext.Height * matrix.Scale_PhysicToPixel_Height;
        //Debug.Log(widgetHeight);

        MarkerWidth = Marker.GetComponent<RectTransform>().rect.width / (shrinkValue_1 * shrinkValue_2);
        //Debug.Log(MarkerWidth);
        MarkerHeight = Marker.GetComponent<RectTransform>().rect.height / (shrinkValue_1 * shrinkValue_2);
        //Debug.Log(MarkerHeight);

        scale_width = widgetWidth / MarkerWidth;
        //Debug.Log(scale_width);
        scale_height = widgetHeight / MarkerHeight;
        //Debug.Log(scale_height);
        changeImageSize();
	}



    private void changeImageSize()
    {
        Marker.transform.localScale = new Vector3(scale_width * 1.2f, scale_height * 1.4f, 1.0f);
        //Marker.transform.localScale = new Vector3(scale_width, scale_height, 1.0f);
    }
}
