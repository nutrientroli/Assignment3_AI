using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;


[Condition("MyConditions/InGoodMood")]
[Help("is the agent in a good mood or not?")]

public class CONDITION_InGoodMood : GOCondition
{
   public override bool Check()
    {
        return gameObject.GetComponent<CUSTOMER_BLACKBOARD>().goodMood;
    }
}
