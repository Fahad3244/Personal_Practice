using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    public Image m_FillImage;
    public int CurrentHealth;
    public int MaxHealth;
    public AnimationCurve interpolationCurve; // This curve controls the interpolation

    private float targetFillAmount;

    void Update()
    {
        targetFillAmount = (float)CurrentHealth / MaxHealth;

        // Calculate the interpolated fill amount using the curve
        float t = interpolationCurve.Evaluate(Time.deltaTime); // Adjust time scale according to your needs
        m_FillImage.fillAmount = Mathf.Lerp(m_FillImage.fillAmount, targetFillAmount, t);
    }
    
    [ContextMenu("Damage")]
    private void TakeDamage()
    {
        CurrentHealth -= 20;
    }
}
