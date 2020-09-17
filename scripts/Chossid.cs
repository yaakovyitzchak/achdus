using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using SimpleJSON;
using static UnityEngine.MonoBehaviour;
namespace Achdus
{
    public class Chossid : Medabeir
    {

 
        public float speed = 5;
        public float flyingSpeed = 5;

        public int howMuchScore = 5;
        public Text counText;
		public bool ruhtzon = true;
   
        private Vector3 down;
        public GameObject mount, myOrigin, model, water;
        private CharacterController cont;
        private CharacterController mountCont;
        public Dictionary<string, AnimationClip> animationClips;

       
        
        public Chossid() : this(null) {}

        public Chossid(dynamic data) : base(new Davar(data))
        {
            isSelectable = false;
       //     Start();
        
    
        }

        public void Start()
        {
           
           
            cont = parentGameObject.GetComponent<CharacterController>();

      //      parentGameObject.tag = "Player";
            parentGameObject.layer = 2;

            originalJumpiness = jumpiness;


            if (mount)
                mountCont = mount.GetComponent<CharacterController>();

        }



        public override void FixedUpdate()
        {
			if(ruhtzon) {
				myInput.SetAxis("Horizontal", Achdus.Input.GetAxis("Horizontal"));
				myInput.SetAxis("Vertical", Achdus.Input.GetAxis("Vertical"));
				myInput.SetAxis("Jump", Achdus.Input.GetAxis("Jump"));
				

				if (UnityEngine.Input.GetMouseButton(1))
				{
					direction = Camera.main.gameObject.transform.eulerAngles.y;
					if (UnityEngine.Input.GetMouseButton(0))
					{
						moveV = 1;
					} 
					Cursor.lockState = CursorLockMode.Confined;

				}
				if (!UnityEngine.Input.GetMouseButton(0) && !UnityEngine.Input.GetMouseButton(1))
				{
					Cursor.visible = true;
				}
				
			}
            base.FixedUpdate();

            



        }

        


        

        public void Jump(float force)
        {
            if (!jumped)
            {
                jumped = true;
                originalJumpiness = jumpiness;
                jumpiness = force;
                overrideJump = true;
            }
        }

        public void IncreaseSize(float amount)
        {
            Vector3 temp = gameObject.transform.localScale;
            temp = temp * amount;
            gameObject.transform.localScale += temp;
        }


        public override void OnCollisionStay(Collision other)
        {

            //   hitN = other.contacts[0].normal;
        }

        

        public override void OnTriggerEnter(Collider col)
        {
			base.OnTriggerEnter(col);
            if (col.tag != "Water")
            {
                var script = col.gameObject.GetComponent<CollectableItem>();

                if (col.gameObject.tag == "mount")
                {
                    mount = col.gameObject;
                    mount.gameObject.transform.parent = gameObject.transform;
                    isFlying = true;

                }

                if (script != null)
                {
                    int id = script.itemID;
                    col.gameObject.SetActive(false);
                    print("hit item " + id);
                }
                else
                {

                }
            }
            else
            {
                if (gameObject.transform.position.y > col.gameObject.transform.position.y)
                    water = col.gameObject;
            }

        }

        public override void OnTriggerExit(Collider col)
        {
			base.OnTriggerExit(col);
            if (gameObject.transform.position.y > col.gameObject.transform.position.y)
                water = null;
        }

        bool isUnderwater = false;
        void checkWater()
        {
            if (water != null && Camera.main.gameObject.transform.position.y < water.gameObject.transform.position.y)
            {
                if (!isUnderwater)
                {
                    RenderSettings.fog = true;
                    RenderSettings.fogDensity = 0.15f;
                    RenderSettings.fogMode = FogMode.Exponential;
                    RenderSettings.fogColor = new Color(0.1f, 0.2f, 0.5f, 0.7f);
                    print("hi");
                    isUnderwater = true;
                }
            }
            else
            {
                if (isUnderwater)
                {
                    RenderSettings.fog = false;

                    print("bye!");
                    isUnderwater = false;
                }
            }
        }


        void mountOrUnmount()
        {
            if (isFlying)
            {
                isFlying = false;
                gameObject.transform.parent = null;
                vSpeed = 0;
                regularGravity = 0;
                mount.SetActive(false);
            }
            else
            {
                mount.SetActive(true);

                GameObject seat = mount.gameObject.transform.Find("seat").gameObject;


                Vector3 pPosition = gameObject.transform.position;

                mount.gameObject.transform.position = pPosition;

                gameObject.transform.parent = mount.gameObject.transform;
                Vector3 footHolding = seat.gameObject.transform.localPosition;
                footHolding.y += cont.bounds.size.y / 2;
                gameObject.transform.localPosition = footHolding;

                isFlying = true;
            }
        }



        float RadiansToDegrees(float radian)
        {
            return (Mathf.PI * radian) / 180;
        }

        float DegreesToRadians(float degree)
        {
            return ((degree * 180) / (Mathf.PI));
        }


    }
}