using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private int cash = 0;

    private void Start()
    {
        AddCash(0);
    }

    public void AddCash(int cashAdded)
    {
        cash += cashAdded;
        scoreText.text = "Cash: " + cash;
    }
}
