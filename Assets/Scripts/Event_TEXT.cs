using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_TEXT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().color = UserStash.userstash.TextColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
