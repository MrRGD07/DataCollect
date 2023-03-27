using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GetData : MonoBehaviour
{
    private int _dataSize = 20;
    private float _dataIntakeRate = 0.1f;
    private string _fileName = "";
    private int _testNumber = 1;
    public void DataCollector()
    {
        _fileName = Application.dataPath + "/data.csv";
        StartCoroutine(WaitForData());
        _testNumber++;
    }
    IEnumerator WaitForData()
    {
        Button button = FindObjectOfType<Button>();
        button.interactable = false;

        TextWriter tw = new StreamWriter(_fileName, true);
        tw.WriteLine("Test:" + _testNumber);
        tw.WriteLine("X, Y, Z");
        for (int i = 0; i < _dataSize; i++)
        {
            Debug.Log(Input.acceleration);
            tw.WriteLine((Input.acceleration.x, Input.acceleration.y, Input.acceleration.z));
            yield return new WaitForSeconds(_dataIntakeRate);
        }

        tw.WriteLine("");
        tw.Close();
        button.interactable = true;
    }
}
