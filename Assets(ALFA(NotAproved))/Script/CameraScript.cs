﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float zoomCamera = Input.GetAxis("Mouse ScrollWheel");

        
            camera.orthographicSize -= zoomCamera;
        

    }
}
