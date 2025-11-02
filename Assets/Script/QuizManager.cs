using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [Header("Pengaturan Tombol Jawaban")]
    public Button tombolJawabanBenar;
    public Button[] tombolJawabanSalah;

    [Header("Komponen UI Feedback")]
    public GameObject feedbackPanel;
    public Text feedbackText;

    [Header("Pengaturan Level")]
    public string namaSceneSelanjutnya = "Level 2";
    public float delayPindahScene = 2f;

    public float delayResetSoal = 2f;

    void Start()
    {
        if (feedbackPanel != null)
        {
            feedbackPanel.SetActive(false);
        }

        if (tombolJawabanBenar != null)
        {
            tombolJawabanBenar.onClick.AddListener(FungsiJawabanBenar);
        }

        foreach (Button tombol in tombolJawabanSalah)
        {
            if (tombol != null)
            {
                tombol.onClick.AddListener(FungsiJawabanSalah);
            }
        }
    }

    private void FungsiJawabanBenar()
    {
        if (feedbackPanel != null && feedbackText != null)
        {
            feedbackPanel.SetActive(true);
            feedbackText.text = "Benar!";
            StartCoroutine(PindahSceneSetelahDelay());
        }
        NonaktifkanSemuaTombol();
    }

    private void FungsiJawabanSalah()
    {
        if (feedbackPanel != null && feedbackText != null)
        {
            feedbackPanel.SetActive(true);
            feedbackText.text = "Nguawor Cik!";

            StartCoroutine(ResetSoalSetelahDelay());
        }
        NonaktifkanSemuaTombol();
    }

    private void NonaktifkanSemuaTombol()
    {
        if (tombolJawabanBenar != null)
        {
            tombolJawabanBenar.interactable = false;
        }
        foreach (Button tombol in tombolJawabanSalah)
        {
            if (tombol != null)
            {
                tombol.interactable = false;
            }
        }
    }

    private IEnumerator PindahSceneSetelahDelay()
    {
        yield return new WaitForSeconds(delayPindahScene);
        SceneManager.LoadScene(namaSceneSelanjutnya);
    }

    private IEnumerator ResetSoalSetelahDelay()
    {
        yield return new WaitForSeconds(delayResetSoal);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}