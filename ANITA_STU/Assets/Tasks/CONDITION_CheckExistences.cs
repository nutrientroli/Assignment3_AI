using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;


[Condition("MyConditions/CheckExistences")]
[Help("Check whether we have that (item) or not, use the bool to check the storage instead (know why we did this in this way on the report)")]

public class CONDITION_CheckExistences : GOCondition
{
    [InParam("item")]
    public string item;

    [InParam("checkStorageInstead")]
    public bool checkStorage;

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
        {
            if (checkStorage)
            {
                return blackboard.CheckStorage(item);

            } else
            {
                return blackboard.CheckExistences(item);
            }
        }

        

    }
}