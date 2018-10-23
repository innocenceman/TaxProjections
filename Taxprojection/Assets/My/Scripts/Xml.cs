using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class Xml : MonoBehaviour {

    //Matrixcontrol类中的所需的参数
    public static float fullexplorer;
    public static float notfullexplorer;
    public static float explorerRelatescreen_X;
    public static float explorerRelatescreen_Y;
    public static float screenRelateimage_X;
    public static float screenRelateimage_Y;
    public static float screenWidth_physic;
    public static float screenHeight_physic;
    public static int screenWidth_pixel;
    public static int screenHeight_pixel;

    //RecieveTipsMessage类中所需的数据
    public static string host;
    public static int port;
    public static long buffer_size;


    ////委托：将参数传输给相应的脚本
    //public delegate void TransformData();
    //public event TransformData transformdata;


    private void Awake()
    {
        LogFile.Clear();
        parseXml();
    }

    void parseXml()
    {
        LogFile.OutputLog("==这里是脚本之间的分割线==");
        LogFile.OutputLog("[[Xml]]");
        string filePath = Application.dataPath + @"/My/StreamingAsset/Configutations/Configuration.xml";
        LogFile.OutputLog("filePath:" + filePath);
        if (File.Exists(filePath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            #region 获取Matrixcontrol中的数据
            XmlNodeList Matrixcontrol = xmlDoc.SelectNodes("/Tax/Matrixcontrol");
            foreach (XmlNode node in Matrixcontrol)
            {
                LogFile.OutputLog("[Xml读取Matrixcontrol的数据]:");
                LogFile.OutputLog("-------------------------------------------------------------------------------------------------");
                float.TryParse(node.SelectSingleNode("Fullexplorer").InnerText, out fullexplorer);
                LogFile.OutputLog("Fullexplorer:" + fullexplorer);
                float.TryParse(node.SelectSingleNode("Notfullexplorer").InnerText, out notfullexplorer);
                LogFile.OutputLog("Notfullexplorer:" + notfullexplorer);
                float.TryParse(node.SelectSingleNode("ExplorerRelatescreen_X").InnerText, out explorerRelatescreen_X);
                LogFile.OutputLog("ExplorerRelatescreen_X:" + explorerRelatescreen_X);
                float.TryParse(node.SelectSingleNode("ExplorerRelatescreen_Y").InnerText, out explorerRelatescreen_Y);
                LogFile.OutputLog("ExplorerRelatescreen_Y:" + explorerRelatescreen_Y);
                float.TryParse(node.SelectSingleNode("ScreenRelateimage_X").InnerText, out screenRelateimage_X);
                LogFile.OutputLog("ScreenRelateimage_X:" + screenRelateimage_X);
                float.TryParse(node.SelectSingleNode("ScreenRelateimage_Y").InnerText, out screenRelateimage_Y);
                LogFile.OutputLog("ScreenRelateimage_Y:" + screenRelateimage_Y);
                float.TryParse(node.SelectSingleNode("ScreenWidth_physic").InnerText, out screenWidth_physic);
                LogFile.OutputLog("ScreenWidth_physic:" + screenWidth_physic);
                float.TryParse(node.SelectSingleNode("ScreenHeight_physic").InnerText, out screenHeight_physic);
                LogFile.OutputLog("ScreenHeight_physic:" + screenHeight_physic);
                screenWidth_pixel = int.Parse(node.SelectSingleNode("ScreenWidth_pixel").InnerText);
                LogFile.OutputLog("ScreenWidth_pixel:" + screenWidth_pixel);
                screenHeight_pixel = int.Parse(node.SelectSingleNode("ScreenHeight_pixel").InnerText);
                LogFile.OutputLog("ScreenHeight_pixel:" + screenHeight_pixel);
                LogFile.OutputLog("-------------------------------------------------------------------------------------------------\r\n");

            }
            #endregion

            #region 获取RecieveTipsMessage中的数据
            XmlNodeList RecieveTipsMessage = xmlDoc.SelectNodes("/Tax/RecieveTipsMessage");
            foreach (XmlNode node in RecieveTipsMessage)
            {

                LogFile.OutputLog("[Xml读取Matrixcontrol的数据]:");
                LogFile.OutputLog("-------------------------------------------------------------------------------------------------");
                host = node.SelectSingleNode("host").InnerText.ToString();
                LogFile.OutputLog("ScreenHeight_pixel:" + screenHeight_pixel);
                port = int.Parse(node.SelectSingleNode("port").InnerText);
                LogFile.OutputLog("ScreenHeight_pixel:" + screenHeight_pixel);
                buffer_size = int.Parse(node.SelectSingleNode("BUFFER_SIZE").InnerText);
                LogFile.OutputLog("ScreenHeight_pixel:" + screenHeight_pixel);
                LogFile.OutputLog("-------------------------------------------------------------------------------------------------\r\n");
            }
            #endregion

            
        }

    }
}
