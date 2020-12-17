using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class CallToJs
{
    [DllImport("__Internal")]
    public static extern void SetElementText(int str);
}
