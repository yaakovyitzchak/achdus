//B"H
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.Rendering;

using System;
namespace Achdus {
	public class Asiyah : MonoBehaviour
	{
		public static string MachnEfes(string z, int nm) {
			string rz =z;
			while(rz.Length < nm) {
				rz = "0" + rz;
			}
			return rz;
		}
		public static bool KoysayvShtarShawlaym(string shaym, string toychin) {
			try {
				System.IO.File.WriteAllBytes(
					shaym,
					System.Text.Encoding.Unicode.GetBytes(toychin)
				);
				return true;
			} catch(Exception e){
				return false;
			}
		}
		public string mat = "";
		public string shaym = "";
		RenderTexture rt;
		UTJ.FrameCapturer 
		.MovieEncoder enc;
		double lastFrame;
		double thisFrame;
		double toytilTime = 0;
		Camera ayin;
		bool started = false;
		bool ratzoo = true;
		public UTJ.FrameCapturer
				.MovieEncoderConfigs fig;
		void Start(){
			
		}
		
		public void Hoysscheel()
		{
			Hoysscheel("oynk_" + Achshawv());
		}
		
		public void Oymayd() {
			ratzoo = false;
		}
		
		public void Hoysscheel(
			string shaym
		) {
			Hoysscheel(shaym, "webm");
		}
		public string shtarShaym = "";
		public bool hoyseefZmaneem = false;
		public bool shtarify = false;
		public void Hoysscheel(
			string shaym,
			string meen
		) {
			Hoysscheel(shaym, meen, "");
		}
		
		public string meen;
		public string ikarShaym = "";
		public void Hoysscheel(
			string shaym,
			string meen,
			string isLayv
		)
		{
			this.meen = meen;
			this.shaym = shaym;
			mat = isLayv;
			started = true;
			ratzoo = true;
			ayin = GetComponent<Camera>();
			lastFrame = Achshawv();
			thisFrame = lastFrame;
			rt = new RenderTexture(
				1920,1080,24,RenderTextureFormat.ARGB32
			);
			 fig = new 
			UTJ.FrameCapturer
			.MovieEncoderConfigs(
				meen == "png" ? 
				
				UTJ.FrameCapturer
				.MovieEncoder.Type.Png 
				: meen == "exr" ?
				
				UTJ.FrameCapturer
				.MovieEncoder.Type.Exr
				: meen == "mp4" ?
				
				UTJ.FrameCapturer
				.MovieEncoder.Type.MP4
				: meen == "gif" ?
				
				UTJ.FrameCapturer
				.MovieEncoder.Type.Gif 
				: 
				UTJ.FrameCapturer
				.MovieEncoder.Type.WebM
			);
			fig.Setup(1920, 1080);
		
			if(
				fig.format == 
				UTJ.FrameCapturer
				.MovieEncoder.Type.WebM
			) {
				
			}
			enc = 
			UTJ.FrameCapturer
			.MovieEncoder.Create(
				fig, shaym
			);
			
			isPic = (
				meen == "png" ||
				meen == "exr"
			);
			
			if(isPic && shtarify) {
				ikarShaym = 
				toyldoysAcharOysHaAcharoyn(
					shaym, '/'
				);
				Shtarify(
					shaym, meen
				);
			}
		}
		
		public static
		string toyldoysAcharOysHaAcharoyn(
			string yisoyd,
			char charif
		) {
			string rez = yisoyd;
			int foundInd = -1;
			int i;
			for(
				i = yisoyd.Length - 1;
				i > 0;
				i--
			) {
				if(yisoyd[i] == charif) {
					foundInd = i;
					break;
				}
			}
			if(foundInd > -1) {
				rez = "";
				for(
					i = foundInd + 1;
					i < yisoyd.Length;
					i++
				) {
					rez += yisoyd[i];
				}
			}
			return rez;
		}
		
		
		public System.IO.FileStream nahar = null;
		public System.IO.BinaryWriter shneeIO = null;
		void Shtarify(
			string shaym, string meen
		) {
			
			if(nahar == null) {
				nahar = new System
					.IO
					.FileStream(
						shaym +
						"_shtarific.txt",
						System.IO
						.FileMode
						.Create
					);
				shneeIO = new System
					.IO
					.BinaryWriter(
						nahar
					);
				shneeIO
				.Write(
					System
					.Text
					.Encoding
					.UTF8
					.GetBytes(
						"#B\"H\n" + 
						"ffconcat" +
						" version 1.0"
					)
				);
				
			}
		}

		// Update is called once per frame
		
		int h  = 0;
		bool done = false;
		bool firstTime = false;
		public bool isPic = false;
		public static DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		public List<double> zmanz = new
			List<double>();
		public double Achshawv() {
			return (
				(
					DateTime
					.UtcNow
					- Epoch
				).
				TotalMilliseconds
			);
		}
		int shtareemDon = 0;
		void Update()
		{
			if(!started)
				return;
			if(ayin.targetTexture == null) {
				ayin.targetTexture = rt;
				ayin.Render();
			}
			if(!firstTime) {
				firstTime = true;
				lastFrame = Achshawv();
			}
			if(!done) {
			thisFrame = Achshawv() - lastFrame;
			toytilTime += thisFrame;
			
			if(!ratzoo) {
				done = true;
				enc.Release();
				enc = null;
			} else if(enc != null){
				var na = new NativeArray<byte>(
					1920 * 
					1080 * 4,
					Allocator.Persistent
				);
				AsyncGPUReadback
				.RequestIntoNativeArray(
					ref na,
					rt,
					0,
					mat == "toyharLayv" ?
						TextureFormat.RGBA32 :
						TextureFormat.RGB24,
					q => {
						var b = na.ToArray();
						if(enc != null)
						enc.AddVideoFrame(
							b,
							UTJ
							.FrameCapturer
							.fcAPI
							.fcGetPixelFormat(
								mat == "toyharLayv" ?
									TextureFormat.RGBA32 :
									TextureFormat.RGB24
							),
							Mathf.Floor(
								(float)
								(toytilTime)
							) / 1000
						);
						
						if(isPic) {
						shtareemDon++;
						
						if(hoyseefZmaneem)
						zmanz
						.Add(thisFrame);
						
						if(shneeIO != null) {
							shneeIO
								.Write(
								System
								.Text
								.Encoding
								.UTF8
								.GetBytes(
									"\nfile " + 
									ikarShaym +
									"_" + 
									zeroify(
									shtareemDon,
									6
									) +
									"." + meen + 
									"\nduration "+
									(thisFrame / 1000)
								)
							);
						}
						}
						
						na.Dispose();
					}
				);
			}
			ayin.targetTexture = null;
			lastFrame = Achshawv();
			}
		}
		
		string zeroify(int yees, int zeros) {
			string fin = "" + yees;
			while(fin.Length < zeros) {
				fin = 0 + fin;
			}
			return fin;
		}
		void OnAudioFilterRead(
			float[] soympiles,
			int choyniles
		) {
			if(enc != null && ratzoo) {
				enc
				.AddAudioSamples(
					soympiles
				);
			}
		}
	}
	
	
}