using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class playercontroller : MonoBehaviour
{
    public actiontype selectedaction = actiontype.none;

    public int playerbullet = 0;

    public int playerhealth = 3;

    public Image player1;
    public Sprite defaultSprite,
        loadSprite,
        shootSprite,
        guardSprite,
        gasSprite,
        maskSprite,
        winSprite,
        lossSprite;

    

    
    public void selectaction(int action)
    {
        selectedaction = (actiontype)action;

        if (selectedaction == actiontype.load)
        {
            playerbullet++;
           
        }

        else if (selectedaction == actiontype.shoot)
        {
            playerbullet--;
            
        }
        else if (selectedaction == actiontype.gas)
        {
            playerbullet = playerbullet - 3;
            
        }


        switch (selectedaction)
        {
            case actiontype.load: player1.sprite = loadSprite; break;
            case actiontype.shoot: player1.sprite = shootSprite; break;
            case actiontype.guard: player1.sprite = guardSprite; break;
            case actiontype.gas: player1.sprite = gasSprite; break;
            case actiontype.gasmask: player1.sprite = maskSprite; break;
            default: player1.sprite = defaultSprite; break;

        }

        Invoke(nameof(resetsprite), 3.0f);




        Debug.Log("선택한 행동: " + selectedaction);

        if (Gamemaneger.Instance == null)
        {
            Debug.LogError("null입니다");
            return;
        }
        Gamemaneger.Instance.onplayeractionselected();


    }

    void resetsprite()
    {
        player1.sprite = defaultSprite;
    }
    public void setlossSprite()
    {
        player1.sprite = lossSprite;
       

    }
    public void setwinSprite()
    {
        player1.sprite = winSprite;
       
    }

   
}

