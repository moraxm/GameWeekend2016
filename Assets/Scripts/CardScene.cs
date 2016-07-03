using UnityEngine;
using System.Collections;

public class CardScene : MonoBehaviour
{

    public GameObject m_win;
    public GameObject m_lose;

    public CardUI card;

    public float timeAnimation = 1;

    public AudioSource source;
    public AudioClip audio_win;
    public AudioClip audio_lose;

    // Use this for initialization
    void Start()
    {
        GameManager gm = GameManager.GetInstance();
        Card goBet = null;
        GameObject visible;
        if (gm.player2points > gm.player1points)
        {
            m_win.SetActive(false);
            m_lose.SetActive(true);
            visible = m_lose;
            goBet = gm.betCardPlayer1;
            source.clip = audio_lose;
            source.Play();
            gm.LostCard(goBet);
        }
        else
        {
            m_win.SetActive(true);
            m_lose.SetActive(false);
            visible = m_win;
            goBet = gm.betCardPlayer2;
            source.clip = audio_win;
            source.Play();
            gm.WinCard(goBet);
        }

        card.fillUI(goBet);

        StartCoroutine(PlayAnimation(visible));

    }

    private IEnumerator PlayAnimation(GameObject final)
    {
        Vector3 finalScale = final.transform.localScale;
        final.transform.localScale = Vector3.zero;
        float timeAcum = 0;
        float timeWait = 0.05f;

        while (timeAcum <= timeAnimation)
        {
            Vector3 new_scale = Vector3.Lerp(Vector3.zero, finalScale, timeAcum / timeAnimation);
            final.transform.localScale = new_scale;
            timeAcum += timeWait;
            yield return new WaitForSeconds(timeWait);
        }

    }
}
