using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Siccity.GLTFUtility.Importer.LoadFromFileAsync(
			"ok/wow.gltf",
			new Siccity.GLTFUtility.ImportSettings(),
			lol
		);
    }
	void lol(GameObject go, AnimationClip[] ans) {
		Debug.Log("WE");
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
