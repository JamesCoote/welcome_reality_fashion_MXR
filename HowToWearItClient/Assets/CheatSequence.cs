using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSequence : MonoBehaviour
{
    public GameObject poncho;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivatePoncho());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ActivatePoncho() {

        poncho.transform.localPosition = poncho.transform.localPosition + new Vector3(0, -1.05f, 0);

        yield return new WaitForSeconds(20);

        poncho.gameObject.SetActive(true);
    }
}
