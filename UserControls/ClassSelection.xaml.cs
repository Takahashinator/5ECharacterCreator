using System;
using System.Collections.Generic;
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
using _5ECharacterCreator.Enums;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace _5ECharacterCreator.UserControls
{
    public partial class ClassSelection : UserControl
    {
        public int SetLevel = 1;
        public CharacterClass SetClass;
        public event EventHandler DataChanged;

        public ClassSelection(CharacterClass c)
        {
            if (c == null)
            {
                this.InitializeComponent();
                SetClass = new CharacterClass(ClassEnum.Barbarian);
                SetLevel = 1;

                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Barbarian));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Bard));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Cleric));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Druid));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Fighter));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Monk));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Paladin));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Ranger));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Rogue));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Sorcerer));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Warlock));
                ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Wizard));
                ClassComboBox.SelectedIndex = 0;

                for (int i = 1; i <= 20; i++)
                    LevelComboBox.Items.Add(i);

                LevelComboBox.SelectedIndex = 0;
                return;
            }

            this.InitializeComponent();
            SetClass = c;
            SetLevel = c.Level;
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Barbarian));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Bard));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Cleric));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Druid));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Fighter));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Monk));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Paladin));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Ranger));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Rogue));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Sorcerer));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Warlock));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Wizard));
            ClassComboBox.SelectedIndex = (int)c.EnumType;

            for (int i = 1; i <= 20; i++)
                LevelComboBox.Items.Add(i);

            LevelComboBox.SelectedIndex = c.LevelIndex;
        }

        public ClassSelection()
        {
            this.InitializeComponent();
            SetClass = new CharacterClass(ClassEnum.Barbarian);
            SetLevel = 1;

            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Barbarian));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Bard));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Cleric));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Druid));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Fighter));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Monk));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Paladin));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Ranger));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Rogue));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Sorcerer));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Warlock));
            ClassComboBox.Items.Add(new CharacterClass(ClassEnum.Wizard));
            ClassComboBox.SelectedIndex = 0;

            for (int i = 1; i <= 20; i++)
                LevelComboBox.Items.Add(i);

            LevelComboBox.SelectedIndex = 0;
        }

        public virtual void OnDataChanged()
        {
            var handler = DataChanged;
            handler?.Invoke(this, new EventArgs());
        }
        
        private void ClassComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetClass = (CharacterClass) ClassComboBox.SelectedValue;
            SetClass.LevelTo(SetLevel);
            OnDataChanged();
        }

        private void LevelComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetLevel = (int) LevelComboBox.SelectedValue;
            SetClass?.LevelTo(SetLevel);
            OnDataChanged();
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO When multiclassing (Remove this class information and relevant sublcass info???)
            // Remove the class from the main page
            SetClass = null;
            SetLevel = -1;
            this.Visibility = Visibility.Collapsed;
            OnDataChanged();
        }

        private void ClassSelection_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Check if there is a class already selected

            OnDataChanged();
        }
    }
}
