using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus


[Action("MyActions/ClearUtterance")]
[Help("Clears utterance text")]

public class Action_ClearUtterance : BBUnity.Actions.GOAction
{
   
    private IDialogSystem dialogSystem;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        dialogSystem = gameObject.GetComponent<IDialogSystem>();
        dialogSystem.ClearUtterance();
        return TaskStatus.COMPLETED;
    }

}