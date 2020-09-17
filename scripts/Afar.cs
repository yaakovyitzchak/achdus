using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jint.Native;
using System;
namespace Achdus {
	public class Afar : Domem
	{
		public ParticleSystem AfarSystem = null;
		
		public Afar(JsValue j) : this(new Davar(j)) {}
		
		public Afar(Davar d) : base(d) {
			
			onOrNow(
				"KodemInit", 
				new Func<object, object>(
				(obj1) => {
					AfarSystem = (
						gameObject.
						AddComponent<
							ParticleSystem
						>()
					);
					return null;
				})
			);
		}
	}
}
