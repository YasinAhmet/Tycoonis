using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefEvent : MonoBehaviour
{
    public IncomeScript incomeScript;
    public UserStash userStash;
    public SlaveScript slaveScript;
    
    [TextArea(5,5)]
    public string textToBeThrown;
    public Sprite eventImage;

    // Start is called before the first frame update
    void Start()
    {
        fix();
    }

    public void TriggerDefSpending(bool kind)
    {
        if (kind)
        {
            incomeScript.DefenceSpendingIncrease();
        }
        
        else if (!kind)
        {
            incomeScript.DefenceSpendingLower();
        }
    } 

    public void fix()
    {
        userStash = UserStash.userstash;
        slaveScript = userStash.slavescript;
        incomeScript = userStash.incomemanager;

        transform.Find("EventTXT").gameObject.GetComponent<Text>().text = textToBeThrown;
        transform.Find("EventIMG").gameObject.GetComponent<Image>().sprite = eventImage;
    }

    // Update is called once per frame
    void Update()
    {
        if (userStash == null)
        {
            fix();
        }
    }
}
