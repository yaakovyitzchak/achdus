using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Jint.Native;

namespace Achdus {
	public class Yisayruh {
		/*public static byte[] getFileBytes(string path) {
			 if(
			 path.IndexOf("http://") > -1 || path.IndexOf("https://") > -1
			 ) {
			 
			 }
		}*/
		
		public static float[] floater(
			JsValue j
		) {
			
			/*var arr = j.AsArray();
			//uint length = arr.GetLength();
			//float[length] r = {};
			foreach(var k in arr) {
				
			}
		/*	for(var i = 0; i < length; i++) {
				
			}*/
			var lngth = (int)j.AsNumber();
			float[] r = new float[lngth];
			return r;
		}
		public static float[] float32() {
			return new float[32];
		}
	}

	public class KolDodi
	{
		public class KolClip {
			public AudioClip kol = null;
			public KolClip(AudioClip ac) {
				kol = ac;
			}
		}
		public static class ok {
		
		}
		
		public static KolClip BorayKolClip(
			AudioClip kol
		) {
			return new KolClip(kol);
		}
		
		public static KolMakor BorayKolMakor() {
			return new KolMakor();
		}
		
		public static KolMakor BorayKolMakor(
			GameObject go
		) {
			return new KolMakor(go);
		}
		
		public class KolMakor {
			public AudioSource makor = null;
			
			private KolClip _clip = null;
			public KolClip clip {
				get {
					return _clip;
				} 
				set {
					_clip = value;
					if(makor != null) {
						makor.clip = 
							value.kol;
					}
				}
			}
			
			public KolClip kol {
				get {
					return clip;
				}
				set {
					clip = value;
				}
			}
			public KolMakor(
				GameObject go
			) {
				AudioSource auds = null;
				if(go != null) {
					auds = go.AddComponent<
						AudioSource
					>();
				}
				makor = auds;
			}
			
			public KolMakor() :
			this(new GameObject())
			{}
			
			public void Play() {
				if(makor != null) {
					makor.Play();
				}
			}
			
			public void Stop() {
				if(makor != null) {
					makor.Stop();
				}
			}
			
			public void Pause() {
				if(makor != null) {
					makor.Pause();
				}
			}
			
			
			public void GetOutputData(
				float[] fl,
				int chnl,
				Func<object,object> fnc
			) {
				if(makor != null) {
					Yaakov
					.IkarThread(() => {
						Debug.Log("almost" + fl[3]);
						makor
						.GetOutputData(
							fl,
							chnl
						);
						fnc?.Invoke(fl);
					//	return fl;
						//Debug.Log("wow man" + fl[3]);
					});
				} else {
					Debug.Log("nuld?");
				} 
			}

		}
		

		
		public static void GetKol(
			string url,
			Func<JsValue, JsValue[], JsValue> fnc
		) {
			var rek = (
				UnityWebRequestMultimedia
				.GetAudioClip(
					url,
					AudioType.WAV
				)
			);
			var sant = rek.SendWebRequest();
			sant.completed += (hi) => {
				var c = (
					DownloadHandlerAudioClip
					.GetContent(
						rek
					)
				);
				fnc?.Invoke(
					1,
					new JsValue[]{
						Heeoolee
						.JewS(
							new KolClip(
								c
							)
						)
					}
				);
				
			};
		}
	}
}