using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus


[Action("MyActions/DisengageFromDialog")]
[Help("Stop dialoguin with partner, if any")]

public class Action_DisengageFromDialog : BBUnity.Actions.GOAction
{

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        gameObject.GetComponent<IDialogSystem>().DisengageFromDialog();
        return TaskStatus.COMPLETED;
    }

  

}