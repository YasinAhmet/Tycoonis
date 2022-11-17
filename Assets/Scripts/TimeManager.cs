using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int day;

    public Text text;

    public int turnSpeed = 5;
    public bool timestop = true;

    public int timecounter = 0;

    public Image speed1;
    public Image speed2;
    public Image speed3;
    public Image speed4;
    public Image speed6;
    
    public int _1speed = 2000;
    public int _2speed = 1000;
    public int _3speed = 500;
    public int _4speed = 250;
    public int _5speed = 125;

    public int totalspeed = 500;
    
    public Sprite defaulstate;
    public Color defaultcolor;
    public string textf = "Day: ";
    
    private void Start()
    {
        timeManager = this;
        text.text = textf + " " + day;
        defaulstate = speed1.sprite;
        defaultcolor = speed1.color;
    }

    public void SetTurnSpeed(int speed)
    {
        turnSpeed = speed;
        if (speed < 1)
        {
            speed = 1;
        }
        
        if (speed == 1)
        {
            totalspeed = _1speed;
            SpriteState s = new SpriteState();
            
            speed1.GetComponent<Button>().image.color = Color.gray;
            speed1.GetComponent<Button>().image.sprite = s.pressedSprite;
            
            speed2.GetComponent<Button>().image.sprite = defaulstate;
            speed3.GetComponent<Button>().image.sprite = defaulstate;
            speed4.GetComponent<Button>().image.sprite = defaulstate;
            speed6.GetComponent<Button>().image.sprite = defaulstate;
            
            speed2.GetComponent<Button>().image.color = defaultcolor;
            speed3.GetComponent<Button>().image.color = defaultcolor;
            speed4.GetComponent<Button>().image.color = defaultcolor;
            speed6.GetComponent<Button>().image.color = defaultcolor;
        } else if (speed == 2)
        {
            totalspeed = _2speed;
            SpriteState s = new SpriteState();
            
            speed2.GetComponent<Button>().image.color = Color.gray;
            speed2.GetComponent<Button>().image.sprite = s.pressedSprite;
            
            speed1.GetComponent<Button>().image.color = defaultcolor;
            speed3.GetComponent<Button>().image.color = defaultcolor;
            speed4.GetComponent<Button>().image.color = defaultcolor;
            speed6.GetComponent<Button>().image.color = defaultcolor;
            
            speed1.GetComponent<Button>().image.sprite = defaulstate;
            speed3.GetComponent<Button>().image.sprite = defaulstate;
            speed4.GetComponent<Button>().image.sprite = defaulstate;
            speed6.GetComponent<Button>().image.sprite = defaulstate;
        } else if (speed == 3)
        {
            totalspeed = _3speed;
            SpriteState s = new SpriteState();
            
            speed3.GetComponent<Button>().image.color = Color.gray;
            speed3.GetComponent<Button>().image.sprite = s.pressedSprite;
            
            speed1.GetComponent<Button>().image.sprite = defaulstate;
            speed2.GetComponent<Button>().image.sprite = defaulstate;
            speed4.GetComponent<Button>().image.sprite = defaulstate;
            speed6.GetComponent<Button>().image.sprite = defaulstate;
            
            speed1.GetComponent<Button>().image.color = defaultcolor;
            speed2.GetComponent<Button>().image.color = defaultcolor;
            speed4.GetComponent<Button>().image.color = defaultcolor;
            speed6.GetComponent<Button>().image.color = defaultcolor;
        } else if (speed == 4)
        {
            totalspeed = _4speed;
            SpriteState s = new SpriteState();
            
            speed4.GetComponent<Button>().image.color = Color.gray;
            speed4.GetComponent<Button>().image.sprite = s.pressedSprite;
            
            speed1.GetComponent<Button>().image.sprite = defaulstate;
            speed2.GetComponent<Button>().image.sprite = defaulstate;
            speed3.GetComponent<Button>().image.sprite = defaulstate;
            speed6.GetComponent<Button>().image.sprite = defaulstate;
            
            speed1.GetComponent<Button>().image.color = defaultcolor;
            speed2.GetComponent<Button>().image.color = defaultcolor;
            speed3.GetComponent<Button>().image.color = defaultcolor;
            speed6.GetComponent<Button>().image.color = defaultcolor;
        } else if (speed == 5)
        {
            totalspeed = _5speed;
            SpriteState s = new SpriteState();
            
            speed6.GetComponent<Button>().image.color = Color.gray;
            speed6.GetComponent<Button>().image.sprite = s.pressedSprite;
            
            speed1.GetComponent<Button>().image.sprite = defaulstate;
            speed2.GetComponent<Button>().image.sprite = defaulstate;
            speed3.GetComponent<Button>().image.sprite = defaulstate;
            speed4.GetComponent<Button>().image.sprite = defaulstate;
            
            speed1.GetComponent<Button>().image.color = defaultcolor;
            speed2.GetComponent<Button>().image.color = defaultcolor;
            speed3.GetComponent<Button>().image.color = defaultcolor;
            speed4.GetComponent<Button>().image.color = defaultcolor;
        }
    }

    public void STOP()
    {
        timestop = true;
    }

    public void StopRevert()
    {
        timestop = !timestop;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StopRevert();
        }
        
        if (timestop)
        {
            return;
        }
        
        timecounter++;

        if (timecounter >= totalspeed)
        {
            DealWithTurns();
            timecounter = 0;
        }
        
    }

    public void TurnHappened()
    {
        day++;
        text.text = textf + " " + day;
    }
    
    public static TimeManager timeManager;
    
    public void DealWithTurns()
    {
        UserStash u = UserStash.userstash;

        Debug.Log("GOOD DETECT1 " + u.bGoodslist[0].amount);
        u.TurnHappened();
        Debug.Log("GOOD DETECT2 " + u.bGoodslist[0].amount);
        u.soldierScript.TurnHappened();
        Debug.Log("GOOD DETECT3 " + u.bGoodslist[0].amount);
        u.incomemanager.TurnHappened();
        Debug.Log("GOOD DETECT4 " + u.bGoodslist[0].amount);
        u.trademechanics.turnHappened();
        Debug.Log("GOOD DETECT5 " + u.bGoodslist[0].amount);
        EventThrover.eventThrover.TurnHappened();
        Debug.Log("GOOD DETECT6 " + u.bGoodslist[0].amount);
        TurnHappened();
    }
}
