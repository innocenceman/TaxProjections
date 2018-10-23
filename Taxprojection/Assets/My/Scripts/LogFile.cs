using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class LogFile {
    private static string log_path = Application.dataPath + "/Hololog.txt";
    
    public static void OutputLog(object _txt)
    {
        //if (!isDebuging)
        //{
        //    return;
        //}
        string txt = _txt.ToString().Trim();
        if (!File.Exists(log_path))
        {
            File.Create(log_path);
        }
        StreamWriter sw = new StreamWriter(log_path, true);
        string fileTitle = DateTime.Now.ToString() + "." + DateTime.Now.Millisecond.ToString() + "    ";
        sw.WriteLine(fileTitle + txt);
        sw.Flush();
        sw.Close();
    }

    public static void Clear()
    {
        StreamWriter sw = new StreamWriter(log_path, false);
        sw.Flush();
        sw.Close();
    }
}
