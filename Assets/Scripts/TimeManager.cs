using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int day;

    public Text text;
    // Update is called once per frame
    void Update()
    {
        text.text = text.GetComponent<TextData>().firstText + " " + day;
    }

    public void TurnHappened()
    {
        day++;
    }
}
