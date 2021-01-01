using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jint.Native;
using System.Dynamic;
using System.Text;
using Dom;

namespace Achdus {
    public class TestJS {
        public TestJS(JsValue v) {
            Debug.Log("JST DID " + v);
        } 
    }

    public class Event {
        public Func<JsValue, JsValue[], JsValue> cb = null;
        public string EventType = "";
        public Dom.Event other;
        public string data {
            get {
                return other.data;
            } set {
                other.data = value;
            }
        }
        public Event(string str) {
            EventType = str;
            other = new Dom.Event(str);
        }

        public Event(string str, Func<JsValue, JsValue[], JsValue> func) {
            EventType = str;
            cb = func;
            other = new Dom.Event(str);
        }
    }

    public class EventTarget {
        Dictionary<string, List<Event>> myEvents = new Dictionary<string, List<Event>>();
       /* public void dispatchEvent(Event evn, string data) {
            Debug.Log("What is this data? " + data);
            evn.data = data;
            var evnt = evn.EventType;
            if (myEvents.ContainsKey(evnt)) {
                foreach(var k in myEvents[evnt]) {
                    
                    k.cb(JsValue.FromObject(Yaakov.engine,this), new JsValue[] { JsValue.FromObject(PowerUI.UI.document.JavascriptEngine.Engine,k)});
                }
                
            }
            
        }
        public void dispatchEvent(Event evn) {
            dispatchEvent(evn, "");
        }
		*/

        public void cobify(string ok) {
            if(myEvents.ContainsKey(ok)) {
                var thing = myEvents[ok];
                thing[0].cb(JsValue.FromObject(Yaakov.engine, this), new JsValue[] { "gw" });
            }
        }

        public void addEventListener(string str, Func<JsValue, JsValue[], JsValue> func) {

            if (!myEvents.ContainsKey(str)) {
                myEvents[str] = new List<Event>();
            }
            myEvents[str].Add(new Event(str, func));
            var evn = myEvents[str][0];
            var k = myEvents[evn.EventType][0];
       //     k.cb(JsValue.FromObject(Yaakov.engine,this), new JsValue[] { "afa" });
            // func(JsValue.FromObject(Yaakov.engine, this), new JsValue[] { "asdf"});
        }
    }

    public class Hi : Dom.EventTarget {
        public Hi(JsValue a) {

        }
        public Hi() : this(null) { }
    }
	
	public class Cob {
		/*private Dictionary<string, List<Func<JsValue, JsValue[], JsValue>>> lst = (
			new Dictionary<string, List<Func<JsValue, JsValue[], JsValue>>>
		);*/
		public static Davar lst = new Davar("{}");
		public static void on(string name, Func<JsValue, JsValue[], JsValue> fnc) {
			//cb(JsValue.FromObject(Yaakov.engine, this), new JsValue[] { "gw" });
			
			if(lst[name] == null) {
				lst[name] = new List<object>();
			}
			lst[name].Add(fnc);
		}
		
		public static void Eventify(string ev,  string txt) {

			if(lst[ev] != null) {
				for(var i = 0; i < lst[ev].Count; i++) {
					var t = lst[ev][i] as Func<JsValue, JsValue[], JsValue>;
					
					if(txt != null && t != null) {
						t(
							JsValue.FromObject(Yaakov.engine, ""), 
							new JsValue[] { 
								txt
							}
							
						);
					}
				}
			}
		}
		
		
	}

    public class MyWebSocket : Dom.EventTarget {
        
        
        private HybridWebSocket.WebSocket _socket;
        private Action CustomOnOpen = () => {};
        private long timeSinceCreated = 0;
        private JsValue _constructor = null;

        public string url = "";
        public int readyState {
            get {
                if (_socket != null) {
                    return (int)_socket.GetState();
                } else {
                    return 0;
                }
            }
        }
        public string binaryType = "blob";
        public int bufferedAmount = 0;
        public string extensions = "";
        public string protocol = "";

        public static int CLOSED = 3;
        public static int CLOSING = 2;
        public static int CONNECTING = 0;
        public static int OPEN = 1;

        public long timeStamp {
            get {
                return (DateTime.Now.ToFileTime() - timeSinceCreated) / 10000;
            }
        }

        public object constructor {
            get {
                if(_constructor == null) {
                    _constructor = Yaakov.engine.Eval.Call(null, new JsValue[] {
                        "(new function WebSocket() {}).constructor"
                    });
                }
                return _constructor;
            }
        }

        public MyWebSocket(JsValue url) {
             this.url = url.AsString();
             var openEvent = new Dom.Event("open");
             var msgEvent = new Dom.Event("message");
             var closeEvent = new Dom.Event("close");
             var errorEvent = new Dom.Event("error");
             _socket = HybridWebSocket.WebSocketFactory.CreateInstance(this.url);
            
           
            
            _socket.OnOpen += () => {

                COBY.queueOfActionsInMainThread.Add(() => {
                    timeSinceCreated = DateTime.Now.ToFileTime();
                    dispatchEvent(openEvent);
                });
                 CustomOnOpen();
                
        
             };
            
            _socket.OnMessage += (msgBytes) => {
                COBY.queueOfActionsInMainThread.Add(() => {
					
					
					
                //    msgEvent.data = ;
					
					
					
					var e = new Dom.Event("message");
					e.data = Encoding.UTF8.GetString(msgBytes);
                    dispatchEvent(e);
                });
                //    
            };

            _socket.OnClose += (e) => {
                COBY.queueOfActionsInMainThread.Add(() => {
                    closeEvent.code = int.Parse(e.ToString());
                    dispatchEvent(closeEvent);
                });
            };

            _socket.OnError += err => {
                COBY.queueOfActionsInMainThread.Add(() => {
                    errorEvent.code = err;
                    dispatchEvent(errorEvent);
                });
            };
            _socket.Connect();

        }

        

        private void myDispatch(Dom.Event iVent) {
         //   var l = Events.Get(iVent.EventType);
         //   foreach(var k in l) {
        //        k.handleEvent(iVent);
         //   }
        }

        public void close() {
            if(_socket != null) {
                _socket.Close();
            }
        }

        public object onmessage {
            get {
                return GetFirstDelegate<Dom.Event>("message");
            }
            set {
                eventListening(value, "message");
            }
        }

        public object onopen {
            get {
                return GetFirstDelegate<Dom.Event>("open");
            }
            set {
                eventListening(value, "open");
            }
        }

        private void eventListening(object value, string isit) {
       //     clearEventListeners();
            if (value is Func<JsValue, JsValue[], JsValue> func) addEventListener(isit, func);
        }
		
		
		
        public void send(string str) {
            //var str = val.AsString();
            _socket.Send(Encoding.UTF8.GetBytes(str));
        }
		
		public void send(byte[] val) {
            _socket.Send(val);
        }
		/*
		public void send(Yetzirah.HaaretzDayuh val) {
			var t = new System.Threading.Thread(() => {
				_socket.Send(val.dahs);
			});
			t.Start();
        }
     */
    }

    public class DavarList  {
        private List<dynamic> _myList = new List<dynamic>();
        public int length {
            get {
                return Count;
            }
        }
        public dynamic this[int index] {
            get => _myList[index]; set {
                _myList[index] = value;
                _myList.GetEnumerator();
            }
        }
        public DavarList() : this(new List<dynamic>()) { }

        public DavarList(dynamic input) {
            _myList = input;
        }
        public void Add(dynamic item) {
            _myList.Add(item);
        }

        public int Count {
            get {
                return _myList.Count;
            }
        }
        public void Clear() {
            _myList.Clear();
        }

        public override string ToString() {
            var result = "";
            result += "[";
            var index = 0;
            foreach(var i in this) {
				if(i != null) {
					result += i;
				} else {
					result += "null";
				}
                if (index < this.length - 1) {
                    result += ",";
                }
                index++;
            }
            result += "]";
            return result;
        }
        public IEnumerator<dynamic> GetEnumerator() {
           return _myList.GetEnumerator();
        }
    }

    public class Davar/* : IEnumerable*/{
        private Dictionary<string, object> myDict = new Dictionary<string, object>();
        private object mainObj;
		
		/*public IEnumerable GetEnumerable() {
			
		}*/
		
        public void test() {
            var css = new List<Css.StyleSheet>();
            var a = new DavarList(css);
            foreach(var k in a) {

            }
           
        }
        private static Jint.Native.Json.JsonSerializer cerial;
		public void deleteProperty(string keyName) {
			if(myDict.ContainsKey(keyName)) {
				myDict.Remove(keyName);
			}
		}
        
        public dynamic Get(string key) {
            if (myDict.ContainsKey(key)) {
                return this[key];
            }
            else {
                return null;
            }
        }

        public dynamic this[string ok] 
	
		{
            get {

                if (myDict.ContainsKey(ok)) {

                    if (!myDict[ok].GetType().ToString().Contains("System.Func`3[JsValue,JsValue[],JsValue]"))
                        return myDict[ok];
                    else {
                        var func = myDict[ok] as Func<JsValue, JsValue[], JsValue>;

                        return func.ToString();
                    }
                }
                else {
                    return null;
                }
            }
            set {
                myDict[ok] = value;
            }
        }


        public Davar() : this(new Dictionary<string, object>()) { }

        public Davar(JsValue js) {
            Init(myParser(js));
        }
		
        public Davar(string jsObj) {
            Init(myParser(jsObj));

        }

        public Davar(object input) : 
			this(JsValue.FromObject(
				PowerUI
				.UI
				.document
				.JavascriptEngine.Engine,
				input
			))
		{ 
			
		}


        public Davar(Dictionary<string, object> input) {


            Init(input);
        }

        private void Init(Dictionary<string, object> input) {
            
            cerial = new Jint.Native.Json.JsonSerializer(Yaakov.engine);
            var actualDict = input;
            if(actualDict == null) {
                actualDict = new Dictionary<string, object>();
            }
            foreach (var k in actualDict) {
                this[k.Key] = (dynamic)k.Value;
            }

        }

        Dictionary<string, object> myParser(string jsObj) {
            Dictionary<string, object> result;
            JsValue val;
            try {
                val = Yaakov.engine.Eval.Call(null,
                    new JsValue[] { "new Object(" + jsObj + ")" }
                );

            }
            catch  {

                val = JsValue.FromObject(Yaakov.engine, new Dictionary<string, object>() { });
            }
            try {
                result = val.ToObject() as Dictionary<string, object>;
            } catch {
                result = new Dictionary<string, object>() { };
            }
            return result;
        }

        Dictionary<string, object> myParser(JsValue jsObj) {
            Dictionary<string, object> result;
            try {
                result = jsObj.ToObject() as Dictionary<string, object>;
            }
            catch  {
                result = new Dictionary<string, object>();
            }
            return result;
        }

        public string Stringed() {
            return Stringed(myDict);
        }

        string Stringed(Dictionary<string, object> input) {
            string result = "{";
            var index = 0;
            foreach (var i in input) {
                result += "\"" + i.Key + "\":";
                result += Represent(i.Value);

                if (index < input.Count - 1) {
                    result += ",";
                }
                index++;
            }
            result += "}";
            return result;
        }

        string Represent(object i) {
            string result = "";

            if (i is string) {
                result += "\"" + i + "\"";
            } else if(i == null) {
				result += "null";
			}
            else if (i is Dictionary<string, object> asdf) {
                result += Stringed(asdf);
            }
            else if (i.GetType().ToString().Contains("System.Collections.Generic.List")) {
                var list = (dynamic)i;
                result += "[";
                for (var x = 0; x < list.Count; x++) {
                    result += Represent(list[x]);
                    if (x < list.Count - 1) {
                        result += ",";
                    }
                }
                result += "]";
            }
            else if (i is object[] arr) {
                result += "[";
                for (var x = 0; x < arr.Length; x++) {
                    result += Represent(arr[x]);
                    if (x < arr.Length - 1) {
                        result += ",";
                    }
                }
                result += "]";
            }
            else if (i.GetType().ToString().Contains("System.Func")) {
                if(i is Func<JsValue, JsValue[], JsValue> js) {
                    result += "\"" + js.toString() + "\"";
                } else 
                    result += "function(){}";

            }
            else if(
                  i.GetType().ToString().Contains("Int") ||
                  i.GetType().ToString().Contains("Double") ||
                  i.GetType().ToString().Contains("Single") ||
                  i.GetType().ToString().Contains("Long") ||
                  i.GetType().ToString().Contains("Float") ||
                  i.GetType().ToString().Contains("String")
                ) {
                result += i;
            } else {
                result += "\"" + i.ToString() + "\"";
            }
            return result;
        }

        public override string ToString() {
            return Stringed();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() {
            return myDict.GetEnumerator();
        }

        //  public IEnumerable 

        public Vector3 ToVector3() {
            float x = Get("x") != null ? Float(Get("x")) : 0;
            float y = Get("y") != null ? Float(Get("y")) : 0;
            float z = Get("z") != null ? Float(Get("z")) : 0;
            Vector3 result = new Vector3(x, y, z);
            return result;
        }

        public Quaternion ToQuaternion() {
            var vect = ToVector3();
            Quaternion temp = Quaternion.Euler(vect.x, vect.y, vect.z);
            return temp;
        }

        public static float Float(object inp) {
            return float.Parse(inp + "");
        }

        public float Float(string inp, float oy = 0) {
            var temp = Get(inp);

            return temp != null ? float.Parse((temp) + "") : oy;
        }

        public static Davar From(Dictionary<string, object> input) {
            return new Davar(input);
        }
        /*    public static void Objectify(Dictionary<String, System.Object> inputObject) {

            }*/
    }
}