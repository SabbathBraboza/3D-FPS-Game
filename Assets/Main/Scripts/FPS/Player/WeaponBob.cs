using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBob : MonoBehaviour
{
    public float EffectIntensity = 0.02f;
    public float EffectIntensityX = 1f;
    public float EffectSpeed = 6.8f;
    public float SinTime;
    private PlayerCameraMove Follow;
    private Vector3 OriginalOffset;
    private void Start()
    {
        Follow = GetComponent<PlayerCameraMove>();
        OriginalOffset = Follow.offset;
    }
    private void Update()
    {
        WeaponBobProcess();
    }
    public void WeaponBobProcess()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        if (inputVector.magnitude > 0f)
        {
            SinTime += Time.deltaTime * EffectSpeed;
        }
        else
        {        
          
                SinTime = 0;
            
            // Smoothly move SinTime towards zero
            //SinTime = Mathf.MoveTowards(SinTime, 0f, Time.deltaTime * EffectSpeed);
        }
        float sinAmountY = -Mathf.Abs(EffectIntensity * Mathf.Sin(SinTime));
        Vector3 sinAmountX = Follow.transform.right * EffectIntensity * Mathf.Cos(SinTime) * EffectIntensityX;
        
        Follow.offset = new Vector3
        {
            x = OriginalOffset.x,
            y = OriginalOffset.y + sinAmountY,
            z = OriginalOffset.z
        };
        Follow.offset += sinAmountX;
    }
}
