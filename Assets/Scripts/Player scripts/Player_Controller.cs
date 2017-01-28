using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(CharacterController))]
public class Player_Controller : MonoBehaviour {

 //   [SerializeField]
 //   private bool isWalking;
 //   [SerializeField]
 //   private float walkSpeed;
 //   [SerializeField]
 //   private float runSpeed;
 //   [SerializeField]
 //   private float jumpSpeed;
 //   [SerializeField]
 //   private float stickToGroundForce;
 //   [SerializeField]
 //   private float gravityMultiplier;
 //   [SerializeField]
 //   private MouseLook mouseLook;

 //   private bool jump;
 //   private float YRot;
 //   private Vector2 input;
 //   private Vector3 moveDirection = Vector3.zero;
 //   private CharacterController charController;
 //   private CollisionFlags collisionFlags;
 //   private bool prevGrounded;
 //   private Vector3 originalCamPos;
 //   private bool jumping;

 //   void OnEnable() 
	//{
	//	SetInitialReferences();	
	//}

 //   void Update()


	//void SetInitialReferences() 
	//{
 //       charController = GetComponent<CharacterController>();
 //       originalCamPos = GetComponent<Camera>().transform.localPosition;
 //       jumping = false;
 //       mouseLook.Init(transform, GetComponent<Camera>().transform);
 //   }

 //   private void UpdateCameraPosition(float speed)
 //   {
 //       Vector3 newCameraPos;
 //       if(charController.velocity.magnitude > 0 && charController.isGrounded)
 //       {
 //           GetComponent<Camera>().transform.localPosition =
 //       }
 //   }
}
