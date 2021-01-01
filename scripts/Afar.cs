//B"H
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jint.Native;
using System;
namespace Achdus {
	public class Afar : Roochnee
	{
		
		public ParticleSystem AfarSystem = null;
		public ParticleSystemRenderer AfarYetzirah = null;
		public ParticleSystem.EmissionModule shefuh;
		
		
		public void MishanehAfarKawmoys(int spd) {
			var m =AfarSystem
			.main;
			m.maxParticles = spd;
		}
		
		public void MishanehMirootza(int spd) {
			var m =AfarSystem
			.main;
			m.startSpeed = spd;
		}
		public void MishanehAychoys(
			float km
		) {
			MishanehAychoys(km, km, km);
		}
		
		public void MishanehAychoys(
			float kx,
			float ky,
			float kz
		) {
			var m = AfarSystem.main;
			if(!m.startSize3D)
				m.startSize3D = true;
			m.startSizeXMultiplier = kx;
			m.startSizeYMultiplier = ky;
			m.startSizeZMultiplier = kz;
		}
		
		public void MishanehShefah(float am) {
		
			if(AfarSystem != null) {
				shefuh = AfarSystem.emission;
				shefuh.rate = am;
			}
		}
		
		public void MishanehTziur() {
			MishanehTziur(new Davar());
		}
		public void MishanehTziur(JsValue d) {
			MishanehTziur(new Davar(d));
		}
		
		public Material mat = null;
		public void MishanehTziur(Davar d) {
			if(AfarYetzirah != null) {
				if(mat == null) {
					var shayd = d["tzayl"];
					Shader s = null;
					if(shayd != null) {
						try {
							s = Shader.Find(shayd);
						} catch(Exception e) {
							
						}
					}
					
					if(s == null) {
						s = Shader.Find("Transparent/Diffuse");
					}
					mat = new Material(s);
					AfarYetzirah.material = mat;
				}
				
				var text = d["tziur"];
				if(text != null) {
					Texture2D txt = null;
					try {
						txt = Tzirum.GetTexture(text);
					} catch (Exception e) {
						
					}
					if(txt != null) {
						mat.mainTexture = txt;
					}
				}
				
				var color = d["mareh"];
				if(color != null) {
					mat.color = Color.red;
					Debug.Log("ok!?" + color);
					if (color is string) {
						if (ColorUtility.TryParseHtmlString(
							color as string, out Color myColor
						)) {
							mat.color = myColor;
						}
					}
				}
			}
		}
		
		public void MishanehHaschalasMareh(float r, float g, float b) {
			AfarSystem.startColor = new Color(r, g, b);
		}
		
		public void MissHapaychHaguf(Domem d) {
			var shayp = AfarSystem.shape;
			shayp.enabled = true;
			shayp.shapeType = ParticleSystemShapeType.Mesh;
			shayp.mesh = d._guf;
		}
		
		public Afar() 
		: this(new Davar("{}")) {}
		
		public Afar(Jint.Native.JsValue d) 
		: this(new Davar(d)) {}
		
		public Afar(Davar d) : base(d) {
			AfarSystem = (
				gameObject.
				AddComponent<
					ParticleSystem
				>()
			);
			AfarYetzirah = (
				gameObject.
				GetComponent<
					ParticleSystemRenderer
				>()
			);
		}
	}
}
