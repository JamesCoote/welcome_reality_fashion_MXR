using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClothOnWind : MonoBehaviour
{

    private Cloth clothMod;

    public AnimationCurve windX;
    public AnimationCurve windY;
    public AnimationCurve windZ;
    public float strengthX;
    public float strengthY;
    public float strengthZ;
    public float gustChancePerSecondX;
    public float gustChancePerSecondY;
    public float gustChancePerSecondZ;
    public float maxGustTimeX;
    public float minGustTimeX;
    public float maxGustTimeY;
    public float minGustTimeY;
    public float maxGustTimeZ;
    public float minGustTimeZ;
    private List<float> gustTimeLeftX = new List<float>();    
    private List<float> gustTimeLeftY = new List<float>();
    private List<float> gustTimeLeftZ = new List<float>();
    private List<float> gustDirectionX = new List<float>();
    private List<float> gustDirectionY = new List<float>();
    private List<float> gustDirectionZ = new List<float>();

    public GameObject directionPointer;

    // Use this for initialization
    void Start()
    {
        if (directionPointer == null)
        {
            directionPointer = Camera.main.gameObject;
        }

        clothMod = this.GetComponent<Cloth>();
    }

    // Update is called once per frame
    void Update()
    {
        // generate new gusts
        float rndX = UnityEngine.Random.Range(0f, 1f);
        if (rndX < (Time.deltaTime * gustChancePerSecondX))
        {
            gustTimeLeftX.Add(UnityEngine.Random.Range(minGustTimeX, maxGustTimeX));
            gustDirectionX.Add(UnityEngine.Random.Range(0, 1) > 0 ? 1f : -1f);
        }
        float rndY = UnityEngine.Random.Range(0f, 1f);
        if (rndY < (Time.deltaTime * gustChancePerSecondY))
        {
            gustTimeLeftY.Add(UnityEngine.Random.Range(minGustTimeY, maxGustTimeY));
            gustDirectionY.Add(UnityEngine.Random.Range(0, 1) > 0 ? 1f : -1f);
        }
        float rndZ = UnityEngine.Random.Range(0f, 1f);
        if (rndZ < (Time.deltaTime * gustChancePerSecondZ))
        {
            gustTimeLeftZ.Add(UnityEngine.Random.Range(minGustTimeZ, maxGustTimeZ));
            gustDirectionZ.Add(UnityEngine.Random.Range(0, 1) > 0 ? 1f : -1f);
        }


        // calculate total gust
        float gustX = 0;
        for (int i = 0; i < gustTimeLeftX.Count;i++)
        {
            float gustPercent = 1f - (gustTimeLeftX[i] / maxGustTimeX);
            gustX += strengthX * windX.Evaluate(gustPercent) * gustDirectionX[i];
        }
        float gustY = 0;
        for (int i = 0; i < gustTimeLeftY.Count; i++)
        {
            float gustPercent = 1f - (gustTimeLeftY[i] / maxGustTimeY);
            gustY += strengthY * windY.Evaluate(gustPercent) * gustDirectionY[i];
        }
        float gustZ = 0;
        for (int i = 0; i < gustTimeLeftZ.Count; i++)
        {
            float gustPercent = 1f - (gustTimeLeftZ[i] / maxGustTimeZ);
            gustZ += strengthZ * windZ.Evaluate(gustPercent);
        }


        // apply gusts
        clothMod.externalAcceleration = (directionPointer.transform.right * gustX) + (directionPointer.transform.up * gustY) + (directionPointer.transform.forward * gustZ);

        // reduce gust times
        for (int i = 0; i < gustTimeLeftX.Count; i++)
        {
            gustTimeLeftX[i] -= Time.deltaTime;
            if (gustTimeLeftX[i] < 0)
            {
                gustTimeLeftX.RemoveAt(i);
                i--;
            }
        }
        for (int i = 0; i < gustTimeLeftY.Count; i++)
        {
            gustTimeLeftY[i] -= Time.deltaTime;
            if (gustTimeLeftY[i] < 0)
            {
                gustTimeLeftY.RemoveAt(i);
                i--;
            }
        }
        for (int i = 0; i < gustTimeLeftZ.Count; i++)
        {
            gustTimeLeftZ[i] -= Time.deltaTime;
            if (gustTimeLeftZ[i] < 0)
            {
                gustTimeLeftZ.RemoveAt(i);
                i--;
            }
        }

    }
}
