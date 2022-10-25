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

    public string uiInfoType = "Money";
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        starttext = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (uiInfoType.Equals("Money")) {
            text.text = starttext + userStash.getMoney();
        }
        else if (uiInfoType.Equals("Work")) {
            text.text = starttext + userStash.getWorkForce();
        }
    }
}
