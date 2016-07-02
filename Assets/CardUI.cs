using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {

    public Text name;

    public Image image;

    public Image type;

    public Text description;

    public Text collection;

    public void fillUI(Card card)
    {
        name.text = card.name;
        description.text = card.description;
    }
}
