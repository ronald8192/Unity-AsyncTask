using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("[Example][Start]");
		AsyncTask asyncTask = gameObject.AddComponent<AsyncTask>();
		asyncTask.SetUrl ("https://sunnywalk.herokuapp.com/api/game_result/new")
			.AddQueryParams ("token", "hxlebnbyciaxzukfj")
			.AddQueryParams ("secret", "8hNwxVMbAUptlmfC4xNMbZuvVW5XVnPXXY2MWJk14T4=")
			.AddQueryParams ("student_id",     5 + ""   )
			.AddQueryParams ("duration",       456 + "" )
			.AddQueryParams ("object_total",   20 + ""  )
			.AddQueryParams ("object_caught",  12 + ""  )
			.Before((t) => { 
				AsyncTask task = (AsyncTask) t;
				Debug.Log("[TRACE][ASYNCTASK] " + task.GetUrl() + task.GetQueryParams());
			})
			.Progress((p) => { 
				float progress;
				float.TryParse(p.ToString(), out progress);
				Debug.Log("[TRACE][ASYNCTASK] Progress: " + (progress * 100) + "%"); 
			})
			.After((data) => { 
				WWW download = (WWW) data;
				Debug.Log("[INFO][ASYNCTASK] Downloaded: " + download.text); 
			}).Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
