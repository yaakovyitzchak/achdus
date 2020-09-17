using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


	public  class Yetzirah : MonoBehaviour
	{
		
		public void Start() {
			for(int i = 0; i < 200; i++) {
				yoytzayr("ok/" + "hi " + i + ".png");
			}
		}
		
		public  void yoytzayr(string derech) {
		//	Yaakov.mainCoby.
			StartCoroutine(Yo(derech));
		}
		
		 IEnumerator Yo(string derech)
		{
			while(true) {
				yield return new WaitForSeconds(1);
				yield return new WaitForEndOfFrame();
				
				var yetzirah = RenderTexture.GetTemporary(
					1920,
					1080,
					0,
					RenderTextureFormat.ARGB32
				);
				
				ScreenCapture.CaptureScreenshotIntoRenderTexture(
					yetzirah
				);
				
				AsyncGPUReadback.Request(
					yetzirah,
					0,
					TextureFormat.ARGB32,
					new Action<AsyncGPUReadbackRequest>(
						(shyluh) => {
							if(shyluh.hasError) {
								Debug.Log("yo man?!");
								return;
							}
							
							var YetzirahTzurah = new Texture2D(
								1920,
								1080,
								TextureFormat.ARGB32,
								false
							);
							
							YetzirahTzurah.
							LoadRawTextureData(
								shyluh.GetData<uint>()
							);
							
							YetzirahTzurah.Apply();
							System.IO.File.WriteAllBytes(
								derech,
								ImageConversion.
								EncodeToPNG(
									YetzirahTzurah
								)
							);
						//	MonoBehaviour.
							DestroyImmediate(
								YetzirahTzurah
							);
						}
					)
				);
				
				RenderTexture.ReleaseTemporary(
					yetzirah
				);
			}
			
			void YoFinishedIt(AsyncGPUReadbackRequest shyluh) {
				
				
			}
		}


	}
