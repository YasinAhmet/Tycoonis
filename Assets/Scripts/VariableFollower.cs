using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableFollower : MonoBehaviour
{
    [SerializeField]
    public UserStash userStash;
    public string starttext;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        starttext = text.text;
    }
}
