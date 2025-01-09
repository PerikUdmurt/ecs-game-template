using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Code.NodeBasedSystem.Core.Datas;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization.Tables;
using UnityEngine.UIElements;

namespace Code.NodeBasedSystem.Editor
{
    public class LocalizedStringEditorContainer : VisualElement
    {
        private readonly LocalizedStringData _localizedStringData;
        private string _targetTableKey;
        
        public LocalizedStringEditorContainer(LocalizedStringData localizedStringData)
        {
            _localizedStringData = localizedStringData;

            if (string.IsNullOrEmpty(localizedStringData.entryKey))
            {
                SetDefaultTableEntry(localizedStringData);
            }
            
            _targetTableKey = localizedStringData.tableKey;
            DrawContainer();
        }

        private void SetDefaultTableEntry(LocalizedStringData localizedStringData)
        {
            ReadOnlyCollection<StringTableCollection> tables = LocalizationEditorSettings.GetStringTableCollections();
            List<string> collectionNames = tables.Select(t => t.TableCollectionName).ToList();

            string entryKey = tables.First().StringTables.First().Values.First().Key;

            localizedStringData.tableKey = collectionNames.First();
            localizedStringData.entryKey = entryKey;
        }

        private void DrawContainer()
        {
            ReadOnlyCollection<StringTableCollection> tables = LocalizationEditorSettings.GetStringTableCollections();
            var collectionNames = tables.Select(t => t.TableCollectionName).ToList();
            
            DropdownField tablesDropdownField = new DropdownField()
            {
                label = "TableKey",
                choices = collectionNames,
            };
            tablesDropdownField.SetValueWithoutNotify(_localizedStringData.tableKey);
            
            DropdownField entryDropdownField = new DropdownField()
            {
                label = "EntryKey",
                choices = GetEntryChoices(_targetTableKey),
                value = _localizedStringData.entryKey
            };
            
            Label label = new Label()
            {
                text = GetLocalizedString(_localizedStringData.entryKey, _localizedStringData.tableKey),
                tooltip = GetLocalizedString(_localizedStringData.entryKey, _localizedStringData.tableKey)
            };
            label.style.overflow = Overflow.Hidden;
            
            tablesDropdownField.RegisterValueChangedCallback(c => OnTableKeyChange(c, entryDropdownField));
            entryDropdownField.RegisterValueChangedCallback(c => OnEntryKeyChange(c, label));
            
            this.Add(tablesDropdownField);
            this.Add(entryDropdownField);
            this.Add(label);
        }

        private void OnEntryKeyChange(ChangeEvent<string> evt, Label label)
        {
            _localizedStringData.entryKey = evt.newValue;
            _localizedStringData.tableKey = _targetTableKey;

            string value = GetLocalizedString(evt.newValue, _targetTableKey);

            label.text = value;
            label.tooltip = value;
        }

        private string GetLocalizedString(string evtNewValue, string targetTableKey)
        {
            StringTableCollection table = GetTableCollectionWithName(_targetTableKey);
            StringTableEntry a = table.StringTables
                .First().Values
                .FirstOrDefault(v => v.Value == _localizedStringData.entryKey);

            if (a == null)
            {
                return $"Not found entry for {targetTableKey}/{_localizedStringData.entryKey}";
            }

            return a.Value;
        }

        private void OnTableKeyChange(ChangeEvent<string> evt, DropdownField entryDropdownField)
        {
            _targetTableKey = evt.newValue;
            entryDropdownField.choices = GetEntryChoices(_targetTableKey);
        }

        private StringTableCollection GetTableCollectionWithName(string targetTableKey)
        {
            ReadOnlyCollection<StringTableCollection> tables = LocalizationEditorSettings.GetStringTableCollections();
            
            return tables
                .FirstOrDefault(t => t.TableCollectionName == targetTableKey);
        }
        
        private List<string> GetEntryChoices(string targetTableKey)
        {
            StringTableCollection targetTable = GetTableCollectionWithName(targetTableKey);

            return targetTable.StringTables
                .First().Values
                .Select(v => v.Key)
                .ToList();
        }
    }
}