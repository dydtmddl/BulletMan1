using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public struct EnemyAction
{
    public actiontype enemyaction;
    public int weight;

    public EnemyAction(actiontype enemyaction, int weight)
    {
        this.enemyaction = enemyaction;
        this.weight = weight;
    }
}






public class enemycontroller : MonoBehaviour
{

    public actiontype selectedaction = actiontype.none;

    public int enemybullet = 0;

    public int enemyhealth = 3;

    public Image player2;
    public Sprite defaultSprite,
        loadSprite,
        shootSprite,
        guardSprite,
        gasSprite,
        maskSprite,
        winSprite,
        lossSprite;







    private actiontype EnemyActionMoving(List<EnemyAction> enemyActions)
    {
        int total = 0;
        foreach (var c in enemyActions) total += c.weight;

        int rand = Random.Range(1, total + 1);
        int sum = 0;

        foreach (var c in enemyActions)
        {
            sum += c.weight;
            if (rand <= sum)
            {
                return c.enemyaction;
            }
        }

        return actiontype.none;
    }

    

    public void decideaction()
    {
        int player1 = Gamemaneger.Instance.player.playerbullet;
        List<EnemyAction> enemyActions = new List<EnemyAction>();



        if (Gamemaneger.Instance.turn == 1)
        {
            selectedaction = actiontype.load;
        }
        else
        {
            if (enemybullet == 0 && player1 == 0)
            {
                enemyActions.Add(new EnemyAction(actiontype.load, 100));
            }
            else if( enemybullet == 0 && player1 > 0)
            {
                enemyActions.Add(new EnemyAction(actiontype.load, 50));
                enemyActions.Add(new EnemyAction(actiontype.guard, 50));
            }
            else if(enemybullet == 0 && player1 >= 3)
            {
                enemyActions.Add(new EnemyAction(actiontype.load, 20));
                enemyActions.Add(new EnemyAction(actiontype.guard, 40));
                enemyActions.Add(new EnemyAction(actiontype.gasmask, 40));
            }
            else if(enemybullet < 3 && player1 <3)
            {
                enemyActions.Add(new EnemyAction(actiontype.load,35));
                enemyActions.Add(new EnemyAction(actiontype.guard, 30));
                enemyActions.Add(new EnemyAction(actiontype.shoot, 35));
            }
            else if(enemybullet <3 && player1 >= 3)
            {
                enemyActions.Add(new EnemyAction(actiontype.load, 10));
                enemyActions.Add(new EnemyAction(actiontype.guard, 25));
                enemyActions.Add(new EnemyAction(actiontype.shoot, 35));
                enemyActions.Add(new EnemyAction(actiontype.gasmask, 30));
            }
            else if(enemybullet >= 3 && player1 < 3)
            {
                enemyActions.Add(new EnemyAction(actiontype.load, 10));
                enemyActions.Add(new EnemyAction(actiontype.guard, 20));
                enemyActions.Add(new EnemyAction(actiontype.shoot, 35));
                enemyActions.Add(new EnemyAction(actiontype.gas, 35));
            }
            else if(enemybullet >= 3 && player1 >= 3){
                enemyActions.Add(new EnemyAction(actiontype.load, 5));
                enemyActions.Add(new EnemyAction(actiontype.guard, 20));
                enemyActions.Add(new EnemyAction(actiontype.shoot, 40));
                enemyActions.Add(new EnemyAction(actiontype.gas, 15));
                enemyActions.Add(new EnemyAction(actiontype.gasmask, 20));
            }

            selectedaction = EnemyActionMoving(enemyActions);
        }

       
        if(ScoreManager.Instance.PlayerRank == ScoreManager.Rank.Bronze)
        {
            if (selectedaction == actiontype.load)
                enemybullet++;
            if (selectedaction == actiontype.shoot)
                enemybullet--;
            if (selectedaction == actiontype.gas)
                enemybullet = enemybullet - 3;
        }
        else if(ScoreManager.Instance.PlayerRank == ScoreManager.Rank.Gold)
        {
            if (selectedaction == actiontype.load)
            {
                int rand = Random.Range(1, 4);
                if(rand == 2)
                {
                    enemybullet++;
                    enemybullet++;
                }
                else
                {
                    enemybullet++;
                }
                
            }
                
            if (selectedaction == actiontype.shoot)
                enemybullet--;
            if (selectedaction == actiontype.gas)
                enemybullet = enemybullet - 3;
        }

        else if(ScoreManager.Instance.PlayerRank == ScoreManager.Rank.Platinum)
        {
            if (selectedaction == actiontype.load)
            {
                int rand = Random.Range(1, 4);
                if (rand == 2)
                {
                    enemybullet++;
                    enemybullet++;
                }
                else
                {
                    enemybullet++;
                }

            }

            if (selectedaction == actiontype.shoot)
            {
                int rand = Random.Range(1, 4);
                if (rand == 2)
                {
                    enemybullet--;
                    enemybullet++;
                }
                else
                {
                    enemybullet--;
                }
                
            }
            if (selectedaction == actiontype.gas)
                enemybullet = enemybullet - 3;
        }

        else if (ScoreManager.Instance.PlayerRank == ScoreManager.Rank.Diamond)
        {
            if (selectedaction == actiontype.load)
            {
                int rand = Random.Range(1, 4);
                if (rand == 2)
                {
                    enemybullet++;
                    enemybullet++;
                }
                else
                {
                    enemybullet++;
                }

            }

            if (selectedaction == actiontype.shoot)
            {
                int rand = Random.Range(1, 4);
                if (rand == 2)
                {
                    enemybullet--;
                    enemybullet++;
                }
                else
                {
                    enemybullet--;
                }

            }
            if (selectedaction == actiontype.gas)
            {
                int rand = Random.Range(1, 4);
                if(rand == 2)
                {
                    enemybullet = enemybullet - 2;
                }
                else
                {
                    enemybullet = enemybullet - 3;
                }
                
            }
        }

        else if (ScoreManager.Instance.PlayerRank == ScoreManager.Rank.Master)
        {
            if (selectedaction == actiontype.load)
            {
                int rand = Random.Range(1, 3);
                if (rand == 2)
                {
                    enemybullet++;
                    enemybullet++;
                }
                else
                {
                    enemybullet++;
                }

            }

            if (selectedaction == actiontype.shoot)
            {
                int rand = Random.Range(1, 3);
                if (rand == 2)
                {
                    enemybullet--;
                    enemybullet++;
                }
                else
                {
                    enemybullet--;
                }

            }
            if (selectedaction == actiontype.gas)
            {
                int rand = Random.Range(1, 3);
                if (rand == 2)
                {
                    enemybullet = enemybullet - 2;
                }
                else
                {
                    enemybullet = enemybullet - 3;
                }

            }
        }

        else if (ScoreManager.Instance.PlayerRank == ScoreManager.Rank.Challenger)
        {
            if (selectedaction == actiontype.load)
            {
                enemybullet++;
                enemybullet++;

            }

            if (selectedaction == actiontype.shoot)
            {
                enemybullet--;

            }
            if (selectedaction == actiontype.gas)
            {
                enemybullet = enemybullet - 1;

            }
        }

        else if (ScoreManager.Instance.PlayerRank == ScoreManager.Rank.Absolute)
        {
            if (selectedaction == actiontype.load)
            {
                enemybullet++;
                enemybullet++;

            }

            if (selectedaction == actiontype.shoot)
            {
                int rand = Random.Range(1, 3);
                if (rand == 2)
                {
                    enemybullet--;
                    enemybullet++;
                }
                else
                {
                    enemybullet--;
                }

            }
            if (selectedaction == actiontype.gas)
            {
                int rand = Random.Range(1, 3);
                if (rand == 2)
                {
                    enemybullet = enemybullet - 1;
                    enemybullet = enemybullet + 1;
                }
                else
                {
                    enemybullet = enemybullet - 3;
                }

            }
        }

        else if (ScoreManager.Instance.PlayerRank == ScoreManager.Rank.Unlimited)
        {
            if (selectedaction == actiontype.load)
            {
                int rand = Random.Range(1, 3);
                if (rand == 2)
                {
                    enemybullet++;
                    enemybullet++;
                    enemybullet++;
                }
                else
                {
                    enemybullet++;
                }

            }

            if (selectedaction == actiontype.shoot)
            {
                int rand = Random.Range(1, 3);
                if (rand == 2)
                {
                    enemybullet--;
                    enemybullet++;
                }
                else
                {
                    enemybullet--;
                }

            }
            if (selectedaction == actiontype.gas)
            {
                enemybullet = enemybullet - 1;

            }
        }

        Debug.Log("Àû Çàµ¿: " + selectedaction);

        switch (selectedaction)
        {
            case actiontype.load: player2.sprite = loadSprite; break;
            case actiontype.shoot: player2.sprite = shootSprite; break;
            case actiontype.guard: player2.sprite = guardSprite; break;
            case actiontype.gas: player2.sprite = gasSprite; break;
            case actiontype.gasmask: player2.sprite = maskSprite; break;
            default: player2.sprite = defaultSprite; break;

        }

        Invoke(nameof(resetsprite), 3.0f);
    }


    void resetsprite()
    {
        player2.sprite = defaultSprite;
    }
    public void setlossSprite()
    {
        player2.sprite = lossSprite;
        
    }
    public void setwinSprite()
    {
        player2.sprite = winSprite;
        
    }

}
