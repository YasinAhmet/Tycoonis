using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFollower : MonoBehaviour
{
    public List<GameObject> phases = new List<GameObject>();

    public int activephase = 0;
    public void Start()
    {
        phases[0].SetActive(true);
    }

    public void next()
    {
        activephase++;
        phases[activephase].SetActive(true);
        phases[activephase-1].SetActive(false);
    }

    public void Finish()
    {
        Destroy(this.gameObject);
    }
}
