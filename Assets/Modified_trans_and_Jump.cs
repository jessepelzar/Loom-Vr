﻿using UnityEngine;
using System.Collections;

public class Modified_trans_and_Jump : MonoBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}


    /// <summary>
    /// If true, reset the initial yaw of the player controller when the Hmd pose is recentered.
    /// </summary>
    public bool HmdResetsY = true;

    /// <summary>
    /// If true, each OVRPlayerController will use the player's physical height.
    /// </summary>
    public bool useProfileData = true;



    //public GameObject sphere = GameObject.Find("Sphere");

    //struct currentPose { OVRPose }
    // OVRTracker.Frustum


    private float InitialYRotation = 0.0f;
    private OVRPose? InitialPose;
    private bool tankOrViewMovement = true; // allows the user to switch between tank like movement and
                                             // vision based movement. True is tank, false is vision









    /*
        if the camera collides with something


    lerp camera in Z direction towards playerObject to minimum distance from playerObject(that way camera never goes through playerObject)


    if camera is at minimum distance, lerp opacity of playerObject material to 30% (so player doesnt block view of environment)


    if camera exits collision


    lerp camera in Z direction away from playerObject to maximum distance from player
    lerp playerObject material opacity to 100%
    */

    //   public void onTriggerEnter(Collider camera) {
    //   Debug.Log("Entered the spherical zone");
    // if (Input.GetAxis("Y") != null) { return; }
    // }


    //  Collider sphereCollider = new Collider();

   // public InputField[] openingTextField = null; // GameObject.FindGameObjectsWithTag("Input") as InputField;
    //private Button submitButton = null;



    // scaling variable

    public float moveTheGodDamnSphere = 3f;
    public float turnTheFuckingSphere = 50f;

    //gets current head pos and stores it in a vector; also gets current head orientation and stores it in a quaternion
    public Vector3 currentPosition = OVRPose.identity.position;
    public Quaternion currentOrientaion = OVRPose.identity.orientation;


    void Start()
    {
        //openingTextField.onS
        Quaternion startRotation = transform.rotation;

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Hit BEFORE recenter pose");
            OVRManager.display.RecenterPose();
            Debug.Log("Hit after recenter pose");
        }

        // may have extract this into a settings menu
        //change tank based vs view based control


        //get rid of this for a bit until vision based
        //is solved
    
        //if (Input.GetKey(KeyCode.RightShift))
    //    {
     //       if (tankOrViewMovement)
      //      {
       //         tankOrViewMovement = false;
        //    }
         //   else { tankOrViewMovement = true; }
        //}


        if (tankOrViewMovement)
        {
            tankBasedControls();
        }
        else
        {
            visionBasedControls();

        }


        //vertical translation
        //debug only
        if (Input.GetKey(KeyCode.Space))
        {
            //osselate

            transform.Translate(new Vector3(0, 1, 0) * moveTheGodDamnSphere * Time.deltaTime, Space.Self);


        }

        if (Input.GetKey(KeyCode.Tab))
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * turnTheFuckingSphere, Space.Self);
        }



    }

    public void ResetOrientation()
    {
        if (HmdResetsY)
        {
            Vector3 euler = transform.rotation.eulerAngles;
            euler.y = InitialYRotation;
            transform.rotation = Quaternion.Euler(euler);
        }
    }





    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // { }
    // ok pass in a translational animator, the object that we want shifted and then the index layer. What?}





    public void tankBasedControls()
    {

        //lets give using head tracking as forward
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // Vector3 rotatedForward = currentOrientaion* (Vector3.forward + currentPosition);
            // transform.Rotate.currentOrientaion //nope
            transform.Translate(Vector3.forward * moveTheGodDamnSphere * Time.deltaTime, Space.Self);
            // OVRManager.display.RecenterPose += ;
            //gameObject.Updated

            //transform.Translate(Vector3.forward * moveTheGodDamnSphere * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(currentOrientaion * Vector3.back * Time.deltaTime * moveTheGodDamnSphere, Space.Self);
            //            Transform.Translate(new Vector3)
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(currentOrientaion * Vector3.right * moveTheGodDamnSphere * Time.deltaTime, Space.Self);

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveTheGodDamnSphere * Time.deltaTime, Space.Self);

        }


    }


    public void visionBasedControls()
    {
        // currentOrientaion && currentPosition

        // was gonna do the full key suit but this makes a lot more sense... for now


        // if they click the mouse down then trigger the event

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("You are pressing the left mouse key bro");

            //  OVRResetOrientation reset;

            Quaternion userHeadQuaternion = OVRPose.identity.orientation;
            Vector3 userHeadEuler = OVRPose.identity.orientation.eulerAngles;

            userHeadEuler.y = 0;

            // Quaternion localEuler = Quaternion.AngleAxis(userHeadEuler.x, userHeadQuaternion);



            //gameObject.transform.Translate(newForward, Space.World);



            //OVRManager.display.RecenterPose();

            // reset.guiText = "Test v8" ;

            // lets get some directional movement going
            //Steps
            //Find the direction of the current gaze and set that to be the start of the cordinate system each frame
            // Translate forward using vector3 forward
            gameObject.transform.ToOVRPose(true);







        }

    }



}
