using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.DialogueSystem.UI.View
{
    public class DialogueChoicesUIView : MonoBehaviour
    {
        [SerializeField] private MyButton _choiceButtonPrefab;
        [SerializeField] private LayoutGroup _choiceLayoutGroup;
        
        private List<MyButton> _instantiatedButtons = new();

        public MyButton CreateButton(string buttonText)
        {
            MyButton button = Instantiate<MyButton>(_choiceButtonPrefab, _choiceLayoutGroup.transform);
            button.SetButtonText(buttonText);
            _instantiatedButtons.Add(button);
            button.gameObject.SetActive(true);
            return button;
        }

        public void ReleaseButton(MyButton button)
        {
            _instantiatedButtons.Remove(button);
            Destroy(button.gameObject);
        }
    }
}