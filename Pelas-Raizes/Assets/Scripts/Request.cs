using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//pra image
using TMPro;//pra text mash pro

public class Request : MonoBehaviour
{
    public string plantName;
    public int needed, obtained;
    public bool complete;
    public Sprite plantImage;

    public void NewMission(string name, int need, Sprite image)
    {
        plantName = name;
        needed = need;
        obtained = 0;
        complete = false;
        plantImage = image;
        GetComponentInChildren<Image>().sprite = image;
        UpdateText();
    }

    public void Obtain()
    {
        obtained++;
        if(obtained>=needed)
            complete = true;
        UpdateText();
    }

    public void UpdateText()
    {
        GetComponentInChildren<TMP_Text>().text = obtained+"/"+needed;
    }
}
