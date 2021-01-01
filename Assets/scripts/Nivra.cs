using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jint.Native;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
namespace Achdus {
    
    public class Nivra : Heeoolee {
        public int NivraID = -1;
		public NivraTriggers nivraTenua;
		
		public AnimationClip[] chayoosClips = null;
        public Nivra() : this(new Davar()) { }
        public Nivra(JsValue data) : this(new Davar(data)) 
		{}
        public Nivra(Davar data) : base(data) {
           
        }
		
		
		public virtual void HeessCheel() {
			
		}
		
		public virtual void KodemInit() {
			
		}
		
		private NivraTriggers _olamd = null;
		public NivraTriggers nivraTriggers {
			get {
				if(_olamd == null) {
					_olamd = (
						gameObject.
						AddComponent<
							NivraTriggers
						>()
					);
					_olamd.Init(this);
				}
				return _olamd;
			} set {
				if(value == null) {
					MonoBehaviour.
					Destroy(_olamd);
				}
			}
		}
		
        
		
    }

    
}