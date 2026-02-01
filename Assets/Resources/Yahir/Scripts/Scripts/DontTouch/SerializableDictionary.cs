using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class SerializableDictionaryEntry<TKey, TValue>
{
	public TKey Key;
	public TValue Value;
}

[Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
	[SerializeField]
	private List<SerializableDictionaryEntry<TKey, TValue>> entries = new List<SerializableDictionaryEntry<TKey, TValue>>();

	private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

	public void OnBeforeSerialize() {}

	public void OnAfterDeserialize()
	{
		dictionary.Clear();
		foreach (var entry in entries)
		{
			dictionary[entry.Key] = entry.Value;
		}
	}

	public TValue this[TKey key]
	{
		get => dictionary[key];
		set
		{
			if (dictionary.ContainsKey(key))
			{
				dictionary[key] = value;
			}
			else
			{
				dictionary.Add(key, value);
				entries.Add(new SerializableDictionaryEntry<TKey, TValue> { Key = key, Value = value });
			}
		}
	}

	public Dictionary<TKey, TValue> ToDictionary()
	{
		return new Dictionary<TKey, TValue>(dictionary);
	}
}
