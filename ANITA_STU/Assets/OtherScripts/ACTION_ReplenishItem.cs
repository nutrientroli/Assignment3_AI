using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using BBUnity.Actions;


[Action("MyActions/ReplenishItem")]

public class ACTION_ReplenishItem : GOAction
{
    [InParam("itemToReplenish")]
    public string item;
    [InParam("increaseAmount")]
    public int amount;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        ANITAs_BLACKBOARD blackboard = gameObject.GetComponent<ANITAs_BLACKBOARD>();
        if (blackboard == null)
        {
            return TaskStatus.FAILED;

        } else
        {
            if (item == "APPLE")
            {
                blackboard.IncreaseApplesAmount(amount);

            } else if (item == "PEACH")
            {
                blackboard.IncreasePeachesAmount(amount);

            } else
            {
                return TaskStatus.FAILED;
            }

            return TaskStatus.COMPLETED;
        }
    }


}
