using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int ID;
    public int Value;
    public Image CardFace;
    public Button CardButton;
    public bool isOpen = false;

    void Start()
    {
        isOpen = false;
    }

    public void SelectCard()
    {
        isOpen = true;
        CardButton.interactable = false;
        if(GamePlay.OnCardSelect != null)
            GamePlay.OnCardSelect(ID, Value);
    }

    public void FaceDown()
    {
        CardFace.gameObject.SetActive(false);
        CardButton.interactable = true;
        isOpen = false;
    }
}
