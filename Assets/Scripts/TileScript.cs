using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get;private set; }
    private Color32 fullColor = new Color32(255, 118, 118, 225);
    private Color32 emptyColor = new Color32(96, 225, 90, 225);
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform pTransform;
    public bool IsEmpty {  get; private set; }
    public void SetUp(Point gridPos,Vector3 worldPos,Transform parent)
    {
        IsEmpty = true;
        this.GridPosition = gridPos;
        pTransform.position = worldPos;
        pTransform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver()
    {
        if (GameManager.Instance.clickedCanon != null)
        {
            if (IsEmpty && gameObject.CompareTag("Grass"))
            {
                ColorTile(emptyColor);
            }
            if (!IsEmpty || gameObject.CompareTag("Desert"))
            {
                ColorTile(fullColor);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }
    }
    private void OnMouseExit()
    {
        ColorTile(Color.white);
    }

    private void PlaceTower()
    {
        GameObject canon = Instantiate(GameManager.Instance.clickedCanon.CanonPrefab, transform.position, Quaternion.identity);
        canon.GetComponentInParent<SpriteRenderer>().sortingOrder = GridPosition.y;
        canon.transform.SetParent(transform);
        canon.transform.position = new(canon.transform.position.x, canon.transform.position.y, 0);
        IsEmpty = false;
        Hover.Instance.Deactivate();
        ColorTile(Color.white);
    }
    private void ColorTile(Color32 newColor)
    {
        spriteRenderer.color = newColor;
    }
}
