using UnityEngine;
using System.Collections;

public class AsyncTask : MonoBehaviour {

	private string url = "";
	private string queryParams = "";
	private System.Action<object> before;
	private System.Action<object> progress;
	private System.Action<object> after;

	/// <summary>
	/// Execute the async task.
	/// </summary>
	public IEnumerator Start () {
		before (this);

		Debug.Log("[TRACE][ASYNCTASK] " + url + queryParams);
		WWW download = new WWW( url + queryParams );

		while (!download.isDone) {
			progress (download.progress);
			//yield return new WaitForSeconds(.001f);
		}

		yield return download;
		after(download);

	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update () {
	
	}

	/// <summary>
	/// Sets the URL.
	/// </summary>
	/// <returns>AsyncTask</returns>
	/// <param name="url">URL.</param>
	public AsyncTask SetUrl(string url){
		if (!url.EndsWith ("?")) {
			url += "?";
		}
		this.url = url;
		return this;
	}

	/// <summary>
	/// Gets the URL.
	/// </summary>
	/// <returns>The URL.</returns>
	public string GetUrl(){
		return url;
	}

	/// <summary>
	/// Gets the query parameters.
	/// </summary>
	/// <returns>The query parameters.</returns>
	public string GetQueryParams(){
		return queryParams;
	}
	
	/// <summary>
	/// ConstructAdds the query parameters. (helper)
	/// </summary>
	/// <returns>The query parameter.</returns>
	/// <param name="key">Key.</param>
	/// <param name="value">Value.</param>
	public AsyncTask AddQueryParams(string key, string value){
		queryParams += WWW.EscapeURL(key) + "=" + WWW.EscapeURL(value) + "&";
		return this;
	}

	/// <summary>
	/// Code runs before sending WWW request.
	/// Object itself (AsyncTask) will parse to `after`
	/// </summary>
	/// <param name="before">System.Action Before.</param>
	public AsyncTask Before(System.Action<object> before){
		this.before = before;
		return this;
	}

	/// <summary>
	/// Progress the specified progress.
	/// Progress (float in object) will parse to `after`.
	/// Please parse it to float by using `float.TryParse`.
	/// </summary>
	/// <param name="progress">System.Action Progress.</param>
	public AsyncTask Progress(System.Action<object> progress){
		this.progress = progress;
		return this;
	}

	/// <summary>
	/// Code runs after sending WWW request.
	/// WWW object will parse to `after`
	/// </summary>
	/// <param name="after">System.Action After.</param>
	public AsyncTask After(System.Action<object> after){
		this.after = after;
		return this;
	}
}
