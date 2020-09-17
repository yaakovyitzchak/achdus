using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Jint.Native;

namespace Achdus {
    public static class Tzirum {
        private static Dictionary<string, byte[]> RawAssetDataList = new Dictionary<string, byte[]>();
        public static void LoadAsset(string name, byte[] content) {
            RawAssetDataList[name] = content;
        }

        public static Davar scripts = new Davar();
        public static Davar Textures = new Davar();

        public static Texture2D GetTexture(string textureName) {
            return Textures[textureName];
        }

        public static void LoadTextures(JsValue list) {
            LoadTextures(new DavarList(list));
        }

        public static void LoadTextures(DavarList list) {
            if (list[0] != null) {
                var davar = new Davar(list[0]);
                if (davar["name"] is string str && davar["url"] is string url) {
                    var index = 0;
                    var looper = new InfiniteLooper();
                    looper.Set((res, err) => {
                        LoadTexture(davar["name"], davar["url"], new Action<string>((er) => {
                            if(index < list.length - 1) {
                                LoadTexture(davar["name"], davar["url"], new Action<string>(a => looper.LoopMethod(a, er)));
                            }
                            index++;
                        }));


                    });
                }
            }
        }

        public static void LoadTexture(string name, string url, Action<string> cb) {
            if (Textures[name] != null || Textures[url] != null) {
                cb(null);
            }
            else {
                LoadAsset(name, url, (bytes, err) => {

                    if (err == null && bytes != null) {

                        try {
                            var texture = new Texture2D(0, 0);
                            texture.LoadImage(bytes);

                            var realName = name;
                            if (realName == null) {
                                realName = url;
                            }
                            Textures[realName] = texture;
                       
                            cb(null);
                        }
                        catch (Exception e) {
                            Debug.Log("maybe here?");
                            cb(e.ToString());
                        }
                    }
                    else {
                        Debug.Log("or is it?" + err);

                        cb(err);
                    }
                });
            }
        }

        public static void LoadTexture(dynamic jsDict) {
            var dict = new Davar(jsDict);
     
            if (dict["url"] != null) {
                LoadTexture(
                    dict["name"],
                    dict["url"],
                    new Action<string>(err => {
                        var func = dict["callback"];
                        if(func is Func<JsValue, JsValue[], JsValue> jsFunc) {
                            jsFunc?.Invoke(
                                new JsValue(true),
                                new JsValue[] {
                                    err
                                }
                            );
                        }
                    })
                );
            }
        }

        public static void LoadAsset(string name, string url, Action<byte[], string> cb) {
		/*
            if (Yaakov.mainCoby != null) {
                Yaakov.mainCoby.GetURL(url, (handler, err) => {
                    if (handler != null && handler.data != null) {
                        LoadAsset(name, handler.data);
                        cb(handler.data, err);
                    }
                    else {
                        cb(null, err);
                    }
                });
            }
            else {
                cb(null, "couldn't find mainCoby!");
            }
			
			*/

			new Achdus.Giluy(
				url,
				true,
				new System.Action<object, string>(
					(res, err) => {
						if ( 
							res is byte[]
						) {
							LoadAsset(name,res as byte[]);
							cb(res as byte[], err);
						}
						else {
							cb(null, err);
						}
					}
				)
			);
        }

        public static void LoadAssets(Dictionary<string, object> json, Func<JsValue, JsValue[], JsValue> cb) {
            var davar = Davar.From(json);
        }


        public static byte[] GetRaw(string assetName) {
            if (RawAssetDataList.ContainsKey(assetName)) {
                return RawAssetDataList[assetName];
            }
            else {
                return null;
            }
        }
    }
}