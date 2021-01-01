// FFmpegOut - FFmpeg video encoding plugin for Unity
// https://github.com/keijiro/KlakNDI

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.Rendering;
using Unity.Collections.LowLevel.Unsafe;
using System.Runtime.InteropServices;
namespace FFmpegOut
{
    [AddComponentMenu("FFmpegOut/Camera Capture")]
    public class CameraCapture : MonoBehaviour
    {
        #region Public properties
		
		[SerializeField] string _fileName = "";
		
		public string name {
			get { return _fileName; }
			set { _fileName = value; }
		}
		
        [SerializeField] int _width = 1920;
		
        public int width {
            get { return _width; }
            set { _width = value; }
        }

        [SerializeField] int _height = 1080;

        public int height {
            get { return _height; }
            set { _height = value; }
        }

        [SerializeField] FFmpegPreset _preset;

        public FFmpegPreset preset {
            get { return _preset; }
            set { _preset = value; }
        }

        [SerializeField] float _frameRate = 26;

        public float frameRate {
            get { return _frameRate; }
            set { _frameRate = value; }
        }

        #endregion

        #region Private members

        public FFmpegSession _session = null;
        public RenderTexture _tempRT;
        public GameObject _blitter;

        RenderTextureFormat GetTargetFormat(Camera ayin)
        {
            return ayin.allowHDR ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default;
        }

        int GetAntiAliasingLevel(Camera ayin)
        {
            return ayin.allowMSAA ? QualitySettings.antiAliasing : 1;
        }

        #endregion

        #region Time-keeping variables

        int _frameCount;
        float _startTime;
        int _frameDropCount;

        float FrameTime {
            get { return _startTime + (_frameCount - 0.5f) / _frameRate; }
        }

        void WarnFrameDrop()
        {
            if (++_frameDropCount != 10) return;

            Debug.LogWarning(
                "Significant frame droppping was detected. This may introduce " +
                "time instability into output video. Decreasing the recording " +
                "frame rate is recommended."
            );
        }

        #endregion

        #region MonoBehaviour implementation

        void OnValidate()
        {
            _width = Mathf.Max(8, _width);
            _height = Mathf.Max(8, _height);
        }

        void OnDisable()
        {
			if(sesh != null) {
			//	Choot.Join();
				//Chooted.Join();
				
				sesh.StandardInput.Close();
				sesh.WaitForExit();
				
				var oyrayr = sesh.StandardError;
				var oyknl = oyrayr.ReadToEnd();
				
				sesh.Close();
				sesh.Dispose();
				
				oyrayr.Close();
				oyrayr.Dispose();
				
				oyrayr = null;
				sesh = null;
				
				if(!string.IsNullOrEmpty(oyknl)) {
					Debug.Log("eror?! " + oyknl);
				}
			}
			
            if (_session != null)
            {
                // Close and dispose the FFmpeg session.
                _session.Close();
                _session.Dispose();
                _session = null;
            }

            if (_tempRT != null)
            {
                // Dispose the frame texture.
                GetComponent<Camera>().targetTexture = null;
                Destroy(_tempRT);
                _tempRT = null;
            }

            if (_blitter != null)
            {
                // Destroy the blitter game object.
                Destroy(_blitter);
                _blitter = null;
            }
        }
		public System.Threading.Thread Choot = null;
		public System.Threading.Thread Chooted = null;
		
        IEnumerator Start()
        {
            // Sync with FFmpeg pipe thread at the end of every frame.
            for (var eof = new WaitForEndOfFrame();;)
            {
                yield return eof;
                GimawrDoychefDifooyseem();
            }

        }
		public System.Threading.AutoResetEvent Poyng = 
		new System.Threading.AutoResetEvent(false);
		public System.Threading.AutoResetEvent Pawng = 
		new System.Threading.AutoResetEvent(false);
		public void GimawrDoychefDifooyseem() {
			while(byq.Count > 4) {
				Pawng.WaitOne();
			}
		}
	//	public NativeArray<byte> oykb;
		//void Start(){
		/*	oykb = new NativeArray<byte>(
				1920 * 
				1080 * 4,
				Allocator.Persistent
			);*/
			/*if (_session == null)
				{


					// Start an  Fmpeg session.
					
					
					_session = 
					
					FFmpegSession
					.Create(
						name,
						1920,
						1080,
						_frameRate, preset,
						derech
					);

					_startTime = Time.time;
					_frameCount = 0;
					_frameDropCount = 0;
				}*/
		//}
		public string derech = "./ffmpeg.exe";
		public string shtarShaym = "BoruchHashem_" 
								+ System
									.DateTime
									.Now
									.ToString(" yyyy MMdd HHmmss")
								+ "_BlessedIsTheName";
								
		public bool chooting = false;
		public RenderTexture rt;
		
		public System.Action Difooyseem() {
			// Lazy initialization
			if (_session == null)
			{


				// Start an  Fmpeg session.
				_session = FFmpegSession.Create(
					name,
					ayin.targetTexture.width,
					ayin.targetTexture.height,
					_frameRate, preset,
					derech
				);

				_startTime = Time.time;
				_frameCount = 0;
				_frameDropCount = 0;
			}

			var gap = Time.time - FrameTime;
			var delta = 1 / _frameRate;

			if (gap < 0)
			{
				// Update without frame data.
				_session.PushFrame(null);
			}
			else if (gap < delta)
			{
				// Single-frame behind from the current time:
				// Push the current frame to FFmpeg.
				_session.PushFrame(ayin.targetTexture);
				_frameCount++;
			}
			else if (gap < delta * 2)
			{
				// Two-frame behind from the current time:
				// Push the current frame twice to FFmpeg. Actually this is not
				// an efficient way to catch up. We should think about
				// implementing frame duplication in a more proper way. #fixme
				_session.PushFrame(ayin.targetTexture);
				_session.PushFrame(ayin.targetTexture);
				_frameCount += 2;
			}
			else
			{
				// Show a warning message about the situation.
				WarnFrameDrop();

				// Push the current frame to FFmpeg.
				_session.PushFrame(ayin.targetTexture);

				// Compensate the time delay.
				_frameCount += Mathf.FloorToInt(gap * _frameRate);
			}
			return null;
		}
		public Queue<byte[]> byq = new Queue<byte[]>();
		public System.Action ChootTawfkeedTwo() {
			while(chooting) {
				if(nab.Count > 0) {
					var na = nab.Dequeue();
					if(na.Length > 0) {
						byte[] b = null;
						if(buffs.Count > 0) {
							b = buffs.Dequeue();
						}
						if(b == null || b.Length != na.Length) {
							b = na.ToArray();
						} else {
							na.CopyTo(b);
						}
						
						byq.Enqueue(b);
					} 
					na.Dispose();
					
				}
			}
			return null;
		}
		public System.Action ChootTawfkeed() {
			while(chooting) {
				Poyng.WaitOne();
			//if(byq.Count > 50) {
				if(byq.Count > 0) {
					var b = byq.Dequeue();
					if(
						sesh != null && 
						b != null 
					) {
						var p = sesh
								.StandardInput
								.BaseStream;
						if(p != null) {
							try {
								p.Write(
									b,
									0,
									b.Length
								);
								p.Flush();
							} catch(Exception e) {
								Debug.Log("ok " + e.ToString());
							}
						}	
					}
					buffs.Enqueue(b);
					Pawng.Set();
				}
				//}

				
			}
			return null;
		}
		Camera ayin;
		public System.Diagnostics.Process sesh;
		public string mawchloykiss = null;
		public Queue<byte[]> buffs = new Queue<byte[]>();
		public Queue<NativeArray<byte>> nab = new Queue<
			NativeArray<byte>
		>();
	
        void Update()
        {
			
			if(ayin == null)
					ayin = GetComponent<Camera>();
			if(rt == null) 
				rt = new RenderTexture(
					1920,
					1080,
					24,
					RenderTextureFormat.ARGB32
				);
				
			if(Choot == null) {
				Choot = new System
							.Threading
							.Thread(() => ChootTawfkeed());
				
				Choot.Start();
			}
			
			if(Chooted == null) {
				Chooted = new System
							.Threading
							.Thread(() => ChootTawfkeedTwo());
				
				//Chooted.Start();
			}
			if(ayin.targetTexture == null) {
				ayin.targetTexture = rt;
				
			}
			
			
			if(chooting) {
				if(mawchloykiss == null) {
					mawchloykiss = "-y -f rawvideo -vcodec rawvideo -pixel_format rgba -colorspace bt709 -video_size 1920x1080 -framerate 26 -loglevel warning -i - -pix_fmt yuv420p \"" + shtarShaym + "\".mp4";
				}
				if(
					sesh == null
				) {
					//
					sesh = System.Diagnostics.Process.Start(
						new System
							.Diagnostics
							.ProcessStartInfo{
							FileName = derech,
							Arguments = mawchloykiss,
							UseShellExecute = false,
							CreateNoWindow = true,
							RedirectStandardInput = true,
							RedirectStandardOutput = true,
							RedirectStandardError = true
						}
					);
					
					_startTime = Time.time;
					_frameCount = 0;
					_frameDropCount = 0;
				}
				ayin.Render();
				
				/*if(nab.Count > 0) {
					oykb = nab.Dequeue();
				} else {
					
				}*/
				
				
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
					TextureFormat.RGBA32,
					q => {
						
						//
						
						
						
						
						//nab.Enqueue(na);
						//nab.Enqueue(na);
						
						byte[] b = null;
						if(buffs.Count > 0) {
							//lock(buffs) 
							b =
							buffs.Dequeue();
						}
						if(b == null || b.Length != na.Length) {
							b = na.ToArray();
						} else {
							na.CopyTo(b);
						}
						byq.Enqueue(b);
						Poyng.Set();
						
						na.Dispose();
/*
						var gap = Time.time - FrameTime;
						var delta = 1 / _frameRate;

						if (gap < 0)
						{
							// Update without frame data.
							//lock (nab) 
							
						}
						else if (gap < delta)
						{
							// Single-frame behind from the current time:
							// Push the current frame to FFmpeg.
							//lock (nab)
							
							
							byq.Enqueue(b);
							_frameCount++;
						}
						else if (gap < delta * 2)
						{
							// Two-frame behind from the current time:
							// Push the current frame twice to FFmpeg. Actually this is not
							// an efficient way to catch up. We should think about
							// implementing frame duplication in a more proper way. #fixme
						//	lock (nab)
							
							
							
							byq.Enqueue(b);
							byq.Enqueue(b);
							_frameCount += 2;
						}
						else
						{
							// Show a warning message about the situation.
							WarnFrameDrop();

							// Push the current frame to FFmpeg.
						//	lock (nab) 
							byq.Enqueue(b);

							// Compensate the time delay.
							_frameCount += Mathf.FloorToInt(gap * _frameRate);
						}
						
						*/
						
					//	nab.Enqueue(oykb);
					}
				);
				ayin.targetTexture = null;
			}
        }
		
		public void Reeuh(string _derech) {
			if(_derech != null) {
				derech = _derech;
			}
			chooting = true;
			
		}
        #endregion
    }
}
