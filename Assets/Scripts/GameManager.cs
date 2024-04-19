using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreTextField;

    // Update is called once per frame
    void Update()
    {
        scoreTextField.text = "Score : " + score.ToString();
    }
    public void AddScore(){
        score++;
    }
}
