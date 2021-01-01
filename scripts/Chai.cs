using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
namespace Achdus
{
    public class Chai : Tzomayach
    {
        public Achdus.InputSystem myInput = new Achdus.InputSystem();
        public Rigidbody myRigid = null;
        public CapsuleCollider capsuleCollider = null;
        
        public float movementSpeed = 5,
            moveH = 0,
            moveV = 0,
            moveS = 0,
            direction = 0,
            turningSpeed = 3,
            jumpiness = 6.0f,
            originalJumpiness,
            actualSpeed = 0f,
            vSpeed = 5f,
            slopeSpeed = 8f,
            mySlopeLimit = 45f;

        public bool jumped = false, 
            isFlying = false, 
            isFalling = false,
            overrideJump = false, 
            canJump = true, 
            isSliding = false, 
            inFrontAboutToSlide = false,
            startedSliding = false;

        public Vector3 moveVec = new Vector3(),
            hitN = new Vector3(),
            frontHitN = new Vector3(),
            inputV = new Vector3();

        public Quaternion turningQ;
		
		
		public Chai(Jint.Native.JsValue d) : this(
			new Davar(d)
		)
        {
			
        }

        public Chai(Davar data) : base(data) {}

        public override void Init()
        {
			
            base.Init();
			meen = "chai";
            originalJumpiness = jumpiness;
            MakeParentCapsule();
            _modelGameObject = gameObject;
			if(parentGameObject != null) {
				gameObject = parentGameObject;
				gameObject.name = _modelGameObject.name;
				_modelGameObject.name += "_model";
			}
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            analyzeInputVectorsAndResetVariables();
            jumpLogicAndGravity();
            adjustMovmentVectorToCurrentVariables();
            slidingLogic();
            finalizeMovement();
        }


        
        public void GetNormalToGroundFromInFront()
        {
            RaycastHit hit;
            var tempDir = direction + 90f;
            var xValue = -Mathf.Cos(tempDir * Mathf.Deg2Rad);
            var zValue = Mathf.Sin(tempDir * Mathf.Deg2Rad);
            Vector3 start = parentGameObject.transform.position;
            var distanceOut = controller.radius + controller.skinWidth;
            var amountUpAgain = 0.5f;
            start.x += xValue * distanceOut;
            start.y -= controller.height / 2 - amountUpAgain;
            start.z += zValue * distanceOut;
            var distanceDown = amountUpAgain * 2;
            if (vSpeed <= 0)
            {
                if (Physics.Raycast(start, -parentGameObject.transform.up, out hit, distanceDown))
                {
                    if(hit.collider.gameObject != null && hit.collider.gameObject.tag != "Player") {
                        frontHitN = hit.normal;
                    //     Debug.Log("normally? " + frontHitN);
                        Debug.DrawRay(start, -parentGameObject.transform.up, Color.blue, 0, true);
                    }
                }
            }
        }

        
        public void OnSlideStart()
        {

            moveH = 0;
        //    Debug.Log(moveVec.y = 0);
            moveV = 0;
        //    Debug.Log("Just staretd sliding!");
            startedSliding = true;
        }

        public void OnSlideEnd()
        {
     //       Debug.Log("Just stopped sliding!");
            myRigid = null;

            startedSliding = false;
        }

        public override void OnControllerColliderHit(ControllerColliderHit hitted)
        {
            Vector3 start = parentGameObject.transform.position;
            start.y -= controller.height / 2;
            RaycastHit hit;
            hitN = new Vector3();
            if (Physics.Raycast(start, -parentGameObject.transform.up, out hit, Mathf.Infinity))
            {
                hitN = hit.normal;
                //    Debug.DrawRay(start, -parentGameObject.transform.up, Color.red, 0, true);
            }


            //    Debug.Log("Controller hitting!");
        }

        void MakeParentCapsule()
        {
            
            var solidAttempt = gameObject.transform.FindDeepChild("solid");
            if (solidAttempt != null)
            {
				parentGameObject = solidAttempt.gameObject;
				
				parentGameObject.transform.SetParent(
					gameObject.transform.parent
				);
				
				parentGameObject.GetComponent<Renderer>().enabled = false;
				
				
				
				
				controller = parentGameObject.AddComponent<
					CharacterController
				>();
				
				
				Vector3 tempPos = gameObject.transform.position;
				
				tempPos.y -= controller.skinWidth / 2;
				
				gameObject.transform.position = tempPos;
				
				
				
		
				var creation = parentGameObject.AddComponent<
					NivraTriggers
				>();
				creation.Init(this);
				
				
				gameObject.transform.SetParent(
					parentGameObject.transform
				);
            }
			
        }

        void analyzeInputVectorsAndResetVariables() {
            if (!overrideJump)
                jumped = false;

            isFalling = false;
            moveH = 0;
            moveV = 0;
            moveS = 0;
            moveH = myInput.GetAxisRaw("Horizontal");
            moveV = myInput.GetAxisRaw("Vertical");
        
            try
            {
                moveS = myInput.GetAxisRaw("Strife");
            }
            catch
            {

            }

            direction += moveH * turningSpeed;

            
            turningQ = Quaternion.Euler(0, direction, 0);

            Vector3 movement = new Vector3(moveV, 0, 0);
            
            
        }

        void jumpLogicAndGravity() {
            regularGravity += Physics.gravity.y * Time.deltaTime;
            if (controller.isGrounded/* && !isSliding*/)
            {
                vSpeed = -10f;
                regularGravity = 0f;

            } else 
            {
                vSpeed = regularGravity;

            }

            if ((controller.collisionFlags & CollisionFlags.Above) != 0)
            {
                if (vSpeed > 0)
                {
                    vSpeed *= -1;
                    regularGravity = 0;
                }
            }

            if (myInput.GetAxisRaw("Jump") > 0 && controller.isGrounded/* && !isSliding*/)
            {
                jumped = canJump;

            }

            if (jumped)
            {

                regularGravity = jumpiness;
                vSpeed = jumpiness;
                jumpiness = originalJumpiness;
                overrideJump = false;
            }
        }


        

        void adjustMovmentVectorToCurrentVariables() {
            inputV = new Vector3(moveS, 0, moveV);

            inputV.Normalize();

            actualSpeed = movementSpeed;

            moveVec = turningQ * inputV;
            moveVec *= actualSpeed;
            moveVec.y = vSpeed;
        }

        void slidingLogic() {
            if (isSliding)
                {
                    moveVec.x += (1f - hitN.y) * hitN.x * slopeSpeed;
                    vSpeed = -10f;
                    moveVec.z += (1f - hitN.y) * hitN.z * slopeSpeed;
                }

                 
                frontHitN = new Vector3();
                GetNormalToGroundFromInFront();
                
                isSliding = !(Vector3.Angle(Vector3.up, hitN) <= mySlopeLimit);
                inFrontAboutToSlide = !(Vector3.Angle(Vector3.up, frontHitN) <= mySlopeLimit);

                if (isSliding)
                {
                    if (!startedSliding)
                    {
                        OnSlideStart();
                    }
                }
                else
                {
                    if (startedSliding)
                    {
                        OnSlideEnd();
                    }
                }
        }

        void finalizeMovement() {
            
            _modelGameObject.transform.rotation = turningQ;
            parentGameObject.transform.rotation = turningQ;
           
            if (controller.enabled) controller.Move(moveVec * Time.deltaTime);
        }


    }
}