using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

public class GameStatReceiver : MonoBehaviour
{
    [SerializeField] private string _url;
    [SerializeField] private string _apiKey;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest(_url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.SetRequestHeader("X-Master-Key", _apiKey);

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
                yield break;
            }

            string contentType = webRequest.GetResponseHeader("Content-Type");
            Debug.Log($"Successfull API GET with Content Type: '{contentType}'");
            
            ProcessJSONResponse(webRequest);
        }
    }

    private static void ProcessJSONResponse(UnityWebRequest webRequest)
    {
        var deserialised = JsonConvert.DeserializeObject<JObject>(webRequest.downloadHandler.text);
        var results = deserialised["record"].ToObject<Dictionary<string, JObject>>();
        foreach (var key in results.Keys)
        {
            Debug.Log($"Updating stats for class: {key}");
            var stats = results[key].ToObject<Dictionary<string, float>>();

            if (key == "Timer")
            {
                var instance = FindObjectOfType<Timer>();
                UpdateClassStats(stats, instance);
                instance.UpdateAfterStatChange();
            }
            else if (key == "PlayerMovement")
            {
                var instance = FindObjectOfType<PlayerMovement>();
                UpdateClassStats(stats, instance);
                instance.UpdateAfterStatChange();
            }
            else if (key == "AnimalSpawner")
            {
                foreach (var instance in FindObjectsOfType<AnimalSpawner>())
                {
                    UpdateClassStats(stats, instance);
                    instance.UpdateAfterStatChange();
                }
            }
        }
    }

    private static void UpdateClassStats(Dictionary<string, float> stats, object instance)
    {
        foreach (var fieldname in stats.Keys)
        {
            Debug.Log(fieldname);
            var prop = instance.GetType().GetField(fieldname, System.Reflection.BindingFlags.NonPublic
                    | System.Reflection.BindingFlags.Instance);
            var value = Convert.ChangeType(stats[fieldname], prop.FieldType);
            prop.SetValue(instance, value);
        }
    }
}
