using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetQuantity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Card card = GetComponentInParent<Card>();
        Text text = GetComponent<Text>();
        // TODO: 
        int quantity = 1;// GameManager.GetInstance().getCardQuantity();
        text.text = "x" + quantity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
