using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using _5ECharacterCreator.Enums;
using _5ECharacterCreator.UserControls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _5ECharacterCreator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClassPage : Page
    {
        private ObservableCollection<CharacterClass> ClassListviewItems = new ObservableCollection<CharacterClass>();
        private ObservableCollection<Subclass> SubClassListviewItems = new ObservableCollection<Subclass>();

        //private bool _ignoreOnLoad = false;

        public ClassPage()
        {
            this.InitializeComponent();
            //ClassListviewItems = new ObservableCollection<CharacterClass>
            //{
            //    new CharacterClass(ClassEnum.Barbarian),
            //    new CharacterClass(ClassEnum.Bard),
            //    new CharacterClass(ClassEnum.Cleric),
            //    new CharacterClass(ClassEnum.Druid),
            //    new CharacterClass(ClassEnum.Fighter),
            //    new CharacterClass(ClassEnum.Monk),
            //    new CharacterClass(ClassEnum.Paladin),
            //    new CharacterClass(ClassEnum.Ranger),
            //    new CharacterClass(ClassEnum.Rogue),
            //    new CharacterClass(ClassEnum.Sorcerer),
            //    new CharacterClass(ClassEnum.Warlock),
            //    new CharacterClass(ClassEnum.Wizard),
            //};
            //ClassList.ItemsSource = ClassListviewItems;
        }

        private void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Characteristics));
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO When multiclassing, enable button
            var lastbutton = MainStackPanel.Children.Last();
            MainStackPanel.Children.Remove(lastbutton);
            var newClassSelection = new ClassSelection();
            newClassSelection.DataChanged += ClassSelection_OnDataChanged;
            MainStackPanel.Children.Add(newClassSelection);
            MainStackPanel.Children.Add(lastbutton);
        }

        private void ClassSelection_OnDataChanged(object sender, EventArgs e)
        {
            //if (_ignoreOnLoad)
            //    return;

            ClassSelection classItem = null;
            foreach (var item in MainStackPanel.Children)
            {
                if (item is ClassSelection && item.Visibility == Visibility.Visible)
                {
                    classItem = item as ClassSelection;
                    MainPage.GenCharacter.Classes = classItem.SetClass;
                }
            }


            SubclassStackPanel.Children.Clear();
            OptionsStackPanel.Children.Clear();
            SubOptionsStackPanel.Children.Clear();

            // Display Subclass Selection
            DisplayRelevantSubclassInfo(classItem);

            // Display changed class data if it is selected
            if (sender is ClassSelection classSelectionObj)
            {
                if (classSelectionObj.SetClass == null)
                    return;
                var selectedClass = new CharacterClass(classSelectionObj.SetClass.EnumType, 20);
                ClassDetailsHeader.Text = selectedClass.Name;
                ClassDetailsSubHeader.Text = selectedClass.GetClassSubheader();
                ClassDetailsStackPanel.Children.Clear();
                selectedClass.GetClassDetails(ClassDetailsStackPanel);
            }

            // Display Class Choices
            DisplayClassChoices(classItem);

            //var classList = new List<ClassSelection>();
            //foreach (var item in MainStackPanel.Children)
            //{
            //    if (item is ClassSelection && item.Visibility == Visibility.Visible)
            //    {
            //        classList.Add(item as ClassSelection);   
            //    }
            //}

            //SubclassStackPanel.Children.Clear();
            //OptionsStackPanel.Children.Clear();
            //SubOptionsStackPanel.Children.Clear();

            //// Display Subclass Selection
            //foreach (var classItem in classList)
            //{
            //    DisplayRelevantSubclassInfo(classItem);
            //}

            //MainPage.GenCharacter.Classes.Clear();
            //foreach (var classObj in classList)
            //{
            //    MainPage.GenCharacter.Classes.Add(classObj.SetClass);
            //}

            //// Display changed class data
            //if (sender is ClassSelection classSelectionObj)
            //{
            //    if (classSelectionObj.SetClass == null)
            //        return;
            //    var selectedClass = new CharacterClass(classSelectionObj.SetClass.EnumType, 20);
            //    ClassDetailsHeader.Text = selectedClass.Name;
            //    ClassDetailsSubHeader.Text = selectedClass.GetClassSubheader();
            //    ClassDetailsStackPanel.Children.Clear();
            //    selectedClass.GetClassDetails(ClassDetailsStackPanel);

            //    foreach (var item in classList)
            //    {
            //        // Display Class Choice Menu
            //        foreach (var choice in item.SetClass.ClassChoices)
            //        {
            //            var classChoiceBox = new ClassChoiceControl(choice);
            //            classChoiceBox.SelectionChanged += ClassChoiceSelectionChanged;
            //            OptionsStackPanel.Children.Add(classChoiceBox);
            //            // TODO make sure options are remembered and checked when added
            //        }
            //    }
            //}
        }

        private void DisplayClassChoices(ClassSelection classItem)
        {
            if (classItem != null)
            {
                foreach (var choice in classItem.SetClass.ClassChoices)
                {
                    var classChoiceBox = new ClassChoiceControl(choice);
                    classChoiceBox.SelectionChanged += ClassChoiceSelectionChanged;
                    // Check if any choices were previously selected
                    foreach (var trait in choice.Choices)
                    {
                        foreach (var addedTrait in MainPage.GenCharacter.Traits)
                        {
                            if (string.Equals(addedTrait.Header, trait.Header))
                            {
                                classChoiceBox.Select(trait);
                            }
                        }
                    }
                    OptionsStackPanel.Children.Add(classChoiceBox);
                }
            }
        }

        private void ClassChoiceSelectionChanged(object sender, EventArgs e)
        {
            if (sender is ClassChoiceControl ccc)
            {
                if (e is ClassChoiceEventArgs ccea)
                {
                    ClassDetailsHeader.Text = ccea.TCB.Context.Header;
                    ClassDetailsSubHeader.Text = ccea.TCB.Context.FullDescription;
                    ClassDetailsStackPanel.Children.Clear();
                }
            }
        }

        /// <summary>
        /// Displays a selector for the subclass depending on if it is avaliable for the selected level
        /// </summary>
        /// <param name="classItem"></param>
        private void DisplayRelevantSubclassInfo(ClassSelection classItem)
        {
            if (classItem == null)
                return;
            //    // barb >=3
            //    // bard >=3
            //    // cleric = all
            //    // druid >= 2
            //    // fighter >= 3
            //    // monk >= 3
            //    // Paladin >= 3
            //    // ranger >= 3
            //    // rogue >= 3
            //    // Sorcerer = all
            //    // warlock = all
            //    // Wizard >= 2
            var level = classItem.SetLevel;
            var classy = classItem.SetClass;
            var subclassList = classy.GetAllowedSubclasses();
            var subclassName = classy.SubclassName;

            switch (classy.EnumType)
            {
                case ClassEnum.Barbarian:
                    if (level < 3)
                        return;
                    break;
                case ClassEnum.Bard:
                    if (level < 3)
                        return;
                    break;
                case ClassEnum.Cleric:
                    break;
                case ClassEnum.Druid:
                    if (level < 2)
                        return;
                    break;
                case ClassEnum.Fighter:
                    if (level < 3)
                        return;
                    break;
                case ClassEnum.Monk:
                    if (level < 3)
                        return;
                    break;
                case ClassEnum.Paladin:
                    if (level < 3)
                        return;
                    break;
                case ClassEnum.Ranger:
                    if (level < 3)
                        return;
                    break;
                case ClassEnum.Rogue:
                    if (level < 3)
                        return;
                    break;
                case ClassEnum.Sorcerer:
                    break;
                case ClassEnum.Warlock:
                    break;
                case ClassEnum.Wizard:
                    if (level < 2)
                        return;
                    break;
                default:
                    return;
            }

            var newComboBox = new ComboBox
            {
                Margin = new Thickness(20, 5, 0, 5),
                Width = 300,
            };
            newComboBox.SelectionChanged += SubclassOnSelectionChanged;
            foreach (var subclassOption in subclassList)
            {
                newComboBox.Items.Add(new Subclass(subclassOption, level));
            }

            foreach (Subclass item in newComboBox.Items)
            {
                if (MainPage.GenCharacter.Subclasses != null && item.EnumType == MainPage.GenCharacter.Subclasses.EnumType)
                {
                    newComboBox.SelectedIndex = newComboBox.Items.IndexOf(item);
                    // Update existing subclass
                    MainPage.GenCharacter.Subclasses = item;
                }
            }

            //// Check added subclasses and choose the correct one if it has been chosen previously
            //Subclass subClassToChange = null;
            //foreach (var subclass in MainPage.GenCharacter.Subclasses)
            //{
            //    foreach (Subclass item in newComboBox.Items)
            //    {
            //        if (item.EnumType == subclass.EnumType)
            //        {
            //            newComboBox.SelectedItem = item;
            //            subClassToChange = subclass;
            //        }
            //    }
            //}

            //// Update the existing SubClass
            //if (MainPage.GenCharacter.Subclasses.Contains(subClassToChange))
            //{
            //    MainPage.GenCharacter.Subclasses.Remove(subClassToChange);
            //    var updatedSC = new Subclass(subClassToChange.EnumType, level);
            //    MainPage.GenCharacter.Subclasses.Add(updatedSC);
            //}

            //newComboBox.SelectedIndex = 0;
            SubclassStackPanel.Children.Add(new TextBlock
            {
                Text = subclassName,
                FontSize = 30,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(20,5,0,5),
            });
            SubclassStackPanel.Children.Add(newComboBox);
        }

        private void SubclassOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            // Display subclass data
            if (sender is ComboBox combobox && combobox.SelectedValue is Subclass selection)
            {
                var selectedClass = new Subclass(selection.EnumType, 20);
                ClassDetailsHeader.Text = selectedClass.Name;
                ClassDetailsSubHeader.Text = selectedClass.GetSubclassSubheader();
                ClassDetailsStackPanel.Children.Clear();
                selectedClass.GetClassDetails(ClassDetailsStackPanel);

                SubOptionsStackPanel.Children.Clear();

                MainPage.GenCharacter.Subclasses = selection;

                // Display SubClass Choice Menu
                foreach (var choice in selection.ChoiceList)
                {
                    var classChoiceBox = new ClassChoiceControl(choice);
                    classChoiceBox.SelectionChanged += ClassChoiceSelectionChanged;
                    // Check if any choices were previously selected
                    foreach (var trait in choice.Choices)
                    {
                        foreach (var addedTrait in MainPage.GenCharacter.Traits)
                        {
                            if (string.Equals(addedTrait.Header, trait.Header))
                            {
                                classChoiceBox.Select(trait);
                            }
                        }
                    }

                    SubOptionsStackPanel.Children.Add(classChoiceBox);
                }

                //if (!MainPage.GenCharacter.Subclasses.Contains(selection))
                //{
                //    MainPage.GenCharacter.Subclasses.Add(selection);
                //}
            }
        }

        private void ClassPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            //_ignoreOnLoad = true;
            CharacterClass selectedClass = null;
            if (MainPage.GenCharacter.Classes != null)
            {
                selectedClass = MainPage.GenCharacter.Classes;
            }

            var lastbutton = MainStackPanel.Children.Last();
            MainStackPanel.Children.Remove(lastbutton);
            var newClassSelection = new ClassSelection(selectedClass);
            newClassSelection.DataChanged += ClassSelection_OnDataChanged;
            MainStackPanel.Children.Add(newClassSelection);
            MainStackPanel.Children.Add(lastbutton);

            //if (MainPage.GenCharacter.Classes.Count > 0)
            //{
            //    var lastbutton = MainStackPanel.Children.Last();
            //    MainStackPanel.Children.Remove(lastbutton);
            //    foreach (var classobj in MainPage.GenCharacter.Classes)
            //    {
            //        var newClassSelection = new ClassSelection(classobj);
            //        newClassSelection.DataChanged += ClassSelection_OnDataChanged;
            //        MainStackPanel.Children.Add(newClassSelection);
            //    }
            //    MainStackPanel.Children.Add(lastbutton);
            //}
            //else
            //{
            //    AddButton_OnClick(this, new RoutedEventArgs());
            //}
            //_ignoreOnLoad = false;
        }
    }
}
