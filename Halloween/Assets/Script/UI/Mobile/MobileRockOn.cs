﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileRockOn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var trigger = GetComponent<EventTrigger>();
        var entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };

        var player = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerScr2D>();
        //entry.callback.AddListener((eventData) => { player.MobileRockOnControl(); });
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
