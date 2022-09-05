using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;



// https: //www. youtube. com/watch?v=HnzmnSqE-Bc  Help
// i updated it, now code is shit but works somehow
public class Hand : MonoBehaviour
{

    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_pose = null;
    private FixedJoint m_Joint = null;

    public Interactable m_CurrentInteractable = null;
    public List<Interactable> m_ContactInteractable = new List<Interactable>();
    

    // Start is called before the first frame update
    private void Awake()
    {
        m_pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();

    }

    // Update is called once per frame
    void Update()
    {
        //Add mesh collider of forehand  bat because it removed in BaCollier script
        GameObject GoForeHandBat = GameObject.FindGameObjectWithTag("ForeHandBat");
               
            if (GoForeHandBat.GetComponent<MeshCollider>().enabled == false)
                {
                    GoForeHandBat.GetComponent<MeshCollider>().enabled = true;
                }


        
        //Down
        if (m_GrabAction.GetStateDown(m_pose.inputSource))
        {
           // print(m_pose.inputSource + "Trigger Down ");
            Pickup();
        }

        // Up
        if (m_GrabAction.GetStateUp(m_pose.inputSource))
        {
           // print(m_pose.inputSource + "Trigger UP ");
            Drop();
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("ttBall"))
            return;

        if (m_ContactInteractable.Count<1)
            m_ContactInteractable.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other)
    {
       if (!other.gameObject.CompareTag("ttBall"))
            return;

       m_ContactInteractable.Remove(other.gameObject.GetComponent<Interactable>());
    }

    public void Pickup()
    {
        //Get the nearest Ineteractable 
         m_CurrentInteractable = GetNearestInteractable();
        //GameObject ttballclone = GameObject.FindGameObjectWithTag("ttBall");
        //m_CurrentInteractable = ttballclone;
        
        // Null check
        if (!m_CurrentInteractable)
            return;

        //Already Heldcheck
        if (m_CurrentInteractable.m_ActiveHand)
            m_CurrentInteractable.m_ActiveHand.Drop();
       

        //Position
        m_CurrentInteractable.transform.position = transform.position;

        //attach
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        //Set Active hand
       m_CurrentInteractable.m_ActiveHand = this;

    }
    public void Drop()
    {
        //null check
        if (!m_CurrentInteractable)
            return;

        //apply velocity
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = m_pose.GetVelocity();
        targetBody.angularVelocity = m_pose.GetAngularVelocity();

        //detach
        m_Joint.connectedBody = null;

        //clear
       m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;

    }

    
    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        
         foreach(Interactable interactable in m_ContactInteractable)
         {
            //distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if (distance< minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
           // m_ContactInteractable.Add(gameObject.GetComponent<Interactable>());
        }

       
        return nearest;
        
    }
    

}
