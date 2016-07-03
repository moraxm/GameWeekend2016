using UnityEngine;
using System.Collections;

public class StoreScene : MonoBehaviour {

  public CardUI ui_card;
	// Use this for initialization
	void Start () {
    Card c = GameManager.GetInstance().GetRandomCard();
    ui_card.fillUI(c);
	}
	
}
