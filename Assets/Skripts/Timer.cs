using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public float countDownTimer = 5f;

    [Header("Things to stop")]
    public Player  player1;
    public Player player2;
    public Player player3;

    public OpponentCar opponentCar;
    public OpponentCar opponentCar1;
    public OpponentCar opponentCar2;
    public OpponentCar opponentCar3;
    public OpponentCar opponentCar4;

   

    [Header("Text Part")]
    public Text countDownText;
    public Text LetsGo;

    private void Start()
    {
        StartCoroutine(TimeCount());       
    }
    private void Update()
    {
        if (countDownTimer > 1)
        {
            player1.accelerationForce = 0f;
            player2.accelerationForce = 0f;
            player3.accelerationForce = 0f;
            opponentCar.movingSpeed = 0f;
            opponentCar1.movingSpeed = 0f;
            opponentCar2.movingSpeed = 0f;
            opponentCar3.movingSpeed = 0f;
            opponentCar4.movingSpeed = 0f;
        }
        else if(countDownTimer == 0)
        {
            player1.accelerationForce = 300f;
            player2.accelerationForce = 300f;
            player3.accelerationForce = 300f;
            opponentCar.movingSpeed = 10f;            
            opponentCar1.movingSpeed = 12f;
            opponentCar2.movingSpeed = 11f;
            opponentCar3.movingSpeed = 12f;
            opponentCar4.movingSpeed = 10f;
        }
    }

    IEnumerator TimeCount()
    {
        while (countDownTimer > 0)
        {
            countDownText.text  = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }
        LetsGo.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        LetsGo.gameObject.SetActive(false);

    }
}
