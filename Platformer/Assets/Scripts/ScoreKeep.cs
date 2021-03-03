using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeep : MonoBehaviour
{
    public int RockCount;
    Text ScoreDisplay;
    private void Start()
    {
        ScoreDisplay = GetComponent<Text>();
    }
    private void Update()
    {
        ScoreDisplay.text = "x" + RockCount.ToString();
    }

}
