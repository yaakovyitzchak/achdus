//B"H
using UnityEngine;
namespace Achdus {
	public class Briah {
		public static Color toyharMareh = new Color(0f,0f,0f,0f);
		public static Camera Ayin = null;
		public static Camera AyinShayneeh = null;
		
		public static void EtzemHashamayimLiToyhar() {
			EtzemHashamayimLiToyhar(new Davar("{}"));
		}
		
		public static void EtzemHashamayimLiToyhar(Jint.Native.JsValue js) {
			EtzemHashamayimLiToyhar(new Davar(js));
		}
		
		public static void EtzemHashamayimLiToyhar(
			Davar dv
		) {
			if(Ayin == null) 
				Ayin = Yaakov.mainCoby.ikarAyin;
				
			if(AyinShayneeh == null) 
				AyinShayneeh = Yaakov.mainCoby.shneeuh;
			string meen = dv["meen"] is string ? 
							dv["meen"] : "";
			
			Ayin.clearFlags = (
				meen == "rakia" ?
					CameraClearFlags.Skybox :
				meen == "oymik" ?
					CameraClearFlags.Depth :
				meen == "efess" ?
					CameraClearFlags.Nothing :	
				CameraClearFlags.SolidColor
			);
			Ayin.backgroundColor = (
				Mareh(dv["mareh"])
			);
			
			AyinShayneeh.clearFlags = Ayin.clearFlags;
			AyinShayneeh.backgroundColor = Ayin.backgroundColor;
		}
		
		public static Color Mareh(object clr) {
			Color cl = toyharMareh;
			if(clr is string) {
				
			
				if (
					ColorUtility
					.TryParseHtmlString(
						clr as string, out Color myColor
					)
				) {
					cl = myColor;
				}
				return cl;
			}
			
			if(clr is Jint.Native.JsValue) {
				return Mareh(
					new Davar(clr as Jint.Native.JsValue)
				);
			}
			
			if(clr is Davar) {
				Davar d = clr as Davar;
				float r = d["r"] != null ? d["r"] : 0;
				float g = d["g"] != null ? d["g"] : 0;
				float b = d["b"] != null ? d["b"] : 0;
				float a = d["a"] != null ? d["a"] : 1;
				cl = new Color(
					r,
					g,
					b,
					a
				);
			}
			
			return cl;
		}
		
	}
}
