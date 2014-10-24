using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO.Ports;
public class FirstPlayer : Player
{
    private RaycastHit hit;

    //Animation on Player - Soldier.prefab
    private AnimationClip idle;
    public AnimationClip run;
    public AnimationClip fire;
    public AnimationClip die;
    public GameObject respawnEffect;
    public Slider healthBar;
    public Text gameText;
    public ArduinoTalk controller;
    public AnimationClip Idle
    {
        get
        {
            return this.idle;
        }
        set
        {
            this.idle = value;
        }
    }
    void Start()
    {
        
        this.Health = 100;
        this.Speed = 10;
        this.Xp = 0;
        for (int i = 1; i < weapons.Length; i++)
        {
            this.Weapons[i].SetActive(false);
        }
        gameText.enabled = false;
    }
    void OnHealthChange()
    {
        healthBar.value = this.Health;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        OnHealthChange();
        if (this.IsAlive == false)
        {
            // TODO: this.DeadPlayer();
        }
        this.KeyListener();
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        //Moving & Firing
        if ((horizontalMove != 0 || verticalMove != 0) && (this.IsAlive))
        {
            this.MoveWASD(horizontalMove, verticalMove);
            this.Rotation();
            this.animation.Play(run.name);
            
        }
        // Idle
        else
        {
            // Fire
            if ((Input.GetMouseButton(0)) && (this.IsAlive))
            {
                //TODO: Mouse Button Shoot the enemy
                this.animation.CrossFade(fire.name);
            }

            else if (this.IsAlive)
            {
                this.animation.CrossFade(fire.name);
            }

            this.Rotation();

        }

        //Dead
        if ((this.Health <= 0) && (this.IsAlive))
        {
            this.Died();
            
            gameText.enabled=true;
        }
        else
        {
            gameText.enabled = false;
        }
        if (this.Xp >= this.NextLevel)
        {
            this.Level++;
            this.NextLevel *= 1.643f;
        }
    }

    public void Died()
    {
        this.animation.CrossFade(die.name);
        if (this.Level > 5)
        {
            this.transform.position = new Vector3(-154.9781f, 1.132813f, 14.37274f);
        }
        else
        {
            this.transform.position = new Vector3(1043.214f, 41.76284f, 692.0972f);
        }

        this.Health = 90;
        this.NextLevel /= 1.643f;
        this.Xp = this.NextLevel - 20;

        if (this.Level - 1 < 0)
        {
            this.Level = 0;
        }
        else
        {
            this.Level--;
        }

        if (this.Score - 5000f <= 0)
        {
            this.Score = 0f;
        }
        else
        {
            this.Score -= 5000f;
        }
        Instantiate(this.respawnEffect, transform.position, Quaternion.identity);

        Debug.Log("Died");
        Debug.Log(this);
    }
}
