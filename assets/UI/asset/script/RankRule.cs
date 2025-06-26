using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankRule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject ShowRankRule;
    public void Showrule()
    {
        ShowRankRule.SetActive(true);
    }
    public void Unshowrule()
    {
        ShowRankRule.SetActive(false);
    }
    public void Togglerule()
    {
        ShowRankRule.SetActive(!ShowRankRule.activeSelf);
    }
}
