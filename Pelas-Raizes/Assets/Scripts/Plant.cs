using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public Sprite image, cardImage;
    public string plantType, plantName, description;
    public bool selected;

    void OnMouseOver()
    {
        selected = true;
    }
    
    void OnMouseExit()
    {
        selected = false;
    }

    public void NewEmpty()
    {
        SetValues(null, null, "empty", "empty", "");
    }

    public void SetValuesFrom(Plant plant)
    {
        SetValues(plant.image, plant.cardImage, plant.plantType, plant.plantName, plant.description);
    }

    public void SetValues(Sprite image, Sprite cardImage,string plantType,string plantName,string description)
    {
        this.image = image;
        this.cardImage = cardImage;
        this.plantType = plantType;
        this.plantName = plantName;
        this.description = description;
    }

    public void TurnOff()
    {
        NewEmpty();
        ShowSprite();
        SetCollision(false);
        selected = false;
    }
    public void SetPosition(float x, float y)
    {
        transform.position = new Vector3(x, y, 1);
    }

    public void ShowSprite()
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public Sprite GetCard()
    {
        return cardImage;
    }
    
    public void SetCollision(bool boolean)
    {
        GetComponent<CircleCollider2D>().enabled = boolean;
    }
}
