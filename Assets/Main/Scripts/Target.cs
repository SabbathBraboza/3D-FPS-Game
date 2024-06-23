using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum Type
    {
        Static, Looping , Once, Arc, Circle
    }

    [Header("GameObjects:")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform A; [SerializeField] private Transform B;
    [Space(10f)]
    [SerializeField] private Type type;
    [SerializeField] private float Speed;
    [SerializeField] private float Delay;
      private float ArcAmplitude = 1f;
      private float ArcSpeed = 1f;
      private float t;

      private void OnValidate() => enabled = type != Type.Static;
    
    private IEnumerator Start()
    {
        if(type == Type.Static)
        {
            yield break;
        }
        enabled = false;
        yield return  new  WaitForSeconds(Delay);
        enabled = true;
    }

    private void Update()
    {
        switch(type)
        {
            case Type.Looping:
                t = Mathf.PingPong(Speed * Time.time, 1f);
                break;
             
            case Type.Once:
            t += Speed * Time.deltaTime;
               if (t > 1f)  type = Type.Static;
                break;

         case Type.Arc:
                   float arcX = Mathf.Sin(t * Mathf.PI); 
                   float arcY = Mathf.Cos(t * Mathf.PI);

                    arcX *= ArcAmplitude;
                    arcY *= ArcAmplitude;

                     transform.position += ArcSpeed * Time.deltaTime * new Vector3(arcX, arcY, 0f); 
                     t += Time.deltaTime * ArcSpeed;

                      if (t > 1f)   t = 0f;
                      break;

                  case Type.Circle:
                  
                        break;     
            }
            target.localPosition = Vector3.Lerp(A.localPosition, B.localPosition, t);
    }
}
