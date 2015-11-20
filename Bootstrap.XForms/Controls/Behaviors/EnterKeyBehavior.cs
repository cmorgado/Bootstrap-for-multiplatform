using Xamarin.Forms;
using Entry = Xamarin.Forms.Entry;


namespace Bootstrap.XForms.Controls.Behaviors
{
    /// <summary>
    ///  <Interactivity:Interaction.Behaviors>
    ///   <MoreBehaviors:CommandOnEnterPress Command="{Binding DoCommand}" />
    ///  </Interactivity:Interaction.Behaviors>
    /// </summary>

    class TextChangedBehavior : Corcav.Behaviors.Behavior<Entry>
    {

        public static readonly BindableProperty TextProperty = BindableProperty.Create<TextChangedBehavior, string>(p => p.Text, null, propertyChanged: OnTextChanged);
        public static readonly BindableProperty PatternProperty = BindableProperty.Create<TextChangedBehavior, string>(p => p.Pattern, null, propertyChanged: OnTextChanged);
        private static void OnTextChanged(BindableObject bindable, string oldvalue, string newvalue)
        {
            if (string.IsNullOrEmpty(newvalue)) return;
            var textChangedBehavior = bindable as TextChangedBehavior;
            if (textChangedBehavior != null)
                textChangedBehavior.AssociatedObject.Text = newvalue;
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Text = e.NewTextValue;
        }


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public string Pattern
        {
            get { return (string)GetValue(PatternProperty); }
            set { SetValue(PatternProperty, value); }
        }

        protected override void OnAttach()
        {
            AssociatedObject.TextChanged += OnTextChanged;

        }


        protected override void OnDetach()
        {
            AssociatedObject.TextChanged -= OnTextChanged;
        }
    }



}
