/*
    MotionCaptureEdior: A Unity editor extension window to handle captured motion and audio for use with Microsoft Rocket Box Avatars.
    @Author: Matt P.
*/
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MotionCaptureEditor : EditorWindow {
    //int _selectedAnimator = 0;
    //int _selectedAudio = 0;

    //int _selectedAvatar = 0;

    //int xPos = 0, yPos = 0, zPos = 0;

    //bool _isPlaying = false;
    //public GameObject avatarInstance = null;
    //public GameObject aSource = null;
    //string[] _avatarOptions = Directory.GetFiles ("./Assets/Resources/Avatars").Select (file => Path.GetFileName (file).Split ('.') [0]).ToArray ();

    //string[] _animatorOptions = Directory.GetFiles ("./Assets/Animators", "*.controller").Select (file => Path.GetFileName (file)).ToArray ();
    //string[] _audioOptions = Directory.GetFiles ("./Assets/Resources/AudioRecordings").Where (name => !name.EndsWith (".meta")).Select (file => Path.GetFileName (file).Split ('.') [0]).ToArray ();

    //[MenuItem ("CreateAR/Avatar Animation Manager")] // -> Update this link to update how this editor window is accessed in the toolbar.
    //public static void ShowWindow () {
    //    GetWindow<MotionCaptureEditor> ("Avatar Animation Manager");
    //}

    //void OnGUI () {

    //    // -- Begin drop down box selections section --
    //    EditorGUI.BeginChangeCheck ();

    //    GUILayout.Label ("Avatar Selection", EditorStyles.boldLabel);

    //    this._selectedAvatar = EditorGUILayout.Popup ("Avatar: ", _selectedAvatar, _avatarOptions);

    //    GUILayout.Label ("Captured Content", EditorStyles.boldLabel);

    //    this._selectedAnimator = EditorGUILayout.Popup ("Animator: ", _selectedAnimator, _animatorOptions);

    //    this._selectedAudio = EditorGUILayout.Popup ("Audio Recording: ", _selectedAudio, _audioOptions);

    //    if (EditorGUI.EndChangeCheck ()) {
    //        Debug.Log (_animatorOptions[_selectedAnimator]);
    //    }
    //    // -- End drop down selection --

    //    GUILayout.Label ("Position Avatar (Optional)", EditorStyles.boldLabel);

    //    xPos = EditorGUILayout.IntField ("X Position: ", xPos);
    //    yPos = EditorGUILayout.IntField ("Y Position: ", yPos);
    //    zPos = EditorGUILayout.IntField ("Z Position: ", zPos);

    //    // Add a space between "Sections"
    //    EditorGUILayout.Space ();
    //    Rect r = EditorGUILayout.GetControlRect (GUILayout.Height (10 + 1));
    //    r.height = 1;
    //    r.y += 10 / 2;
    //    r.x -= 2;
    //    r.width += 6;
    //    EditorGUI.DrawRect (r, Color.grey);

    //    if (avatarInstance == null) {

    //        if (GUILayout.Button ("Spawn Selected Items")) {

    //            GameObject avatar = Resources.Load ("Avatars/" + _avatarOptions[_selectedAvatar] + "/Export/" + _avatarOptions[_selectedAvatar]) as GameObject;
    //            avatarInstance = Instantiate (avatar);

    //            // Position the avatar based on the three input field values.
    //            avatarInstance.transform.position = new Vector3 (xPos, yPos, zPos);
    //            avatarInstance.transform.Rotate (0.0f, 180.0f, 0.0f, Space.Self);

    //            AnimatorController animationController = (AnimatorController) AssetDatabase.LoadAssetAtPath ("Assets/Animators/" + _animatorOptions[_selectedAnimator], typeof (AnimatorController));

    //            avatarInstance.GetComponent<Animator> ().runtimeAnimatorController = animationController;

    //            // Attach an audio clip to the Avatar Game Object.
    //            AudioSource audioSource = avatarInstance.AddComponent<AudioSource> () as AudioSource;

    //            AudioClip audioClip = Resources.Load<AudioClip> ("AudioRecordings/" + _audioOptions[_selectedAudio]);

    //            // Attach the clip to the audio source, and ensure that it will play as soon as the game object becomes active
    //            audioSource.clip = audioClip;
    //            audioSource.playOnAwake = true;

    //            // Attach the mouth movement script to the avatar instance & attach the RocketBox MJaw transform. 
    //            MouthMovement mouthMovement = avatarInstance.AddComponent<MouthMovement>();
    //            mouthMovement.MJaw = avatarInstance.transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2/Bip01 Neck/Bip01 Head/Bip01 MJaw");
    //            //TODO: Consider a less hardcoded method and implement error checking. 

    //        }
    //    } else {
    //        if (GUILayout.Button ("Delete Instance")) {
    //            // Removes GameObject instance from the scene, and deletes references to it in this script.
    //            DestroyImmediate (avatarInstance);
    //        }

    //    }

    //    if (!_isPlaying) {
    //        if (GUILayout.Button ("Play Scene")) {
    //            EditorApplication.ExecuteMenuItem ("Edit/Play");
    //            _isPlaying = !_isPlaying;
    //        }
    //    } else {
    //        if (GUILayout.Button ("Stop Scene")) {
    //            EditorApplication.ExecuteMenuItem ("Edit/Play");
    //            _isPlaying = !_isPlaying;
    //        }
    //    }

    //    // Add a space between "Sections"
    //    EditorGUILayout.Space ();

    //    GUILayout.Label ("Animation Clip Creation", EditorStyles.boldLabel);
    //    GUILayout.Label ("You can create a new Animation Clip with CinemaMocap2.");

    //    if (GUILayout.Button ("Open CinemaMocap2")) {
    //        Debug.Log ("CinemaMocap2 button pressed.");
    //        EditorApplication.ExecuteMenuItem ("Window/Cinema Suite/Cinema Mocap 2/Cinema Mocap 2");
    //    }

    //    // TODO: Make this lable removeable by implementing an automated script to do this.
    //    GUILayout.Label ("Your new Animation Clip must be attached to a new Animator which must be stored in Assets / Animators.");

    //}
}