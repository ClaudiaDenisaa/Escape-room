using UnityEngine;

public class GreekBookManager : MonoBehaviour
{
    public GameObject coverPageGreek;
    public GameObject firstPageGreek;
    public GameObject greekAlphabetPage;

    private int currentPage = 0;
    private bool bookIsOpen = false;

    void Update()
    {
        if (!bookIsOpen)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            NextPage();
        }
    }

    void NextPage()
    {
        currentPage++;

        if (currentPage > 2)
            currentPage = 0;

        Debug.Log("NextPage -> currentPage = " + currentPage);
        ShowPage(currentPage);
    }

    void ShowPage(int page)
    {
        Debug.Log("ShowPage called with page = " + page);

        if (coverPageGreek != null)
            coverPageGreek.SetActive(page == 0);
        else
            Debug.LogError("coverPageGreek nu este asignat!");

        if (firstPageGreek != null)
            firstPageGreek.SetActive(page == 1);
        else
            Debug.LogError("firstPageGreek nu este asignat!");

        if (greekAlphabetPage != null)
            greekAlphabetPage.SetActive(page == 2);
        else
            Debug.LogError("greekAlphabetPage nu este asignat!");

        Debug.Log("Cover active: " + (coverPageGreek != null && coverPageGreek.activeSelf));
        Debug.Log("First active: " + (firstPageGreek != null && firstPageGreek.activeSelf));
        Debug.Log("Alphabet active: " + (greekAlphabetPage != null && greekAlphabetPage.activeSelf));
    }

    public void OpenCoverPage()
    {
        bookIsOpen = true;
        currentPage = 0;
        ShowPage(currentPage);
        Debug.Log("Greek book opened on CoverPage");
    }

    public void CloseBook()
    {
        bookIsOpen = false;
        currentPage = 0;
        ShowPage(currentPage);
        Debug.Log("Greek book closed");
    }
}