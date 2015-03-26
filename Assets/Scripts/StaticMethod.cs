using UnityEngine;
using System.Collections;
/* Log
 * 전역적으로 쓰이는 함수들 중 어디 하나의 포함시키기 어려운 것들을 한 군데에 모아놓음.
 * 생성자 : 이존하
 * 작업목록 
 * 2015.03.16 - 생성, CopyComponent<T> 선언
 */
public static class StaticMethod {

    static public T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }
}
