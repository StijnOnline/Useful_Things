//Modified from answer by TomZe at https://answers.unity.com/questions/796881/c-how-can-i-let-something-happen-after-a-small-del.html

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using System;

public static class Executor {


    /// <summary>
    /// Executes parameterless function or lambda after delay.<br/>
    /// Usage: Executor.DelayExecute(this, 1f, Func)
    /// </summary>
    public static Coroutine DelayExecute(MonoBehaviour mono_script, float DelayInSeconds, Action lambda ) {
        return mono_script.StartCoroutine(Delayed(DelayInSeconds, lambda));
    }

    /// <summary>
    /// Executes function or lambda with parameters after delay.<br/>
    /// Usage: Executor.DelayExecute(this, 1f, Func, parameters)
    /// </summary>
    public static Coroutine DelayExecute( MonoBehaviour mono_script, float DelayInSeconds, Action<object[]> lambda, params object[] parameters ) {
        return mono_script.StartCoroutine(Delayed(DelayInSeconds, lambda, parameters));
    }

    
    static IEnumerator Delayed( float DelayInSeconds, Action lambda ) {
        yield return new WaitForSeconds(DelayInSeconds);
        lambda.Invoke();
    }
    static IEnumerator Delayed( float DelayInSeconds, Action<object[]> lambda, params object[] parameters ) {
        yield return new WaitForSeconds(DelayInSeconds);
        lambda.Invoke(parameters);
    }



    /// <summary>
    /// Executes parameterless function or lambda when condition is met.<br/>
    /// Usage: Executor.DelayExecute(this, 1f, Func, parameters)
    /// </summary>
    static public Coroutine ConditionExecute( MonoBehaviour mono_script, Func<bool> condition, Action lambda) {
        return mono_script.StartCoroutine(Delayed(condition, lambda));
    }
    /// <summary>
    /// Executes function or lambda with parameters when condition is met.<br/>
    /// Usage: Executor.DelayExecute(this, 1f, Func, parameters)
    /// </summary>
    static public Coroutine ConditionExecute( MonoBehaviour mono_script, Func<bool> condition, Action<object[]> lambda, params object[] parameters ) {
        return mono_script.StartCoroutine(Delayed(condition, lambda, parameters));
    }
    static IEnumerator Delayed( Func<bool> condition, Action lambda ) {
        yield return new WaitUntil(condition);
        lambda.Invoke();
    }
    static IEnumerator Delayed( Func<bool> condition, Action<object[]> lambda, params object[] parameters ) {
        yield return new WaitUntil(condition);
        lambda.Invoke(parameters);
    }


    public static void StopExecute( MonoBehaviour mono_script, Coroutine coroutine ) {
        mono_script.StopCoroutine(coroutine);
    }


}

