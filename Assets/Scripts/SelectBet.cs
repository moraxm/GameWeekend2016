using UnityEngine;
using System.Collections;

public class SelectBet : MonoBehaviour {
    
    public void Select()
    {
        GameManager.GetInstance().betCardPlayer1 = SelectCard.selected[0];
    }
}
