using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericUI : MonoBehaviour
{
    [Tooltip("Label when the player wins.")]
    public GameObject winnerLabel;
    [Tooltip("Label when the player looses.")]
    public GameObject looserLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        // Hide labels.
        this.winnerLabel.SetActive(false);
        this.looserLabel.SetActive(false);
        
        // Events listeners
        GameController.Instance.OnCheckResultEvent += ShowResult;
    }

    // Show if the labels "Winner" or "Looser".
    void ShowResult(bool isWon)
    {
        // If the player won the game
        if (isWon)
        {
            this.winnerLabel.SetActive(true);
            this.looserLabel.SetActive(false);
        }
        else
        {
            this.winnerLabel.SetActive(false);
            this.looserLabel.SetActive(true);
        }
            
    }
}
