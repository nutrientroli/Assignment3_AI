using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus


[Action("MyActions/EngageInDialog")]
[Help("Engage in a dialog with a partner")]

public class Action_EngageInDialog : BBUnity.Actions.GOAction
{

    [InParam("partner")]
    [Help("the object that is going to be asked")]
    public GameObject partner;

    
    private IDialogSystem partnerDialogSystem;

    public override void OnStart()
    {
        if (partner!=null) partnerDialogSystem = partner.GetComponent<IDialogSystem>();
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if (partnerDialogSystem == null)
        {
            Debug.Log("Ask fails because target or its dialogSystem not found");
            return TaskStatus.FAILED;
        }
        else
        {
            // let's call our own engage...
            if (gameObject.GetComponent<IDialogSystem>().EngageInDialog(partnerDialogSystem))
                return TaskStatus.COMPLETED;
            else return TaskStatus.FAILED;
        }
    }

}