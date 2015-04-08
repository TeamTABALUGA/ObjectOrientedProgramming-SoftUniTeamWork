using UnityEngine;
using System.Collections;

public interface ICreature
{
    float Health { get; set; }
    float MovementSpeed { get; set; }
    float Score { get; }
    float Xp { get; set; }
    bool IsAlive { get; }
}
