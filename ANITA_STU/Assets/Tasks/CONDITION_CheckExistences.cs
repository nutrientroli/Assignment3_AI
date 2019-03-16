using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;


[Condition("MyConditions/CheckExistences")]
[Help("Check whether we have that (item) or not")]

public class CONDITION_CheckExistences : GOCondition
{
    [InParam("item")]
    string item;

    // only relevant method for conditions. Perform a check and return the result
    public override bool Check()
    {
        

        ANITAs_BLACKBOARD blackboard = gameObject.GetComponent<ANITAs_BLACKBOARD>();
        if (blackboard == null)
        {
            Debug.Log("No blackboard attached in CheckExistences. Failing");
            return false;
        }
        else
            return blackboard.CheckExistences(item);
        

    }
}