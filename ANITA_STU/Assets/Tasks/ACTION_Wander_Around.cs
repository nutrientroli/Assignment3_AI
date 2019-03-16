using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using BBUnity.Actions;		  // actions with "gameobject"

using Steerings;

[Action("MyActions/Wander Around")]  
[Help("Wanders around an attractor")]


public class ACTION_Wander_Around : GOAction {

    [InParam("attractor")] 
    public GameObject attractor;

    [InParam("seek weight")] 
    public float seekWeight;

    private WanderAround wanderAround;

    public override void OnStart()
    {
        base.OnStart();

        wanderAround = gameObject.GetComponent<WanderAround>();
        wanderAround.attractor = attractor;
        wanderAround.seekWeight = seekWeight;

        wanderAround.enabled = true;
    }


    public override TaskStatus OnUpdate()
    {
        return TaskStatus.RUNNING;
    }


    public override void OnAbort()
    {
        base.OnAbort();
        wanderAround.enabled = false;
    }
    

}
