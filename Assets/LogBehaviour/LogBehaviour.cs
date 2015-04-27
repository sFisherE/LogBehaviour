using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum LogType
{
    Noraml,
    Warning,
    Error,
}

[System.Serializable]
public class LogEntry
{
    public LogType type;
    public string content;
}
/// <summary>
///   继承于改类的脚本，可以直接在Inspector上查看他的log
/// </summary>
public class LogBehaviour : MonoBehaviour
{
    [SerializeField,Log]
    public List<LogEntry> logs = new List<LogEntry>();

    public void Log(object message)
    {
        logs.Add(new LogEntry() { type = LogType.Noraml, content = message.ToString() });
        Debug.Log(message);
    }
    public void LogError(object message)
    {
        logs.Add(new LogEntry() { type = LogType.Error, content = message.ToString() });
        Debug.LogError(message);

    }
    public void LogWarning(object message)
    {
        logs.Add(new LogEntry() { type = LogType.Warning, content = message.ToString() });
        Debug.LogWarning(message);
    }
}
