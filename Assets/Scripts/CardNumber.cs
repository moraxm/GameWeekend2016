using UnityEngine;
using System.Collections;

public class CardNumber : MonoBehaviour {

    public int numberCard;

	// Use this for initialization
	void Start () {
        Collection collection = GetComponentInParent<Collection>();
        Card card = GameManager.GetInstance().allCardCollection[collection.collection][numberCard];

        CardUI cardUI = GetComponentInChildren<CardUI>();
        cardUI.fillUI(card);
	}
}
