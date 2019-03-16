using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus


[Action("MyActions/TellEngaged")]
[Help("Tell something to the dialog partner -fail if none-")]

public class Action_TellEngaged : BBUnity.Actions.GOAction
{
    [InParam("index")]
    public int index;

    [InParam("duration")]
    public int duration;

    private IDialogSystem dialogSystem;
    private float elapsedTime;

    public override void OnStart()
    {
        base.OnStart();
        dialogSystem = gameObject.GetComponent<IDialogSystem>();
        // first utter
        dialogSystem.SetUtterance(index);
        // then give partner time to answer
        elapsedTime = 0;

    }

    public override TaskStatus OnUpdate()
    {

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= duration)
        {
            dialogSystem = gameObject.GetComponent<IDialogSystem>();
            if (dialogSystem.Tell(index, false))  return TaskStatus.COMPLETED;
            else return TaskStatus.FAILED;
        }
        else
        {
            return TaskStatus.RUNNING;
        }


    }

}