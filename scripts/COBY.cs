
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Linq;
using System.Reflection;
using Jint.Native;
using System.Runtime.InteropServices;
public class COBY : MonoBehaviour
{
    public string serverURL = null;
    public string serverID = null;
	
    public static Dictionary<string, List<Action>> callbacks = new Dictionary<string, List<Action>>();
    public static Dictionary<string, float> Axis = new Dictionary<string, float>();
    public static Assembly asm;
    public static string codeURL = null;
	
    public static List<Action> queueOfActionsInMainThread = new List<Action>();
	
	public static List<
		Dictionary<
			Achdus.Tzomayach, 
			string
		>
	> chayoosQs = 
	new List<
		Dictionary<
			Achdus.Tzomayach, 
			string
		>
	>();
	
    public static void print(string msg)
    {
        try {
      //      if (msg != null && msg is string) Debug.Log(msg);
        } catch(Exception e) {

        }
        
    }

    public class CobySocket
    {
        
        public HybridWebSocket.WebSocket ws;
        private Dictionary<SimpleJSON.JSONNode, SimpleJSON.JSONNode> adans = new Dictionary<SimpleJSON.JSONNode, SimpleJSON.JSONNode>();
        private Dictionary<string, Action<SimpleJSON.JSONNode>> adanFunctions = new Dictionary<string, Action<SimpleJSON.JSONNode>>();
        private List<Action> actionsToDoWhenOpened = new List<Action>();

        public CobySocket(string url, Action<CobySocket> onOpen)
        {
            HybridWebSocket.WebSocket tws = HybridWebSocket.WebSocketFactory.CreateInstance(url);

            tws.OnOpen += () => {
                actionsToDoWhenOpened.ForEach(x => queueOfActionsInMainThread.Add(x));
                actionsToDoWhenOpened.Clear();
                onOpen(this);
            };

            tws.OnMessage += (bite) => {
                var msg = "";
                try
                {
                    msg = parseMsgAsFromByte(bite);

                    if (IsJSON(msg))
                    {
                    //    Debug.Log(msg);
                        var par = SimpleJSON.JSON.Parse(msg);
                        foreach (var kv in par)
                        {
                            adans[kv.Key] = kv.Value;
                            if (adanFunctions.ContainsKey(kv.Key))
                            {
                                Action tmp = () => {
                                    adanFunctions[kv.Key](kv.Value);

                                };
                                queueOfActionsInMainThread.Add(tmp);

                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    print("an error: " + e);
                }
            };

            tws.OnError += (err) => {
                OnSocketError(err);
            };
            tws.Connect();
            this.ws = tws;
        }

        public CobySocket(string url) : this(url, s => { }) { }



        public void on(string msg, Action<SimpleJSON.JSONNode> resp)
        {
            adanFunctions[msg] = val => {
                resp(val);
            };

        }

        public void OnMessage()
        {

        }

        private string parseFromBase64IfSo(string input)
        {
            string str = input;
            if (IsBase64(str))
            {
                str = Encoding.UTF8.GetString(
                    System.Convert.FromBase64String(str)
                );
            }
            else
            {
            }
            return str;
        }
        private string parseMsgAsFromByte(byte[] bite)
        {
            var str = Encoding.UTF8.GetString(bite);
            return str;
        }

        public void SendAndBinaryify(string key, string value)
        {
            var bites = Encoding.UTF8.GetBytes(value);
            var baseicly = System.Convert.ToBase64String(bites);
            Send(key, baseicly);
        }

        public void Send(string data) {
            ws.Send(Encoding.UTF8.GetBytes(data));
        }

        public void Send(string title, params string[] entries)
        {
            Json.JSArray obj = null;
            if (entries.Length > 1)
            {
                obj = new Json.JSArray();
                for (int index = 0; index < entries.Length; index++)
                {
                    if (index <= entries.Length - 2)
                    {
                        obj[index] = new Json.JSValue(entries[index + 1]);
                    }
                }
            }
            else if (entries.Length < 1)
            {
                entries[0] = "";
            }


            Action tmp = () => {
                var newJSON = new Json.JSArray();
                if (obj != null)
                {
                    newJSON[title] = obj;
                }
                else
                {
                    newJSON[title] = new Json.JSValue(entries[0]);
                }
                string msg = newJSON.ToJSONString();
                ws.Send(Encoding.UTF8.GetBytes(msg));
          //      Debug.Log(Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(msg)));


            };

            if (ws.GetState() == HybridWebSocket.WebSocketState.Open)
            {
                tmp();

            }
            else
            {
                actionsToDoWhenOpened.Add(tmp);

            }

        }
    }

    public static HybridWebSocket.WebSocket MakeSocket(string url)
    {
        HybridWebSocket.WebSocket ws = HybridWebSocket.WebSocketFactory.CreateInstance(url);
        ws.OnOpen += () => {
            OnSocketOpen();
        };

        ws.OnMessage += (bite) => {
            var msg = "";
            try
            {
                msg = Encoding.UTF8.GetString(bite);
            }
            catch (Exception e)
            {
                print("an error: " + e);
            }

            OnSocketMessage(ws, msg);
        };

        ws.OnError += (err) => {
            OnSocketError(err);
        };

        ws.Connect();
        return ws;
    }

    public static void QuickSocket(string url, string msgToSend, Action<string> callbackWithReturnMessage)
    {
      //  Debug.Log(url);
   //     Debug.Log(msgToSend);
  //      Debug.Log(callbackWithReturnMessage);
        var tmp = MakeSocket(url);
        if (tmp.GetState() == HybridWebSocket.WebSocketState.Open)
        {
            SocketSend(tmp, msgToSend);
            tmp.OnMessage += (bite) =>
            {
                string msg = "nothing";
                try
                {
                    msg = Encoding.UTF8.GetString(bite);
                    callbackWithReturnMessage(msg);
                    tmp.Close();
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            };
        }
        else
        {
            Debug.Log("not open :(");
        }
    }
	
	
	public static string cleanGdrive(string gdrives) {
		//65279
		return gdrives;
	}

    public static void OnSocketOpen()
    {
        print("I connected");


    }

    public static void GetComponent(GameObject g, string monoType)
    {
        Type type = Type.GetType(monoType);
        var x = g.GetComponent(type);
    }

    public static void AddComponent(GameObject g, string monoType)
    {
        
        
        Type type = Type.GetType(monoType);
        var x = g.AddComponent(type);
    }

    public static void OnSocketMessage(HybridWebSocket.WebSocket ws, string msg)
    {
        print("just recieved: " + msg);

    }

    public static void OnSocketError(string msg)
    {
        print("Just got an error: " + msg);
    }

    public static void SocketSend(HybridWebSocket.WebSocket ws, string msg)
    {
        ws.Send(Encoding.UTF8.GetBytes(msg));
        print("I just sent: " + msg);
    }

    public static void on(string socketCMD, Action<string> cb)
    {


    }


	
    void Update()
    {
        if(callbacks.ContainsKey("Update"))
        {
            callbacks["Update"]
			.ToList()
			.ForEach(x=>x());
        }

		/*if(chayoosQs.Count > 0) {
			
			for(
				var i = 0;
				i < chayoosQs.Count; 
				i++
			) {
				foreach(var k in chayoosQs[i]) {
					var tzo = k.Key as Achdus.Tzomayach;
		
					if(tzo.chayoos != null) {
					
						tzo
						.chayoos
						.Play(k.Value as string);
						Debug.Log("ok now" + k.Value + 
						k.Key);
						chayoosQs.RemoveAt(
							i
						);
					}
				}
			}
		}*/
		
        if (queueOfActionsInMainThread.Count > 0)
        {
            for(var i = 0; i < queueOfActionsInMainThread.Count; i++) {
                queueOfActionsInMainThread[i]();
            }
            queueOfActionsInMainThread.Clear();
        }
    }

    private void FixedUpdate()
    {
        Axis["Horizontal"] = Input.GetAxisRaw("Horizontal");
        Axis["Vertical"] = Input.GetAxisRaw("Vertical");
        Axis["Fire1"] = Input.GetAxisRaw("Fire1");
        Axis["Fire2"] = Input.GetAxisRaw("Fire2");
        Axis["Fire3"] = Input.GetAxisRaw("Fire3");
        Axis["Jump"] = Input.GetAxisRaw("Jump");
        Axis["Mouse X"] = Input.GetAxisRaw("Mouse X");
        Axis["Mouse Y"] = Input.GetAxisRaw("Mouse Y");
        Axis["Mouse ScrollWheel"] = Input.GetAxisRaw("Mouse ScrollWheel");
        Axis["Submit"] = Input.GetAxisRaw("Submit");
        Axis["Cancel"] = Input.GetAxisRaw("Cancel");

        if (callbacks.ContainsKey("FixedUpdate"))
        {
            callbacks["FixedUpdate"]
			.ToList()
			.ForEach(x => x());
        }
    }

    private void LateUpdate()
    {
        if (callbacks.ContainsKey("LateUpdate"))
        {
            callbacks["LateUpdate"]
			.ToList()
			.ForEach(x => x());
        }
    }

    public static bool IsBase64(string base64String)
    {
        if (
            string.IsNullOrEmpty(base64String) ||
            base64String.Length % 4 != 0 ||
            base64String.Contains(" ") ||
            base64String.Contains("\t") ||
            base64String.Contains("\r") ||
            base64String.Contains("\n")
        ) return false;
        try
        {
            System.Convert.FromBase64String(base64String);
            return true;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return false;
    }

    public static bool IsJSON(string j)
    {
        bool result = false;
        try
        {
            SimpleJSON.JSON.Parse(j);
            result = true;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return result;
    }
    
    public static void ResetMe()
    {
    //    PowerUI.UI.Html = "";
        callbacks = new Dictionary<string, List<Action>>();
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects().ToList().ForEach(x => {
            if (x.name != "invincible" && x.name != "#PowerUI") Destroy(x);
        });
    }
	

	
    public static void DoFunction(string funcName, string arg)
    {
        MethodInfo method = asm.GetType("Achdus.Yaakov").GetMethod(funcName);
        if (method != null)
        {
            method.Invoke(null, new object[] { arg });
        }
    }

    void Socketize(string server, string id)
    {
        var mainSocket = new CobySocket(server, (me) =>
        {
            me.Send("from unity", id);
            me.on("activate achdus", (info) =>
            {
            //    Debug.Log(info);
                string funcName = info["function"];
                string arg = info["arg"];
             //   Debug.Log("func: " + funcName);
                if(funcName != null && arg != null)
                {
                //    Debug.Log("doing " + funcName + " with " + arg);
                    DoFunction(funcName, arg);
                }
            });
            me.on("got binary", binary => {
           //     Debug.Log(binary);
            });
        });
    }

    [DllImport("_Internal")]
	private static extern void Hello();

	
	public Achdus.CameraController cameraComponent = null;
	public Camera ikarAyin = null;
	public Camera shneeuh = null;
	public Achdus.Domem ayinShaynee = null;
	public Achdus.Domem ayin = null;
    void Start()
    {
		ikarAyin = GetComponent<Camera>();
		cameraComponent = GetComponent<
			Achdus.CameraController
		>();
		var shnee = GameObject.Find(
			"shneeuh78"
		);
		/*ayin = new Achdus.Domem(new Achdus.Davar(new Dictionary<
				string,
				object
			>{
				{"gameObject", gameObject}
			})
		);*/
		if(shnee != null) {
			//ayinShaynee = new Achdus.Domem(new Achdus.Davar(
			//);
			/*var dict = new Dictionary<
					string,
					object
				>() {
					{"gameObject", shnee}
				};
			var dav = new Achdus.Davar(
				dict
			);
			ayinShaynee = new Achdus.Domem(dav);*/
			
			
			Achdus.Yaakov.on("Update", () => {
				shnee.transform.position = gameObject.transform.position;
				shnee.transform.rotation = gameObject.transform.rotation;
				//shnee.transform.Rotate(0f, 0.0f, 180.0f);
				/*shnee.transform.rotation = new Quaternion(
					gameObject.transform.rotation.x + (180 * ((float)Math.PI) / 180),
					gameObject.transform.rotation.y,
					gameObject.transform.rotation.z, 1f
				);*/
				//ayinShaynee.position = ayin.position;
			});
			shneeuh = shnee.GetComponent<Camera>();
			Matrix4x4 mat = Camera.main.projectionMatrix;
			mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
		//	shneeuh.projectionMatrix = mat;
		}
		/*string uis = "http://localhost:8000/ok.sk";
		Debug.Log("hey , its me");
		Debug.Log(URIHelper.GetDirectoryName(uis));
		Debug.Log("me again");
		Debug.Log(URIHelper.GetFileFromUri(new Uri(uis)));
		Debug.Log("OK by");*/
        Achdus.Yaakov.InitAsync(this);
		
        /*
        readFile("data.json", (result, err) => {

             if (result != null) {
                 var json = new Achdus.Davar(result);
                 Debug.Log(json);
                 if (json != null) {
                     if (json["server"] != null) {
                         serverURL = "ws://" + json["server"];
                     }

                     if (json["unityID"] != null) {
                         serverID = json["unityID"];
                     }

                     if(json["scripts"] != null) {
                        if(json["scripts"] is object[] arr) {
                            if(arr.Length > 0) {
                                if(arr[0] is string str) {
                                    int amountRead = 0;
                                    var looper = new Achdus.InfiniteLooper();
                                    looper.Set(new Action<string, string>((string res2, string err2) => {
                                        Achdus.Tzirum.scripts[arr[amountRead] as string] = res2;
                                        amountRead++;
                                       
                                        if (!(amountRead > arr.Length - 1)) {
                                       
                                            
                                            readFile(arr[amountRead].ToString(), looper.LoopMethod);
                                        } else {

                                        }
                                        
                                    }));
                                    readFile(arr[amountRead].ToString(), looper.LoopMethod);
                                   
                                }
                            }
                        }
                    }

                    if (serverURL != null && serverID != null) {
                       
                        Socketize(serverURL, serverID);
                        Debug.Log("Time: " + DateTime.Now.ToFileTime());
                    }
                 }
             }

             Achdus.Yaakov.SetPowerUIDoc("Loaded data info, processing...");
            

        });*/

     //   Achdus.Yaakov.SetPowerUIDoc("Hi there! Just loading some start up stuff");


	
		
		/* else {
			Debug.Log("WOW");
		//	Hello();
		}*/

        Brutalize(
			"ikar.html", 
			new Action<bool> (
				b => {
					if(!b) {
						Brutalize(
							"index.html", new Action<bool> (
								c => {
									if(!c) {
										Brutalize(
											"main.html", new Action<bool> (
												d => {
													if(!d)
														Achdus
														.Yaakov
														.SetPowerUIDoc(
															"nothing!"
														);
												}
											)
										);
									
									}
								}
							)
						);
						
					}
				}
			)
		);
		
        asm = typeof(Achdus.Yaakov).Assembly;
	//	Debug.Log(asm);
    }
	
	
	void Brutalize(string path, Action<bool> cb) {
		bool isData = false;
		bool isAndFirst = false;
		if(Application.platform == RuntimePlatform.WebGLPlayer) {
			path = Application.dataPath + "/" + path;
			isData = true;
		}
		if(Application.platform == RuntimePlatform.Android) {
			path = "etzem://" + path;
			isAndFirst = true;
		}
		
		new Achdus
		.Giluy(
			path,
			new Action<object, string>(
				(rez, err) => {
					if(err != null) {
						if(!isData)
						new Achdus
						.Giluy(
							!isAndFirst ?
								"etzem://" :
							"" + path,
							new Action<object, string>(
								(rez2, err2) => {
									if(err2 != null) {
										new Achdus
										.Giluy(
											"dayuh://" + path,
											new Action<object, string>(
												(rez3, err3) => {
													if(err3 != null) {
													} else {
														Achdus
														.Yaakov
														.SetPowerUIDoc(
															rez3 as string
														);
													}
												}
											)
										);
									} else {
										Achdus
										.Yaakov
										.SetPowerUIDoc(
											rez2 as string
										);
									}
								}
							)
						);
					} else {
					
						if(rez is string) {
							Achdus
							.Yaakov
							.SetPowerUIDoc(
								rez as string
							);
						}
					}
				}
			)
		);
	/*new System.Action<object, string>(
		try {
			
			var path = url != null ? url : "http://localhost:770/main.html";
			readFile(path, (result, err) => {
				if(result != null) {
					Achdus.Yaakov.SetPowerUIDoc(result);
				} else if(err != null) {
					Debug.Log(err);
					readFile(path, (result2, err2) => {
						if(err2 != null) {
							Debug.Log(err2);
						}
						if(result2 != null){
							Achdus
							.Yaakov
							.SetPowerUIDoc(
								result2
							);
							
						}
					}, true);
				}
			});
		} catch(Exception e){}*/
	}
	
	public void Cobifilous() {
		Debug.Log("HI THERE");
	}
	
    public IEnumerator GetURLCoroutine(string url, Action<DownloadHandler, string> cb) {
		//Debug.Log("aboutto get it " +url);
        var www = UnityWebRequest.Get(url); //UnityWebRequest.Get(url);
			
        yield return www.SendWebRequest();
        string error = null;
        if (www.isNetworkError || www.isHttpError) {
            error = www.error;
			Debug.Log("LOL man rly???" + error);
            cb(null, error);
        }
        else {
		
            cb(www.downloadHandler, error);
        }
    }
	public void his(string now) {
		Debug.Log("OK!!!!!" + now);
	}
    public void GetURL(string url, Action<DownloadHandler, string> cb) {
   //     var getter = new Getter();
        StartCoroutine(GetURLCoroutine(url, cb));
    }

    void readFile(string fileName, Action<string, string> cb, bool purs = false) {
        var result = "";
		var c = new StringComparison();
        var path = fileName;
		//Application.dataPath + "/" + 
		if(path.IndexOf("http", 0, 4, c) == -1)
			path = Application.dataPath + "/" + path;
		
        
	//	Debug.Log("got it" + path);
        if (path.IndexOf("http", 0, 4, c) > -1) {

            GetURL(path, (dh, err) => {

                if(dh != null && dh.text != null) {
                    cb(dh.text.ToString(), null);
                } else if(err != null) {
                    cb(null, err);
                } else {
                    cb(null, null);
                }
            });
        }
        else {
		//	Debug.Log("nopedy " + path);
            try {
				var pawth = "";
				if(!purs) {
					pawth = Application
						.dataPath;
				} else {
					pawth = Application
						.persistentDataPath;
				}
                var r = new System.IO.StreamReader(pawth + "/" + fileName);

                result = r.ReadToEnd();
                cb(result, null);
                r.Close();
            } catch (Exception e) {
				
                cb(null, "Error for path:\"" + path + "\"Couldn't get to 'dat file man: " + e);
            }
        }
    }
}

namespace Achdus
{
    public class InputSystem {
        private Dictionary<string, float> axes = new Dictionary<string, float>();
        public InputSystem() {

        }

        public void SetAxis(string axis, float value) {
            axes[axis] = value;
        }

        public float GetAxisRaw(string axis) {
            if(axes.ContainsKey(axis)) {
                return axes[axis];
            } else {
                return 0;
            }
        }

        public float GetAxis(string axis) {
            return GetAxisRaw(axis);
        }

        
    }

    public static class Input
    {
        public static float GetAxis(string axis)
        {
            float result = 0;
            if(COBY.Axis.ContainsKey(axis))
            {
                result = COBY.Axis[axis];
            }
            return result;
        }

        public static float GetAxisRaw(string axis)
        {
            return GetAxis(axis);
        }
    }

    public class Tafkid {
        public string Name { get; set; }
        public string Parameters { get; set; }
        public string Body { get; set; }
    }

    class InfiniteLooper {
        Action<string, string> mid;

        public InfiniteLooper() { }
        public InfiniteLooper(Action<string, string> act) {
            mid = act;
        }

        public void Set(Action<string, string> middleAction) {
            mid = middleAction;
        }

        public void LoopMethod(string res2, string err2) {
            mid?.Invoke(res2, err2);
        }
		
    }

    public class Yaakov
    {
        public static Davar hashObjs = new Davar();
		public static Davar nivrayim = new Davar();
		public static int nivraCount = 0;
        public static COBY mainCoby = null;
        public static Jint.Engine engine;
        private static List<Action> acts = new List<Action>();
		
		public static void HoyseefNivra(string shaym, Heeoolee n) {
			nivrayim[shaym] = n;
			nivraCount++;
		}
		
		public static void SealaykNivra(string shaym) {
			var niv = ChuhpayshNivra(shaym);
			if(niv != null) {
				MonoBehaviour.Destroy(niv.gameObject);
				nivrayim.deleteProperty(shaym);
			}
		}
		
		public static void MishahnehNivra(string shaym, string shaymChadash) {
			
			if(nivrayim[shaym] != null) {
				try {
				nivrayim[shaymChadash] = nivrayim[shaym];
				nivrayim.deleteProperty(shaym);
				} catch(Exception e) {
					Debug.Log("WEL:?" + e);
				}
			}

			
		}
		
		public static Heeoolee ChuhpayshNivra(string shaym) {
			return (
				nivrayim[shaym] 
			);
		}
		
        public static async void InitAsync(COBY c) {
            mainCoby = c;

            var tst = new Dom.Event("hia");

            engine = new Jint.Engine();
           
            try {
           
            } catch(Exception e) {
                Debug.Log("HA : "+e);
            }
        }

		public static string shaymifier() {
			string rez = "";
			/*for(int i = 0; i < 10; i++) {
				rez += i;
				
			}*/
			rez += nivraCount;
			return rez;
		}
		
        public static void JsFunction(object func) {

            
            try {
                var j = func as Func<JsValue, JsValue[], JsValue>;
                
            } catch(Exception e) {
                Debug.Log(e);
            }
        }

        public static string MakeCobyString(string _source, Jint.Parser.Ast.Statement body, IEnumerable<Jint.Parser.Ast.Identifier> parameters, Jint.Parser.Ast.Identifier id) {
            var paramsStr = "";
            for(var p = 0; p < parameters.Count(); p++) {
                paramsStr += parameters.ElementAt(p).Name;
                if(p < parameters.Count() - 1) {
                    paramsStr += ",";
                }
            }
       //     Debug.Log(paramsStr);
            var sourceLines = _source.Split('\n');
            var startLine = body.Location.Start.Line;
            var endLine = body.Location.End.Line;

            var startCol = body.Location.Start.Column;
            var endCol = body.Location.End.Column;
            var functionStr = "function";
            if (id != null) {
                functionStr += " " + id.Name;
            }
            var grandSubStr = "";

            for (var lineNumb = startLine - 1; lineNumb < sourceLines.Length; lineNumb++) {
                var str = sourceLines[lineNumb];
                var tmpSubstring = "";

                if (lineNumb == startLine - 1) {
                    var subLength1 = str.Length - startCol;

                    tmpSubstring = str.Substring(startCol - 1, subLength1);
                    
                }
                else if (lineNumb + 1 < endLine) {
                    tmpSubstring = str;
                }
                else {

                //    tmpSubstring = str.Substring(endCol - 1, endCol);

                    grandSubStr += tmpSubstring;
                    break;
                }
                
                grandSubStr += tmpSubstring + "\n";
            }


            functionStr += "(" + paramsStr + ") {" + grandSubStr + "}";
            
            return functionStr;
        }
		public static void hi() {
			Debug.Log("ASDF");
		}
        public static void Giluy(object path, dynamic cb) {
            new Giluy(path, cb);
        }

        public static void doDOMActions() {
            for(var i = 0; i < acts.Count; i++) {
                acts[i]?.Invoke();
            }
            acts.Clear();
        }

        public static Dom.Node GetById(string id) {
           return PowerUI.UI.document.getElementById(id);
        }

        public static void addToFinishedLoadingQue(Action a) {
            acts.Add(a);
        }
		
		public static void IkarThread(
			Func<JsValue, JsValue[], JsValue> act
		) {
			COBY.queueOfActionsInMainThread.Add(() => {
				act(
					1, new JsValue[] {}
				);
			});
		}
		
		public static void IkarThread(
			Action act
		) {
			COBY.queueOfActionsInMainThread.Add(() => {
				act();
			});
		}
        public static void CompileJavaScript(string js)
        {
            COBY.ResetMe();
            var html = "<!doctype html><html><head><meta charset=\"UTF-8\"><style>body,html{color:black;} .wow:hover{background:yellow}</style></head><body><script>";
            foreach(var script in Tzirum.scripts) {
                html += script.Value;
            }
            html += js + "</script></body></html>";

            PowerUI.UI.Html = html;

        }

        public static void SetPowerUIDoc(string html)
        {
            PowerUI.UI.Html = html;
        }

        public static void ClearGameObjects() {
            COBY.ResetMe();
        }

        public static void on(string func, Action cb)
        {
            if(!COBY.callbacks.ContainsKey(func)) COBY.callbacks[func] = new List<Action>();
            COBY.callbacks[func].Add(cb);
        }
		
		public static bool removeEvent(
			string fnc, 
			Action ac
		) {
			if(COBY.callbacks.ContainsKey(fnc)) {
				var index = COBY
					.callbacks[fnc]
					.IndexOf(ac);
				if(index > -1) {
					COBY.callbacks[fnc].RemoveAt(index);
					return true;
				} else return false;
			} else return false;
		}
		
		public static void require(string pth) {
			new Giluy(
				pth,
				new Action<object, string>((r, e) => {
					if(e == null) {
						var k = r as string;
						Debug.Log(r as string);
						PowerUI.UI.Html += "<script>" + 
						k +
						"</script>";
					}
				})
			);
		}

        
    }
}