
using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using BBUnity.Actions;		  // actions with "gameobject"

using Steerings;

[Action("MyActions/ArriveByTag")]  // name of the action for BB engine
[Help("Goes to (ARRIVES) a location specifieb with a tag")]

public class ACTION_ArriveByTag : GOAction  // inherit from GOAction
// to have access to the gameobject
// Beware: GOActions ARE NOT MonoBehaviours
{

    [InParam("tag")] // the tag of the object we want to go to... 
    public string tag;

    [InParam("closeEnough")] // there or not yet?
    public float closeEnough;

    private Arrive arrive;
    private GameObject target;

    // BB engine OnStart method (equivalent to Start of MonoBehaviours)
    public override void OnStart()
    {
        base.OnStart();

        target = GameObject.FindGameObjectWithTag(tag);
        if (target == null)
        {
            Debug.Log("ACTION_ArriveByTag will fail because target not located...");
            return;
        }
        arrive = gameObject.GetComponent<Arrive>();
        arrive.target = target;
        arrive.closeEnoughRadius = closeEnough;  // onUpdate will also take care of this
        arrive.enabled = true;
    }


    // BB engine OnUpdate method
    public override TaskStatus OnUpdate()
    {
        if (target == null) return TaskStatus.FAILED;

        if (SensingUtils.DistanceToTarget(gameObject, target) <= closeEnough)
        {
            arrive.enabled = false;
            return TaskStatus.COMPLETED; // COMPLETED = SUCCESSFUL termination
        }
        else
        {
            return TaskStatus.RUNNING;  // RUNNING = not COMPLETED yet
        }
    }

    // what to do if task is aborted while running
    public override void OnAbort()
    {
        base.OnAbort();
        arrive.enabled = false;
    }

}