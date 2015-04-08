using UnityEngine;
using System.Collections;

/// <summary>
/// Initilize new Gate Requared: float randomSecondsBetweenCreations int amountOfMonsters, Array of creatures -> from Unity Inspector
/// </summary>
public abstract class GateBase : MonoBehaviour, IPortal
{
    private float secondsBetweenCreation = 0;
    private float[] randomSecondsBetweenCreations = new float[2] { 0, 0 };
    public GameObject[] creatures;
    private int amountOfMonsters;
    private bool isAlive = true;
    private uint maximumAmountOfMonsters;
    public uint monstersAmount = 0;
    private float timer = 0;

    public uint MaximumAmountOfMonsters
    {
        get;
        set;
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

    public float[] RandomSecondsBetweenCreations
    {
        get { return randomSecondsBetweenCreations; }
        set { randomSecondsBetweenCreations = value; }
    }

    public float SecondsBetweenCreation
    {
        get
        {
            this.secondsBetweenCreation = Random.Range(this.RandomSecondsBetweenCreations[0], this.RandomSecondsBetweenCreations[1]);
            return this.secondsBetweenCreation;
        }
        set
        {
            // value = Random.Range(this.RandomSecondsBetweenCreations[0], this.RandomSecondsBetweenCreations[1]);
            this.secondsBetweenCreation = value;
        }
    }

    public GameObject[] Creatures
    {
        get
        {
            return this.creatures;
        }
        set { this.creatures = value; }
    }

    public int AmountOfMonsters
    {
        get
        {
            return this.amountOfMonsters;
        }
        set { this.amountOfMonsters = value; }
    }

    //public virtual void Start()
    //{
    //    InvokeRepeating("Create", 2,this.SecondsBetweenCreation);
    //}

    public void Create()
    {
        foreach (var mutant in creatures)
        {
            GameObject newCreature = Instantiate(mutant, this.transform.position, Quaternion.identity) as GameObject;
        }
    }

    public void Update()
    {
        if (this.IsAlive == false)
        {
            this.DestoyGate();
        }
        timer += Time.deltaTime;

        Collider[] hitInfo = Physics.OverlapSphere(transform.position, 60f);
        foreach (var obj in hitInfo)
        {
            if (obj.tag == "Player" && this.timer >= this.SecondsBetweenCreation)
            {
                Invoke("Create", 5);
                this.timer = 0;
            }
        }

    }

    private void DestoyGate()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        //if (this.monstersAmount <= this.MaximumAmountOfMonsters)
        //{
        //    if (other.tag == "Player")
        //    {
        //        Invoke("Create", 2);
        //    }

        //    this.monstersAmount += (uint)creatures.Length;
        //}
    }
}
