using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Gamemaneger : MonoBehaviour 
{
    public static Gamemaneger Instance;
    public playercontroller player;
    public enemycontroller enemy;

    public ScoreManager RatingStstem;

    public Button[] btns;
    public GameObject retrybutton;
    public GameObject Title;
    

    public int turn = 1; //턴 카운트


    
  


    public TMP_Text resultText; //결과 출력 텍스트변수
    public TMP_Text turncount;   // 턴 출력 텍스트변수
    public TMP_Text bulletcount1;
    public TMP_Text bulletcount2;
    public TMP_Text gameovertext;
    public TMP_Text phealth;
    public TMP_Text ehealth;
    

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameresultcheck()
    {
        if(player.playerhealth == 0)
        {
            RatingStstem.RatingDown();
            RatingStstem.SaveRatingRank();

            gameovertext.text = "패배하였습니다..";
            gameovertext.gameObject.SetActive(true);
            retrybutton.SetActive(true);
            Title.SetActive(true);

            player.setlossSprite();
            enemy.setwinSprite();
            

            
        }
        else if (enemy.enemyhealth == 0)
        {
            RatingStstem.RatingUp();
            RatingStstem.SaveRatingRank();

            gameovertext.text = "승리하였습니다!!";
            gameovertext.gameObject.SetActive(true);
            retrybutton.SetActive(true);
            Title.SetActive(true);

            player.setwinSprite();
            enemy.setlossSprite();
        }
    }


    public void buttonupdate()
    {
        btns[0].interactable = player.playerbullet > 0;
        btns[4].interactable = player.playerbullet >= 3;
    }



    public void showhealth()
    {
        phealth.text = $"현재 체력 :  {player.playerhealth}";
        ehealth.text = $"현재 체력 :  {enemy.enemyhealth}";

    }
    public void showbullet()
    {
        bulletcount1.text = $"playerbullet {player.playerbullet}";
        bulletcount2.text = $"enemybullet {enemy.enemybullet}";
    }
    

    public void showturn() //현재 턴 보여주는 함수
    {
        turncount.text = $"turn {turn}";

    }

    private void Awake()
    {
        Instance = this;
        showbullet();
        showhealth();
        buttonupdate();
        

        retrybutton.SetActive(false);
        Title.SetActive(false);
        gameovertext.gameObject.SetActive(false);

    }

    public void onplayeractionselected()
    {
        
        enemy.decideaction();
        showturn();
        resolveturn();
    }

    void resolveturn()
    {
        actiontype p = player.selectedaction;
        actiontype e = enemy.selectedaction;

        string result = $"player: {p}, enemy : {e} \n";

        if ((p == actiontype.shoot && e != actiontype.shoot && e != actiontype.guard && e != actiontype.gas) || (p == actiontype.gas && e != actiontype.gasmask && e !=actiontype.shoot && e != actiontype.gas))
        {


            result += "attack success!!";
            enemy.enemyhealth--;
        }
        else if ((p == actiontype.shoot && e == actiontype.guard) || (p == actiontype.gas && e == actiontype.gasmask))
            result += "attack fail!!";
        else if ((p == actiontype.guard && e == actiontype.shoot) || (p == actiontype.gasmask && e == actiontype.gas))
            result += "guard success!!";


        else if ((e == actiontype.shoot && p != actiontype.shoot && p != actiontype.guard && p != actiontype.gas) || (e == actiontype.gas && p != actiontype.gasmask && p != actiontype.shoot && p != actiontype.gas))
        {


            result += "you attcked!!";
            player.playerhealth--;
        }
        
        
        else
            result += "draw!!! ";

        resultText.text = result;

        turn++;


        showbullet();
        buttonupdate();
        showhealth();
        gameresultcheck();


        
    }



    public void GoTitle()
    {
        SceneManager.LoadScene("Titlescene");
    }
    

    
}

