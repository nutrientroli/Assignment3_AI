using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;

[Condition("MyConditions/CustomerInStore")]
[Help("true if there's a customer to see to...")]

public class CONDITION_CustomerInStore : GOCondition
{

    [InParam("inside store point")]
    public GameObject store;

    [OutParam("customer")]
    public GameObject customer;

    public override bool Check()
    {
        customer = SensingUtils.FindInstanceWithinRadius(store, "CUSTOMER", 30);
        return customer != null;
    }
}