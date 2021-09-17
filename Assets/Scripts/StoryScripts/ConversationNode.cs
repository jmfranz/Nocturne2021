using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationNode : MonoBehaviour
{
    public enum PropPositions
    {
        NoProp,
        Center,
        Boundary,
    }

    public Vector3 LookAtPoint { get; private set; }
    public List<GameObject> InitialAvatars;
    public GameObject Prop;
    public ConversationNodeData.ConversationPlacementTypes PlacementType;
    public float Radius;
    public PropPositions PropPosition;

    List<GameObject> _boundaryObjects;

    // Start is called before the first frame update
    void Start()
    {
        if(Prop == null)
        {
            PropPosition = PropPositions.NoProp;
        }

        _boundaryObjects = new List<GameObject>(InitialAvatars);

        //Assign each avatar to the conversation node
        foreach(var avatar in InitialAvatars)
        {
            avatar.GetComponent<AvatarController>().ActiveNode = this;
        }

        if(PropPosition == PropPositions.Boundary)
        {
            _boundaryObjects.Insert(0, Prop);
        }

        LookAtPoint = transform.position; //Default in case there are no avatars

        //Place each boundary object on the edge 
        for (int i=0; i < _boundaryObjects.Count; i++)
        {
            GameObject boundaryObject = _boundaryObjects[i];
            float angle = ((float)i / _boundaryObjects.Count) * 360f;

            boundaryObject.transform.localPosition = new Vector3(
                Radius * Mathf.Cos(angle * (Mathf.PI / 180)),
                transform.localPosition.y,
                Radius * Mathf.Sin(angle * (Mathf.PI / 180))
            );

            //Make avatars look at prop if exists, otherwise look at center
            if (PropPosition != PropPositions.NoProp && boundaryObject != Prop)
            {
                LookAtPoint = Prop.transform.position;
            }
            else if(PropPosition == PropPositions.NoProp)
            {
                LookAtPoint = transform.position;
            }

            boundaryObject.transform.LookAt(LookAtPoint);
            boundaryObject.transform.localEulerAngles = new Vector3(
                0,
                boundaryObject.transform.localEulerAngles.y,
                boundaryObject.transform.localEulerAngles.z
            );
        }
    }

    //Return: Position of where avatar should stand
    public Vector3 AddAvatar(GameObject newAvatar)
    {
        Radius = CalculateProxemicRadius(_boundaryObjects.Count, PlacementType);

        //Reposition other avatars in circle to make room for 1 more
        float angle;

        for (int i = 0; i < _boundaryObjects.Count; i++)
        {
            //Skip prop in repositioning if applicable
            if(i==0 && PropPosition == PropPositions.Boundary)
            {
                continue;
            }

            AvatarController avatarController = _boundaryObjects[i].GetComponent<AvatarController>();
            angle = ((float)i / (_boundaryObjects.Count + 1)) * 360f;

            Vector3 offset = new Vector3(
                Radius * Mathf.Cos(angle * (Mathf.PI / 180)),
                transform.localPosition.y,
                Radius * Mathf.Sin(angle * (Mathf.PI / 180))
            );

            avatarController.SetDestination(transform.position + offset);
        }

        //Reparent new avatar
        newAvatar.transform.parent = transform;

        //Set new avatar's position - temp
        angle = ((float)_boundaryObjects.Count / (_boundaryObjects.Count + 1)) * 360f;

        //Register new avatar
        _boundaryObjects.Add(newAvatar);

        Vector3 localOffset = new Vector3(
                Radius * Mathf.Cos(angle * (Mathf.PI / 180)),
                transform.localPosition.y,
                Radius * Mathf.Sin(angle * (Mathf.PI / 180))
        );

        return transform.position + localOffset;
    }


    public void RemoveAvatar(GameObject avatar)
    {
        _boundaryObjects.Remove(avatar);
    }


    public void AllAvatarsLookAt(Transform lookAtPoint, List<GameObject> exceptions = null)
    {
        foreach(var obj in _boundaryObjects)
        {
            if(obj != Prop && (exceptions == null || !exceptions.Contains(obj)))
            {
                obj.transform.LookAt(lookAtPoint);

                obj.transform.localEulerAngles = new Vector3(
                    0,
                    obj.transform.localEulerAngles.y,
                    obj.transform.localEulerAngles.z
                );
            }
        }
    }

    //Might want to extract this to somewhere else
    //Returns radius based on proxemic distance type and number of avatars
    public static float CalculateProxemicRadius(int numberOfAvatars, ConversationNodeData.ConversationPlacementTypes type)
    {
        float baseRadius;

        switch (type)
        {
            case ConversationNodeData.ConversationPlacementTypes.Intimate:
                baseRadius = 0.25f;
                break;
            case ConversationNodeData.ConversationPlacementTypes.Personal:
                baseRadius = 0.6f;
                break;
            case ConversationNodeData.ConversationPlacementTypes.Social:
                baseRadius = 0.9f;
                break;
            default:
                Debug.LogErrorFormat("Conversation Placement Type not handled to produce proxemic radius '{0}", type);
                return -1f;
        }

        //Equation could be refined in the future
        float result = baseRadius + (Mathf.Max(numberOfAvatars - 2, 0) * 0.15f);

        return result;
    }

    public void ResetAvatarLookAt()
    {
        foreach (var obj in _boundaryObjects)
        {
            if (obj != Prop)
            {
                obj.transform.LookAt(LookAtPoint);

                obj.transform.localEulerAngles = new Vector3(
                0,
                obj.transform.localEulerAngles.y,
                obj.transform.localEulerAngles.z
            );
            }
        }
    }
}
