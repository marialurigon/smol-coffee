using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Deslizar Fixo")]
    public float distance;
    public float slideSpeed, targetPosition;

    [Header("Mover pelas bordas")]
    public float moveSpeed;
    public float border, limit;
    public bool moving;

    [Header("Posições para Mover")]
    public Vector3 menuPosition;
    public Vector3 cutscenePosition;
    public Vector3 insidePosition;
    public Vector3 outsidePosition;
    public bool movable;

    void Start()
    {
        moving = false;
        movable = false;
    }

    void Update()
    {
        GetInput();
    }



    public void GetInput()
    {
        if(Input.mousePosition.x<= border)
            MoveLeft();
        else if(Input.mousePosition.x>=(Screen.width-border))
            MoveRight();
    }

    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }

    public void MoveToMenu()
    {
        MoveTo(menuPosition);
    }

    public void MoveToCutscene()
    {
        MoveTo(cutscenePosition);
    }

    public void MoveToInside()
    {
        MoveTo(insidePosition);
    }

    public void MoveToOutsidee()
    {
        MoveTo(outsidePosition);
    }

    public void MoveLeft()
    {
        if(movable)
        {
            float newX = transform.position.x - (moveSpeed * Time.deltaTime);
            if (newX<-limit)
                newX = -limit;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    public void MoveRight()
    {
        if(movable)
        {
            float newX = transform.position.x + (moveSpeed * Time.deltaTime);
            if (newX>limit)
                newX = limit;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        
    }

    public void SlideLeft()
    {
        if(!moving)
        {
            moving = true;
            targetPosition = transform.position.x - distance;
            StartCoroutine(Slide(-1));
        }
        
    }

    public void SlideRight()
    {
        if(!moving)
        {
            moving = true;
            targetPosition = transform.position.x + distance;
            StartCoroutine(Slide(1));
        }
    }

    public void SetMovable(bool boolean)
    {
        movable = boolean;
    }


    public IEnumerator Slide(int direction)
    {
        while(true)
        {
            if(moving)
            {
                float newX = transform.position.x + (slideSpeed * direction);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);

                float distance = 0;

                if(direction>0)
                    distance = targetPosition-transform.position.x;
                else if(direction<0)
                    distance = transform.position.x-targetPosition;

                if(distance <= 0.05f)
                {
                    transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
                    moving = false;
                }
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
