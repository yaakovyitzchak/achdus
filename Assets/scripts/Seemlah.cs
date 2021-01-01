using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jint.Native;
using System;
namespace Achdus {
	public class Seemlah : Domem
	{
		public Cloth Kaylee = null;
		
		
		public Seemlah() : this(new Davar()) {}
		
		public Seemlah(JsValue j) : this(new Davar(j)) {}
		

		public Seemlah(Davar d) : base(d) {
			
			onOrNow(
				"KodemInit", 
				new Func<object, object>(
				(obj1) => {
					Kaylee = (
						gameObject.
						AddComponent<
							Cloth
						>()
					);
					return null;
				})
			);
		}
		
	}
}
