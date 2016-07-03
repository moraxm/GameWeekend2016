﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCard : MonoBehaviour {

    public static List<Card> selected = new List<Card>();
    private static int MaxCards = 2;

    public Image ImageSelected;

    public void Select() {
        CardUI card = GetComponentInChildren<CardUI>();
        if (selected.Contains(card.card))
        {
            selected.Remove(card.card);
            Color c = ImageSelected.color;
            c.a = 0f;
            ImageSelected.color = c;
        } else
        if (selected.Count < MaxCards)
        {
            selected.Add(card.card);
            Color c = ImageSelected.color;
            c.a = 0.33f;
            ImageSelected.color = c;
        }
    }
}
