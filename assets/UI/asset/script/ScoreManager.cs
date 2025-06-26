using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;


    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        rating = PlayerPrefs.GetInt("rating", 0);
        string MyRank = PlayerPrefs.GetString("rank", "Bronze");
        PlayerRank = (Rank)System.Enum.Parse(typeof(Rank), MyRank);
        continuous = PlayerPrefs.GetInt("continue", 0);

        ShowRatingRank();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum Rank
    {
        Bronze,
        Silver,
        Gold,
        Platinum,
        Diamond,
        Master,
        Challenger,
        Absolute,
        Unlimited

    }

    public int rating = 0;
    public int continuous = 0;
    public Rank PlayerRank = Rank.Bronze;

    public TMP_Text ShowRating;
    public TMP_Text ShowRank;
    public TMP_Text conwin;

    public void RatingUp()
    {
        continuous += 1;
        int rand = Random.Range(20, 31);
        rating += (rand + continuous);

        CheckRank();

    }
    public void RatingDown()
    {
        continuous = 0;
        int rand = Random.Range(15, 20);
        rating -= rand;

        CheckRank();

    }
    public void CheckRank()
    {
        if (rating < 100)
        {
            PlayerRank = Rank.Bronze;
        }
        else if (rating < 300)
        {
            PlayerRank = Rank.Silver;
        }
        else if (rating < 600)
        {
            PlayerRank = Rank.Gold;
        }
        else if (rating < 1000)
        {
            PlayerRank = Rank.Platinum;
        }
        else if (rating < 1500)
        {
            PlayerRank = Rank.Diamond;
        }
        else if (rating < 2100)
        {
            PlayerRank = Rank.Master;
        }
        else if (rating < 2800)
        {
            PlayerRank = Rank.Challenger;
        }
        else if (rating < 3600)
        {
            PlayerRank = Rank.Absolute;
        }
        else
        {
            PlayerRank = Rank.Unlimited;
        }
    }

    public void ShowRatingRank()
    {

        if (ShowRating == null || ShowRank == null)
        {
            Debug.LogWarning("no link");
            return;
        }

        ShowRating.text = $"·¹ÀÌÆÃ : {rating}";
        ShowRank.text = $"·©Å© : {PlayerRank}";
        conwin.text = $"¿¬½Â : {continuous}";
    }






    public void SaveRatingRank()
    {
        PlayerPrefs.SetInt("rating", rating);
        PlayerPrefs.SetString("rank", PlayerRank.ToString());
        PlayerPrefs.SetInt("continue", continuous);
    }






}
