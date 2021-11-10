using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Tool_Manager : MonoBehaviour
{
    #region Instance
    private static Tool_Manager instance;
    public static Tool_Manager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    } 
    #endregion

    [SerializeField] private GameObject popupCanvasObject;
    [SerializeField] private RectTransform popupObject;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Vector3 offset;
    [SerializeField] private int padding = 10;

    private Canvas popupCanvas;
    private Vector3 newPos;
    private StringBuilder sb = new StringBuilder();

    private void Start()
    {
        popupCanvas = popupCanvasObject.GetComponent<Canvas>();
        newPos = Input.mousePosition + offset;
    }

    private void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        if (!popupCanvasObject.activeSelf) { return; }

        newPos = Input.mousePosition + offset;
        newPos.z = 0f;
        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupObject.rect.width * popupCanvas.scaleFactor) + padding;
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }
        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding;
        if (topEdgeToScreenEdgeDistance < 0)
        {
            newPos.y += topEdgeToScreenEdgeDistance;
        }
        popupObject.transform.position = newPos;
    }
    public void OpenTool(Slot slot)
    {
        sb.Length = 0;
        // Item Name
        sb.Append("<color=red>" + slot.item.myName + "</color>");
        sb.AppendLine();
        // Item ItemType
        sb.Append("<color=green>" + slot.item.itemType.ToString() + "</color>");
        sb.AppendLine();
        if (slot.item is Skill_Item)
        {
            // Item Skill Pasif - Active
            sb.Append("<color=yellow>" + ((slot.item as Skill_Item).IsPasif() ? "Pasif" : "Active") + "</color>");
            sb.AppendLine();
        }
        // Item Price
        sb.Append("<color=blue>Price : " + slot.item.itemPrice + (slot.item.isPriceTl ? " Tl." : " Exp.") + "</color>");
        sb.AppendLine();
        // Item Desc
        sb.Append(slot.item.myDesc);
        sb.AppendLine();
        // Item Special
        sb.Append(slot.item.ItemSpecial());

        infoText.text = sb.ToString();

        popupCanvasObject.gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
    }
    public void CloseTool()
    {
        popupCanvasObject.gameObject.SetActive(false);
    }
}