using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ClickPlacer : MonoBehaviour, IMixedRealityPointerHandler {

    private int clickCount = 0;

    static Pose p1Pose, p2Pose;
    static Vector3 playerPos;
    static Quaternion playerRot;

    public enum CalibrationStates { NotCalibrated, Calibrating, Finished };
    public static CalibrationStates CalibrationState = CalibrationStates.NotCalibrated;

    GameObject cube1, cube2;

    void Awake()
    {
        if(CalibrationState == CalibrationStates.Calibrating)
        {
            GameObject P1 = GameObject.Find("P1");

            Transform mainCamera = GameObject.Find("MixedRealityPlayspace (1)").transform.GetChild(0); // Need to access the pos, rot of main camera
            
            //Accounts for change in origin from calibration scene 
            mainCamera.position = playerPos;
            mainCamera.rotation = playerRot;

            DisableNavMeshAgents();

            P1.transform.position = p1Pose.position;

            //P1 is the pivot point of hte model.
            P1.transform.LookAt(p2Pose.position);
            P1.transform.rotation = Quaternion.Euler(0, P1.transform.rotation.eulerAngles.y, 0);

            var model = P1.transform.GetChild(0);
            model.transform.parent = null;

            foreach (Transform child in model.transform)//.GetComponentsInChildren<Transform>())
            {
                child.parent = null;
            }


            //Add an anchor to the pivot of the model.
            ///P1.AddComponent<WorldAnchor>();

            //De-parent and add anchor for each "Anchorable"
            //The trick here is to add anchors to targets instead of the model. Drift is unnavoidable however local drift
            // is is not as bad as the drift of the big model (because of angular velocity).
            //The hololens WILL autocorrect for drift as it gathers environemntal information.
            foreach (GameObject anchorable in GameObject.FindGameObjectsWithTag("Anchorable"))
            {
                anchorable.transform.parent = null;
                //anchorable.AddComponent<WorldAnchor>();
            }


            //Let's disable the spacial mesh :)
            //Note that the observer is still running we are just not rendering the mesh
            //CoreServices.SpatialAwarenessSystem.Disable();

            GetComponent<ObserverMeshToggler>().DisableObserverMeshes();

            //Change resolution to fine
            GetComponent<ObserverMeshToggler>().ChangeObserverResolution();

            EnableNavMeshAgents();

            CalibrationState = CalibrationStates.Finished;
        }
    }

    void Start()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if(clickCount > 2 || CalibrationState != CalibrationStates.NotCalibrated || SceneManager.GetActiveScene().name == "AR Standville Museum-David Choco Manco-Mona_Campbell")
            return;

        var pos = eventData.Pointer.Result.Details.Point;
        GameObject P1 = GameObject.Find("P1");

        if (clickCount == 0)
        {
            p1Pose.position = pos;
            cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.position = pos;
            cube1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        else if (clickCount == 1)
        {
            p2Pose.position = pos;

            cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube2.transform.position = pos;
            cube2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
 

        clickCount++;
    }

    public void ReloadScene()
    {
        clickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Called when the player says "Reset Calibration"
    public void ResetCalibration()
    {
        clickCount = 0;

        Destroy(cube1);
        Destroy(cube2);
    }

    // Called when the player says "Play Story"
    public void ShowStory() 
    {
        if(clickCount < 2) // it isn't calibrated
        {
            return;
        }

        CalibrationState = CalibrationStates.Calibrating;

        Transform mixedRealityPlayspace = GameObject.Find("MixedRealityPlayspace (1)").transform.GetChild(0); // Need to access the pos, rot of main camera
        playerPos = mixedRealityPlayspace.position;
        playerRot = mixedRealityPlayspace.rotation;

        SceneManager.LoadScene(1);
    }

    void DisableNavMeshAgents()
    {
        GameObject[] avatars = GameObject.FindGameObjectsWithTag("Avatar");
        GameObject[] agents = GameObject.FindGameObjectsWithTag("IsAgent");

        for(int i = 0; i < avatars.Length; i++)
        {
            GameObject avatar = avatars[i];
            avatar.GetComponent<NavMeshAgent>().enabled = false;
            avatar.GetComponent<Rigidbody>().useGravity = false;
            avatar.GetComponent<AvatarController>().enabled = false;
        }

        for (int i = 0; i < agents.Length; i++)
        {
            GameObject agent = agents[i];
            agent.GetComponent<NavMeshAgent>().enabled = false;
            agent.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void EnableNavMeshAgents()
    {
        GameObject[] avatars = GameObject.FindGameObjectsWithTag("Avatar");
        GameObject[] agents = GameObject.FindGameObjectsWithTag("IsAgent");

        for (int i = 0; i < avatars.Length; i++)
        {
            GameObject avatar = avatars[i];
            avatar.GetComponent<NavMeshAgent>().enabled = true;
            avatar.GetComponent<Rigidbody>().useGravity = true;
            avatar.GetComponent<AvatarController>().enabled = true;
        }

        for (int i = 0; i < agents.Length; i++)
        {
            GameObject agent = agents[i];
            agent.GetComponent<NavMeshAgent>().enabled = true;
            agent.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
