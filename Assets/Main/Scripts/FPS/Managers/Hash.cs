using UnityEngine;

namespace FPS.Utility
{
      public static class Hash
      {
            public static readonly int Shoot = Animator.StringToHash("IsShoot");
            public static readonly int Reload = Animator.StringToHash("IsReload");
      }
}
