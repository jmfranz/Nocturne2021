using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    public ConversationPlayer TellFok;
    public ConversationPlayer TellCatherine;

    public GameObject SteepedInSecrecy_Newspaper;
    public GameObject TheCreature_Newspaper;

    public GameObject End;

    public TMPro.TMP_Text strikeBar;
    public TMPro.TMP_Text endStrikeBar;

    public FadeController fadeController;

    public AudioSource switchingSoundSource;
    public AudioClip SteepedInSecrecy_Sound;
    public AudioClip TheCreature_Sound;
    public AudioClip SteepedInScandal_Sound;
    public AudioClip TellFokEndingSound;
    public AudioClip TellCatEndingSound;
    public AudioClip CreatureSound;

    // Update is called once per frame
    void Update()
    {
        if (TellFok._remainingLines.Count == 0 && fadeController.faded)
        {
            SteepedInSecrecy();
            StartCoroutine(EndingTime(30));
        }
        if (TellCatherine._remainingLines.Count == 0)
        {
            SteepedInScandal();
            StartCoroutine(EndingTime(2));
        }

    }

    public void TheEnd()
    {
        End.SetActive(true);
    }

    public IEnumerator EndingTime(int time)
    {
        yield return new WaitForSeconds(time);
        End.SetActive(true);
    }

    public void SteepedInSecrecy()
    {
        switchingSoundSource.PlayOneShot(SteepedInSecrecy_Sound);
        switchingSoundSource.PlayOneShot(TellFokEndingSound);
        fadeController.Fade(SteepedInSecrecy_Newspaper.GetComponent<CanvasGroup>());
        StartCoroutine(EndingTime(30));
    }

    public void SteepedInScandal()
    {
        switchingSoundSource.PlayOneShot(SteepedInScandal_Sound);
        switchingSoundSource.PlayOneShot(TellCatEndingSound);
        StartCoroutine(EndingTime(4));
    }

    public void TheCreature_GetKickedOut()
    {
        switchingSoundSource.PlayOneShot(CreatureSound);
        endStrikeBar.enabled = true;
        strikeBar.enabled = false;
        fadeController.Fade(TheCreature_Newspaper.GetComponent<CanvasGroup>());
        switchingSoundSource.PlayOneShot(TheCreature_Sound);
        StartCoroutine(EndingTime(30));
    }
}
