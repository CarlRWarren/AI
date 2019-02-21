using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : ActionNode
{
    public override DecisionTreeNode Execute()
    {
        isActive = true;
        //perform action
        return null;
    }
}
