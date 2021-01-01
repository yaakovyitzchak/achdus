using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using SimpleJSON;
using System;
namespace Achdus
{
	
    public class Tzomayach : Domem
    {
        public GameObject parentGameObject;
        public GameObject _modelGameObject;
        public GameObject target = null;
		public Animation chayoos;
		
        public Tzomayach() : this(new Davar("{}"))
        {
			
        }
		
		public Tzomayach(Jint.Native.JsValue d) : this(new Davar(d))
        {
			
        }
		
		private List<string>
		_chayoosQ = new List<string>();
		
        public Tzomayach(Davar data) : base(data)
        {
			
			onOrNow(
				"KodemInit", 
				new Func<object, object>(
				(obj1) => {
					BoynayChayoosHanefesh(chayoosClips);
					return null;
				})
			);
			
			on("Update", new Func<object, object>((o) => {
				if(chayoos != null) {
					
					if(_chayoosQ.Count > 0) {
						for(
							var i = 0; 
							i < _chayoosQ.Count; 
							i++
						) {
							chayoos.Play(_chayoosQ[i]);
						}
					}
				}
				return null;
			}));
        }
		
		public void Update() {
			
		}
		
		public void PlayChayoos(string chayoosShaym) {
			if(chayoos != null) {
				COBY.queueOfActionsInMainThread.Add(() => {
			//		if(chayoos[chayoosShaym] != null)
						chayoos.Play(chayoosShaym);
				});
			} else {
				_chayoosQ.Add(chayoosShaym);
			}
		}
		
		public void PlayChayoosFade(string chayoosShaym) {
			if(chayoos != null) {
				COBY.queueOfActionsInMainThread.Add(() => {
					if(chayoos[chayoosShaym] != null)
						chayoos.CrossFade(chayoosShaym);
				});
			}
		}
		
		public void SleepChayoos(string chayoosShaym) {
			Shaynuh(chayoosShaym);
		}
		
		public void ShaynuhChayoos(string chayoosShaym) {
			Shaynuh(chayoosShaym);
		}
		
		public void Shaynuh(string chayoosShaym) {
			if(chayoos != null) {
				COBY.queueOfActionsInMainThread.Add(() => {
					if(chayoos[chayoosShaym] != null)
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
					case "forever": 
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
				var go = gameObject;
				if(meen == "chai") {
					go = _modelGameObject;
				}
				chayoos = go.GetComponent<
					Animation
				>();
				if(chayoos == null) {
					chayoos = go.AddComponent<
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