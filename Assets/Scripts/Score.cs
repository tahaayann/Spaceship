using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public float score = 0;

    public void Start()
    {
        score = 0;
    }

    public void Update()
    {
        scoreText.text = "SCORE " + score.ToString();
    }
}
