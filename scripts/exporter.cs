using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityGLTF;
using System.IO;
public class exporter : MonoBehaviour
{
	
	public string RetrieveTexturePath(UnityEngine.Texture texture)
	{
		return gameObject.GetComponent<Renderer>().sharedMaterial.mainTexture.name;
	}
	public string outputFile = "file";
	// Use this for initialization
	void Awake()
	{
		/*var exporter = new GLTFSceneExporter(new[] {transform}, RetrieveTexturePath);
		var appPath = Application.dataPath;
		var wwwPath = appPath.Substring(0, appPath.LastIndexOf("Assets")) + "www";
		exporter.SaveGLTFandBin(wwwPath, outputFile);*/
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
