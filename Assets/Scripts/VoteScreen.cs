using UnityEngine;
using System.Collections;

public class VoteScreen : MonoBehaviour {

  public CardUI m_card;

	// Use this for initialization
	void Start () {
    m_card.fillUI(GameManager.GetInstance().GetRandomCard());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
