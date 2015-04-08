using UnityEngine;
using System.Collections;

public class Gate : GateBase
{
     void Start()
    {
        this.RandomSecondsBetweenCreations = new float[2] { 5, 30 };
        this.MaximumAmountOfMonsters = 20;
    }
}
