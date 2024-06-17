﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject BlyncController;
    public BlyncControllerData sensorData;
    public BlyncSceneIdentity sceneIdentity;
    public GameObject bike;

    // Set callback when blync connects and enable Blync controller
    void Start()
    {
        sensorData.RegisterBlyncConnectedListener(BlyncConnected);
        BlyncController.SetActive(true);
    }

    
    void BlyncConnected(bool status)
    {
        if (status)
        {
            StartSession();
            bike.GetComponent<Mover>().enabled = true;
        }
        else
        {
            //disconnected
        }
        
    }
    bool turnset = false;
    public void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (!turnset)
            {
                turnset = true;
                RecenterHandlebar();
            }
        }
        
    }


    //call to recenter the user's handlebar to the middle
    public void RecenterHandlebar()
    {
        sensorData.setCenterCorrection();
    }

    //stop biking session e.g at the end of a game round
    public void StopSession()
    {
        sensorData.ChangeSession(false);
    }

    //Create your scene and get scene Id from your companion app
    public void SetSceneId(string sceneId)
    {
        sceneIdentity.sceneId = sceneId;
    }

    //Start biking session. 
    public void StartSession()
    {
        sensorData.ChangeSession(true);
    }
}
