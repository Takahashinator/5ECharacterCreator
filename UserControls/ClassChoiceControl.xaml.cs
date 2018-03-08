using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using _5ECharacterCreator.HelperStructs;
using _5ECharacterCreator.Pages;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace _5ECharacterCreator.UserControls
{
    public partial class ClassChoiceControl : UserControl
    {
        private readonly int numberofchoices = 1;
        private readonly ObservableCollection<TraitCheckbox> OptionListviewItems = new ObservableCollection<TraitCheckbox>();
        public event EventHandler SelectionChanged;

        public ClassChoiceControl(ClassChoice choiceObj)
        {
            this.InitializeComponent();

            // Unpack details (# of choices)
            numberofchoices = choiceObj.ItemstoChoose;
            ListViewHeader.Text = choiceObj.Header;
            NumChoicesHeader.Text += " " + numberofchoices;

            // Add each choice to the display
            foreach (var item in choiceObj.Choices)
            {
                OptionListviewItems.Add(new TraitCheckbox(item));
            }
            OptionList.ItemsSource = OptionListviewItems;
        }

        public virtual void OnDataSelectionChanged(object obj)
        {
            var handler = SelectionChanged;
            handler?.Invoke(this, new ClassChoiceEventArgs(obj as TraitCheckbox));
        }

        private void OptionList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnDataSelectionChanged(OptionList.SelectedItem);
        }

        private void Selection_OnChecked(object sender, RoutedEventArgs e)
        {
            // check how many checkboxes are checked and disable the others
            if (e.OriginalSource is CheckBox cb)
            {
                if (cb.DataContext is TraitCheckbox TCB)
                {
                    if (!MainPage.GenCharacter.Traits.Contains(TCB.Context))
                    {
                        MainPage.GenCharacter.Traits.Add(TCB.Context);
                    }

                    for (var i = 0; i < OptionListviewItems.Count; i++)
                    {
                        if (OptionListviewItems[i].Equals(TCB))
                        {
                            OptionList.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }

            int count = OptionListviewItems.Count(item => item.IsChecked);

            if (count >= numberofchoices)
            {
                foreach (var item in OptionListviewItems)
                {
                    if (!item.IsChecked)
                    {
                        // Disable
                        item.IsEnabledBindingHandle = false;
                    }
                }
            }
        }

        //TODO Handle on clear event??? (to delete all relevent traits?)

        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is CheckBox cb)
            {
                if (cb.DataContext is TraitCheckbox TCB)
                {
                    if (MainPage.GenCharacter.Traits.Contains(TCB.Context))
                    {
                        MainPage.GenCharacter.Traits.Remove(TCB.Context);
                    }
                }
            }

            int count = OptionListviewItems.Count(item => item.IsChecked);
            if (count < numberofchoices)
            {
                foreach (var item in OptionListviewItems)
                {
                    if (!item.IsChecked)
                    {
                        // Enable
                        item.IsEnabledBindingHandle = true;
                    }
                }
            }
        }

        public void Select(Trait trait)
        {
            foreach (var tcb in OptionListviewItems)
            {
                if (string.Equals(tcb.Context.Header, trait.Header))
                    tcb.IsChecked = true;
            }
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Binding Class for the option Checkboxes
    /// </summary>
    public class TraitCheckbox : INotifyPropertyChanged
    {
        public bool IsChecked { get; set; } = false;
        private bool _isEnabledBindingHandle = true;

        public bool IsEnabledBindingHandle
        {
            get => _isEnabledBindingHandle;
            set
            {
                _isEnabledBindingHandle = value;
                UpdateProperty("IsEnabledBindingHandle");
            }
        }

        public Trait Context { get; set; }

        public TraitCheckbox(Trait c)
        {
            Context = c;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateProperty(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class ClassChoiceEventArgs : EventArgs
    {
        public ClassChoiceEventArgs(TraitCheckbox businessObject)
        {
            TCB = businessObject;
        }

        public TraitCheckbox TCB { get; }
    }
}
