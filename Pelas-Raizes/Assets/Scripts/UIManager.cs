using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Areas do Canvas")]
    public GameObject menuScreen;
    public GameObject cutsceneScreen;
    public GameObject insideScreen;
    public GameObject outsideScreen;
    public GameObject dialogueScreen;
    public GameObject pauseScreen;

    void Start()
    {
        HideAll();
        ShowInside(true);//mudar
    }
    public void HideAll()
    {
        menuScreen.SetActive(false);
        cutsceneScreen.SetActive(false);
        insideScreen.SetActive(false);
        outsideScreen.SetActive(false);
        pauseScreen.SetActive(false);
        dialogueScreen.SetActive(false);
        
    }

    public void ShowMenu(bool active)
    {
        menuScreen.SetActive(active);
    }

    public void ShowCutscene(bool active)
    {
        cutsceneScreen.SetActive(active);
    }
    public void ShowInside(bool active)
    {
        insideScreen.SetActive(active);
    }

    public void ShowOutside(bool active)
    {
        outsideScreen.SetActive(active);
    }
    public void ShowDialogue(bool active)
    {
        dialogueScreen.SetActive(active);
    }

    public void ShowPause(bool active)
    {
        pauseScreen.SetActive(active);
    }
    
}
