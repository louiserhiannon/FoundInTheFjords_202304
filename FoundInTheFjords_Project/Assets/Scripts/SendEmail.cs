using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;

public class SendEmail : MonoBehaviour
{
    private string uri = "https://api.sendgrid.com/v3/mail/send";
    public static SendEmail SE;
    public string templateID;

    //public ChangeScene changeScene;

    private void Awake()
    {
        SE = this;
    }


    public IEnumerator PostData_Coroutine(string emailAddress, string templateID) 
    {
        string jsonStr = "{\"personalizations\": [{\"to\": [{\"email\": \"" + emailAddress + "\"}]}],\"from\": {\"email\": \"hello@foundinthefjords.org\"},\"subject\": \"Your commitment in Found in the Fjords\",\"content\": [{\"type\": \"text/plain\", \"value\": \"and easy to do anywhere, even with cURL\"}],\"template_id\":\"" + templateID + "\"}";
        // Transform string into byte array
        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonStr);
        Debug.Log(templateID);
        Debug.Log(emailAddress);
        Debug.Log(jsonStr);
        // Load API key from credebtials file, which is not tracked by git. Contact Aya for a copy.
        string sgk = System.IO.File.ReadLines(Application.dataPath + "/key.txt").First(); 
        //Debug.Log(sgk);
        // Using Post method for UnityWebRequest doesn't work well with sending JSON. Use this way instead.
        var www = new UnityWebRequest(uri, "POST");
        www.SetRequestHeader("Content-Type", "application/json");
        // Authorize with API key
        www.SetRequestHeader("Authorization", $"Bearer {sgk}");
        www.uploadHandler = (UploadHandler) new UploadHandlerRaw(data);
        yield return www.SendWebRequest();
        string error = null;
        if ((www.result != UnityWebRequest.Result.Success))
        {
            error = www.error;
            Debug.Log("Oh no! " + error);
        }
        if ((www.result == UnityWebRequest.Result.Success))
        {
            error = www.error;
            Debug.Log("Success!");
        }
        
    }
}
