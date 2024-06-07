using UnityEngine;

public class CannonUIScaler : MonoBehaviour
{
    private void Awake()
    {
        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("PHONEEEEEEEEEEEEEEEEEEEEEEEE");
            GetComponent<RectTransform>().localScale = Vector3.one * 4;
        }
        else
        {
            Debug.Log("NOT PHONEEEEEEEEEEEEEEEEEEEEE");
            GetComponent<RectTransform>().localScale = Vector3.one;
        }
    }
}
