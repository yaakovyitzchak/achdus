using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achdus {
	public class Ayin : Roochnee
	{
		public RenderTexture rt = null;
		public Camera ayinAdan = null;
		
		public Ayin() 
		: this(new Davar("{}")) {}
		
		public Ayin(Jint.Native.JsValue d) 
		: this(new Davar(d)) {}
		
		public Ayin(Davar d) : base(d) {
			ayinAdan = gameObject
			.AddComponent<
				Camera
			>();
		}
		
		public void Yoytzayr(Domem dm) {
			if(rt == null) {
				rt = new RenderTexture(
					1920,
					1080,
					24,
					RenderTextureFormat.ARGB32
				);
			}
			dm.renderer.material.mainTexture = 
			rt;
			if(ayinAdan != null) {
				ayinAdan.targetTexture = 
				rt;
			}
		}
	}
}
