using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogData
{

    public static string filename = "IML456Data.csv";

    public static void NewPerson(string name)
    {
        // PC PATH:  
        // MOBILE PATH: HTC-10\Settings\Storage\Files\Android\data\com.YDM.YDM\files\IML456Data.csv

        var filePath = Application.persistentDataPath + "/" + filename;
        Debug.Log("Writing to: " + filePath);
        File.AppendAllText(filePath, '\n' + name);
    }

    public static void NewTrialResult(string result)
    {
        var filePath = Application.persistentDataPath + "/" + filename;
        File.AppendAllText(filePath, ',' + result);
    }
}