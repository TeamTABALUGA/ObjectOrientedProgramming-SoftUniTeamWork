using UnityEngine;
using System.Collections;

public class BossAppear : GateBase
{

    // Use this for initialization
    void Start()
    {
        this.RandomSecondsBetweenCreations = new float[2] { 100, 120 };
        this.MaximumAmountOfMonsters = 20;
    }
}
