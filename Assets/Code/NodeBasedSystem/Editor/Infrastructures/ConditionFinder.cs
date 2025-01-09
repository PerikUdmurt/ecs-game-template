using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Code.NodeBasedSystem.Core.Conditions;
using UnityEngine;

namespace NodeBasedEditor.Editors
{
    public static class ConditionFinder
    {
        private static Dictionary<string, Type> _eventTypes;
        private static List<string> _names;

        static ConditionFinder()
        {
            _names = new List<string>();
            _eventTypes = new Dictionary<string, Type>();
            FindConditions();
        }

        public static List<string> Names
        {
            get => _names;
        }

        public static bool TryGetConditionType(string eventName, out Type eventType)
        {
            if (eventName == null)
                throw new ArgumentNullException(nameof(eventName));
            
            if (_eventTypes.TryGetValue(eventName, out Type resultType))
            {
                eventType = resultType;
                return true;
            }

            eventType = null;
            return false;
        }

        private static void FindConditions()
        {
            Assembly assembly = Assembly.Load("Assembly-CSharp");

            var events = from m in assembly.GetTypes()
                from a in m.GetCustomAttributes(typeof(NodeConditionAttribute), true)
                select m;
            
            Debug.Log($"{assembly.FullName} founded {events.Count()} types");

            foreach (var eventType in events)
            {
                NodeConditionAttribute attribute =
                    (NodeConditionAttribute)eventType.GetCustomAttribute(typeof(NodeConditionAttribute));
                _eventTypes.Add(attribute.Name, eventType);
                _names.Add(attribute.Name);
            }
        }
    }
}