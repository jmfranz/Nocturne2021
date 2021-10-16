using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    public ConversationPlayer TellFok;
    public ConversationPlayer TellCatherine;

    public GameObject End;

    public List<GameObject> TurnOff; 

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
    public Strikes strikes;

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
            StartCoroutine(EndingTime(40, SecrecyImage, SteepedInSecrecy_Sound, TellFokEndingSound));
            endStarted = true;
        }
        if (!endStarted && TellCatherine._remainingLines.Count == 0)
        {
            StartCoroutine(EndingTime(40, ScandalImage, SteepedInScandal_Sound, TellCatEndingSound));
            endStarted = true;
        }
        if (!endStarted && strikes.kickOut)
        {
            StartCoroutine(EndingTime(40, CreatureImage, CreatureSound, TheCreature_Sound));
            endStarted = true;
        }
    }

    public IEnumerator EndingTime(int time, GameObject image, AudioClip newspaperClip, AudioClip endSound)
    {
        offsetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 14);

        //Start visual ending
        foreach (var obj in TurnOff)
        {
            obj.SetActive(false);
        }
        Instantiate(image, offsetPosition, Quaternion.identity);

        //Start audio ending
        switchingSoundSource.PlayOneShot(newspaperClip);
        switchingSoundSource.PlayOneShot(endSound);

        //Ending words
        yield return new WaitForSeconds(time);
        End.SetActive(true);
    }



    /*public void SteepedInSecrecy()
    {

        offsetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 14);

        //Start visual ending
        TurnOff.SetActive(false);
        Instantiate(SecrecyImage, offsetPosition, Quaternion.identity);

        //Start audio ending
        switchingSoundSource.PlayOneShot(SteepedInSecrecy_Sound);
        switchingSoundSource.PlayOneShot(TellFokEndingSound);

        //Thanks for playing Spill
        StartCoroutine(EndingTime(40));
    }

    public void SteepedInScandal()
    {
        offsetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 14);

        //Start visual ending
        TurnOff.SetActive(false);
        Instantiate(ScandalImage, offsetPosition, Quaternion.identity);
        
        //Start audio ending
        switchingSoundSource.PlayOneShot(SteepedInScandal_Sound);
        switchingSoundSource.PlayOneShot(TellCatEndingSound);

        //Thanks for playing Spill
        StartCoroutine(EndingTime(40));
    

    public void TheCreature_GetKickedOut()
    {
        offsetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 14);

        //Start visual ending
        foreach (var obj in TurnOff)
        {
            obj.SetActive(false);
        }
        Instantiate(CreatureImage, offsetPosition, Quaternion.identity);

        //Start audio ending
        switchingSoundSource.PlayOneShot(CreatureSound);
        switchingSoundSource.PlayOneShot(TheCreature_Sound);

        //Thanks for playing Spill
        StartCoroutine(EndingTime(40));
    }*/
}
