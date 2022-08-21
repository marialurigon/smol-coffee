using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public Plant[] greenhouse;

    public int actualMission, limitOfMissions;

    public AudioClip healSound, cleanSound, strongSound;

    public Request[] requests;
    public Mission[] missionList;

    void Start()
    {
        actualMission = 0;
        EmptyCollection();
        SetMission();
    }

    public void EmptyCollection()
    {
        foreach(Plant plant in greenhouse)
        {
            plant.NewEmpty();
            plant.ShowSprite();
        }
            
    }

    public void AddPlant(Plant plant)
    {
        foreach(Request req in requests)
        {
            if((req.plantName == plant.plantName) && (!req.complete))
            {
                req.Obtain();

                if(plant.plantType == "Curativa")
                    AudioManager.instance.Play(healSound);
                else if(plant.plantType == "Limpeza")
                    AudioManager.instance.Play(cleanSound);
                else if(plant.plantType == "Força")
                    AudioManager.instance.Play(strongSound);

                break;
            }
        }

        foreach(Plant vase in greenhouse)
        if(vase.plantName == plant.plantName)
            return;

        foreach(Plant empty in greenhouse)
        if(empty.plantName == "empty")
        {
            empty.SetValuesFrom(plant);
            break;
        }
    }

    public void ShowCollection()
    {
        foreach(Plant vase in greenhouse)
            vase.ShowSprite();
    }

    public void SetMission()
    {
        for(int i = 0; i<3;i++)
        {
            string name = missionList[actualMission].requests[i].plantName;
            int quantity = missionList[actualMission].requests[i].quantity;
            Sprite image = missionList[actualMission].requests[i].image;
            requests[i].NewMission(name, quantity, image);
        }
    }

    public bool IsMissionComplete()
    {
        foreach(Request request in requests)
        {
            if(!request.complete)
                return false;
        }
        return true;
    }

    public bool IsNeeded(string plantName)
    {
        foreach(Request req in requests)
        {
            if((req.plantName == plantName) && (!req.complete))
                return true;
        }
        return false;
    }

    public void ReviewMission()
    {
        if(IsMissionComplete())
        {
            if(actualMission<(limitOfMissions-1))
            {
                actualMission++;
                SetMission();
            }
            else
            {
                //Ganhou o jogo
            }
        }
    }
}

[System.Serializable]
public class VirtualRequest
{
    public string plantName;
    public int quantity;

    public Sprite image;
}

[System.Serializable]
public class Mission
{
    public VirtualRequest[] requests;
}
