using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillRound : MonoBehaviour {

    public Text roundText;

    public void Start()
    {
        roundText.text += (GameManager.GetInstance().currentWave + 1);
    }

}
