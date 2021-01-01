using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Jint.Native;
using System.IO;
namespace Achdus {
	public class Yisayruh {
		/*public static byte[] getFileBytes(string path) {
			 if(
			 path.IndexOf("http://") > -1 || path.IndexOf("https://") > -1
			 ) {
			 
			 }
		}
		public static void SetPropertyValue
		(object p_object, string p_propertyName, object value) {
			PropertyInfo property = (
				p_object
				.GetType()
				.GetProperty(p_propertyName)
			);
			property
			.SetValue(
				p_object, 
				Convert.ChangeType(
					value, property.PropertyType
				),
				null
			);
		}
		public static object GetPropertyValue<T>
		(object obj, string propName) { 
			var prop = (
				
				obj
				.GetType()
				.GetProperty(propName)
			); 
			if(prop != null) {
				return (T) prop.GetValue(obj, null);
			} else return default(T);
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
		public static float[] ConvertByteToFloat(byte[] array) {
		  float[] floatArr = new float[array.Length / 4];
		  for (int i = 0; i < floatArr.Length; i++) {
			if (BitConverter.IsLittleEndian) {
			  Array.Reverse(array, i * 4, 4);
			}
			floatArr[i] = BitConverter.ToSingle(array, i * 4);
		  }
		  return floatArr;
		}
		
		public static void Kol(
			string path, 
			System.Func<
				JsValue, JsValue[], JsValue
			> fun
		) {
			Kol(
				path, new GameObject(), fun
			);
		}
		
		public static void Kol(
			string path, 
			GameObject go,
			System.Func<
				JsValue, JsValue[], JsValue
			> fun
		) {
			new Giluy(
				path,
				true,
				new System.Action<object, string>(
					(rez, err) => {
						if(rez is byte[] b) {
							var stream = new System.IO.MemoryStream(b);
							var mf = new NLayer.MpegFile(stream);
							var samp = new float[
								mf.Length
							];
							mf.ReadSamples(
								samp,
								0,
								(int)mf.Length
							);
							var clap = AudioClip.Create(
								path,
								samp.Length,
								mf.Channels,
								mf.SampleRate,
								false
							);
						//	clap.loadInBackground = true;
							clap.SetData(samp,0);
							var kold = new KolMakor(go);
							var klip = new KolClip(clap);
							kold.clip = klip;
							fun(1, new JsValue[] {Heeoolee.JewS(kold)});
						}
						
						if(err != null) {
							fun(1, new JsValue[]{
								null,
								"dude there's an error" + err
							});
						}
					}
				)
			);
		}
		
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
			public float[] mirachefess = null;
			private KolClip _clip = null;
			private Action oyk = null;
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
			
			public void HeessCheelTzayad(
				string fncName,
				int chnl
			) {
				if(mirachefess == null) {
					mirachefess = new float[32];
				}
				if(oyk == null) {
					oyk = () => {
						makor
						.GetOutputData(
							mirachefess,
							chnl
						);
					};
				}
				Yaakov.on(fncName, oyk);
			}
			
			
			
			public void HeessCheelTzayad() {
				HeessCheelTzayad("FixedUpdate", 0);
			}
			
			public void YoyshayvTzayad() {
				YoyshayvTzayad("FixedUpdate");
			}
			
			public void YoyshayvTzayad(string fnc) {
				if(oyk != null) {
					Yaakov.removeEvent(fnc, oyk);
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
			Func<JsValue, JsValue[], 
			JsValue> fnc
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

