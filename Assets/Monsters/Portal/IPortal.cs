using System;
using UnityEngine;

public interface IPortal
{
    float[] RandomSecondsBetweenCreations { get; set; }
    GameObject[] Creatures { get; set; }
    int AmountOfMonsters { get; set; }
    bool IsAlive { get; set; }
}
