using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus


[Action("MyActions/Sell")]
[Help("Sell item")]

public class Action_Sell : BBUnity.Actions.GOAction
{

    [InParam("item")]
    [Help("the object that is going to be asked")]
    public string item;


    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        ANITAs_BLACKBOARD blackboard = gameObject.GetComponent<ANITAs_BLACKBOARD>();
        if (blackboard==null)
        {
            Debug.Log("no blackboard attached in Sell");
            return TaskStatus.FAILED;
        }
        else
        {
            if (blackboard.Sell(item)) return TaskStatus.COMPLETED;
            else return TaskStatus.FAILED;
        }
    }

}