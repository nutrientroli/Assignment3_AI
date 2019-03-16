
using UnityEngine;

public class CUSTOMER_BLACKBOARD : MonoBehaviour, IDialogSystem
{

    private TextMesh utteranceLine;
    public IDialogSystem partner = null;
    public bool goodMood = true;

    public string[] utterances =
    {
        "Hello...", //0
        "An apple, please",//1
        "A peach, please", //2
        "Some grapes, please", //3
        "Thank you\nGoodbye", // 4
        "Now let me\ngo home...",
        "...and eat this\nfantastic fruit",//6
        "shit!\nno fruit today",
        "I'll go for a\ngreasy burger",//8
        "Let me go buy\nsome tasty fruit..."
    };
    
    // Start is called before the first frame update
    void Start()
    {
        utteranceLine = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        gameObject.AddComponent<DieNear>();
        GetComponent<DieNear>().cemetery = GameObject.Find("exitPoint");
    }


    public void SetUtterance(int index)
    {
        utteranceLine.text = utterances[index];
    }

    public void ClearUtterance()
    {
        utteranceLine.text = "";
    }

    public string BeAsked(string question)
    {
        // a more "intelligent system would analyze the question before answering";
        int number = Random.Range(1, 4);
        SetUtterance(number);
        return utterances[number];
    }

    public void BeTold(string sentence)
    {
        // senteces with negative words affect the mood of the agent...
        if (sentence.ToUpper().Contains("NO")
            || sentence.ToUpper().Contains("NONE")
            || sentence.ToUpper().Contains("DON'T")) goodMood = false;
    }

    public bool EngageInDialog(IDialogSystem partner)
    {
        // you want to engage with someone. Use this method
        if (partner.BeEngagedInDialog(this))
        {
            this.partner = partner;
            return true;
        }
        return false; // returning false means partner has refused.
    }

    public bool BeEngagedInDialog (IDialogSystem partner)
    {
        // someone wants to talk to you. You may refuse or accept
        // this agent always accepts
        this.partner = partner;
        return true;
    }

    public void BeDisengagedFromDialog()
    {
        // a disengaged customer becomes an EX_CUSTOMER
        // else "race conditions" may re-engage it and thwart expected behaviour
        gameObject.tag = "EX_CUSTOMER";
        this.partner = null;
    }

    public void DisengageFromDialog()
    {
        throw new System.NotImplementedException();
    }

    public bool IsEngagedInDialog()
    {
        return this.partner != null;
    }

    public string Ask(int index, bool utter)
    {
        // do nothing. Customers make no questions
        return null;
    }

    public bool Tell(int index, bool utter)
    {
        // customers only answer questions
        throw new System.NotImplementedException();
    }
}
