using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Lister : MonoBehaviour
{
    public int checkingpage = 0;
    public List<Text> textfields;
    public List<Image> itemImgZone;
    public List<Resource> lastlisttaken = null;
    
    public void CheckingPage(bool incOrdec)
    {
        if (incOrdec)
        {
            checkingpage++;
        }
        else if (!incOrdec && checkingpage > 0)
        {
            checkingpage--;
        }

        if (lastlisttaken != null)
        {
            S();
        }
    }
    public void S()
    {
        for (int i = 0; i < textfields.Count; i++)
        {
            if (lastlisttaken.Count <= i+checkingpage*8)
            {
                textfields[i].text = "Empty Slot";
                itemImgZone[i].sprite = null;
                continue;
            }

            itemImgZone[i].sprite = lastlisttaken[i+checkingpage*8].goodIMG;
            textfields[i].text = "Price: " + lastlisttaken[i+checkingpage*8].priceAsLuxury + " " + lastlisttaken[i+checkingpage*8].amount.ToString(CultureInfo.CreateSpecificCulture("eu-ES"));
        }
    }
    public void S(List<Resource> list)
    {
        lastlisttaken = list;
        for (int i = 0; i < textfields.Count; i++)
        {
            if (lastlisttaken.Count <= i+checkingpage*8)
            {
                textfields[i].text = "Empty Slot";
                itemImgZone[i].sprite = null;
                continue;
            }

            itemImgZone[i].sprite = lastlisttaken[i+checkingpage*8].goodIMG;
            textfields[i].text = "Price: " + lastlisttaken[i+checkingpage*8].priceAsLuxury + " " + lastlisttaken[i+checkingpage*8].amount.ToString(CultureInfo.CreateSpecificCulture("eu-ES"));
        }
    }

    public void S(List<Resource> list, string amountTag)
    {
        lastlisttaken = list;
        for (int i = 0; i < textfields.Count; i++)
        {
            if (lastlisttaken.Count <= i+checkingpage*8)
            {
                textfields[i].text = "Empty Slot";
                itemImgZone[i].sprite = null;
                continue;
            }

            itemImgZone[i].sprite = lastlisttaken[i+checkingpage*8].goodIMG;
            textfields[i].text = "Price: " + lastlisttaken[i+checkingpage*8].priceAsLuxury + " " + lastlisttaken[i+checkingpage*8].amount.ToString(CultureInfo.CreateSpecificCulture("eu-ES")) + " " + amountTag;
        }
    }

}
