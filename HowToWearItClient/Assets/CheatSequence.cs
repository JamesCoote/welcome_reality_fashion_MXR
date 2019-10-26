using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSequence : MonoBehaviour
{
    public List<GameObject> poncho;
    public float delay = 2;
    
    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_EDITOR
        delay = 20f;
        StartCoroutine(ActivatePoncho());
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(ActivatePoncho());
        }
    }

    IEnumerator ActivatePoncho() {

        for (int i = 0; i < poncho.Count; i++)
        {
            poncho[i].transform.localPosition = poncho[i].transform.localPosition + new Vector3(0, -1.05f, 0);
        }

        yield return new WaitForSeconds(delay);

#if UNITY_EDITOR
        Time.timeScale = 0.1f;
#endif

        for (int i = 0; i < poncho.Count; i++)
        {
            poncho[i].gameObject.SetActive(true);
        }
    }
}
