using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text resultText; 
    GameObject player;
    Vector3 orizinPosition;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.fontSize = 140;
        player = GameObject.FindWithTag("Player");
        orizinPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        score = player.transform.position.x - orizinPosition.x;
        scoreText.text ="キョリ : " + (int)score;
        resultText.text = score.ToString("F0");
    }
}
