using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class RecieveTipsMessage : MonoBehaviour {

    //与服务器端的套结字
    public Socket clientSocket;

    //服务端的IP和端口号
    private string host;
    private int port;

    //提示框的提示信息
    private string recvStr;

    //接收缓冲区
    private long BUFFER_SIZE;
    private static byte[] readbuffer;

    //获取类ChangeTipsCircleContext
    private ChangeTipsCircleContext changeTipsCircleContext;

    void Start()
    {
        changeTipsCircleContext = GameObject.Find("UIManager").GetComponent<ChangeTipsCircleContext>();
        GainConfigData();
        readbuffer = new byte[BUFFER_SIZE];
        connection();
    }

    private void Update()
    {
        //传递信息给提示框
        changeTipsCircleContext.SetMessage(recvStr);

    }

    private void GainConfigData()
    {
        host = Xml.host;
        port = Xml.port;
        BUFFER_SIZE = Xml.buffer_size;

        //Debug.Log("host:" + host);
        //Debug.Log("port:" + port);
        //Debug.Log("BUFFER_SIZE:" + BUFFER_SIZE);
    }

    #region Socket连接并接收数据
    public void connection()
    {
        recvStr = "";
        //Socket
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPAddress ip = IPAddress.Parse(host);
        //connection
        clientSocket.Connect(ip, port);
        Debug.Log("连接成功。。。。");
        //开启异步Socket接收消息
        clientSocket.BeginReceive(readbuffer, 0, readbuffer.Length, SocketFlags.None, RecieveCb, null);
    }

    private void RecieveCb(IAsyncResult ar)
    {
        try
        {
            //结束接收消息
            int count = clientSocket.EndReceive(ar);
            string str = Encoding.UTF8.GetString(readbuffer, 0, count);
            if (readbuffer.Length > 1024 * 1024)
            {
                recvStr = "";
            }
            recvStr = str + "\n";

            //继续接收
            clientSocket.BeginReceive(readbuffer, 0, readbuffer.Length, SocketFlags.None, RecieveCb, null);
        }
        catch (Exception)
        {
            clientSocket.Close();
        }
    } 
    #endregion

}
