using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PegaLocalizacao : MonoBehaviour
{

    public static PegaLocalizacao Instance { set; get; }
    public float latitude;
    public float longitude;

    // Start is called before the first frame update
    public void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        latitude = -22.5073396f;
        longitude = -41.9231485f;
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        Debug.Log("Location: " + latitude + " " + longitude);
        yield break;
    }
}