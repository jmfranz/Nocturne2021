using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;

public class Cognitive_Catherine_Reaction : MonoBehaviour
{
   [SerializeField] private CognitiveWorldSwitch cognitiveWorldSwitch;
    
    private Dictionary<string, Action> convoSecretKeyword = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    [SerializeField] ParticleSystem cognitiveWorldEffects;
    private Animator animator;
    private int isSurprisedHash;
    private int cognitiveReactionTime = 8;
    public bool reactionComplete;


    // Start is called before the first frame update
    void Start()
    {
        reactionComplete = false;
        animator = GetComponent<Animator>();
        isSurprisedHash = Animator.StringToHash("isSurprised");

        //Add the Keywords and the corresponding reaction to the dictionary convoSecretKeyword.
        convoSecretKeyword.Add("Seduced", RespondToSeduce);
        convoSecretKeyword.Add("Seduce", RespondToSeduce);
        convoSecretKeyword.Add("Seclude", RespondToSeduce);
        convoSecretKeyword.Add("Seduction", RespondToSeduce);

        keywordRecognizer = new KeywordRecognizer(convoSecretKeyword.Keys.ToArray(), ConfidenceLevel.Medium);

        //Add the event RecognizeSpeech to the keywordRecognizer object
        keywordRecognizer.OnPhraseRecognized += RecocorgnizedSpeech;

        //Start the object recognizer to use the microphone service on the device.
        keywordRecognizer.Start();

        // create a boolean variable for the isSuprised hash for readability
        bool isSurprised = animator.GetBool(isSurprisedHash);

        
    }

    private void RecocorgnizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        convoSecretKeyword[speech.text].Invoke();
    }
      
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RespondToSeduce();
        }
    }
    private void RespondToSeduce()
    {
        //Animation to react to the keyword seduced or seduce or Seduction
        StartCoroutine(CatherinReaction());
               

        //Stop using the keyword Recorgnizer object
        keywordRecognizer.Stop();

        
        //Stop playing the particle effect as the user transitions to the real world
        cognitiveWorldEffects.Stop();

        //Transition to the real world
        
    }

    IEnumerator CatherinReaction()
    {
        animator.SetBool(isSurprisedHash, true);
        yield return new WaitForSeconds(cognitiveReactionTime);
        animator.SetBool(isSurprisedHash, false);
        reactionComplete = true;
        cognitiveWorldSwitch.LeaveCognitive();
    }

}
