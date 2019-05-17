using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BehaviorProject
{
    public class SwitchBehavior : Behavior<Switch>
    {
        /// <summary>
        /// The command property.
        /// </summary>
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(SwitchBehavior), null);

        /// <summary>
        /// The converter property.
        /// </summary>
        public static readonly BindableProperty ConverterProperty = BindableProperty.Create("ValueConverter", typeof(IValueConverter), typeof(SwitchBehavior), null);

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets the converter.
        /// </summary>
        /// <value>The converter.</value>
        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(ConverterProperty); }
            set { SetValue(ConverterProperty, value); }
        }

        /// <summary>
        /// Gets the bindable.
        /// </summary>
        /// <value>The bindable.</value>
        public Switch Bindable { get; private set; }

        /// <summary>
        /// On attached to.
        /// </summary>
        /// <param name="bindable">The bindable component.</param>
        protected override void OnAttachedTo(Switch bindable)
        {
            base.OnAttachedTo(bindable);
            Bindable = bindable;
            Bindable.BindingContextChanged += OnBindingContextChanged;
            Bindable.Toggled += OnSwitchToggled;
        }

        /// <summary>
        /// Ons the binding context changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
            BindingContext = Bindable.BindingContext;
        }

        /// <summary>
        /// Ons the switch toggled.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (Command != null)
            {
                var item = Converter.Convert(e, typeof(object), null, null);

                if (!Command.CanExecute(item))
                {
                    return;
                }

                Command.Execute(item);
            }
        }

        /// <summary>
        /// On detaching from.
        /// </summary>
        /// <param name="bindable">The bindable component.</param>
        protected override void OnDetachingFrom(Switch bindable)
        {
            base.OnDetachingFrom(bindable);
            Bindable.BindingContextChanged -= OnBindingContextChanged;
            Bindable.Toggled -= OnSwitchToggled;
            Bindable = null;
        }
    }
}
