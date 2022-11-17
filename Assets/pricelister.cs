using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pricelister : MonoBehaviour
{
    public List<GameObject> pricezones;

    void Update()
    {
        pricezones[0].GetComponent<Text>().text = "Basic Food Prices: " + UserStash.userstash.trademechanics.marketPrice_bfood;
        pricezones[1].GetComponent<Text>().text = "Basic Material Prices: " + UserStash.userstash.trademechanics.marketPrice_bmat;
        pricezones[2].GetComponent<Text>().text = "Basic Good Prices: " + UserStash.userstash.trademechanics.marketPrice_bgood;
        pricezones[3].GetComponent<Text>().text = "Basic Gun Prices: " + UserStash.userstash.trademechanics.marketPrice_bgun;
    }
}
