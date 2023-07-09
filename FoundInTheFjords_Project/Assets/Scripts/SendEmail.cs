using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;

public class SendEmail : MonoBehaviour
{
	private string api_key = "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";
	
    private string uri = "https://api.sendgrid.com/v3/mail/send";

    private string jsonStr = "{\"personalizations\": [{\"to\": [{\"email\": \"ayalan@gmail.com\"}]}],\"from\": {\"email\": \"hello@foundinthefjords.org\"},\"subject\": \"Your commitment in Found in the Fjords\",\"content\": [{\"type\": \"text/plain\", \"value\": \"and easy to do anywhere, even with cURL\"}]}";

    public IEnumerator PostData_Coroutine() 
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonStr);
        Debug.Log(data);


        var www = new UnityWebRequest(uri, "POST");
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Authorization", $"Bearer {api_key}");
            www.uploadHandler = (UploadHandler) new UploadHandlerRaw(data);
            yield return www.SendWebRequest();
            string error = null;
            //var result = "";
            if ((www.result == UnityWebRequest.Result.ProtocolError) || (www.result == UnityWebRequest.Result.ConnectionError))
            {
                error = www.error;
                Debug.Log("Oh no! " + error);
            }
        }
    }
}
