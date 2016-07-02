using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class IsUnlocked : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        Card card = gameObject.GetComponentInParent<Card>();

        List<Card> cards = GameManager.GetInstance().m_playerCardColletion[card.collection];

            if (cards.Contains(card))
            {
                gameObject.SetActive(false);
            }
	}
}
