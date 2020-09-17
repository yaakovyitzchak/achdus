using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Achdus
{
    public class NivraTriggers : MonoBehaviour
    {
        public Achdus.Nivra Nivra;
		public Davar userData = new Davar();
		
        public void Init(Nivra davar)
        {
            Nivra = davar;
        }
		
        public void Start()
        {
           if (Nivra != null) Nivra.Start();
        }

        private void OnTriggerEnter(Collider other)
        {
			
            if (Nivra != null) {
				Nivra.OnTriggerEnter(other);

			}
        }

        private void OnTriggerExit(Collider other)
        {
            if (Nivra != null) Nivra.OnTriggerExit(other);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (Nivra != null) Nivra.OnControllerColliderHit(hit);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (Nivra != null) Nivra.OnCollisionEnter(other);
        }

        private void OnCollisionStay(Collision other)
        {
            if (Nivra != null) Nivra.OnCollisionStay(other);
        }

        private void OnCollisionExit(Collision other)
        {
            if (Nivra != null) Nivra.OnCollisionExit(other);
        }

        private void Update() {
            if(Nivra != null)    Nivra.Update();
        }

        private void FixedUpdate() {
            if(Nivra != null) Nivra.FixedUpdate();
        }

        private void LateUpdate() {
            if (Nivra != null) Nivra.LateUpdate();
        }


    }
}