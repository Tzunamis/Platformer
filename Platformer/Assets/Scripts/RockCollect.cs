using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollect : MonoBehaviour
{
    ScoreKeep SK;

    private void Start()
    {
        SK = GameObject.Find("RockCountText").GetComponent<ScoreKeep>();
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.name == "Player")
        {
            SK.RockCount++;
            Debug.Log(SK.RockCount);
            Destroy(gameObject);
        }
    }
}
