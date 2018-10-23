using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class XMLUI : MonoBehaviour
{
    private ArrayList Adialogue = new ArrayList();
    private ArrayList Bdialogue = new ArrayList();
    private ArrayList textList = new ArrayList();

    void Update()
    {
        Debug.Log("123");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 100, 50), "生成XML"))
        {
            CreateXML();
            Debug.Log("生成XML");
        }

        if (GUI.Button(new Rect(50, 100, 100, 50), "读取XML"))
        {
            LoadXml();
            Debug.Log("读取XML");
        }

        if (GUI.Button(new Rect(50, 150, 100, 50), "修改XML"))
        {
            updateXML();
            Debug.Log("修改XML");

        }

        if (GUI.Button(new Rect(50, 200, 100, 50), "增加XML节点"))
        {
            addXMLData();
            Debug.Log("增加XML");
        }
    }

    //创建XML
    void CreateXML()
    {
        string path = Application.dataPath + "/My/StreamingAsset/Configutations/Configuration1.xml";
        if (!File.Exists(path))
        {
            //创建最上一层的节点。
            XmlDocument xml = new XmlDocument();
            //创建最上一层的节点。
            XmlElement root = xml.CreateElement("Tax");
            //创建子节点
            XmlElement element = xml.CreateElement("messages");
            //设置节点的属性
            element.SetAttribute("id", "1");
            XmlElement elementChild1 = xml.CreateElement("contents");

            elementChild1.SetAttribute("name", "a");
            //设置节点内面的内容
            elementChild1.InnerText = "这就是你，你就是天狼";
            XmlElement elementChild2 = xml.CreateElement("mission");
            elementChild2.SetAttribute("map", "abc");
            elementChild2.InnerText = "去吧，少年，去实现你的梦想";
            //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
            element.AppendChild(elementChild1);
            element.AppendChild(elementChild2);
            root.AppendChild(element);
            xml.AppendChild(root);
            //最后保存文件
            xml.Save(path);
        }
    }

    //读取XML
    void LoadXml()
    {
        //创建xml文档
        XmlDocument xml = new XmlDocument();

        xml.Load(Application.dataPath + "/data2.xml");
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("objects").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {

            if (xl1.GetAttribute("id") == "1")
            {
                //继续遍历id为1的节点下的子节点
                foreach (XmlElement xl2 in xl1.ChildNodes)
                {
                    //放到一个textlist文本里
                    //textList.Add(xl2.GetAttribute("name") + ": " + xl2.InnerText);
                    //得到name为a的节点里的内容。放到TextList里
                    if (xl2.GetAttribute("name") == "a")
                    {
                        Adialogue.Add(xl2.GetAttribute("name") + ": " + xl2.InnerText);
                        print("******************" + xl2.GetAttribute("name") + ": " + xl2.InnerText);
                    }
                    //得到name为b的节点里的内容。放到TextList里
                    else if (xl2.GetAttribute("map") == "abc")
                    {
                        Bdialogue.Add(xl2.GetAttribute("name") + ": " + xl2.InnerText);
                        print("******************" + xl2.GetAttribute("name") + ": " + xl2.InnerText);
                    }
                }
            }
        }
        print(xml.OuterXml);
    }

    //修改XML
    void updateXML()
    {
        string path = Application.dataPath + "/data2.xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList xmlNodeList = xml.SelectSingleNode("objects").ChildNodes;
            foreach (XmlElement xl1 in xmlNodeList)
            {
                if (xl1.GetAttribute("id") == "1")
                {
                    //把messages里id为1的属性改为5
                    xl1.SetAttribute("id", "5");
                }

                if (xl1.GetAttribute("id") == "2")
                {
                    foreach (XmlElement xl2 in xl1.ChildNodes)
                    {
                        if (xl2.GetAttribute("map") == "abc")
                        {
                            //把mission里map为abc的属性改为df，并修改其里面的内容
                            xl2.SetAttribute("map", "df");
                            xl2.InnerText = "我成功改变了你";
                        }

                    }
                }
            }
            xml.Save(path);
        }
    }

    //添加XML
    void addXMLData()
    {
        string path = Application.dataPath + "/data2.xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.SelectSingleNode("objects");
            //下面的东西就跟上面创建xml元素是一样的。我们把他复制过来就行了
            XmlElement element = xml.CreateElement("messages");
            //设置节点的属性
            element.SetAttribute("id", "2");
            XmlElement elementChild1 = xml.CreateElement("contents");

            elementChild1.SetAttribute("name", "b");
            //设置节点内面的内容
            elementChild1.InnerText = "天狼，你的梦想就是。。。。。";
            XmlElement elementChild2 = xml.CreateElement("mission");
            elementChild2.SetAttribute("map", "def");
            elementChild2.InnerText = "我要妹子。。。。。。。。。。";
            //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
            element.AppendChild(elementChild1);
            element.AppendChild(elementChild2);

            root.AppendChild(element);

            xml.AppendChild(root);
            //最后保存文件
            xml.Save(path);
        }
    }
}