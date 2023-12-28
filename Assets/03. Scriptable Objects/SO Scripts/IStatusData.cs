using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatusData
{
    string Name { get; }
    int Hp { get; }
    int Mp { get; }
    int Atk { get; }
    int Def { get; }
    int Foc { get; }
    float Crit { get; }
    float Agi { get; }
}
