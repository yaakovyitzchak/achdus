using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jint.Native;
using System;

namespace Achdus {

    public class Giluy {
        public string path;
        public dynamic cb;
		public bool isBinary = false;
        public Giluy(object path) : this(path, null) { }
		public Giluy(object path, object cb) : this(path, false, cb){}
        public Giluy(object path, bool bine, object cb) {
			isBinary = bine;
            if(path is string str) {
                this.path = str;
            } else if(path is JsValue js) {
                this.path = path.ToString();
            } else {
                try {
                    this.path = path.ToString();
                } catch(Exception e) {
                    Debug.Log(e);
                }
            }

            if(cb is Func<JsValue, JsValue[], JsValue> jsCB) {
                this.cb = jsCB;
            } else if(cb is Action<Davar, string> ac) {
                this.cb = ac;
            }

            if(this.path != null && this.cb != null) {
                load(this.cb);
            }
        }

		public static byte[] ReadBytes(string path) {
			return (
				System.IO.File.ReadAllBytes(
					path
				)
			);
		}

        public void load(object inputCB) {
            if(path != null) {
                var cb = new Action<object, string>((res,err) => {
                    if (inputCB is Func <JsValue, JsValue[], JsValue>) {
						byte[] bytes = null;
						string strang = null;
						if(res is byte[]) bytes = res as byte[];
						if(res is string) strang = res as string;
						JsValue ok = null;
						if(strang != null) {
							ok = new JsValue(
								strang
							);
						} else if(bytes != null) {
							ok = JsValue.FromObject(
								PowerUI
								.UI
								.document
								.JavascriptEngine
								.Engine,
								bytes
							);
						}
						
						(inputCB as Func<JsValue, JsValue[], JsValue>)
						(new JsValue(true), new JsValue[] {	
							ok, new JsValue(err)
						});
						
                    } else if (inputCB is Action<object, string> a) {
                        a(res,err);
                    }
                });
				var d = new Davar();
                if(path.IndexOf("http://") > -1 || path.IndexOf("https://") > -1) {
                  
					Yaakov.mainCoby.GetURL(path, (dh, err) => {
                        if(dh != null) {
							if(!isBinary)
								cb(dh.text, err);
							if(isBinary) {
								cb(dh.data, err);
							}
						}
						
                    });
                } else {

					var pers = "etzem://";
					var dayt = "dayuh://";

					if(
						path.Length > pers.Length &&
						path.Substring(0, pers.Length + 1)
						.IndexOf(pers) > -1
					) {
						path = (
							Application.persistentDataPath + "/" +
							path.Substring(
								pers.Length, path.Length
							)
						);
					}
					
					if(
						path.Length > dayt.Length &&
						path.Substring(0, dayt.Length + 1)
						.IndexOf(dayt) > -1
					) {
						path = (
							Application.dataPath + "/" +
							path.Substring(
								dayt.Length, path.Length
							)
						);
					}
					
					if(!isBinary) {
						var result = "";
						try {
							var r = new System.IO.StreamReader(path);

							result = r.ReadToEnd();
							r.Close();
							cb(result, null);
						} catch(Exception e) {
							cb(null, "some error " + e.ToString());
						}
					} else {
						try {
							var bites = (
								ReadBytes(path)
							);
							cb(bites, null);
						} catch(Exception e) {
							cb(null, "some error " + e.ToString());
						}
					}
					
			  
  
                }
            }
        }

        public void send() {

        }
    }
}