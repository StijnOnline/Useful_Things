using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class PercentageAttribute : PropertyAttribute {
    public PercentageAttribute( )
    {
    }
}