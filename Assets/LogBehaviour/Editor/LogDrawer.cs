using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Reflection;

[CustomPropertyDrawer(typeof(LogAttribute))]
public class LogDrawer : PropertyDrawer
{
    int drawNum = 0;
    int height = 16;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //drawNum = 0;
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, label);

        LogAttribute log = attribute as LogAttribute;



    }

    // Overriding the GetPropertyHeight gives us the possibility to specify the property height
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Twice as high as a default property height
        return base.GetPropertyHeight(property, label) + height * drawNum;// *drawNum;
    }

    private object GetParentObjectOfProperty(string path, object obj)
    {
        string[] fields = path.Split('.');

        // We've finally arrived at the final object that contains the property
        if (fields.Length == 1)
        {
            return obj;
        }

        // We may have to walk public or private fields along the chain to finding our container object, so we have to allow for both
        FieldInfo fi = obj.GetType().GetField(fields[0], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        obj = fi.GetValue(obj);

        // Keep searching for our object that contains the property
        return GetParentObjectOfProperty(string.Join(".", fields, 1, fields.Length - 1), obj);
    }
}
