﻿using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;
using System.Threading;
using System.Collections;
public class ArduinoMoves : MonoBehaviour
{

    private Vector3 position;
    private float speed = 10;
    private RaycastHit hit;
    Vector3 lookTarget;

    public AnimationClip idle;
    public AnimationClip run;
    public AnimationClip fire;
    public AnimationClip die;
    //Arduino Add-in
    SerialPort sp = new SerialPort("COM3", 9600);
    public float direction=0;
    //TODO:Health system
    private float health = 65000;

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 20;
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        //Arduino movement
        if (sp.IsOpen)
        {
            try
            {
                direction = sp.ReadByte();
                print(sp.ReadByte());
                ArduinoMoves(direction);
                
            }
            catch (System.Exception)
            {
            }
        }
       
       
        
        //Moving & Firing
        if(horizontalMove != 0 || verticalMove != 0)
        {
            MoveWASD(horizontalMove, verticalMove);
            Rotation();
        }
        // Idle
        else
        {
            // Fire
            if (Input.GetMouseButton(0))
            {
                //TODO: Mouse Button Shoot the enemy
                animation.CrossFade(fire.name);
            }
            
            else
            {
                animation.CrossFade(idle.name);
            }

            Rotation();

        }
        //Dead
        if (health <= 0)
        {
            animation.CrossFade(die.name);
        }

    }

    private void Rotation()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           lookTarget = hit.point;

       }
        transform.LookAt(lookTarget);
    }

    public void MoveWASD(float horizontalMove, float verticalMove)
    {
        if (horizontalMove != 0 || verticalMove != 0)
        {
            transform.position += (Vector3.forward * (verticalMove) + Vector3.right * horizontalMove) * Time.deltaTime * speed;
        }
        
        animation.CrossFade(run.name);
    
    }
    public void ArduinoMoves(float direction)
    {
        if (direction != 0)
        {
            transform.position += (Vector3.right * speed * Time.deltaTime);
           
        }
        animation.Play(run.name);
    }
}