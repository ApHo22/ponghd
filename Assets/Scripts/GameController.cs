using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Text scoreTextBlue;
    public Text scoreTextRed;

    private bool started = false;

    private int scoreBlue = 0;
    private int scoreRed = 0;

   private BallController ballController;

   private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.started)
        return;

        if(Input.GetKey(KeyCode.Space)){
            this.started = true;
            this.ballController.Go();
        }
    }

    public void ScoreGoalBlue(){
        Debug.Log("ScoreGoalBlue");
        this.scoreRed += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRed(){
        Debug.Log("ScoreGoalRed");
        this.scoreBlue += 1;
        UpdateUI();
        ResetBall();
    }
    private void UpdateUI(){
        this.scoreTextBlue.text = this.scoreBlue.ToString();
        this.scoreTextRed.text = this.scoreRed.ToString();
    }

    private void ResetBall(){
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.ballController.Go();
    }
}
