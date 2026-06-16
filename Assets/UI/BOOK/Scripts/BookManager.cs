using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject coverPage;
    public GameObject morsePage;
    public GameObject decypherPage;

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

        if (coverPage != null)
            coverPage.SetActive(page == 0);
        else
            Debug.LogError("coverPage nu este asignat!");

        if (morsePage != null)
            morsePage.SetActive(page == 1);
        else
            Debug.LogError("morsePage nu este asignat!");

        if (decypherPage != null)
            decypherPage.SetActive(page == 2);
        else
            Debug.LogError("decypherPage nu este asignat!");

        Debug.Log("Cover active: " + (coverPage != null && coverPage.activeSelf));
        Debug.Log("Morse active: " + (morsePage != null && morsePage.activeSelf));
        Debug.Log("Decypher active: " + (decypherPage != null && decypherPage.activeSelf));
    }

    public void OpenCoverPage()
    {
        bookIsOpen = true;
        currentPage = 0;
        ShowPage(currentPage);
        Debug.Log("Book opened on CoverPage");
    }

    public void CloseBook()
    {
        bookIsOpen = false;
        currentPage = 0;
        ShowPage(currentPage);
        Debug.Log("Book closed");
    }
}