using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SortOfRes
{
    scrap,
    electronic,
    plastic

}
public class ObjectFactory
{
    public SortOfRes sortOfRes;

    // Maximum objects allowed!  
    private static int mPoolMaxSize = 10;
    // My Collection Pool  
    private static readonly Queue objPool = new Queue(mPoolMaxSize);

    public Resource GetObject(SortOfRes _sortOfRes)
    {
        this.sortOfRes = _sortOfRes;
        Resource oResource;

        // check from the collection pool. If exists return object else create new  
        if (Resource.Counter >= mPoolMaxSize && objPool.Count > 0)
        {
            // Retrieve from pool  
            oResource = RetrieveFromPool();
            oResource.sortOfRes = this.sortOfRes;
        }
        else
        {
            oResource = GetNewObject();
            oResource.sortOfRes = this.sortOfRes;
        }
        return oResource;
    }
    private Resource GetNewObject()
    {
        // Creates a new employee  
        Resource oRes = new Resource();
        objPool.Enqueue(oRes);
        return oRes;
    }
    protected Resource RetrieveFromPool()
    {
        Resource oRes;
        // if there is any objects in my collection  
        if (objPool.Count > 0)
        {
            oRes = (Resource)objPool.Dequeue();
            Resource.Counter--;
        }
        else
        {
            // return a new object  
            oRes = new Resource();
        }
        return oRes;
    }
}
public class Resource
{
    public static int Counter = 0;
    public Image image;
    public Text text;
    public SortOfRes sortOfRes;
    
    public Resource()
    {

        ++Counter;
        
        this.image.gameObject.transform.SetParent(Variables.mainUI.transform);
        this.image.transform.position = Variables.scrapyardPosition + new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);

        this.text.gameObject.transform.SetParent(Variables.mainUI.transform);
        this.text.transform.position = image.transform.position + new Vector3(125, 125, 0);
        this.text.text = "+ " + (1 * Variables.clickMultiplier).ToString();
        //PREFAB NEHMEN, script Decrement counter()
        if (this.sortOfRes == SortOfRes.scrap)
        {
            Sprite sprite = Resources.Load<Sprite>("ConceptGraphics/scrap");
            this.image.GetComponent<Image>().sprite = sprite;
            
        }
        else if (this.sortOfRes == SortOfRes.electronic)
        {
            Sprite sprite = Resources.Load<Sprite>("ConceptGraphics/electronics");
            this.image.GetComponent<Image>().sprite = sprite;
        }
        else if (this.sortOfRes == SortOfRes.plastic)
        {
            Sprite sprite = Resources.Load<Sprite>("ConceptGraphics/plastics");
            this.image.GetComponent<Image>().sprite = sprite;
        }
        else
        {
            Debug.Log("no SortOfRes Defined");
        }

        
    }

   
}
