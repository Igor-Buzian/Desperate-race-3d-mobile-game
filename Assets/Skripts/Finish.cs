using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [Header("Finish UI Var")]
    public GameObject finishUI;
    public GameObject playerUI;
    //public GameObject playerCar;

    [Header("Text")]
    public Text resultText;
    public Text circleNum;
    public Text CurrentTime;

    [Header("Finish Text")]
    public Text FinishCurrentTime;
    public Text FinishTheBestTime;

    private float time = 0;
    private int minutes = 0;
    private int seconds = 0;
    private int milliseconds = 0;
    private float theBestTime;

    private int counter;
    private int EnemyÑounter;
    private void Start()
    {
        theBestTime = PlayerPrefs.GetFloat("BTime", 1000f);

        StartCoroutine(waitForFinishUI());        
    }
    private void Update()
    {
        StartCoroutine(EnumeratorTime());
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            counter++;
            //PlayerPrefs.SetFloat("LapsCounter", counter);
            circleNum.text = $"Laps: \r\n{counter}/3";
        }
        else if(collider.gameObject.tag == "OpponentCar")
        {
            EnemyÑounter++;
        }

        if (EnemyÑounter >= 11 && counter == 3)
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            resultText.color = Color.red;
            resultText.text = "You Lose...";
        }
        else if (counter == 3)
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            resultText.color = Color.black;
            resultText.text = "Victory!";
        }
        else if (counter == 2)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

    IEnumerator waitForFinishUI()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    IEnumerator finishZoneTimer()
    {
        yield return new WaitForSeconds(1f);
        finishUI.SetActive(true);
        playerUI.SetActive(false);   
        Time.timeScale = 0f;

        if (time < theBestTime)
        {
            theBestTime = time;
            PlayerPrefs.SetFloat("BTime", theBestTime);

            FinishCurrentTime.color = Color.green;
            FinishTheBestTime.color = Color.green;

            FinishCurrentTime.text = FormatTime(time);
            FinishTheBestTime.text = FormatTime(theBestTime);
        }
        else
        {
            FinishCurrentTime.color = Color.red;

            FinishCurrentTime.text = FormatTime(time);
            FinishTheBestTime.text = FormatTime(theBestTime);            
        }
    }
    IEnumerator EnumeratorTime()
    {
        yield return new WaitForSeconds(5);
        time += Time.deltaTime;


        CurrentTime.text = " Time: \r\n"+ FormatTime(time);
    }
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 10) % 10);

        return string.Format("{0}:{1}.{2}", minutes, seconds, milliseconds);
    }
}
