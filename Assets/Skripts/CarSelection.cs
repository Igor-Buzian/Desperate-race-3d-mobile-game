using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [Header("Buttons and Canvas")]

    public Button next;
    public Button back;
    public Button play;

    private int currentCar;
    private GameObject[] carList;

    [Header("Camera")]
    public GameObject cam1;
    public GameObject cam2;

    [Header("Buttons and Canvas")]
    public GameObject selectionCanvas;
    public GameObject SkipButton;
    public GameObject PlayButton;
    public GameObject ChooseCanvas;
    public Canvas MultiplayerCanvas;

    private void Awake()
    {
        selectionCanvas.SetActive(false);
        PlayButton.SetActive(false);
        cam2.SetActive(false);
    }

    private void Start()
    {
        currentCar = PlayerPrefs.GetInt("CarSeleted");
        carList = new GameObject[transform.childCount];

        for (int i = 0; i < carList.Length; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in carList)
        {
            go.SetActive(false);
        }

        if (carList[currentCar])
        {
            carList[currentCar].SetActive(true);
        }

        UpdateButtons();
    }

    private void UpdateButtons()
    {
        back.interactable = (currentCar > 0);
        next.interactable = (currentCar < transform.childCount - 1);
    }

    private void ChooseCar(int index)
    {
        currentCar = index;
        UpdateButtons();

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void SwitchCar(int switchCar)
    {
        int newIndex = currentCar + switchCar;

        if (newIndex >= 0 && newIndex < transform.childCount)
        {
            ChooseCar(newIndex);
        }
    }

    public void playGame()
    {
        PlayerPrefs.SetInt("CarSeleted", currentCar);
        play.gameObject.SetActive(false);
        ChooseCanvas.SetActive(true);
    }
    public void Singleplayer()
    {
        SceneTransition.SwithToScene("scene_day");
    }
    public void Multiplayer()
    {
        MultiplayerCanvas.gameObject.SetActive(true);
        SceneTransition.SwithToScene("Multiplayer");
    }
    public void SkipButtons()
    {
        selectionCanvas.SetActive(true);
        PlayButton.SetActive(true);
        SkipButton.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
