using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeathScoreDisplay : MonoBehaviour
{
    public GameController gameController;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        string score = gameController
                        .GetComponent<GameController>()
                        .bugsExterminated
                        .ToString();
        txt.text = "Your Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
