using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingGenerator : MonoBehaviour
{
    private const float MAX_RING_RADIUS = 5f;
    private const float MIN_RING_RADIUS = 1;
    private List<float> ringRadii;

    public int numRings = 3;
    public GameObject ringPrefab;
    public Color ringColor;

    // Start is called before the first frame update
    void Awake()
    {
        ringRadii = new List<float>();
        createRings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createRings()
    {
        numRings = LevelManager.Instance.getRoundType().numRings;
        float ringDistance = (MAX_RING_RADIUS - MIN_RING_RADIUS) / numRings;

        for(int i = 1; i <= numRings; i++)
        {
            float ringRadius = MIN_RING_RADIUS + ringDistance * i;
            GameObject ring = Instantiate(ringPrefab, transform);
            ring.transform.localScale = ring.transform.localScale * ringRadius * 2;

            SpriteRenderer ringSprite = ring.GetComponent<SpriteRenderer>();
            float colorVal = (ringRadius / MAX_RING_RADIUS);
           // ringSprite.color = new Color(colorVal, colorVal, colorVal);
            ringSprite.color = new Color(ringColor.r, ringColor.g, ringColor.b, Mathf.Lerp(0.5f, 0.2f, colorVal));
            //ringSprite.color = ringColor * colorVal;
            ringSprite.sortingOrder = numRings - i;
            ringRadii.Add(ringRadius);
        }
    }

    public float getRadius(int ringNum)
    {
        if(ringNum > numRings || ringNum <= 0)
        {
            Debug.LogError("Invalid ringNum.");
            return 0;
        }

        return ringRadii[ringNum - 1];
    }

    public bool checkValidRing(int ringNum)
    {
        if(ringNum > numRings || ringNum <= 0)
        {
            return false;
        }
        return true;
    }
}
