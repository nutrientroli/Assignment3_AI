using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;

[Condition("MyConditions/Feel unsafe")]
[Help("Am I too far from my safety point? True if out of safety area or (when returning) out of extra safety area")]
public class CONDITION_FeelUnsafe : GOCondition {


    [InParam("attractor")]
    public GameObject attractor;

    [InParam("safety radius")] 
    public float safetyRadius;

    [InParam("extra safety radius")]
    public float extraSafetyRadius;

    private bool lastTick = false;

    public override bool Check()
    {
        float distance = SensingUtils.DistanceToTarget(gameObject, attractor);

        // out of safety area? return true
        // inside of extra safety area? return false
        // otherwise return what was returned the previus tick

        if (distance > safetyRadius)
        {
            lastTick = true;
            return lastTick;
        }

        if (distance <= extraSafetyRadius)
        {
            lastTick = false;
            return lastTick;
        }

        return lastTick;
    }
}
