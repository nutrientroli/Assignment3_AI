using UnityEngine;

public class ANITAs_BLACKBOARD : MonoBehaviour, IDialogSystem
{
    public int peaches = 2;
    public int apples = 1;

    private TextMesh utteranceLine;
    private TextMesh peachLine, appleLine;
    private IDialogSystem partner;

    public string[] utterances =
    {
        "unused utterance", // 0
        "unused utterance",
        "unused utterance",  // 2
        "unused utterance", // 3
        "unused utterance",
        "unused utterance",//5
        "unused utterance",//6
        "unused utterance",
        "unused utterance",//8
        "unused utterance",//9
        "It seems there's\na customer",
        "How can I help you\ndear customer?",//11
        "Oh, I'm sorry\nwe do not sell that", // 12
        "Yes, well sell that!",
        "Here you have!!!\nEnjoy it!", // 14
        "What a pity!!!\nNone left!",
        "Waiting for a customer..." // 16
    };
    
   
    void Start()
    {
        utteranceLine = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        peachLine = GameObject.Find("PEACH").transform.GetChild(0).GetComponent<TextMesh>();
        appleLine = GameObject.Find("APPLE").transform.GetChild(0).GetComponent<TextMesh>();

        peachLine.text = "x " + peaches;
        appleLine.text = "x " + apples;
    }

    public bool CheckExistences(string item)
    {
        if (item == "APPLE") return apples > 0;
        if (item == "PEACH") return peaches > 0;
        return false;
    }

    public bool Sell(string item)
    {
        if (!CheckExistences(item)) return false;

        switch (item)
        {
            case "APPLE": apples--; appleLine.text = "x " + apples; return true;
            case "PEACH": peaches--; peachLine.text = "x " + peaches; return true;
            default: return false;
        }
    }

    public void SetUtterance (int index)
    {
        utteranceLine.text = utterances[index];
    }

    public void ClearUtterance ()
    {
        utteranceLine.text = "";
    }

    public string BeAsked(string question)
    {
        // Anita is not suposed to receive direct questions
        return "??";
    }

    public bool EngageInDialog(IDialogSystem partner)
    {
        // you want to engage with someone? Use this method
        if (partner.BeEngagedInDialog(this))
        {
            this.partner = partner;
            return true;
        }
        return false; // returning false means partner has refused.
    }

    public bool BeEngagedInDialog(IDialogSystem partner)
    {
        // Anita is not supposed to be asked to engage. She'll take initiative.
        throw new System.NotImplementedException();
    }

    public void BeDisengagedFromDialog()
    {
        // Anita is not supposed to be asked to disengage. She'll take initiative.
        throw new System.NotImplementedException();
    }

    public void DisengageFromDialog()
    {
        if (partner != null)
            partner.BeDisengagedFromDialog();
        partner = null;
    }

    public bool IsEngagedInDialog()
    {
        // Anita does not need this. By the time being
        throw new System.NotImplementedException();
    }



    public string Ask(int index, bool utter)
    {
        if (partner==null)
        {
            Debug.Log("Cannot ask since no partner known");
            return null;
        }
        else
        {
            if (utter) SetUtterance(index);
            return partner.BeAsked(utterances[index]);
        }
    }

    public bool Tell(int index, bool utter)
    {
        if (partner == null)
        {
            Debug.Log("Cannot ask since no partner known");
            return false;
        }
        else
        {
            if (utter) SetUtterance(index);
            partner.BeTold(utterances[index]);
            return true;
        }

    }

    public void BeTold(string sentence)
    {
        throw new System.NotImplementedException();
    }
}
