using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.MonoBehaviour;
using System;
using Jint.Native;
namespace Achdus {
    public class Heeoolee {
        private Dictionary<string, List<Func<object, object>>> peulosAchshawv = new Dictionary<string, List<Func<object, object>>>();
		
		public Davar cald = 
		new Davar();
		
		private Dictionary<
			string,
			object
		> chootifiedComponents = new Dictionary<
			string,
			object
		> {
			{"box", typeof(BoxCollider)}
		};
        private Davar properties = new Davar();
        private Davar functions = new Davar();
        private string propertiesToCopy = @"
            position  
            rotation 
            scale 
            texture 
            color";

        private string _textureStr;
        private Texture _actualTexture;
        public object texture {
            get {
                return _actualTexture;
            }
            set {
				if(value is string)
					SetMyTexture(value as string);
				else SetTexture(value);
            }
        }

        /*
         * if (value is string textureURL) {
                    Debug.Log("getting texture: " + textureURL);
                    var asset = Tzirum.GetRaw(textureURL);
                    if (asset != null) {
                        SetTexture(asset);
                        Debug.Log("YAY?");
                    }
                    else {
                        Debug.Log("NOPE");
                        Tzirum.LoadAsset(textureURL, textureURL, (result, error) => {
                            if (result != null) {
                                Debug.Log("OK now");
                                SetTexture(result);
                            }
                            else {
                                Debug.Log("OY? " + error);
                            }
                        });
                    }
                }
         * */
		private string shaym = "bli mah";
		public string name {
			get {
				return shaym;
			}
			
			set {
				Achdus.Yaakov.MishahnehNivra(shaym, value);
				shaym = value;
				if(gameObject != null) 
					gameObject.name = shaym;
				
			}
		}
		
		private Davar dayy = new Davar();
		public Davar dayuh {
			get {
				return dayy;
			}
		}
		
        public GameObject gameObject;

        public Renderer[] renderers;
       
        
        public bool isSelectable = true;
        public List<Material> materialsInChildren;
        public string domemPath;
        public Renderer Renderer;
        public float regularGravity = 0f;
        public Davar data = new Davar();
        public CharacterController controller = null;
        Collider collider = null;

        public bool isTrigger {
            get {
                if (collider == null) {
                    collider = gameObject.GetComponent<Collider>();
                }
                if (collider != null)
                    return collider.isTrigger;
                else return false;
            }
            set {
                if (collider == null) {
                    collider = gameObject.GetComponent<Collider>();
                }
                if (collider != null) {
                    collider.isTrigger = value;
               //     Debug.Log("SEt it? " + collider.isTrigger);
                }
                else {
             //       Debug.Log("nlld?");
                }
                Set("isTrigger", value);
            }
        }

        public object position {
            get {
                return gameObject != null &&
                        gameObject.transform != null ? gameObject.transform.position : new Vector3();

            }
            set {
                if (gameObject != null && gameObject.transform != null) {
                    var newVector = new Vector3();
                    if (value is Dictionary<string, object>) {
                        var temp = new Davar(value);
                        newVector = temp.ToVector3();
                    }
                    else if (value is Vector3) {
                        newVector = (Vector3)value;
                    }
                    gameObject.transform.position = newVector;
                    if (controller != null && controller.enabled == true) {
                        controller.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
                    }
                }
                Set("position", value);
            }
        }

        public object scale {
            get {
                return gameObject != null &&
                        gameObject.transform != null ? gameObject.transform.localScale : new Vector3();

            }
            set {
                if (gameObject != null && gameObject.transform != null) {
                    var newVector = new Vector3();
                    if (value is Dictionary<string, object>) {
                        var temp = new Davar(value);
                        newVector = temp.ToVector3();
                    }
                    else if (value is Vector3) {
                        newVector = (Vector3)value;
                    }
                    gameObject.transform.localScale = newVector;
                }
                Set("scale", value);
            }
        }

        public object rotation {
            get {
                return gameObject != null &&
                        gameObject.transform != null ? gameObject.transform.rotation : Quaternion.Euler(0, 0, 0);

            }
            set {
                if (gameObject != null && gameObject.transform != null) {
                    var newVector = Quaternion.Euler(0, 0, 0);
                    if (
						value is Dictionary<string, object> ||
						value is JsValue
					) {
                        var temp = new Davar(value);
                        newVector = temp.ToQuaternion();
                    }
                    else if (value is Quaternion) {
                        newVector = (Quaternion)value;
                    }
                    gameObject.transform.rotation = newVector;
                }
                Set("rotation", value);
            }
        }
		private Clickable _clickable = null;
		public Clickable clickable {
			get {
				if(_clickable == null) {
					gameObject.
					AddComponent<
						Clickable
					>();
				}
				return _clickable;
			} set {
				if(value == null) {
					MonoBehaviour.
					Destroy(
						_clickable
					);
				}
			}
		}
		
		

        public Renderer renderer {
            get {
                if (Renderer == null) {
                    if(gameObject != null)
                        Renderer = gameObject.GetComponent<Renderer>();
                }
                return Renderer;
            }
			
        }

        public object color {
            get {
                var rend = renderer;
                if (rend != null) {
                    return rend.material.color;
                }
                else {
                    return null;
                }
            }
            set {
                var rend = renderer;

                if (value is string) {
                    if (ColorUtility.TryParseHtmlString(value as string, out Color myColor)) {
                        if (rend != null) {
                            rend.material.color = myColor;
                        }
                    }
                }
                else if (value is Dictionary<string, object>) {
                    var temp = new Davar(value);
                    var myColor = new Color(temp.Float("r"), temp.Float("g"), temp.Float("b"));//, temp.Float("a",1)
                    if (rend != null) {
                        rend.material.color = myColor;
                    }
                }

                Set("color", value);
            }
        }

        
        public Heeoolee() : this(new Davar()) { }

        public Heeoolee(JsValue data) : this(new Davar(data)) { }


		string tmpName = "";
		
        public Heeoolee(Davar data) {
            this.data = data;
            if (data != null) {
                AddFunctions();
                AddTextures();


                var props = Remove(propertiesToCopy.Split(' '), "\n");
                foreach (var i in props) {
                    foreach (var dataBlock in data) {
                        if (dataBlock.Key.ToString() == i) {
                            Define(i, dataBlock.Value);
                        }
                    }
                }  
            }
			
			on("HeessCheel", new Func<object, object>((o) => {
				//Debug.Log(" testing WOW!?");
				return null;
			}));
         //   Init();
			if (data["name"] is string str) {
                tmpName = str;
            } else {
				tmpName = Achdus.Yaakov.shaymifier() ;
			}
        }

		
		
		public Collider HoyseefComponent(
			string meen, 
			GameObject go = null
		) {
			if(go is GameObject) {
				switch(meen) {
					case "box": 
					return 
					go.AddComponent<BoxCollider>();
					break;
					case "mesh":
					return 
					go.AddComponent<MeshCollider>();
					break;
					default: return null;
				}
			} else return null;
		}
		
        public override string ToString() {
            return properties.ToString();
        }
        public void Define(string propertyName, dynamic value) {
            properties[propertyName] = value;
        }

        public void Set(string propertyName, dynamic value) {
            Define(propertyName, value);
        }

        public JsValue Get(string propertyName) {
            return properties[propertyName];
        }

        public virtual void Init() {
			
			
			Achdus.Yaakov.HoyseefNivra(tmpName,this);
			name = tmpName;
			
			KodemInit();
			AyshPeula("KodemInit", this);
			
			AyshPeula("Init", this);
			AyshPeula("Neeor", this);
			
        }
		
		public virtual void KodemInit() {
		
		}
		
        public virtual void Start() {
         //   if (peulosAchshawv.ContainsKey("HeessCheel")) peulosAchshawv["HeessCheel"].ForEach(x => x(this));
			AyshPeula("HeessCheel", this);
        }



        public virtual void OnTriggerEnter(Collider col) {
			AyshPeula("TriggerEnter", col);
        }

        public virtual void OnTriggerExit(Collider col) {
			AyshPeula("TriggerExit", col);
        }

        public virtual void OnControllerColliderHit(ControllerColliderHit hit) {
			AyshPeula("ControllerColliderHit", hit);
           
        }

        public virtual void OnCollisionEnter(Collision hit) {
			AyshPeula("ControllerColliderStay", hit);
        }

        public virtual void OnCollisionStay(Collision hit) {
			AyshPeula("ControllerColliderStay", hit);
        }

        public virtual void OnCollisionExit(Collision hit) {
			AyshPeula("ControllerColliderExit", hit);
        }

        public virtual void Update() {
			
			AyshPeula("Update", this);
			AyshPeula("HissHavoos", this);
           
        }

        public virtual void FixedUpdate() {
			AyshPeula("FixedUpdate", this);
			AyshPeula("HissHavoosMesooken", this); 
        }

        public virtual void LateUpdate() {
			AyshPeula("LateUpdate", this);
        }

        public void AddTextures() {
            /*
            }*/
            if(data != null)
                SetMyTexture(data["texture"]);
            
        }

        public void SetMyTexture(string name) {
			if (name != null) {
				string textureURL = name;
			//	Debug.Log("getting texture: " + textureURL);
				var asset = Tzirum.GetRaw(textureURL);
				if (asset != null) {
					SetTexture(asset);
				//	Debug.Log("YAY?");
				}
				else {
				//	Debug.Log("NOPE");
					Tzirum.LoadAsset(textureURL, textureURL, (result, error) => {
						if (result != null) {
					//		Debug.Log("OK now");
							SetTexture(result);
						}
						else {
						//	Debug.Log("OY? " + error);
						}
					});
				}
			}
			/*
            if (name != null) {
                var loadedTxt = Tzirum.Textures[name];
                if (loadedTxt != null) {
                    SetTexture(loadedTxt);
                }
            }*/
        }
		public Shader tr = null;
        public void SetTexture(object data) {
            Texture2D t = null;
            if (data is byte[] bytes) {
                t = new Texture2D(0, 0);
                t.LoadImage(bytes);
            } else if(data is Texture2D text) {
                t = text;
            }
            if (t != null) {
				if(tr == null) {
					tr = Shader.Find("Transparent/Diffuse");
				}
                var mat = new Material(tr);
                mat.mainTexture = t;
                _actualTexture = t;
                if (renderer != null) renderer.material = mat;
            }
        }

        public void AddFunctions() {
            var funcs = "Update HeessCheel Neeor HissHavoos FixedUpdate TriggerEnter TriggerExit LateUpdate ControllerColliderHit CollisionExit ControllerColliderStay CollisionEnter";
            var list = funcs.Split(' ');
            if (data != null) {
                foreach (var k in data) {
                    if (k.Value is Func<JsValue, JsValue[], JsValue> act) {
					//	Debug.Log("HI ! " + k.Key + " and name: "+ name);
                        Func<object, object> test = delegate (
							object a
						) {
                            act(1, new JsValue[] {JewS(a)});
                            return null;
                        };

                        on(k.Key, test);
                    }
                }
            }
        }
		
		public void onOrNow
		(
			string eventName, 
			Func<object, object> action
		) {
			if(
				cald[eventName] != null
			) {
				action?.Invoke(cald[eventName]);
			} else {
				on(eventName, action);
			}
		}
		
		public void AyshPeula(string peulaShaym, object dvarim) {
			if (peulosAchshawv.ContainsKey(peulaShaym)) {
				peulosAchshawv[peulaShaym]
					.ForEach(x => x(dvarim));
			}
			cald[peulaShaym] = true;
		}
		
		public static JsValue JewS(object mah) {
			return JsValue.FromObject(
				PowerUI.UI.document.JavascriptEngine.Engine,
				mah
			);
		}
		
        public void on(string eventName, Func<object, object> action) {
            if (!peulosAchshawv.ContainsKey(eventName)) {
                peulosAchshawv[eventName] = new List<Func<object, object>>();
            }
			
            peulosAchshawv[eventName].Add((object tmp) => {

                action?.Invoke(tmp);
                return null;
            });

        }

        public void clear(string eventName) {
            if (peulosAchshawv.ContainsKey(eventName)) {
                peulosAchshawv[eventName].Clear();
            }
        }

        



        public List<Material> GetAllMaterialsInChildren() {
            List<Material> result = new List<Material>();
            var renderers = gameObject.GetComponentsInChildren<Renderer>();
            for (var i = 0; i < renderers.Length; i++) {
                for (int k = 0; k < renderers[i].materials.Length; k++) {
                    result.Add(renderers[i].materials[k]);
                }
            }
            return result;
        }

        public void SetWorldPosition(Davar mapData) {

            if (mapData != null) {
                if (mapData.Get("position") != null) {
                    var pos = new Davar(mapData.Get("position"));
                    gameObject.transform.position = pos.ToVector3();

                }

                if (mapData.Get("rotation") != null) {
                    var rotation = new Davar(mapData.Get("rotation"));
                    gameObject.transform.rotation = rotation.ToQuaternion();
                }

                if (mapData.Get("scale") != null) {
                    var temp = new Davar(mapData.Get("scale"));
                    gameObject.transform.localScale = temp.ToVector3();
                }
            }
            else {
                Debug.Log("yu got nulld");
            }
        }

        public Bounds LocalBounds(GameObject gb) {
            Quaternion currentRotation = gb.transform.rotation;
            gb.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Bounds bounds = new Bounds(gb.transform.position, Vector3.zero);
            foreach (Renderer renderer in gb.GetComponentsInChildren<Renderer>()) {
                bounds.Encapsulate(renderer.bounds);
            }
            Vector3 localCenter = bounds.center - gb.transform.position;
            bounds.center = localCenter;

            gb.transform.rotation = currentRotation;
            return bounds;
        }

        public List<string> Remove(string[] inp, string excluder) {
            var result = new List<string>();
            var acceptables = "qwertyuiopasdfghjklzxcvbnm$@#%^!&*()_+{}|:>?<~`";
            var length = 0;
            foreach (var i in inp) {
                var hasIt = false;
                var temp = i;
                foreach (var y in i) {
                    if (acceptables.Contains(y.ToString())) {
                        hasIt = true;
                    }

                }

                if (temp.Length > 0 && hasIt) {
                    result.Add(temp);
                }

                length++;
            }
            return result;
        }
    }
}