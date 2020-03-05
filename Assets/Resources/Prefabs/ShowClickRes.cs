public enum SortOfRes
{
    scrap,
    electronic,
    plastic

}
public class ShowClickRes
{
    //public static int Counter = 0;
    public Image image;
    public Text text;
    public SortOfRes sortOfRes;

    public ShowClickRes(SortOfRes _sortOfRes)
    {
        this.sortOfRes = _sortOfRes;

        //++Counter;

        
        this.image = GameObject.Instantiate(Variables.clickImage);
        this.image.gameObject.transform.SetParent(Variables.mainUI.transform);
        this.image.transform.position = Variables.scrapyardPosition + new Vector3(Random.Range(-175, 175), Random.Range(-175, 175), 0);

        this.text = GameObject.Instantiate(Variables.clickText);
        this.text.gameObject.transform.SetParent(Variables.mainUI.transform);
        this.text.transform.position = image.transform.position + new Vector3(125, 125, 0);
        this.text.text = "+ " + (1 * Variables.clickMultiplier).ToString();

        
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