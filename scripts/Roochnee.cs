using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Achdus {
	public class Roochnee : Heeoolee
	{
		public Roochnee() 
		: this(new Davar("{}")){}
		
		public Roochnee(Jint.Native.JsValue d) 
		: this(new Davar(d)){}
		
		public Roochnee(Davar d) : base(d) {
			gameObject = new GameObject(tmpName);
			AyshPeula("KodemInit", this);
			
			AyshPeula("Init", this);
			AyshPeula("Neeor", this);
		}
	}
}