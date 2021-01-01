using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;
using System;
using SimpleJSON;
public class mouthMover : MonoBehaviour
{
 //   public string mouthJSONFileName;
    public  TextAsset  mouthJSONText;
    public string audioTrack = "";
	public string jsonData = "";
	
	
    public object[] mouths = null;
    public SimpleJSON.JSONNode mouthJSON = null;
    public string folderWithMouthsName;
    public GameObject DirectorObject = null;
    public Renderer myrenderer= null;
//    Object[] Pics = null;
    Shader transparentShader = null;
	public string mouthList = "";
	public string dataList = "";
    Dictionary<string, int> md = new Dictionary<string, int>
    {
        {"X",1},
        {"E",2},
        {"B",3},
        {"C",4},
        {"F",5},
        {"A",6},
        {"G",7},
        {"H",8},
        {"D",9},
    };
	Achdus.Davar lipData = new Achdus.Davar();
	private List<Texture> textures = new List<Texture>();
    int CurrentMouthIndex = 0;
    UnityEngine.Playables.PlayableDirector myDirector = null;
    void Start()
    {
		transparentShader = Shader.Find("Unlit/Transparent");
		myrenderer = GetComponent<Renderer>();
        myrenderer.material.shader = transparentShader;
		if(mouthList != "") {
			Debug.Log("OK man");
			Debug.Log(mouthList);
			Achdus.Yaakov.Giluy(
				mouthList, 
				(Action<Achdus.Davar, string>)((msg, er) => {
					Debug.Log("hey!!");
					if(msg["text"] != null) {
						Debug.Log(msg["text"]);
						var j= new Achdus.Davar(msg["text"]);/*
						try {
							j = JSON.Parse(msg["text"]);
						} catch(Exception e) {
							Debug.Log(e);
						}*/
						if(j != null) {
							Debug.Log("GOT J!");
							Debug.Log(j);
							if(j["mouths"] != null) {
								var c = j["mouths"].Length;
								var i = 0;
								Action<string> f = null;
								f =  (Action<string>)(s => {	
									if(i < c) {
										string h = j["mouths"][i];
										Debug.Log(h);
										Achdus.Yaakov.Giluy(
											h,
											new Action<Achdus.Davar, string>((m,e) => {
												if(m["data"] != null) {
													Debug.Log("got some data!");
													var data = m["data"];
													var tex = new Texture2D(2,2);
													
													tex.LoadImage((byte[])data);
													myrenderer.material.mainTexture = tex;
													textures.Add(tex);
													if(j["lipData"] != null) {
														/*
														*/
													}
													Debug.Log("added!");
													Debug.Log(textures.Count);
												}
											})
										);
										i++;
										f("S");
									}
								});
								f("a");
								/*
								for(var i = 0; i < j["mouths"].Count; i++) {
									Debug.Log("OK!");
									Debug.Log(j["mouths"][i]);
									
								}*/
							}
							if(j["lipData"] != null) {
								Achdus.Yaakov.Giluy(
									j["lipData"],
									new Action<Achdus.Davar, string>((ms, err) => {
										if(ms["text"] != null) {
											lipData = new Achdus.Davar(ms["text"]);
											Debug.Log("LOL A FIED!!!");
											Debug.Log(
												lipData["mouthCues"][10]["value"]
											);
											mouths = lipData["mouthCues"];
											Debug.Log(mouths);
										}
										Debug.Log(ms);
									})
								);
							}
							
							Debug.Log("LIPTER??");
							Debug.Log(j["lipData"]);
							
							
						}
					}/*
					if(msg.data != null) {
						Debug.Log("got some data!");
						Debug.Log(data);
						var tex = new Texture2D(2,2);
						tex.LoadImage(data);
						myrenderer.material.mainTexture = tex;
					}*/
					if(er != null) {
						Debug.Log(er);
					}
				})
			);
		}
		myDirector = DirectorObject.GetComponent<UnityEngine.Playables.PlayableDirector>();
		/*new COBY.Giluy(jsonData, delegate(str) {
				
			});
		}
		/*if(true) {
			
		}
        transparentShader = Shader.Find("Unlit/Transparent");
        audioTrack = "";
        string jsonTxt = null;
        Object[] picsToGet = null;
        
        if(DirectorObject != null)
        {
            myDirector = DirectorObject.GetComponent<UnityEngine.Playables.PlayableDirector>();
            Debug.Log(myDirector);
        }
     
            if (folderWithMouthsName != null)
            {
                picsToGet = Resources.LoadAll(folderWithMouthsName, typeof(Texture));
                Debug.Log(folderWithMouthsName);
                Debug.Log(picsToGet);
            }
     //       Debug.Log("trying to load JSON from " + mouthJSONFileName);
            /*TextAsset tmp = Resources.Load(System.IO.Path.Combine("JSON", mouthJSONFileName)) as TextAsset;
            if (tmp != null)
            {
                jsonTxt = tmp.text;
                Debug.Log("J!");
                Debug.Log(jsonTxt);
             }*/
			 /*
        if(mouthJSONText != null)
        {
            jsonTxt = mouthJSONText.text;
            Debug.Log(jsonTxt);
        }

        if(jsonTxt != null)
        {
            if (myDirector != null)
            {
                Init(myDirector, jsonTxt, picsToGet);
            }
        }
        */
		
    }
/*
    public void Init(UnityEngine.Playables.PlayableDirector director, string inputJSON, Object[] listOfPictures = null)
    {
        Debug.Log("going in");
        if (inputJSON != null)
        {
            Debug.Log("got in");


            var text = inputJSON;
            try
            {
                mouthJSON = SimpleJSON.JSON.Parse(text);
                if(mouthJSON != null)
                {
                    mouths = mouthJSON["mouthCues"];
                }
                Debug.Log(mouths);
                myrenderer = GetComponent<Renderer>();
                myrenderer.material.shader = transparentShader;
            } catch(System.Exception e)
            {
                Debug.Log("An error: ");
                Debug.Log(e);
            }
        }
        if(listOfPictures != null)
        {
            Pics = listOfPictures;
            Debug.Log(Pics);
        }
    }

    IEnumerator PlayMouth()
    {
        yield return new WaitForSeconds(0.04f);
        if (CurrentMouthIndex < Pics.Length)
        {
            CurrentMouthIndex++;
        }
        if (CurrentMouthIndex >= Pics.Length)
        {
            CurrentMouthIndex = 0;
        }
        StartCoroutine(PlayMouth());
    }
*/
    // Update is called once per frame
	private int k = 0;
    void Update()
    {
		/*
		if(k > textures.Count - 1) k = 0;
		if(textures.Count > 0) {
			myrenderer.material.mainTexture = textures[k];
		}
		k++;
		*/
		
        if (mouths != null && textures != null && myDirector != null && md != null)
        {
            var timeline = (TimelineAsset)myDirector.playableAsset;
            var actualTrack = timeline.GetOutputTracks()./*Where(t => t.name == audioTrack).*/
			
			FirstOrDefault(t => t is AudioTrack);
            var clip = actualTrack.GetClips().FirstOrDefault();
            var audioClip = ((AudioPlayableAsset)clip.asset).clip;
            var time = myDirector.time;
            var startTime  = clip.start;
            var endTime = clip.end;

            var curMouth = (Dictionary<string, dynamic>)(mouths.SingleOrDefault(dx => {
					/*var x = new Achdus.Davar(dx);
					Debug.Log(x);
					Debug.Log(dx);*/
					var x = dx as Dictionary<string, object>;
                   return (
						(double)x["start"] + startTime <= time && time <= (double)x["end"] + startTime || 
						(double)x["start"] == 0 &&  (double)x["start"] > time - startTime || 
						(double)x["end"] >= endTime
					);
					return true;
			}));
			Achdus.Davar cm = null;
			if(curMouth != null) {
				cm  = new Achdus.Davar(curMouth);
			}

            //  Debug.Log("Up-dating mouths: " + curMouth + " and time! " + time + " and start " + startTime + "and offset " + (time - startTime));
			var index = md[curMouth["value"]];
			
            var val = textures[index + 1];//textures.Where(x=>x.name.IndexOf(curMouth["value"]) > -1).FirstOrDefault();
            Debug.Log("value? " + val + "mouth in general: " + curMouth["value"]);
           
          //  Debug.Log(val);
            Debug.Log("Length ?" + textures.Count);
            if (val != null)
            {
                myrenderer.material.mainTexture = (Texture)val;
            }
            else
            {
                 Debug.Log("WELL");
            }
            
        }
    }
}
