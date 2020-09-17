using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outfitter : MonoBehaviour
{
    [Serializable]
    public struct CobyOutfit
    {
        public string name;
        public string color;
    }
    public List<CobyOutfit> myOut;
    public Dictionary<string, Material> ClothMaterials = new Dictionary<string, Material>();
    // public List<List<string>> hi;
    public TextAsset ClothsJSON;
    private SimpleJSON.JSONNode clothes;/* = new Dictionary<string, string>() {
        {"shirt", "white"},

        { "pants", "black" },
        {"hat", "black"},

        {"tzitzis", "white"},
        {"hair", "#826641"},
        {"face", "brown"},
        {"jacket","black"},
        {"pupal","black"},
        {"shoes","black"},
        {"yarmulka","black"},
        {"skin","#f9da84"},
        {"eye","white"}
    };*/

    void MakeOutfit(string outfitJSONText = null)
    {
        if (outfitJSONText != null)
        {

          //  Debug.Log("Wokring with JSON");
         //   Debug.Log(ClothsJSON);
            try
            {
                clothes = SimpleJSON.JSON.Parse(outfitJSONText);
   //             Debug.Log("REal JSON");
                Debug.Log(clothes);

            } catch(Exception e)
            {
                Debug.Log(e);
            }
            if (clothes != null)
            {
                var renderers = (GetComponentsInChildren<Renderer>());
                // var skin = GetComponent<SkinnedMeshRenderer>();
                Debug.Log(renderers);
                Debug.Log(renderers.Length);
                foreach (var skin in renderers)
                {

                    int size = skin.materials.Length;
                    var maters = new Material[size];
                    var materials = skin.materials;
           //         Debug.Log(materials);
           //         Debug.Log("How much materials??");
           //         Debug.Log(materials.Length);
                    for (int k = 0; k < size; k++)
                    {
                    //    Debug.Log("Here goes a mat:");


                        materials[k] = new Material(Shader.Find("Standard"));
                        materials[k].name = skin.materials[k].name;
                        skin.materials[k].color = new Color(200, 2, 3);
                        //Debug.Log(materials[k]);
                        var m = materials[k];

                        string updatedName = m.name.Replace(" (Instance)", "");
                        skin.materials[k].name = updatedName;
                     //   Debug.Log("new name?");
                      //  Debug.Log(skin.materials[k].name);
                        ClothMaterials[updatedName] = skin.materials[k];

                    }
                }

                //    i.materials = materials;



                processClothColors(clothes);
            }
        }
    }

    private void processClothColors(SimpleJSON.JSONNode temp)
    {
        if (temp != null && temp.Count > -1)
        {
            foreach (var x in temp)
            {
                ChangeCloth(x.Key, x.Value);
            }
        }
    }

    public void ChangeCloth(string clothName, string colorName)
    {
        Color myCol;
        if (ColorUtility.TryParseHtmlString(colorName, out myCol))
        {
            if (ClothMaterials.ContainsKey(clothName))
            {
 
                ClothMaterials[clothName].color = myCol;

            } else
            {

               
            }
            
        } else
        {
            print("color didn't work:" + clothName + ", with color:" + colorName);
        }
    }
    int m = 0;
    IEnumerator PlayMouth()
    {
        yield return new WaitForSeconds(0.04f);
        if(m < pics.Length)
        {
            m++;
        } 
        if(m >= pics.Length)
        {
            m = 0;
        }
        StartCoroutine(PlayMouth());
    }
    // Start is called before the first frame update
    UnityEngine.Object[] pics;
    Renderer myrenderer;
    UnityEngine.Playables.PlayableDirector pd = null;
    SimpleJSON.JSONNode mouths = null;
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
    void Start()
    {

        /*  var cube = GameObject.Find("Cube");
          if(cube != null)
          {
              pd = cube.GetComponent<UnityEngine.Playables.PlayableDirector>();
          }
          if (pd != null)
          {
              pics = Resources.LoadAll("mouth", typeof(Texture));
              myrenderer = GetComponent<Renderer>();
              Debug.Log(pics);
              Debug.Log(myrenderer);
              StartCoroutine(PlayMouth());
              Debug.Log("About to send stuff!");
              var socket = new COBY.CobySocket("ws://localhost:8000");
              socket.on("cool google response", (data) =>
              {
                  Debug.Log("I GOT IT!!!!!");
                  Debug.Log(data);
                  var myJson = SimpleJSON.JSON.Parse(data);
                  mouths = myJson["mouthCues"];
                  Debug.Log(mouths);
              });
              socket.Send("get me an exclusive file", "http://localhost:8000/file/1kvWv3CtFCqfQUMldtjfAB2nWBeTiJXWNTXAYh8h07uI");


          } else
          {
              Debug.Log("NULLD");
          }*/
        if (ClothsJSON != null)
        {
            MakeOutfit(ClothsJSON.text);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouths != null) {
          
            for(int i = 0; i < mouths.Count; i++)
            {
                var time = pd.time;
            
                if (mouths[i]["start"] < time && time < mouths[i]["end"])
                {
                    var val = md[mouths[i]["value"]];
                    Debug.Log(val);
             //       Debug.Log("Length ?" + pics.Length);
                    if (val < pics.Length)
                    {
                        myrenderer.material.mainTexture = (Texture)pics[val-1];
                    }
                } else
                {
        //            Debug.Log("WELL");
                }
            }
        } else
        {
       //     Debug.Log("NO");
        }
        
       // Debug.Log("CUrrent time " + pd.time);
    }
}
