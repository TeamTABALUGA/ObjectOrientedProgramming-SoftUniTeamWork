using UnityEngine;

public abstract class Player : MonoBehaviour, ICreature
{
    private Vector3 position;
    private Vector3 lookTarget;
    private float speed;
    private float health;
    private float xp;
    private float score = 0;
    public GameObject[] weapons = new GameObject[4];
    private bool isAlive = true;
    private int level = 0;
    private float nextLevel = 200;
    private int arduinoDirection;
    public int ArduinoDirection
    {
        get
        {
            return this.arduinoDirection;
        }
        set
        {
            this.arduinoDirection = value;
        }
    }
    public float NextLevel 
    { 
        get 
        {
            return this.nextLevel;
        }
        set 
        {
            this.nextLevel = value;
        }
    }

    public float MovementSpeed { get; set; }

    public int Level
    {
        get
        {
            return this.level;
        }
        set
        {
            this.level = value;
        }
    }

    public bool IsAlive
    {
        get
        {
            return this.isAlive;
        }
        set
        {
            this.isAlive = value;
        }
    }

    public float Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
        }
    }

    public GameObject[] Weapons
    {
        get
        {
            return this.weapons;
        }
        set
        {
            this.weapons = value;
        }
    }

    /// <summary>
    /// Expirience of the player 
    /// </summary>
    public float Xp
    {
        get
        {
            return this.xp;
        }
        set
        {
            this.xp = value;
        }
    }

    /// <summary>
    /// Speed of player
    /// </summary>
    public float Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            this.speed = value;
        }
    }

    /// <summary>
    /// Health points of player
    /// </summary>
    public float Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
        }
    }

    /// <summary>
    /// Make player look allways to the cursor direction
    /// </summary>
    public void Rotation()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            lookTarget = hit.point;
        }
        transform.LookAt(new Vector3(lookTarget.x, transform.position.y, lookTarget.z));

    }

    /// <summary>
    /// Move player on horizontal and vertical direction by buttons WASD and arows
    /// </summary>
    /// <param name="horizontalMove">X-Axis</param>
    /// <param name="verticalMove">Y-Axis</param>
    public void MoveWASD(float horizontalMove, float verticalMove)
    {
        transform.position += (Vector3.forward * verticalMove + Vector3.right * horizontalMove) * speed * Time.deltaTime;
    }
    public void ArduinoMove(int direction)
    {
        switch (direction)
        {
            case 1:
                {
                    transform.position += (Vector3.right * speed * Time.deltaTime);
                }
            break;
            case 2:
            {
                transform.position += (Vector3.left * speed * Time.deltaTime);
            }
            break;
            case 3:
            {
                transform.position += (Vector3.forward * speed * Time.deltaTime);
            }
            break;
            case 4:
            {
                transform.position += (Vector3.back * speed * Time.deltaTime);
            }
            break;
        }
        
    }
    public void KeyListener()
    {
        if (Input.GetKeyDown("1") == true)
        {
            UnselectOther();
            weapons[0].SetActive(true);
        }
        else if (Input.GetKeyDown("2") == true)
        {
            UnselectOther();
            weapons[1].SetActive(true);
        }
        else if (Input.GetKeyDown("3") == true)
        {
            UnselectOther();
            weapons[2].SetActive(true);
        }
        else if (Input.GetKeyDown("g") == true)
        {
            UnselectOther();
            weapons[3].SetActive(true);
        }
    }

    private void UnselectOther()
    {
        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }
    }

    public override string ToString()
    {
        return string.Format("Player: score={0} XP={1}, Health = {2}  Level = {3} NextLevel = {4} ", this.Score, this.Xp, this.Health, this.Level, this.NextLevel);
    }
}
