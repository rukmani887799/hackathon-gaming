using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthPath : MonoBehaviour
{

    public Button centerB;
    public Text centerT;
    public Text textfield;
    public Button leftB;
    public Button rightB;
    public Text GoodBad;
    public Text rightT;
    public Text leftT;
    public int value;
    static int counter = 0;
    public Text stats;
    static int time = 0;
    static int followers = 0;
    static int money = 0;
    static int impact = 0;
    static int XXXcounter = 0;
    static int XXXscore = 0;
    static int lobbyScore = 0;
    static int volScore = 0;
    static int socialScore = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    /*
     * center: 0
     * left: 1
     * right: 2
     */
    public void press()
    {
        stats.gameObject.SetActive(true);
        updateStats();

        counter = counter + value;
        Debug.Log("value: " + value);
        Debug.Log("counter: " + counter);
        switch (counter)
        {
            case 0:
                textfield.text = "What do you want to do?";
                if (GoodBad.text.Equals("bad"))
                {
                    centerT.text = "Research";
                    counter++;
                }
                else if (GoodBad.text.Equals("good"))
                {
                    centerB.gameObject.SetActive(false);
                    leftB.gameObject.SetActive(true);
                    rightB.gameObject.SetActive(true);
                    leftT.text = "Research";
                    rightT.text = "Talk to XXX";
                }
                else
                {
                    textfield.text = "ERROR: EarthPath, press(), case 0 in switch, GoodBad is neither \"good\" nor \"bad\"";
                }
                break;
            case 1: //Research lvl 1
                textfield.text = "You research and learn that there are three main ways to help." +
                    "\nWhat area would you like to start with?";
                centerB.gameObject.SetActive(true);
                leftB.gameObject.SetActive(true);
                rightB.gameObject.SetActive(true);
                centerT.text = "Social";
                rightT.text = "Volunteer";
                leftT.text = "Lobby";
                time++;
                updateStats();
                counter = 3;
                break;
            case 2: //Talk to XXX lvl 1
            case 501:
            case 502:
            case 503:
                int boo = talkToXXX(value);
                if (boo == -1) // not finished
                {
                    counter = counter - value;
                    counter = 500;
                } else if (boo == 0) // bad
                {
                    counter = 0;
                    GoodBad.text = "bad";
                    break;
                } else
                {
                    if (counter != 503)
                    {
                        counter = 503;
                    } else
                    {
                        counter = 3;
                        textfield.text = "What area would you like to start with?";
                        centerB.gameObject.SetActive(true);
                        leftB.gameObject.SetActive(true);
                        rightB.gameObject.SetActive(true);
                        centerT.text = "Social";
                        rightT.text = "Volunteer";
                        leftT.text = "Lobby";
                    }
                }
                break;
            case 3: // Social
                social();
                break;
            case 4: // Lobby
                lobby();
                break;
            case 5: // Volunteer
                volunteer();
                break;
            case 6:
                if (time > 11)
                {
                    textfield.text = "Oh no! Your effects took too long and the Earth is no longer habitable.\n" +
                        "Better luck next time!";
                    centerT.text = "End Game";
                } else { 
                    counter = 3;
                    textfield.text = "What area would you like to work on?";
                    centerB.gameObject.SetActive(true);
                    leftB.gameObject.SetActive(true);
                    rightB.gameObject.SetActive(true);
                    centerT.text = "Social";
                    rightT.text = "Volunteer";
                    leftT.text = "Lobby";
                }
                break;
            default:
                textfield.text = "ERROR, EarthPath, press(), default in switch";
                break;
        }

    }

    void social()
    {
        centerB.gameObject.SetActive(true);
        leftB.gameObject.SetActive(false);
        rightB.gameObject.SetActive(false);
        centerT.text = "Next";
        textfield.text = "You make a change.org petition.\nIt gets 100 signatures!";
        time++;
        followers = followers + 100;
        socialScore++;
        counter = 6;
        updateStats();
    }

    void lobby()
    {
        centerB.gameObject.SetActive(true);
        leftB.gameObject.SetActive(false);
        rightB.gameObject.SetActive(false);
        centerT.text = "Next";
        textfield.text = "You write an article about pollution caused by corporations.\nIt gets the attention of multiple companies who donate money to your cause.";
        time++;
        money = money + 5;
        lobbyScore++;
        counter = 6;
        updateStats();
    }

    void volunteer()
    {
        centerB.gameObject.SetActive(true);
        leftB.gameObject.SetActive(false);
        rightB.gameObject.SetActive(false);
        centerT.text = "Next";
        textfield.text = "You organize an event to plant trees in your neigborhood.";
        time++;
        impact = impact + 5;
        volScore++;
        counter = 6;
        updateStats();
    }

    void updateStats()
    {
        stats.text = "Statistics\n--------------------\n" +
            "Time passed: " + time + " months\nFollowers: " + followers
            + "\nMoney: $" + money + "k\nImpact: " + impact + "%";
    }
    
    int talkToXXX(int value)
    {
        textfield.text = "XXX: Hello!";
        int boo = -1; // -1: not finished, 0: bad, 1: good

        XXXcounter = XXXcounter + value;
        Debug.Log("XXXcounter: " + XXXcounter);
        switch(XXXcounter)
        {
            case 2: // lvl 0
                centerB.gameObject.SetActive(false);
                leftB.gameObject.SetActive(true);
                rightB.gameObject.SetActive(true);
                rightT.text = "Hi, the Scientist told me you could help me!";
                leftT.text = "You look homeless.";
                break;
            case 3: // "You look homeless." lvl 1
                textfield.text = "XXX: I assure you I'm not homeless...";
                XXXscore = XXXscore - 10;
                leftT.text = "Are you are even a scientist?";
                rightT.text = "Anyways, how can I help the environment?";
                XXXcounter++;
                break;
            case 4: // "Hi, the Scientist told me you could help me!" lvl 1
                textfield.text = "XXX: Of course I can! How can I help?";
                XXXscore = XXXscore + 15;
                leftT.text = "You sure you know what you're talking about?";
                rightT.text = "How can I help the environment?";
                break;
            case 5: // "...even a scientist?"/"...you're talking about?" lvl 2
                XXXscore = XXXscore - 10;
                if (XXXscore < 0)
                {
                    textfield.text = "XXX: Yes, of course! I didn't spend 8 years in college for nothing!\n" +
                    "I can see that we do not get along. Have a nice day.";
                    boo = 0;
                    centerB.gameObject.SetActive(true);
                    leftB.gameObject.SetActive(false);
                    rightB.gameObject.SetActive(false);
                    centerT.text = "Next";
                } else
                {
                    textfield.text = "XXX: Yes, of course! I didn't spend 8 years in college for nothing!\n" +
                        "Anyways, you can either do blah blah blah. Have a good day.";
                    centerB.gameObject.SetActive(true);
                    leftB.gameObject.SetActive(false);
                    rightB.gameObject.SetActive(false);
                    centerT.text = "Next";
                    boo = 1;
                }
                break;
            case 6: // "...help the environment?" lvl 2
                XXXscore = XXXscore + 15;
                if (XXXscore < 0)
                {
                    textfield.text = "XXX: You know, I think you would do better off doing your own research. Have a nice day.";
                    boo = 0;
                    centerB.gameObject.SetActive(true);
                    leftB.gameObject.SetActive(false);
                    rightB.gameObject.SetActive(false);
                    centerT.text = "Next";
                }
                else
                {
                    textfield.text = "XXX: You can either do blah blah blah. I hope that helps!";
                    centerB.gameObject.SetActive(true);
                    leftB.gameObject.SetActive(false);
                    rightB.gameObject.SetActive(false);
                    centerT.text = "Next";
                    boo = 1;
                }
                break;
            default:
                textfield.text = "ERROR: EarthPath, talkToXXX, default in switch";
                break;
        }

        return boo;
    }

}
