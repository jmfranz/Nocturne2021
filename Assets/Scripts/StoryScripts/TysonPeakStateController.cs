using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class TysonPeakStateController : MonoBehaviour
{
    [SerializeField] GameObject _event4;
    [SerializeField] AudioClip _nick5Clip;

    public enum StoryStates
    {
        //Tutorial, //Not implemented yet
        ConversingPeriod,

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Event4());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Event3 is the start event right now. The numbers of events line up with numbers on the Tyson's Peak final document

    //Ater 5 minutes Nick announces he isn't feeling well and is turning in for the night...
    IEnumerator Event4()
    {
        yield return new WaitForSeconds(5 * 60.0f);

        _event4.SetActive(true);


        var nick = GameObject.Find("Nick Jones");
        var bedroom1 = GameObject.Find("NickAlone").GetComponent<ConversationNode>();

        DeleteParentConversationPlayers(nick);

        nick.GetComponent<AvatarController>().GoToConversationNode(bedroom1, AvatarController.MovementTypes.Walk);

        var nickAudio = nick.GetComponent<AudioSource>();
        nickAudio.clip = _nick5Clip;
        nickAudio.volume = 1f;
        nickAudio.loop = false;
        nickAudio.Play();


        StartCoroutine(Event5());
    }


    //After 1 more minute Nick collapses, then Rachel leads the party down the hawllway to Nick's room...
    IEnumerator Event5()
    {
        yield return new WaitForSeconds(60.0f);

        GameObject.Find("NickAlone").GetComponent<AudioSource>().Play();
        var nick = GameObject.Find("Nick Jones");
        Destroy(nick.GetComponent<ThirdPersonCharacter>());
        Destroy(nick.GetComponent<Animator>());
        Destroy(nick.GetComponent<AvatarController>());
        Destroy(nick.GetComponent<NavMeshAgent>());
        Destroy(nick.GetComponent<Rigidbody>());
        Destroy(nick.GetComponent<CapsuleCollider>());
        Destroy(nick.GetComponent<AudioSource>());

        nick.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);

        var wholeNode = GameObject.Find("WholeParty").GetComponent<ConversationNode>();
        var rachel = GameObject.Find("Rachel Wilkesbury");
        DeleteParentConversationPlayers(rachel);
        rachel.GetComponent<AvatarController>().GoToConversationNode(wholeNode, AvatarController.MovementTypes.FastWalk);

        yield return new WaitForSeconds(7.0f);

        GameObject.Find("Anna Ricci").GetComponent<AvatarController>().GoToConversationNode(wholeNode, AvatarController.MovementTypes.Walk);

        var shawn = GameObject.Find("Shawn Wilkesbury");
        DeleteParentConversationPlayers(shawn);
        shawn.GetComponent<AvatarController>().GoToConversationNode(wholeNode, AvatarController.MovementTypes.Walk);
        GameObject.Find("Ben Ricci").GetComponent<AvatarController>().GoToConversationNode(wholeNode, AvatarController.MovementTypes.Walk);
        GameObject.Find("Angela Campbell").GetComponent<AvatarController>().GoToConversationNode(wholeNode, AvatarController.MovementTypes.Walk);

        GameObject.Find("Calum Greene").GetComponent<AvatarController>().GoToConversationNode(wholeNode, AvatarController.MovementTypes.Walk);

        yield return new WaitForSeconds(3.0f);

        var marco = GameObject.Find("Marco Ricci");
        DeleteParentConversationPlayers(marco);
        marco.GetComponent<AvatarController>().GoToConversationNode(wholeNode, AvatarController.MovementTypes.Walk);

    }

    void DeleteParentConversationPlayers(GameObject avatar)
    {
        Destroy(avatar.GetComponentInParent<DirectIntroductionController>());

        var convPlayers = avatar.GetComponentsInParent<ConversationPlayer>();
        for (int i = 0; i < convPlayers.Length; i++)
        {
            convPlayers[i].InteruptConversation();
            Destroy(convPlayers[i]);
        }

        avatar.transform.parent.GetComponent<AudioSource>().enabled = false;
    }
}
