using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public GameObject Instance;
    public Win GameWin;
    public static Action<int, int> OnCardSelect;
    public List<Sprite> CardSprites;
    public List<Card> ListCard;
    public Text Score;
    int GameScore;
    bool isTheSame = false;

    void UpdateScore(int changes)
    {
        GameScore += changes;
        if (GameScore < 0)
        {
            GameScore = 0;
        }
        Score.text = GameScore.ToString();
    }

    void Start()
    {
        InitCards();
        MixCards();

        OnCardSelect -= SelectingCard;
        OnCardSelect += SelectingCard;
    }



    Dictionary<int, int> SaveCards = new Dictionary<int, int>();

    void SelectingCard(int card_id, int card_value)
    {
        // Debug.Log("card id: " + card_id + ". card value: " + card_value);
        // Debug.Log("SaveCards.Count: " + SaveCards.Count);
        // lan luot luu lai 2 la ba
        if (!SaveCards.ContainsKey(card_id))
            SaveCards.Add(card_id, card_value);

        if (SaveCards.Count > 1)
        {
            SetAllCardCanClick(false);
            Invoke("CheckCard", 1);
        }

    }

    void SetAllCardCanClick(bool canClick)
    {
        for (int i = 0; i < ListCard.Count; i++)
        {
            ListCard[i].CardButton.interactable = canClick && !ListCard[i].isOpen;
        }
    }

    void CheckCard()
    {
        isTheSame = (SaveCards.ElementAt(0).Value == SaveCards.ElementAt(1).Value);
        if (!isTheSame)
        {
            // up 2 la bai xuong
            ListCard[SaveCards.ElementAt(0).Key].FaceDown();
            ListCard[SaveCards.ElementAt(1).Key].FaceDown();
            UpdateScore(-1);
        }
        else
        {
            UpdateScore(5);
        }
        SaveCards.Clear();
        SetAllCardCanClick(true);

        //kiem tra dieu kien thang
        CheckWin();

    }

    bool CheckWin()
    {
        for (int i = 0; i < ListCard.Count; i++)
        {
            if (!ListCard[i].isOpen)
                return false;
        }
        Debug.Log("game won");

        // Win.UpdateWinScore(GameScore);
        GameWin.SetWinScore(GameScore);
        GameWin.gameObject.SetActive(true);
        Instance.SetActive(false);

        return true;
    }

    void InitCards()
    {
        int v = 0;
        for (int i = 0; i < ListCard.Count; i++)
        {
            ListCard[i].ID = i;
            ListCard[i].Value = v;
            ListCard[i].CardFace.sprite = CardSprites[v];
            if (i % 2 == 1)
                v++;
        }
    }

    void MixCards()
    {
        int random = 0;
        int n = 50;
        while (n-- > 0)
        {
            random = UnityEngine.Random.Range(0, ListCard.Count);
            ListCard[random].transform.SetAsLastSibling();
        }
    }

    void OnEnable()
    {
        MixCards();
    }

    void OnDisable()
    {
        for (int i = 0; i < ListCard.Count; i++)
        {
            ListCard[i].FaceDown();
        }
        SaveCards.Clear();
        SetAllCardCanClick(true);
        GameScore = 0;
        Score.text = GameScore.ToString();
    }
}
