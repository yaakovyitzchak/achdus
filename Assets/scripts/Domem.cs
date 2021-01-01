using SimpleJSON;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;




namespace Achdus
{
    

	


    public class Domem : Nivra
    {
		public static 
		Dictionary<string, GameObject>
		yesodos = new 
		Dictionary<string, GameObject>() {
			{
				"cube", 
				null
			},
			{
				"capsule", 
				null
			},
			{
				"cylinder", 
				null
			},
			{
				"sphere", 
				null
			},
			{
				"plane", 
				null
			},
			{
				"quad", 
				null
			}
		};
		
		public Mesh _guf = null;
		public Vector3[] zawveeosJolder;
		public MeshFilter masht;
		private Davar _data = new Davar();
		private Collider _col = null;
		
		public Davar Neefgash {
			get {
				return new Davar(_col);
			}
			set {
				if(value != null) {
					if(_col != null) {
						MonoBehaviour.
						Destroy(_col);
					}
					var meen = (
						value["type"] != null ?
							value["type"]
						:	value["meen"] != null ?
							value["meen"] : null
					);
					var toldos = (
						value["toldos"] != null ||
						value["children"] != null ?
							true : false
					);
					
					_col = HoyseefComponent(
						meen
					);
					
					if(
						meen != null && 
						toldos
					) {
						var mesheem = 
						gameObject.GetComponentsInChildren<
							Renderer
						>();
						
						
						foreach(Renderer rend in mesheem) {
							var coll = rend.GetComponent<
								Collider
							>();
							
							if(coll == null) {
								HoyseefComponent(
									meen,
									rend.gameObject
								);
							}
						}
					}
				}
			}
		}
		
		public Davar guf {
			get {
				return new Davar(_guf);
			}
		}
		
		public Davar zawveeos {
			get {
				if(_guf != null) {
					return new Davar(_guf.vertices);
				}
				else return null;
			} set {
				/*var length = value.Count;
				var newVerts = new Vector3[length];
				Debug.Log(value + ":" + newVerts);*/
				Debug.Log("HI " + value);
				
			}
		}
        public Domem() : this(new Davar()) { }

        public Domem(Jint.Native.JsValue data) : this(new Davar(data)) { }

 
        public Domem(Davar data) : base(data)
        {
		
			BorayGuf(() => {
				_data = new Achdus.Davar(data);
				//AyshPeula("HeessCheel", this);
				if(
					data["Neefgash"] is
					Dictionary<string, object>
				) {
					data["Neefgash"] =
					new Davar(data["Neefgash"]);
				}
				if(
					data["Collider"] is
					Dictionary<string, object>
				) {
					data["Collider"] =
					new Davar(data["Collider"]);
				}
				
				JustStart();
				Init();
			});
			
			
        }
		
		public void BorayGuf(Action done) {
				var modelURL = data["model"];
				if(
					modelURL != null		
				) {
					new Achdus.Giluy(
						modelURL,
						true,
						new System.Action<object, string> (
							(rez, err) => {
								if(
									rez is byte[] bytes
									
								) {
									AnimationClip[] ans = (
										new AnimationClip[3]
									);
									
									var go = Siccity
									.GLTFUtility
									.Importer
									.LoadFromBytes(
										bytes,
										new Siccity.GLTFUtility.ImportSettings(),
										out ans
									);
									
									if(
										data
										["gameObject"] is
										GameObject
									) {
										gameObject = 
										data
										["gameObject"];
										
										go.transform
										.SetParent(
											gameObject
											.transform
										);
									} else {
										gameObject = go;
									}
									chayoosClips = ans;
									anotherInit(done);
								} else if(err != null) {
									Debug.Log(err);
								}
							}
						)
					);
					
				} else {
					if(
						data
						["gameObject"] is
						GameObject
					) {
						gameObject = 
						data
						["gameObject"];
						
					} else if(
						data["gameObject"] is
						string
					) {
						gameObject = 
						GoFromString(
							data["gameObject"]
						);	
						
					} else {
						gameObject = 
						GoFromString(
							"cube"
						);						
					}
					anotherInit(done);
				}
            
        }
		
		public static
		GameObject 
		GoFromString(string s) {
			GameObject rez = null;


			switch(s) {
				default:
					rez = 
					GameObject
					.CreatePrimitive(
						PrimitiveType
						.Cube
					);
				break;
				case "sphere":
					rez = 
					GameObject
					.CreatePrimitive(
						PrimitiveType
						.Sphere
					);
				break;
				
				case "capsule":
					rez = 
					GameObject
					.CreatePrimitive(
						PrimitiveType
						.Capsule
					);
				break;
				case "quad":
					rez = 
					GameObject
					.CreatePrimitive(
						PrimitiveType
						.Quad
					);
				break;
				case "plane":
					rez = 
					GameObject
					.CreatePrimitive(
						PrimitiveType
						.Plane
					);
				break;
				case "cylinder":
					rez = 
					GameObject
					.CreatePrimitive(
						PrimitiveType
						.Cylinder
					);
				break;
			}
			

			return rez;
	
		}
		
		private void anotherInit(Action done) {
            SetWorldPosition(data);
			done?.Invoke();
		}
		
		public override void KodemInit() {
			Debug.Log("OKWE");
		}
		public void JustStart() {
			base.HeessCheel();
			var yetzirah = gameObject.GetComponent<MeshRenderer>();
			if(yetzirah == null) {
				yetzirah = gameObject.AddComponent<MeshRenderer>();
			}
			BorayGufChadash(new Davar("{}"));
			DealWithGasmiusCollidables();
		}
		
		

		private void DealWithGasmiusCollidables() {
			Neefgash = (
				data != null ? (
					data["Collider"] != null ?
						(data["Collider"]) :
					data["Neefgash"] != null ?
						(data["Neefgash"]) : null
				) : null
			);
		}
		
		public void BorayGufChadash(Davar opts) {
			
			masht = gameObject.GetComponent<MeshFilter>();
			
			if(masht == null)
				masht = gameObject.AddComponent<MeshFilter>();
			
			
			_guf = masht.mesh;
			
			
		/*	zawveeos = new Vector3[3]{
				new Vector3(0,0,0),
				new Vector3(1,0,0),
				new Vector3(1,1,0)
				
				/*
				new Vector3(0,1,0),
				
				new Vector3(0,0,1),
				new Vector3(1,0,1),
				new Vector3(1,1,1),
				new Vector3(0,1,1),*/
				
				
			
		//	guf.vertices = zawveeos;
		//	guf.RecalculateNormals();
		//	yetzirah.mesh = guf;
			if(_guf == null) {
				
				if(opts["zawveeos"] != null) {
					
				}
			}
		}
		
		public void MeshanehHaguf(Davar opts) {
			
		}
    }

    
}

/*

using UnityEngine;

public class Example : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
    }

    void Update()
    {
        for (var i = 0; i < vertices.Length; i++)
        {
            vertices[i] += Vector3.up * Time.deltaTime;
        }

        // assign the local vertices array into the vertices array of the Mesh.
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
}
*/