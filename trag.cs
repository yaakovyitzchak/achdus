using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trag : MonoBehaviour
{
	float dir = 0;
	public float wow = 0;
	CharacterController cc = null;
    // Start is called before the first frame update
    void Start()
    {
		cc = gameObject.GetComponent<CharacterController>();
		if(cc == null) {
			cc = gameObject.AddComponent<CharacterController>();
		}
        Debug.Log("sdadww!");
    }

    // Update is called once per frame
    void Update()
    {
		dir = Input.GetAxisRaw("Horizontal");
			gameObject.transform.position = new Vector3(
				gameObject.transform.position.x + dir / 10 * wow,
				gameObject.transform.position.y,
				gameObject.transform.position.z
				
			);
    }

	
	void OnTriggerEnter(Collider h) {
		Debug.Log("oh now!");
		
	}
}
