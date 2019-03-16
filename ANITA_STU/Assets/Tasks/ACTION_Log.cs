using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

[Action("MyActions/Log")]
[Help("Logs a message for debugging purposes")]

public class ACTION_Log : BBUnity.Actions.GOAction
{
    [InParam("message")]
    public string message;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log(message);
        return TaskStatus.COMPLETED;
    }



}