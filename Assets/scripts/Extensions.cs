using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using Jint.Native;
public static class TransformDeepChildExtension {
    //Breadth-first search
    public static int length(this List<Css.StyleSheet> styles) {
        return styles.Count;
    }

    public static string toString(this Func<JsValue, JsValue[], JsValue> a) {
        var result = a.ToString();
        var getter = Achdus.Yaakov.hashObjs[a.GetHashCode().ToString()];
        if(getter != null) {
            result = getter;
        }
        return result;
    }

    public static JsValue Cobify(this Func<JsValue, JsValue[], JsValue> a, object myData) {
        
        var n = new Func<JsValue>(() => {
            
            Achdus.Yaakov.hashObjs[a.GetHashCode().ToString()] = myData;
            return 0;
        });
        return n();
    }
    public static Transform FindDeepChild(this Transform aParent, string aName)
    {
        var result = aParent.Find(aName);
        if (result != null)
            return result;
        foreach (Transform child in aParent)
        {
            result = child.FindDeepChild(aName);
            if (result != null)
                return result;
        }
        return null;
    }

    public static void rMatches(this string temp, string regText, Action<List<string>> cb) {
        List<string> m = Regex.Matches(temp, regText).Cast<Match>().Select(x=>x.Value).ToList();
        if(m.Count > 1) {
            cb(m);
        }
    }
    public static List<Transform> FindChildrenWithStringInName(this Transform t, string name) {
        List<Transform> result = new List<Transform>();
        for(int i = 0; i < t.childCount; i++) {
            if(t.GetChild(i).gameObject.name.Contains(name)) {
                result.Add(t.GetChild(i));
            }
        }
        return result;
    }

    public static void Print(this Dictionary<string,GameObject> d) {
        foreach(var kp in d) {
            MonoBehaviour.print("[" + kp.Key + "]: ");
            MonoBehaviour.print(kp.Value);
        }
    }
    /* 
    public static Bounds Encapsulation(this IEnumerable<Bounds> bounds)
    {
        return bounds.Aggregate((encapsulation, next) =>
        {
            encapsulation.Encapsulate(next);
            return encapsulation;
        });
    }*/
 
     /*
     //Depth-first search
     public static Transform FindDeepChild(this Transform aParent, string aName)
25.     {
         foreach(Transform child in aParent)
         {
             if(child.name == aName )
                 return child;
30.             var result = child.FindDeepChild(aName);
             if (result != null)
                 return result;
         }
         return null;
35.     }
     */
 }
