using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using System;

[Action("MyActions/QuestionIsEngagedInDialog")]
[Help("succeds only if agent is engaged in a dialog")]

public class Action_QuestionIsEngagedInDialog : BBUnity.Actions.GOAction
{

    public override TaskStatus OnUpdate()
    {
        try
        {
            if (gameObject.GetComponent<IDialogSystem>().IsEngagedInDialog())
                return TaskStatus.COMPLETED;
            else return TaskStatus.FAILED;
        }
        catch (Exception e)
        {
            return TaskStatus.FAILED;
        }
    }

}

