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

        private bool _ignoreOnLoad = false;

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

        //private void ClassCollapsableHeaderButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (ClassList.Visibility == Visibility.Visible)
        //    {
        //        // Collapse
        //        ClassList.Visibility = Visibility.Collapsed;
        //        ClassCollapsableHeaderIcon.Text = "\uE014";
        //    }
        //    else
        //    {
        //        ClassList.Visibility = Visibility.Visible;
        //        ClassCollapsableHeaderIcon.Text = "\uE011";
        //    }
        //}

        //private void ClassList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (!(ClassList.SelectedItem is CharacterClass context)) return;
        //    var tmpClass = new CharacterClass(context.EnumType, 20);
        //    ClassDetailsHeader.Text = tmpClass.Name;
        //    ClassDetailsSubHeader.Text = tmpClass.GetClassSubheader();
        //    ClassDetailsStackPanel.Children.Clear();
        //    tmpClass.GetClassDetails(ClassDetailsStackPanel);

        //    //TODO: Show subclasses if the min level is reached
        //    //TODO: provide a tooltip indicating why it is disabled

        //    // Populate subclass list if applicable
        //    if (SubClassList.Visibility == Visibility.Collapsed)
        //    {
        //        SubclassName.Text = context.SubclassName;
        //        SubClassList.Visibility = Visibility.Visible;
        //    }

        //    // Enable the buttons under certain conditions (minlevel is reached and class is selected)
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

        //    SubClassListviewItems = new ObservableCollection<Subclass>();
        //    foreach (var item in context.GetAllowedSubclasses())
        //    {
        //        SubClassListviewItems.Add(new Subclass(item));
        //    }
        //    SubClassList.ItemsSource = SubClassListviewItems;

        //    if (MainPage.GenCharacter.Classes != null && MainPage.GenCharacter.Subclasses != null
        //        && MainPage.GenCharacter.Classes.Count > 0 && MainPage.GenCharacter.Subclasses.Count == 1)
        //        ButtonNext.IsEnabled = true;
        //    else
        //    {
        //        ButtonNext.IsEnabled = false;
        //    }

        //}

        //private void ClassSelection_OnChecked(object sender, RoutedEventArgs e)
        //{
        //    // Find which item was selected and select the listview item for good measure
        //    if (e.OriginalSource is CheckBox cb)
        //    {
        //        if (cb.DataContext is CharacterClass context)
        //        {
        //            for (var i = 0; i < ClassListviewItems.Count; i++)
        //            {
        //                if (ClassListviewItems[i].Equals(context))
        //                {
        //                    ClassList.SelectedIndex = i;
        //                    break;
        //                }
        //            }

        //            //TODO: Check total level is < 20 (multiclassing)
        //            //TODO: Enable subclass radio buttons

        //            if (!MainPage.GenCharacter.Classes.Contains(context))
        //            {
        //                MainPage.GenCharacter.Classes.Add(context);
        //            }
        //        }
        //    }
        //}

        private void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Characteristics));
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var lastbutton = MainStackPanel.Children.Last();
            MainStackPanel.Children.Remove(lastbutton);
            var newClassSelection = new ClassSelection();
            newClassSelection.DataChanged += ClassSelection_OnDataChanged;
            MainStackPanel.Children.Add(newClassSelection);
            MainStackPanel.Children.Add(lastbutton);
        }

        private void ClassSelection_OnDataChanged(object sender, EventArgs e)
        {
            if (_ignoreOnLoad)
                return;
            var classList = new List<ClassSelection>();
            foreach (var item in MainStackPanel.Children)
            {
                if (item is ClassSelection && item.Visibility == Visibility.Visible)
                {
                    classList.Add(item as ClassSelection);   
                }
            }

            //
            SubclassStackPanel.Children.Clear();

            // Display Subclass Selection
            foreach (var classItem in classList)
            {
                DisplayRelevantSubclassInfo(classItem);
            }

            MainPage.GenCharacter.Classes.Clear();
            foreach (var classObj in classList)
            {
                MainPage.GenCharacter.Classes.Add(classObj.SetClass);
            }

            // Display changed class data
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
        }

        /// <summary>
        /// Displays a selector for the subclass depending on if it is avaliable for the selected level
        /// </summary>
        /// <param name="classItem"></param>
        private void DisplayRelevantSubclassInfo(ClassSelection classItem)
        {
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
                newComboBox.Items.Add(new Subclass(subclassOption));
            }
            newComboBox.SelectedIndex = 0;
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
            
        }

        private void ClassPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            _ignoreOnLoad = true;
            if (MainPage.GenCharacter.Classes.Count > 0)
            {
                var lastbutton = MainStackPanel.Children.Last();
                MainStackPanel.Children.Remove(lastbutton);
                foreach (var classobj in MainPage.GenCharacter.Classes)
                {
                    var newClassSelection = new ClassSelection(classobj);
                    newClassSelection.DataChanged += ClassSelection_OnDataChanged;
                    MainStackPanel.Children.Add(newClassSelection);
                }
                MainStackPanel.Children.Add(lastbutton);
            }
            else
            {
                AddButton_OnClick(this, new RoutedEventArgs());
            }
            _ignoreOnLoad = false;
        }
    }
}
