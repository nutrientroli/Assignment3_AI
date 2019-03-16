using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using BBUnity.Actions;


[Action("MyActions/ParseAnswer")]
[Help("parse a string to get main element")]
public class ACTION_ParseAnswer : GOAction
{

    [InParam("answer")]
    public string answer;
    [OutParam("itemRequested")]
    public string itemRequested;

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        

        if (answer.ToUpper().Contains("APPLE"))
            itemRequested = "APPLE";
        else if (answer.ToUpper().Contains("PEACH"))
            itemRequested = "PEACH";

        if (itemRequested != null) return TaskStatus.COMPLETED;
        else return TaskStatus.FAILED;
    }
}
