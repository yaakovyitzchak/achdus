/// <summary> 
/// <summary> 
/// CameraControllercs.cs 
/// Camera Controller in CSharp v2.1 
/// </summary> 
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;/*
using System.Drawing;*/
namespace Achdus
{
    public class CameraController : MonoBehaviour
    {
		public bool stopit = false;
        public GameObject target;                           // Target to follow 
        public float targetHeight = -3f;                         // Vertical offset adjustment 
        public float distance = 12.0f;                            // Default Distance 
        public float offsetFromWall = 0.7f;                       // Bring camera away from any colliding objects 
        public float maxDistance = 20f;                       // Maximum zoom Distance 
        public float minDistance = 0.6f;                      // Minimum zoom Distance 
        public float xSpeed = 200.0f;                             // Orbit speed (Left/Right) 
        public float ySpeed = 200.0f;                             // Orbit speed (Up/Down) 
        public float yMinLimit = -80f;                            // Looking up limit 
        public float yMaxLimit = 80f;                             // Looking down limit 
        public float zoomRate = 40f;                          // Zoom Speed 
        public float rotationDampening = 3.0f;                // Auto Rotation speed (higher = faster) 
        public float zoomDampening = 2.0f;                    // Auto Zoom speed (Higher = faster) 
        public int collisionLayers;     // What the camera will collide with 
        public bool lockToRearOfTarget = false;             // Lock camera to rear of target 
        public bool allowMouseInputX = true;                // Allow player to control camera angle on the X axis (Left/Right) 
        public bool allowMouseInputY = true;                // Allow player to control camera angle on the Y axis (Up/Down) 
        public bool isMouseBusy = false;
        public int xPos = 30, yPos = 1000;

        private float xDeg = 0.0f;
        private float yDeg = 0.0f;
        private float currentDistance;
        private float desiredDistance;
        private float correctedDistance;
        private bool rotateBehind = false;
        private bool mouseSideButton = false, setCursor = false, mouseClickedToDrag = false;
		private bool isTargetted = false;
        private float pbuffer = 0.0f;       //Cooldownpuffer for SideButtons 
        private float coolDown = 0.5f;      //Cooldowntime for SideButtons  


        /*[StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        public class Point
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        /*
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public System.Int32 X;
            public System.Int32 Y;
        };

        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }*/
    //    [DllImport("__Internal")]
      //  static extern bool CGAssociateMouseAndMouseCursorPosition(bool yes);

        void Start()
        {
			//var ac = GetComponent<AudioListener>();
			//ac.enabled = false;
			//Debug.Log(ac);
            collisionLayers = LayerMask.GetMask("Default");



            Vector3 angles = transform.eulerAngles;
            xDeg = angles.x;
            yDeg = angles.y;
            currentDistance = distance;
            desiredDistance = distance;
            correctedDistance = distance;

            Camera.main.nearClipPlane = 0.01f;
            //CGAssociateMouseAndMouseCursorPosition (true);

            if (lockToRearOfTarget)
                rotateBehind = true;
        }
        void Update()
        {
			if(stopit) return;
            if (target == null)
            {
				isTargetted = false;
                target = GameObject.FindGameObjectWithTag("Player") as GameObject;

				
             //   Debug.Log("Looking for Player");
            } else if(!isTargetted){
				var col = (
					target
					.GetComponent<Collider>()
				);
				if(col != null) {
					targetHeight = (
						col.bounds.max.y
					);
				}
			}
			
			

        }

        //Only Move camera after everything else has been updated 
        void FixedUpdate()
        {
			if(stopit) return;
            // Don't do anything if target is not defined 
            if (target == null)
                return;
            //pushbuffer 
            if (pbuffer > 0)
                pbuffer -= Time.deltaTime;
            if (pbuffer < 0) pbuffer = 0;

            //Sidebuttonmovement 
            if ((Input.GetAxis("Strife") != 0) && (pbuffer == 0))
            {
                pbuffer = coolDown;
                mouseSideButton = !mouseSideButton;
            }
            if (mouseSideButton && Input.GetAxis("Vertical") != 0)
                mouseSideButton = false;

            Vector3 vTargetOffset;

            // If either mouse buttons are down, let the mouse govern camera position 
            bool isMoving = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;

            if (!isMouseBusy)
            {
                if ((UnityEngine.Input.GetMouseButton(0) || UnityEngine.Input.GetMouseButton(1)))
                {
                    if (!mouseClickedToDrag)
                    {
                        //     xPos = GetMousePosition().x;
                        //       yPos = GetMousePosition().y;

                        //  Cursor.visible = false;
                        //            Cursor.lockState = CursorLockMode.Locked;
                        mouseClickedToDrag = true;
                        setCursor = false;

                    }


                    //Check to see if mouse input is allowed on the axis 
                    if (allowMouseInputX)
                    {
                        xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                    //    Debug.Log("mouse moig!");
                    }
                    else
                        RotateBehindTarget();
                    if (allowMouseInputY)
                        yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                    //Interrupt rotating behind if mouse wants to control rotation 
                    if (!lockToRearOfTarget)
                        rotateBehind = false;
                }

                // otherwise, ease behind the target if any of the directional keys are pressed 
                else if (isMoving || rotateBehind || mouseSideButton)
                {
                    RotateBehindTarget();
                }

                if (!(UnityEngine.Input.GetMouseButton(0) || UnityEngine.Input.GetMouseButton(1)))
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;

                    mouseClickedToDrag = false;
                    if (!setCursor)
                    {

                        setCursor = true;

                    }

                }
            }
            else
            {
                mouseClickedToDrag = false;
                //       xPos = GetMousePosition().x;
                //      yPos = GetMousePosition().y;
            }

            if (mouseClickedToDrag)
            {
                //      SetCursorPos(xPos, yPos);
            }

            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);

            // Set camera rotation 
            Quaternion rotation = Quaternion.Euler(yDeg, xDeg, 0);

            // Calculate the desired distance 
            if (!isMouseBusy)
            {
                desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
                desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
                correctedDistance = desiredDistance;
            }

            // Calculate desired camera position 
            vTargetOffset = new Vector3(0, -targetHeight, 0);
			
            Vector3 position = target.transform.position - (rotation * Vector3.forward * desiredDistance + vTargetOffset);
			
            Vector3 temp = new Vector3(offsetFromWall, offsetFromWall, offsetFromWall);
            // Check for collision using the true target's desired registration point as set by user using height 
            RaycastHit collisionHit;
            Vector3 trueTargetPosition = new Vector3(target.transform.position.x, target.transform.position.y + targetHeight, target.transform.position.z);

            // If there was a collision, correct the camera position and calculate the corrected distance 
            var isCorrected = false;
            if (Physics.Linecast(trueTargetPosition, position - temp, out collisionHit, collisionLayers))
            {
                // Calculate the distance from the original estimated position to the collision location, 
                // subtracting out a safety "offset" distance from the object we hit.  The offset will help 
                // keep the camera from being right on top of the surface we hit, which usually shows up as 
                // the surface geometry getting partially clipped by the camera's front clipping plane. 
                correctedDistance = Vector3.Distance(trueTargetPosition, collisionHit.point) - offsetFromWall;
                isCorrected = true;
            }

            /*   if (Physics.Linecast(trueTargetPosition, position, out collisionHit, collisionLayers))
               {
                   correctedDistance = Vector3.Distance(trueTargetPosition, collisionHit.point) - offsetFromWall;
                   isCorrected = true;
               }*/

            // For smoothing, lerp distance only if either distance wasn't corrected, or correctedDistance is more than currentDistance
            currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * zoomDampening) : correctedDistance;

            // Keep within limits 
            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

            // Recalculate position based on the new currentDistance 
            position = target.transform.position - (rotation * Vector3.forward * currentDistance + vTargetOffset);

            //Finally Set rotation and position of camera 
            transform.rotation = rotation;
            transform.position = position;

        }

        public void SnapToTarget()
        {
            var tempE = transform.eulerAngles;
            xDeg = target.transform.eulerAngles.y;
            yDeg = target.transform.eulerAngles.x;
            tempE.y = target.transform.eulerAngles.y;
            transform.eulerAngles = tempE;
            lockToRearOfTarget = true;
        }

        private void RotateBehindTarget()
        {
            float targetRotationAngle = target.transform.eulerAngles.y;
            float currentRotationAngle = transform.eulerAngles.y;
            xDeg = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, rotationDampening * Time.deltaTime);

            // Stop rotating behind if not completed 
            if (targetRotationAngle == currentRotationAngle)
            {
                if (!lockToRearOfTarget)
                    rotateBehind = false;
            }
            else
                rotateBehind = true;

        }


        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360f)
                angle += 360f;
            if (angle > 360f)
                angle -= 360f;
            return Mathf.Clamp(angle, min, max);
        }

    }
}