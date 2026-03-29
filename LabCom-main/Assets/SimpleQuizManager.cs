using UnityEngine;
using UnityEngine.UI; // สำคัญมากสำหรับการควบคุม Image UI

public class SimpleQuizManager : MonoBehaviour
{
    [Header("UI Objects")]
    // ตัวแปรสำหรับลากรูปโจทย์หลัก (QuestionImage.1) มาใส่
    public Image mainQuestionImage; 
    // ตัวแปรสำหรับลากหน้าต่างผลลัพธ์ (ResultPanel) มาใส่ เพื่อปิดมัน
    public GameObject resultPanel; 

    [Header("Quiz Data")]
    // Array สำหรับเก็บรูปโจทย์ทั้งหมดที่คุณเตรียมไว้ (Quiz_1, Quiz_2, Quiz_3...)
    public Sprite[] quizSprites; 

    private int currentQuestionIndex = 0; // ตัวนับว่าตอนนี้อยู่ข้อที่เท่าไหร่ (เริ่มที่ 0 คือข้อแรก)

    void Start()
    {
        // เมื่อเริ่มเกม ให้แสดงรูปโจทย์แรกทันที (ถ้ามีรูปใส่ไว้)
        if (quizSprites.Length > 0 && mainQuestionImage != null)
        {
            mainQuestionImage.sprite = quizSprites[0];
            mainQuestionImage.preserveAspect = true; // ป้องกันรูปเบี้ยว
        }
    }

    // --- ฟังก์ชันนี้จะถูกเรียกเมื่อกดปุ่ม "Next" ---
    public void GoToNextQuestion()
    {
        // 1. เพิ่มตัวนับข้อไป 1
        currentQuestionIndex++;

        // 2. เช็คว่ายังมีโจทย์ข้อถัดไปใน Array ไหม
        if (currentQuestionIndex < quizSprites.Length)
        {
            // --- มีโจทย์ข้อถัดไป ---

            // เปลี่ยนรูปภาพโจทย์หลักให้เป็นรูปข้อถัดไป
            if (mainQuestionImage != null)
            {
                mainQuestionImage.sprite = quizSprites[currentQuestionIndex];
            }

            // ปิดหน้าต่างผลลัพธ์ (ResultPanel) สีเขียว เพื่อให้มองเห็นโจทย์ข้อใหม่
            if (resultPanel != null)
            {
                resultPanel.SetActive(false);
            }

            Debug.Log("ไปโจทย์ข้อที่: " + (currentQuestionIndex + 1));
        }
        else
        {
            // --- หมดโจทย์แล้ว ---
            Debug.Log("จบแบบทดสอบแล้ว!");
            // คุณอาจจะเพิ่มโค้ดเปิดหน้าสรุปคะแนนตรงนี้
        }
    }
}