using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenary : MonoBehaviour
{
    public Plant[] plants, refPlants;
    public Collection collection; 

    void Start()
    {
        NewGame();
    }
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if(Input.GetMouseButton(0))
        {
            foreach(Plant plant in plants)
            {
                if(plant.selected)
                {
                    if(collection.IsNeeded(plant.plantName))
                    {
                        collection.AddPlant(plant);
                        plant.TurnOff();
                    }
                    break;
                }
            }
        }
    }

    public void NewGame()
    {
        foreach(Plant plant in plants)
            plant.NewEmpty();

        int n, limit=0;
        bool aplied;
        foreach(Plant refPlant in refPlants)
        {
            aplied = false;
            do{
                limit++;
                n = Random.Range(0, plants.Length);
                if(string.Equals(plants[n].plantName,"empty"))
                {
                    plants[n].SetValuesFrom(refPlant);
                    aplied = true;
                }
            }while(!aplied && limit<1000);
        }

        foreach(Plant refPlant in refPlants)
        {
            aplied = false;
            do{
                limit++;
                n = Random.Range(0, plants.Length);
                if(string.Equals(plants[n].plantName,"empty"))
                {
                    plants[n].SetValuesFrom(refPlant);
                    aplied = true;
                }
            }while(!aplied && limit<1000);
        }

        foreach(Plant plant in plants)
        {
            if(string.Equals(plant.plantName,"empty"))
            {
                plant.SetValuesFrom(refPlants[0]);
            }
            plant.SetCollision(true);
            plant.ShowSprite();
        }

    }

}
