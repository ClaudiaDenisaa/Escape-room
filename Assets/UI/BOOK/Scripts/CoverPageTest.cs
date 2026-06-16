using UnityEngine;
using UnityEngine.EventSystems;

public class TestPageClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Am dat click pe CoverPage");
    }
}