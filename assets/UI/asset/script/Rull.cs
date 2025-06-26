using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rull : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Rule;
    public void Showrule()
    {
        Rule.SetActive(true);
    }
    public void Unshowrule()
    {
        Rule.SetActive(false);
    }
    public void Togglerule()
    {
        Rule.SetActive(!Rule.activeSelf);
    }
}
