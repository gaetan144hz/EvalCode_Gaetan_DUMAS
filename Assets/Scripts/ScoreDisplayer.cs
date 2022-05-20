using System;
using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    public TextMeshProUGUI tmPro;
    private SnakeController _snakeController;

    private void Awake()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
    }

    public void SetScore(int score)
    {
        tmPro.text = score.ToString();
    }
}
