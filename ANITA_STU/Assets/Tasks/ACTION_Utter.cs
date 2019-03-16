using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

[Action("MyActions/Utter")]
[Help("sets an utterance by index")]

public class ACTION_Utter : BBUnity.Actions.GOAction
{

    [InParam("UtteranceIndex")]
    public int index;
    [InParam("duration", DefaultValue = 3f)]
    public float duration = 3;

   
    private IDialogSystem dialogSystem;
    private float elapsedTime = 0;

    public override void OnStart()
    {
        base.OnStart();

        dialogSystem = gameObject.GetComponent<IDialogSystem>();

        if (dialogSystem == null)
        {
            Debug.Log("No dialog system in Utter. Succeeding, anyway");
            elapsedTime = duration;
        }
        else
        {
            dialogSystem.SetUtterance(index);
            elapsedTime = 0;
        }
    }

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {

        if (elapsedTime >= duration)
            return TaskStatus.COMPLETED;
        else
        {
            elapsedTime += Time.deltaTime;
            return TaskStatus.RUNNING;
        }

    } // OnUpdate

}