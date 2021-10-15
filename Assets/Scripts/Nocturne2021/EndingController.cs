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

    public GameObject P2;

    public TMPro.TMP_Text strikeBar;
    public TMPro.TMP_Text endStrikeBar;

    public AudioSource switchingSoundSource;
    public AudioClip SteepedInSecrecy_Sound;
    public AudioClip TheCreature_Sound;
    public AudioClip SteepedInScandal_Sound;
    public AudioClip TellFokEndingSound;
    public AudioClip TellCatEndingSound;
    public AudioClip CreatureSound;

    public GameObject CreatureImage;
    public GameObject SecrecyImage;
    public GameObject ScandalImage;

    public GameObject Player;

    Vector3 offsetPosition;
    
    // Update is called once per frame
    void Update()
    {
        if (TellFok._remainingLines.Count == 0)
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

    public IEnumerator EndingTime(int time)
    {
        yield return new WaitForSeconds(time);
        End.SetActive(true);
    }

    public void SteepedInSecrecy()
    {
        offsetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 1);

        //Start audio ending
        switchingSoundSource.PlayOneShot(SteepedInSecrecy_Sound);
        switchingSoundSource.PlayOneShot(TellFokEndingSound);
       
        //Start visual ending
        P2.SetActive(false);
        Instantiate(CreatureImage, Player.transform.position, Quaternion.identity);
        
        //Thanks for playing Spill
        StartCoroutine(EndingTime(30));
    }

    public void SteepedInScandal()
    {
        switchingSoundSource.PlayOneShot(SteepedInScandal_Sound);
        switchingSoundSource.PlayOneShot(TellCatEndingSound);
        P2.SetActive(false);
        StartCoroutine(EndingTime(4));
    }

    public void TheCreature_GetKickedOut()
    {
        switchingSoundSource.PlayOneShot(CreatureSound);
        endStrikeBar.enabled = true;
        strikeBar.enabled = false;
        P2.SetActive(false);
        switchingSoundSource.PlayOneShot(TheCreature_Sound);
        StartCoroutine(EndingTime(30));
    }
}
