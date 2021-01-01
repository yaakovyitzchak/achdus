//B"H
using Jint.Native;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.Rendering;
using Unity.Collections.LowLevel.Unsafe;
using System.Runtime.InteropServices;


namespace Achdus {
	
	public class Yetzirah {	
		public class AyinAdan {
			public FFmpegOut.CameraCapture AyinShtar;
			public AyinAdan() {
				var cam = Camera.main;
				AyinShtar = cam.gameObject.AddComponent<
					FFmpegOut.CameraCapture
				>();
			}
			
			public void HeessCheel() {
				HeessCheel(null);
			}
			
			public void HeessCheel(string derech) {
				if(AyinShtar != null) {
					AyinShtar
					.Reeuh(
						derech
					);
				}
			}
			
			public void Oymayd() {
				if(AyinShtar != null)
					MonoBehaviour
					.Destroy(AyinShtar);
			}
		}
		
		public static AyinAdan AyinBihAyin() {
			return new AyinAdan();
		}
	
	
		public class Oyluhm {
			public Asiyah oy = null;
			public Oyluhm(
				string pth
			) : this(pth, "webm") {
			
			}
			public string pth = "";
			public string meen = "";
			public string _mat = "";
			
			public string ikarShaym = "";
			public Oyluhm(
				string pth,
				string meen
			) :this(pth,meen,"") {}
			public Oyluhm(
				string pth,
				string meen,
				string mat
			) {
				_mat = mat;
				this.pth=pth;
				this.meen=meen;
				Camera cam = Yaakov.mainCoby.shneeuh != null ?
				Yaakov.mainCoby.shneeuh : 
				Camera.main;
				if(cam != null) {
					oy = cam
						.gameObject
						.AddComponent<
							Asiyah
						>();
					
				}
			}
			
			public void setZmaneem(bool yes) {
				if(oy != null) {
					oy.hoyseefZmaneem = yes;
				}
			}
			
			public void setShtarif(bool yes) {
				if(oy != null) {
					oy.shtarify = yes;
				}
			}
			
			public void Hoysscheel() {
				if(oy != null)
					oy.Hoysscheel(pth, meen, _mat);
			}
			
			public void Hoysscheel(string isL) {
				if(oy != null)
					oy.Hoysscheel(pth, meen, isL);
			}
			
			public double[] zmaneem() {
				return
					oy.zmanz
					.ToArray();
			}
			
			public void mishanehWebm(string k) {
				if(oy != null) {
					oy
					.fig
					.webmEncoderSettings
					.videoEncoder = (
						k == "vp8" ? 
						
						UTJ.FrameCapturer
						.fcAPI
						.fcWebMVideoEncoder
						.VP8 :
						k == "vp9" ? 
						
						UTJ.FrameCapturer
						.fcAPI
						.fcWebMVideoEncoder
						.VP9 : 
						
						UTJ.FrameCapturer
						.fcAPI
						.fcWebMVideoEncoder
						.VP9LossLess
					);
				}
			}
			public void Hoylt() {
				if(oy != null) {
					oy.Oymayd();
				}
			}
		}
		
		public static Oyluhm Awsay(
			string pth, string meen, string mat
		) {
			return new Oyluhm(pth, meen, mat);
		}
		
		public static Oyluhm Awsay(
			string pth, string meen
		) {
			return new Oyluhm(pth, meen);
		}
		
		public static Oyluhm Awsay(
			string pth
		) {
			return new Oyluhm(pth);
		}
		
		
		public static System.Diagnostics.Process Malach() {
			return new System.Diagnostics.Process();
		}
		
		public static void BoyrayMalach(string str) {
			System.Diagnostics.Process.Start(str);
		}
		
		public static void BoyrayMalach(string str, string arg) {
			System.Diagnostics.Process.Start(str, arg);
		}
		
		
		public class ReshesAyin {
			public UnityCapture uc = null;
			public ReshesAyin() {
				Camera cam;
				cam = Yaakov.mainCoby.shneeuh;
				uc = cam.gameObject.AddComponent<UnityCapture>();
			}
			
			public void Oymayd() {
				if(uc != null) {
					MonoBehaviour.Destroy(uc);
				}
			}
		}
		
		public static ReshesAyin AyinHareshes() {
			return new ReshesAyin();
		}
		
	}
}