using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeepEnd : MonoBehaviour
{
    Text ScoreDisplay;
    Text ScoreText;
    ScoreKeep SK;
    public GameObject ScoreQuote;
    private void Start()
    {
        SK = GameObject.Find("RockCountText").GetComponent<ScoreKeep>();
        ScoreDisplay = GetComponent<Text>();
        ScoreText = ScoreQuote.GetComponent<Text>();
    }
    void Update()
    {
        ScoreDisplay.text = "x" + SK.RockCount.ToString();
        if (SK.RockCount == 0)
        {
            ScoreText.text = "\"That's... honestly impressive.\"";
        }
        else if (SK.RockCount > 0 && SK.RockCount <= 15)
        {
            ScoreText.text = "\"A barely gnomeiceable blast.\"";
        }
        else if (SK.RockCount > 70 && SK.RockCount <= 85)
        {
            ScoreText.text = "\"A gnominal payload, they oughta feel that!\"";
        }
        else if (SK.RockCount > 85 && SK.RockCount <= 90)
        {
            ScoreText.text = "\"Gnomearly Perfect, keep at it!\"";
        }
        else if (SK.RockCount == 91)
        {
            ScoreText.text = "\"TOTAL GNOMECULAR DEVASTATION!!!\"";
        }
        else
        {
            ScoreText.text = "\"A pretty gnormal result.\"";
        }

    }

}
