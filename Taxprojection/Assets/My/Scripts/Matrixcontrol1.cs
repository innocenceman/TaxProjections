using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrixcontrol1 : MonoBehaviour {

    private HTTPtext httptext;

    //坐标变量
    [Tooltip("这是控件在各个坐标系下的坐标")]
    public float X_element;                            //控件在浏览器可视范围内的坐标点(X,Y)
    public float Y_element;
    private float X_element_1;                         //控件在浏览器左上角内的坐标点(X,Y)
    private float Y_element_1;
    private float X_e_screen;                          //控件在屏幕内的坐标点(X,Y)
    private float Y_e_screen;
    private float X_e_image;                           //控件在标识图内的坐标点(X,Y)
    private float Y_e_image;

    //位移变量
    public static float Fullexplorer = 91.11f;                //全屏状态下浏览器菜单栏的高度
    public static float Notfullexplorer = 118.0f;             //非全屏状态下浏览器菜单栏的高度
    public static float ExplorerRelatescreen_X = 0.0f;            //浏览器原点距屏幕原点的位移(X,Y)
    public static float ExplorerRelatescreen_Y = 1080.0f;
    public static float ScreenRelateimage_X = -960.0f;         //屏幕原点距标识图原点的位移(X,Y)
    public static float ScreenRelateimage_Y = -540.0f;

    //矩阵数组
    private float[,] eTe_full;                         //全屏时控件坐标转换到浏览器坐标的平移矩阵
    private float[,] eTe_notfull;                      //非全屏时控件坐标转换到浏览器坐标的平移矩阵
    private float[,] eTs;                              //浏览器坐标转换到屏幕坐标的平移矩阵
    private float[,] sTi;                              //屏幕坐标转换到标识图坐标的平移矩阵
    private float[,] eTi;                              //元素坐标转换到标识图坐标的平移矩阵

    //坐标信息
    public float[,] eInexplorerblank;                 //控件在浏览器可视范围内的坐标位置
    public float[,] eInexplorer;                      //控件相对于浏览器左上角的坐标位置
    public float[,] eInscreen;                        //控件在屏幕中的坐标位置
    public float[,] eInimage;                         //控件在标识图中的坐标位置

    public static float ScreenWidth_physic = 0.51f;
    public static float ScreenHeight_physic = 0.29f;
    public static int ScreenWidth_pixel = 1920;
    public static int ScreenHeight_pixel = 1080;

    private float scale_PhysicToPixel_Width;
    public float Scale_PhysicToPixel_Width
    {
        get { return scale_PhysicToPixel_Width; }
        set { scale_PhysicToPixel_Width = value; }
    }

    private float scale_PhysicToPixel_Height;
    public float Scale_PhysicToPixel_Height
    {
        get { return scale_PhysicToPixel_Height; }
        set { scale_PhysicToPixel_Height = value; }
    }

    private void Update()
    {
        TransformPixelToPhysic();
        Debug.Log("Fullexplorer:" + Fullexplorer);
    }
       private void TransformPixelToPhysic()
    {
        //屏宽的比例（米/像素）
        Scale_PhysicToPixel_Width = ScreenWidth_physic / ScreenWidth_pixel;
        //屏高的比例（米/像素）
        Scale_PhysicToPixel_Height = ScreenHeight_physic / ScreenHeight_pixel;
    }

    #region 控件坐标转换为全屏浏览器坐标
    /// <summary>
    /// 控件坐标转换为全屏浏览器坐标
    /// </summary>
    void ElementToFullExplorer()
    {
        eInexplorerblank = new float[3, 1] { { X_element }, { Y_element }, { 1 } };
        Debug.Log(eInexplorerblank[0, 0]);
        Debug.Log(eInexplorerblank[1, 0]);
        eInexplorer = new float[3, 1] { { X_element_1 }, { Y_element_1 }, { 1 } };
        eTe_full = new float[3, 3] { { 1, 0, 0 }, { 0, 1, Fullexplorer }, { 0, 0, 1 } };
        for (int i = 0; i < 3; i++)
        {
            float sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += eTe_full[i, j] * eInexplorerblank[j, 0];
            }
            eInexplorer[i, 0] = sum;
        }
        X_element_1 = eInexplorer[0, 0];
        Y_element_1 = eInexplorer[1, 0];
        Debug.Log(eInexplorer[0, 0]);
        Debug.Log(eInexplorer[1, 0]);
    }
    #endregion

    #region 控件坐标转换为非全屏浏览器坐标
    /// <summary>
    /// 控件坐标转换为非全屏浏览器坐标
    /// </summary>
    void ElementToNotFullExplorer()
    {
        eInexplorerblank = new float[3, 1] { { X_element }, { Y_element }, { 1 } };
        eInexplorer = new float[3, 1] { { X_element_1 }, { Y_element_1 }, { 1 } };
        eTe_notfull = new float[3, 3] { { 1, 0, 0 }, { 0, 1, Notfullexplorer }, { 0, 0, 1 } };
        for (int i = 0; i < 3; i++)
        {
            float sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += eTe_notfull[i, j] * eInexplorerblank[j, 0];
            }
            eInexplorer[i, 0] = sum;
        }
    }
    #endregion

    #region 浏览器坐标转换为屏幕坐标
    /// <summary>
    /// 浏览器坐标转换为屏幕坐标
    /// </summary>
    void ExplorerToScreen()
    {

        eInexplorer = new float[3, 1] { { X_element_1 }, { Y_element_1 }, { 1 } };
        Debug.Log(eInexplorer[0, 0]);
        Debug.Log(eInexplorer[1, 0]);
        eInscreen = new float[3, 1] { { X_e_screen }, { Y_e_screen }, { 1 } };
        eTs = new float[3, 3] { { 1, 0, ExplorerRelatescreen_X }, { 0, 1, ExplorerRelatescreen_Y }, { 0, 0, 1 } };
        float[,] nagetive = new float[3, 3] { { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } };
        float[,] MiddleMatrix = new float[3, 3];
        for (int i = 0; i < 3; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                float sum = 0;
                for (int k = 0; k < 3; k++)
                {
                    sum += eTs[i, k] * nagetive[j, k];
                }
                MiddleMatrix[i, j] = sum;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            float sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += MiddleMatrix[i, j] * eInexplorer[j, 0];
            }
            eInscreen[i, 0] = sum;
        }
        X_e_screen = eInscreen[0, 0];
        Y_e_screen = eInscreen[1, 0];
        Debug.Log(eInscreen[0, 0]);
        Debug.Log(eInscreen[1, 0]);
    }
    #endregion

    #region 屏幕坐标转换为标识图坐标
    /// <summary>
    /// 屏幕坐标转换为标识图坐标
    /// </summary>
    void ScreenToImage()
    {
        eInscreen = new float[3, 1] { { X_e_screen }, { Y_e_screen }, { 1 } };
        Debug.Log(eInscreen[0, 0]);
        Debug.Log(eInscreen[1, 0]);
        eInimage = new float[3, 1] { { X_e_image }, { Y_e_image }, { 1 } };
        sTi = new float[3, 3] { { 1, 0, ScreenRelateimage_X }, { 0, 1, ScreenRelateimage_Y }, { 0, 0, 1 } };
        for (int i = 0; i < 3; i++)
        {
            float sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += sTi[i, j] * eInscreen[j, 0];
            }
            eInimage[i, 0] = sum;
        }
        X_e_image = eInimage[0, 0];
        Y_e_image = eInimage[1, 0];
        Debug.Log(eInimage[0, 0]);
        Debug.Log(eInimage[1, 0]);
    }
    #endregion

    #region 直接从控件坐标转换到标识图坐标(全屏状态下)
    /// <summary>
    /// 直接从控件坐标转换到标识图坐标(全屏状态下)
    /// </summary>
    public void StraightTranform_FullScreen()
    {
        eInexplorerblank = new float[3, 1] { { X_element }, { Y_element }, { 1 } };
        //Debug.Log("X_element:" + X_element);
        //Debug.Log("Y_element:" + Y_element);
        eInimage = new float[3, 1] { { X_e_image }, { Y_e_image }, { 1 } };
        eTi = new float[3, 3] { { 1, 0, (ScreenRelateimage_X + ExplorerRelatescreen_X) }, { 0, -1, (ScreenRelateimage_Y + ExplorerRelatescreen_Y - Fullexplorer) }, { 0, 0, 1 } };
        //Debug.Log("screenRelateimage_X:" + screenRelateimage_X);
        //Debug.Log("explorerRelatescreen_X:" + explorerRelatescreen_X);
        //Debug.Log("screenRelateimage_Y:" + screenRelateimage_Y);
        //Debug.Log("explorerRelatescreen_Y:" + explorerRelatescreen_Y);
        for (int i = 0; i < 3; i++)
        {
            float sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += eTi[i, j] * eInexplorerblank[j, 0];
            }
            eInimage[i, 0] = sum;
        }
        //Debug.Log("eInimage:" + eInimage[0, 0]);
        //Debug.Log("eInimage:" + eInimage[1, 0]);
        //float[,] scale = new float[3, 3] { { Scale_PhysicToPixel_Width, 0, 0 }, { 0, Scale_PhysicToPixel_Height, 0 }, { 0, 0, 1 } };
        ////将像素坐标转换为物理坐标
        //for (int i = 0; i < 3; i++)
        //{
        //    float sum = 0;
        //    for (int j = 0; j < 3; j++)
        //    {
        //        sum += scale[i, j] * eInimage[j, 0];
        //    }
        //    final[i, 0] = sum;
        //}
    }
    #endregion

    #region 直接从控件坐标转换到标识图坐标(非全屏状态下)
    /// <summary>
    /// 直接从控件坐标转换到标识图坐标(非全屏状态下)
    /// </summary>
    public void StraightTranform_NotFullScreen()
    {
        eInexplorerblank = new float[3, 1] { { X_element }, { Y_element }, { 1 } };
        eInimage = new float[3, 1] { { X_e_image }, { Y_e_image }, { 1 } };
        eTi = new float[3, 3] { { 1, 0, (ScreenRelateimage_X + ExplorerRelatescreen_X) }, { 0, -1, (ScreenRelateimage_Y + ExplorerRelatescreen_Y - Notfullexplorer) }, { 0, 0, 1 } };
        for (int i = 0; i < 3; i++)
        {
            float sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += eTi[i, j] * eInexplorerblank[j, 0];
            }
            eInimage[i, 0] = sum;
        }
        Debug.Log("最终结果：X=" + eInimage[0, 0]);
        Debug.Log("最终结果：Y=" + eInimage[1, 0]);
    } 
    #endregion
}
