using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;


[Condition("MyConditions/CheckStorage")]
[Help("Checks the storage in order to know if there is or not the item requested")]

public class CONDITION_CheckStorage : GOCondition
{
    [InParam("item")]
    public string item;

    [InParam("checkExistances")]
    public bool checkExistances;            // para evitar el bug del sistema solo tendremos una funcion
    
    public override bool Check()
    {
        ANITAs_BLACKBOARD _blackBoard = this.gameObject.GetComponent<ANITAs_BLACKBOARD>();
        if (ReferenceEquals(_blackBoard,null))
        {
            Debug.LogError("No blackboardFound");
            return false;
        } else
        {
            if (checkExistances)
            {
                return _blackBoard.CheckExistences(item);

            } else
            {
                return _blackBoard.CheckStorage(item);
            }


        }

        //throw new System.NotImplementedException();
    }
}
