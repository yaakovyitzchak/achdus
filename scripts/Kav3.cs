using UnityEngine;


namespace Achdus {

	
	public class Kav3 : Chochmah {
		private float _x;
		private float _y;
		private float _z;
		private Davar dv = new Davar();
		public float x {
			get {
				return _x;
			} set {
				_x = value;
				dv["property"] = "x";
				dv["value"] = value;
				
				AyshPeula("shinuy", dv);
				AyshPeula("change", dv);
				
			}
		}
		
		public float y {
			get {
				return _y;
			} set {
				_y = value;
				dv["property"] = "y";
				dv["value"] = value;
				
				AyshPeula("shinuy", dv);
				AyshPeula("change", dv);
				
			}
		}
		
		public float z {
			get {
				return _z;
			} set {
				_z = value;
				dv["property"] = "z";
				dv["value"] = value;
				
				AyshPeula("shinuy", dv);
				AyshPeula("change", dv);
				
			}
		}
		
		public Kav3(float x, float y, float z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}
		
		public void Mechabayr(
			Transform parent,
			string propName
		) {
			
		}
		
		public void Set(Vector3 v) {
			x = v.x;
			y = v.y;
			z = v.z;
		}
		
		
		
		public void Set(Quaternion v) {
			x = v.x;
			y = v.y;
			z = v.z;
		}
		
		public Vector3 ToVector3() {
			return new Vector3(x, y, z);
		}
		
		public override string ToString() {
			return (
				"{\"x\":"
				+ x 
				+ ",\"y\": "
				+ y 
				+ ",\"z\": " 
				+ z + "}"
			);
		}
		
		public Kav3(float x, float y) : this(x,y,0) {}
		public Kav3(float x) : this(x,0,0) {}
		public Kav3() : this(0,0,0) {}
		
	}
}