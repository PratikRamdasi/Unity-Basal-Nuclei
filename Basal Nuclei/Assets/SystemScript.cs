using UnityEngine;
using System.Collections;

public class SystemScript : MonoBehaviour {
	float intensity;
	float direct_input, dopa_input, indirect_input;
	float direct_is, indirect_is, dopa_is;
	ArrayList decreasing_direct, increasing_direct, decreasing_indirect, increasing_indirect, special;
	Color c;

	// Use this for initialization
	void Start () {
		decreasing_indirect = new ArrayList (new GameObject[] {
			GameObject.Find ("IndirectGPe"),
			GameObject.Find ("IndirectThal")
		});

		increasing_indirect = new ArrayList (new GameObject[]{
			GameObject.Find("IndirectCortex"),
			GameObject.Find("IndirectPutamen"),
			GameObject.Find("IndirectSubThal"),
			GameObject.Find("IndirectGPi "),
			GameObject.Find("IndirectSNr")

		});
		Debug.Log ("hello");
		decreasing_direct = new ArrayList (new GameObject[]{
			GameObject.Find("DirectGPi"),
			GameObject.Find("DirectSNr")
		});
		increasing_direct = new ArrayList (new GameObject[]{
			GameObject.Find("DirectCortex"),
			GameObject.Find("DirectPutamen"),
			GameObject.Find("DirectThal")
		});
		special = new ArrayList (new GameObject[]{
			GameObject.Find("DirectSNc"),
			GameObject.Find("IndirectSNc")
		});

		intensity = 0.0f;
		dopa_input = 0.5f;
		direct_input = 0.5f;
		indirect_input = 0.5f;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.X)) {
			direct_input = .1f;
			excite(direct_input);
			inhib (direct_input);
			//Debug.Log (100f * intensity);
		
		} else if (Input.GetKeyDown (KeyCode.C)) {
			direct_input = .3f;
			excite(direct_input);
			inhib (direct_input);
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.V)) {
			direct_input = .5f;
			excite(direct_input);
			inhib (direct_input);
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.B)) {
			direct_input = .7f;
			excite(direct_input);
			inhib (direct_input);
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.N)) {
			direct_input = .8f;
			excite(direct_input);
			inhib (direct_input);
			//Debug.Log (100f * intensity);

		}else if (Input.GetKeyDown (KeyCode.M)) {
			direct_input = 1f;
			excite(direct_input);
			inhib (direct_input);
			//Debug.Log (100f * intensity);

		}else if (Input.GetKeyDown (KeyCode.E)) {
			indirect_input = .1f;
			excite_indirect (indirect_input);
			inhibit_indirect (indirect_input);
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.R)) {
			indirect_input = .3f;
			excite_indirect (indirect_input);
			inhibit_indirect (indirect_input);
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.T)) {
			indirect_input = .4f;
			excite_indirect (indirect_input);
			inhibit_indirect (indirect_input);
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.Y)) {
			indirect_input = .6f;
			excite_indirect (indirect_input);
			inhibit_indirect (indirect_input);
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.U)) {
			indirect_input = .8f;
			excite_indirect (indirect_input);
			inhibit_indirect (indirect_input);
			//Debug.Log (100f * intensity);

		}else if (Input.GetKeyDown (KeyCode.I)) {
			indirect_input = 1.0f;
			excite_indirect (indirect_input);
			inhibit_indirect (indirect_input);
			//Debug.Log (100f * intensity);

		}else if (Input.GetKeyDown (KeyCode.F)) {
			dopa_input = 1f;
			dopa_input_func ();
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.G)) {
			dopa_input = .7f;
			dopa_input_func ();
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.H)) {
			dopa_input = .6f;
			dopa_input_func ();
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.J)) {
			dopa_input = .5f;
			dopa_input_func ();
			//Debug.Log (100f * intensity);

		} else if (Input.GetKeyDown (KeyCode.K)) {
			dopa_input = .3f;
			dopa_input_func ();
			//Debug.Log (100f * intensity);

		}else if (Input.GetKeyDown (KeyCode.L)) {
			dopa_input = 0.0f;
			dopa_input_func ();
			//Debug.Log (100f * intensity);
		}
	}
	float calc_intensity(float input, float direct_is, float dopa_is){
		//Debug.Log (input + " " + direct_is + "  " + dopa_is);
		intensity = 0.5f+(direct_is*((input-0.5f)/2.0f))+(((dopa_input-0.5f)/2.0f)*dopa_is);
		return intensity;
	}

	// DIRECT

	void inhib(float input){
		foreach(GameObject obj in decreasing_direct){
			switch (obj.name) {
			case "DirectGPi":
				direct_is = -1;
				dopa_is = -1;
				break;
			case "DirectSNr":
				direct_is = -1;
				dopa_is = -1;
				break;
			}
			intensity = calc_intensity (input, direct_is, dopa_is);
			if (obj.name == "DirectGPi") {
				c = new Color (intensity, 0.0f, 0.0f, intensity);
			} if (obj.name == "DirectSNr") {
				c = new Color (intensity, 0.0f, 0.0f, intensity);
			}else {
				c = new Color (0.0f, intensity, 0.0f, intensity);
			}
			obj.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", c);
		}
	}
	void excite(float input){
		foreach(GameObject obj in increasing_direct){
			switch(obj.name) {
			case "DirectCortex":
				direct_is = 1;
				dopa_is = 0;
				break;
			case "DirectPutamen":
				direct_is = 1;
				dopa_is = 1;
				break;
			case "DirectThal":
				direct_is = 1;
				dopa_is = 1;
				break;
			}
			intensity = calc_intensity (input, direct_is, dopa_is);
			if (obj.name == "DirectPutamen") {
				c = new Color (intensity, 0.0f, 0.0f, intensity);
			} else {
				c = new Color (0.0f, intensity, 0.0f, intensity);
			}
			obj.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", c);
		}
	}


	// INDIRECT
	void excite_indirect(float input){
		for(int i = 0; i < increasing_indirect.Count; i++){
			GameObject obj = (GameObject)increasing_indirect [i];
			//foreach(GameObject obj in increasing_indirect){
			//Debug.Log (obj.name);
			switch (obj.name) {
			case "IndirectCortex":
				direct_is = 1;
				dopa_is = 0;
				break;
			case "IndirectPutamen":
				direct_is = 1;
				dopa_is = -1;
				break;
			case "IndirectSubThal":
				direct_is = 1;
				dopa_is = -1;
				break;
			case "IndirectGPi ":
				direct_is = 1;
				dopa_is = -1;
				break;
			case "IndirectSNr":
				direct_is = 1;
				dopa_is = -1;
				break;
			default:
				direct_is = 1;
				dopa_is = 1;
				break;
			}
			intensity = calc_intensity (input, direct_is, dopa_is);
			if (obj.name == "IndirectPutamen") {
				c = new Color (intensity, 0.0f, 0.0f);
			} else if (obj.name == "IndirectGPi ") {
				c = new Color (intensity, 0.0f, 0.0f);
			} else if (obj.name == "IndirectSNr") { 
				c = new Color (intensity, 0.0f, 0.0f);
			} else {
				c = new Color (0.0f, intensity, 0.0f);
			}
			obj.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", c);
		}
	}
	void inhibit_indirect(float input){
		foreach(GameObject obj in decreasing_indirect){
			switch(obj.name) {
			case "IndirectGPe":
				direct_is = -1;
				dopa_is = 1;
				break;
			case "IndirectThal":
				direct_is = -1;
				dopa_is = 1;
				break;
			}
			intensity = calc_intensity (input, direct_is, dopa_is);
			if (obj.name == "IndirectGPe") {
				c = new Color (intensity, 0.0f, 0.0f, intensity);
			} else {
				c = new Color (0.0f, intensity, 0.0f, intensity);
			}
			obj.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", c);
		}
	}
	void special_func(){
		foreach (GameObject obj in special) {
			if (obj.name == "DirectSNc") {
				c = new Color (0.0f, 1.0f-intensity, 0.0f, intensity);
			} else {
				c = new Color (1.0f-intensity, 0.0f, 0.0f, intensity);
			}
			obj.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", c);
		}
	}
	void dopa_input_func(){
		inhibit_indirect (indirect_input);
		excite_indirect (indirect_input);
		excite (direct_input);
		inhib (direct_input);
		special_func ();
	}
}
	