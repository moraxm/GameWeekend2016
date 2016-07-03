using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetQuantity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CardUI card = transform.parent.GetComponentInChildren<CardUI>();
        Text text = GetComponent<Text>();
        // TODO: 
        int quantity = card.card.cardCount;
        text.text = "x" + quantity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
