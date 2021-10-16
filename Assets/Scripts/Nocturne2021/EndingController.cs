using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    public ConversationPlayer TellFok;
    public ConversationPlayer TellCatherine;

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

    bool endStarted;
    
    void Start()
    {
        endStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!endStarted && TellFok._remainingLines.Count == 0)
        {
            SteepedInSecrecy();
            StartCoroutine(EndingTime(30));
            endStarted = true;
        }
        if (!endStarted && TellCatherine._remainingLines.Count == 0)
        {
            SteepedInScandal();
            StartCoroutine(EndingTime(30));
            endStarted = true;
        }
    }

    public IEnumerator EndingTime(int time)
    {
        yield return new WaitForSeconds(time);
        End.SetActive(true);
    }

    public void SteepedInSecrecy()
    {
        offsetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 14);

        //Start audio ending
        switchingSoundSource.PlayOneShot(SteepedInSecrecy_Sound);
        switchingSoundSource.PlayOneShot(TellFokEndingSound);

        //Start visual ending
        P2.SetActive(false);
        Instantiate(SecrecyImage, offsetPosition, Quaternion.identity);

        //Thanks for playing Spill
        StartCoroutine(EndingTime(30));
    }

    public void SteepedInScandal()
    {
        offsetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);
        
        //Start visual ending
        P2.SetActive(false);
        Instantiate(ScandalImage, offsetPosition, Quaternion.identity);
        
        //Start audio ending
        switchingSoundSource.PlayOneShot(SteepedInScandal_Sound);
        switchingSoundSource.PlayOneShot(TellCatEndingSound);

        //Thanks for playing Spill
        StartCoroutine(EndingTime(4));
    }

    public void TheCreature_GetKickedOut()
    {
        offsetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);
        
        //Start visual ending
        P2.SetActive(false);
        Instantiate(CreatureImage, offsetPosition, Quaternion.identity);

        //Start audio ending
        switchingSoundSource.PlayOneShot(CreatureSound);
        switchingSoundSource.PlayOneShot(TheCreature_Sound);

        //Thanks for playing Spill
        StartCoroutine(EndingTime(30));
    }
}
