using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveEarth : MonoBehaviour
{
    public Button goodB;
    public Button badB;
    public Button centerB;
    public Text textfield;
    public int value;
    static int counter = 0;
    static int score = 0;
    public Text goodT;
    public Text badT;
    public Text centerT;
    public Text GoodBad;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setTest(string text)
    {
        textfield.text = text;
    }

    public void press()
    {

        counter = counter + value;
        Debug.Log("counter: " + counter);

        switch (counter)
        {
            case 0: // "I think your idea is stupid." lvl 1
                setTest("Scientist: That's not a very nice thing to say." +
                    "\nRegardless, it is much more practical because blah blah blah.");
                badT.text = "Is it really though?";
                goodT.text = "Are you concerned by any roadblocks?";
                score = score - 10;
                counter = counter + 2;
                break;
            case 1: // "You are a genius." lvl 1
                setTest("Scientist: Great minds think alike." +
                    "\nClearly finding a new planet is more practical...");
                badT.text = "Is it really though?";
                goodT.text = "What are the potential roadblocks?";
                score = score + 15;
                counter++;
                break;
            case 2: // "Is it really though?" lvl 2
                setTest("Scientist: Well, I am a highly respected scientist, so I believe so, yes." +
                    "\nNo doubt blank is an issue, but I believe the benefits outway the risks.");
                badT.text = "No need to get your panties in a twist.";
                goodT.text = "My apologies.";
                score = score - 10;
                counter = counter + 2;
                break;
            case 3: // "... difficulties your plan may face?" lvl 2
                setTest("Scientist: Yes, of course. blah blah blah");
                badT.text = "Wow I can't believe you hate the Earth.";
                goodT.text = "Hmm definately a tricky situation we're in.";
                score = score + 15;
                counter++;
                break;
            case 4: // lvl 3
            case 5:
                setTest("Scientist: So what do you think you're going to do to help?");
                badT.text = "Save the Earth";
                goodT.text = "Find a new planet";
                counter = 6;
                break;
            case 6: //"Save the Earth" lvl 4
                if (score < 0)
                {
                    setTest("Scientist: Well, good luck with that.");
                } else
                {
                    setTest("Scientist: Well, I wish you luck! You should talk to XXX, they might be able to help you.");
                }
                goodB.gameObject.SetActive(false);
                badB.gameObject.SetActive(false);
                centerB.gameObject.SetActive(true);
                break;
            case 7: //"Find a new planet" lvl 4
                if (score < 0)
                {
                    setTest("Scientist: Well at least you're not a complete idiot.");
                } else
                {
                    setTest("Scientist: Great! I'm exicted to work together.");
                }
                goodB.gameObject.SetActive(false);
                badB.gameObject.SetActive(false);
                centerB.gameObject.SetActive(true);
                centerT.text = "ERROR: path ends here (not coded yet)";
                break;
            default:
                setTest("ERROR, SaveEarth, press(), default in switch");
                break;
        }
        Debug.Log("score: " + score);
        if (score < 0)
        {
            GoodBad.text = "bad";
        } else
        {
            GoodBad.text = "good";
        }
    }

}
