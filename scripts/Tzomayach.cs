using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
namespace Achdus
{
	
    public class Tzomayach : Domem
    {
        public GameObject parentGameObject;
        public GameObject target = null;
		public Animation chayoos;
		
        public Tzomayach() : this(new Davar("{}"))
        {
			
        }
		
		public Tzomayach(Jint.Native.JsValue d) : this(new Davar(d))
        {
			
        }
		
        public Tzomayach(Davar data) : base(data)
        {
			onOrNow(
				"KodemInit", 
				new Func<object, object>(
				(obj1) => {
					BoynayChayoosHanefesh(chayoosClips);
					Debug.Log("chayoos");
					return null;
				})
			);
        }
		
		public void PlayChayoos(string chayoosShaym) {
			if(chayoos != null) {
				COBY.queueOfActionsInMainThread.Add(() => {
					chayoos.Play(chayoosShaym);
				});
			}
		}
		
		public void PlayChayoosFade(string chayoosShaym) {
			if(chayoos != null) {
				COBY.queueOfActionsInMainThread.Add(() => {
					chayoos.CrossFade(chayoosShaym);
				});
			}
		}
		
		public void Shaynuh(string chayoosShaym) {
			if(chayoos != null) {
				COBY.queueOfActionsInMainThread.Add(() => {
					chayoos.Stop(chayoosShaym);
				});
			}
		}
		
		public void SetChayoosWrap(string wrapType) {
			if(chayoos != null) {
				switch(wrapType) {
					case "loop": 
					chayoos.wrapMode = WrapMode.Loop;
					break;
					case "once": 
					chayoos.wrapMode = WrapMode.Once;
					break;
					case "ping pong": 
					chayoos.wrapMode = WrapMode.PingPong;
					break;
					case "default": 
					chayoos.wrapMode = WrapMode.PingPong;
					break;
					case "liolam": 
					chayoos.wrapMode = WrapMode.ClampForever;
					break;
				}
			}
		}
		
		public void BoynayChayoosHanefesh(
			AnimationClip[] chayeem
		)
		{
			if(chayeem != null) {
				
				chayoos = gameObject.GetComponent<
					Animation
				>();
				if(chayoos == null) {
					chayoos = gameObject.AddComponent<
						Animation
					>();
				}
				
				
				foreach(AnimationClip an in chayeem) {
					an.legacy = true;
				
					
					
					
					chayoos.AddClip(
						an,
						an.name
					);
					
				}
				
				SetChayoosWrap("loop");
				
				

			}
		}
    }
}