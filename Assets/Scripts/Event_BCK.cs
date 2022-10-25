using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_BCK : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (UserStash.userstash.BackGroundSprite != null)
        {
            GetComponent<Image>().sprite = UserStash.userstash.BackGroundSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
