using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutonomousBehaviour : MonoBehaviour
{
    public abstract Vector3 Execute(AutonomousAgent agent, AutonomousAgent target);
}
