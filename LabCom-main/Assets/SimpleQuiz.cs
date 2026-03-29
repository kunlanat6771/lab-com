using UnityEngine;
using TMPro;

public class SimpleQuiz : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip wrongClip;
    public AudioClip correctClip;

    [Header("UI Settings")]
    public TextMeshProUGUI resultText;
    
    // ช่องสำหรับลาก ResultPanel (ภาพเฉลย) มาใส่
    public GameObject resultPanel; 

    private AudioSource audioSource;

    void Start()
    {
        // ตั้งค่า AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) 
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // กันเหนียว: ปิดหน้าจอเฉลยไว้ก่อนตอนเริ่มเกม
        if (resultPanel != null)
        {
            resultPanel.SetActive(false);
        }
    }

    public void Wrong()
    {
        if (wrongClip != null) audioSource.PlayOneShot(wrongClip);
        resultText.text = "❌ Wrong!";
    }

    public void Correct()
    {
        if (correctClip != null) audioSource.PlayOneShot(correctClip);
        resultText.text = "✅ Correct!";

        // สั่งให้หน้าจอเฉลย (ภาพที่มีคำอธิบาย) เด้งขึ้นมา
        if (resultPanel != null)
        {
            resultPanel.SetActive(true);
        }
    }

    // ฟังก์ชันสำหรับปุ่ม NEXT ในหน้าเฉลย (ถ้าต้องการใช้กดเพื่อปิดหน้าจอเฉลย)
    public void CloseResult()
    {
        if (resultPanel != null)
        {
            resultPanel.SetActive(false);
            resultText.text = ""; // ล้างข้อความเก่าออกด้วย
        }
    }
}