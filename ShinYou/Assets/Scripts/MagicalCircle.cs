using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalCircle : MonoBehaviour
{
    [SerializeField]
    public GameObject source;
    [SerializeField]
    public float radius;
    [SerializeField]
    public float totalTime;

    private int triOverNum;
    // Start is called before the first frame update
    private void Awake()
    {
        triOverNum = (int)((radius * Mathf.Cos(30 * Mathf.Deg2Rad) * 2 * 3)
            / source.transform.localScale.x)-1;
    }

    void Start()
    {
        StartCoroutine(TriDraw(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriApp(int num)
    {
        StartCoroutine(TriDraw(num));
    }

    private IEnumerator TriDraw(int num)
    {
        var sourceScale = source.transform.localScale.x;
     
        if (num < triOverNum/3f)
        {
            var startPoint = new Vector3(0, radius, 0);
            var point = new Vector3(startPoint.x + (Mathf.Sin(30 * Mathf.Deg2Rad) * sourceScale * num),
                startPoint.y - (Mathf.Cos(30 * Mathf.Deg2Rad) * sourceScale * num), 0);
            GameObject pointObj = Instantiate(source, Vector3.zero, transform.rotation);
            pointObj.transform.parent = transform;
            pointObj.transform.localPosition = point;
        }
        else if(num >= triOverNum / 3f && num < triOverNum / 3f * 2f)
        {
            var startPos = new Vector3(Mathf.Cos(30 * Mathf.Deg2Rad) * (radius * Mathf.Cos(30 * Mathf.Deg2Rad) * 2),
                -(Mathf.Sin(30 * Mathf.Deg2Rad) * radius), 0);
            var point = new Vector3(startPos.x - (sourceScale * (num - (int)(triOverNum / 3f))),
                startPos.y, 0);
            GameObject pointObj = Instantiate(source, Vector3.zero, transform.rotation);
            pointObj.transform.parent = transform;
            pointObj.transform.localPosition = point;
        }
        else if(num >= triOverNum / 3f * 2f && num < triOverNum)
        {
            var startPoint = new Vector3(-Mathf.Cos(30 * Mathf.Deg2Rad) * (radius * Mathf.Cos(30 * Mathf.Deg2Rad) * 2),
                -(Mathf.Sin(30 * Mathf.Deg2Rad) * radius), 0);
            var point = new Vector3(startPoint.x + (Mathf.Sin(30 * Mathf.Deg2Rad) * sourceScale * (num - (int)(triOverNum / 3f * 2f))),
                startPoint.y + (Mathf.Cos(30 * Mathf.Deg2Rad) * sourceScale * (num - (int)(triOverNum / 3f * 2f))), 0);
            GameObject pointObj = Instantiate(source, Vector3.zero, transform.rotation);
            pointObj.transform.parent = transform;
            pointObj.transform.localPosition = point;
        }
        yield return null;
        if(num < triOverNum) TriApp(num + 1);
        yield break;
    }
}
