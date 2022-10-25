using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextData : MonoBehaviour
{
    public string firstText;
    // Start is called before the first frame update
    void Start()
    {
        firstText = gameObject.GetComponent<Text>().text;
    }

}
