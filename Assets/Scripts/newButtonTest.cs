using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newButtonTest : MonoBehaviour
{

    public Text textfield;
    public Button badB;
    public Button goodB;
    public Button startB;
    public Text buttonT;
    public Button button4;
    int counter = 0;
    public Text GoodBad;
    public Button researchB;
    public Button XXXB;
    public Text stats;
    public Image background;
    public Image labImage;
    public Image spaceImage;
    public Image whiteImage;

    void Start()
    {
        textfield.gameObject.SetActive(false);
        goodB.gameObject.SetActive(false);
        badB.gameObject.SetActive(false);
        button4.gameObject.SetActive(false);
        GoodBad.gameObject.SetActive(false);
        XXXB.gameObject.SetActive(false);
        researchB.gameObject.SetActive(false);
        stats.gameObject.SetActive(false);
        labImage.gameObject.SetActive(false);
        spaceImage.gameObject.SetActive(false);
        whiteImage.gameObject.SetActive(false);
    }

    public void setTest(string text)
    {
        textfield.text = text;
    }

    public void showText()
    {
        textfield.gameObject.SetActive(true);
        buttonT.text = "Next(Button)";

        switch (counter)
        {
            case 0:
                setTest("Pollution is destroying the Earth!\nYou want to help, but how?");
                counter++;
                break;
            case 1:
                setTest("You are friends with a well-known scientist! Maybe they know what to do?");
                counter++;
                break;
            case 2:
                startB.gameObject.SetActive(false);
                goodB.gameObject.SetActive(true);
                badB.gameObject.SetActive(true);

                background.sprite = labImage.sprite;
                whiteImage.gameObject.SetActive(true);
                textfield.color = new Color(0, 0, 0, 255);

                setTest("You: I want to see if I can save this world.\n" +
                    "Scientist: I don't think we can save this world. I'm going to build a ship and find a new planet.");
                break;
            default:
                setTest("ERROR: newButtonTest, showText(), deault case in switch");
                break;
        }
    }

}
