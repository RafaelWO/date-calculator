using System.Windows.Input;

namespace DateCalculator.BusinessClasses
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand AddAnniversary = new RoutedUICommand
            (
                "Add Anniversary",
                "AddAnniversary",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Enter, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand DeleteAnniversary = new RoutedUICommand
            (
                "Delete Anniversary",
                "DeleteAnniversary",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Delete)
                }
            );

        public static readonly RoutedUICommand CreateCalenderEvent = new RoutedUICommand
            (
                "Create Calender Event",
                "CreateCalenderEvent",
                typeof(CustomCommands)
            );

        //Define more commands here, just like the one above
    }
}
