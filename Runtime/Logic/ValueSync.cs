using System;

namespace EssentialUtils
{
    /*
        Simple two-way binding that you run manually.
        Main value has a higher priority
    */

    public class ValueSync
    {
        public Func<object> MainValueGetter { get; set; }
        public Action<object> MainValueSetter { get; set; }
        public Func<object> SecondaryValueGetter { get; set; }
        public Action<object> SecondaryValueSetter { get; set; }
        public Func<object, object> Cloner { get; set; }
        public Func<object, object, bool> Comparator { get; set; }

        public event Action OnMainValueChanged;
        public event Action OnSecondaryValueChanged;

        object previousMainValue;
        object previousSecondaryValue;

        public ValueSync(Func<object> mainValueGetter, Action<object> mainValueSetter,
            Func<object> secondaryValueGetter, Action<object> secondaryValueSetter,
            Action onMainValueChanged = null, Action onSecondaryValueChanged = null,
            Func<object, object> cloner = null, Func<object, object, bool> comparator = null)
        {
            MainValueGetter = mainValueGetter;
            MainValueSetter = mainValueSetter;
            SecondaryValueGetter = secondaryValueGetter;
            SecondaryValueSetter = secondaryValueSetter;
            Cloner = cloner;
            Comparator = comparator;

            OnMainValueChanged = onMainValueChanged;
            OnSecondaryValueChanged = onSecondaryValueChanged;

            MonoBehaviourHelper.Instance.onUpdate += Update;
        }

        public void Dispose()
        {
            MonoBehaviourHelper.Instance.onUpdate -= Update;
        }

        void Update()
        {
            var mainValue = MainValueGetter();
            var secondaryValue = SecondaryValueGetter();

            if (previousMainValue != null && previousSecondaryValue != null)
            {
                var mainValueIsSame = Comparator != null
                    ? Comparator(mainValue, previousMainValue)
                    : mainValue.Equals(previousMainValue);

                var secondaryValueIsSame = Comparator != null
                    ? Comparator(secondaryValue, previousSecondaryValue)
                    : secondaryValue.Equals(previousSecondaryValue);

                var valuesAreSame = Comparator != null
                    ? Comparator(mainValue, secondaryValue)
                    : mainValue.Equals(secondaryValue);

                if (!mainValueIsSame && !valuesAreSame)
                {
                    UnityEngine.Debug.Log("Changing secondary value");
                    SecondaryValueSetter(mainValue);
                    OnMainValueChanged?.Invoke();
                }
                else if (!secondaryValueIsSame && !valuesAreSame)
                {
                    UnityEngine.Debug.Log("Changing main value");
                    MainValueSetter(secondaryValue);
                    OnSecondaryValueChanged?.Invoke();
                }
            } 

            previousMainValue = Cloner != null ? Cloner(mainValue) : mainValue;
            previousSecondaryValue = Cloner != null ? Cloner(secondaryValue) : secondaryValue;
        }
    }
}