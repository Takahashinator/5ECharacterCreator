using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using _5ECharacterCreator.Enums;
using _5ECharacterCreator.Pages;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _5ECharacterCreator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RaceSelection : Page
    {
        private ObservableCollection<Race> RaceListviewItems = new ObservableCollection<Race>();
        private ObservableCollection<Subrace> SubRaceListviewItems = new ObservableCollection<Subrace>();

        public RaceSelection()
        {
            this.InitializeComponent();
            RaceListviewItems = new ObservableCollection<Race>
            {
                new Race(RaceEnum.Dragonborn),
                new Race(RaceEnum.Dwarf),
                new Race(RaceEnum.Elf),
                new Race(RaceEnum.Gnome),
                new Race(RaceEnum.HalfElf),
                new Race(RaceEnum.HalfOrc),
                new Race(RaceEnum.Halfling),
                new Race(RaceEnum.Human),
                new Race(RaceEnum.Tiefling),
            };
            RaceList.ItemsSource = RaceListviewItems;
        }

        private void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ClassPage));
        }

        private void RaceCollapsableHeaderButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (RaceList.Visibility == Visibility.Visible)
            {
                // Collapse
                RaceList.Visibility = Visibility.Collapsed;
                RaceCollapsableHeaderIcon.Text = "\uE014";
            }
            else
            {
                RaceList.Visibility = Visibility.Visible;
                RaceCollapsableHeaderIcon.Text = "\uE011";
            }
        }

        private void SubRaceCollapsableHeaderButton_OnClickRaceCollapsableHeaderButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SubRaceList.Visibility == Visibility.Visible)
            {
                // Collapse
                SubRaceList.Visibility = Visibility.Collapsed;
                SubRaceCollapsableHeaderIcon.Text = "\uE014";
            }
            else
            {
                SubRaceList.Visibility = Visibility.Visible;
                SubRaceCollapsableHeaderIcon.Text = "\uE011";
            }
        }

        private void RaceList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(RaceList.SelectedItem is Race context)) return;
            RaceDetailsHeader.Text = context.Name;
            RaceDetailsSubHeader.Text = context.GetRaceSubheader();
            RaceDetailsStackPanel.Children.Clear();
            context.GetRaceDetails(RaceDetailsStackPanel);

            //// Populate subrace list if applicable
            //SubRaceListviewItems = new ObservableCollection<Subrace>();
            //foreach (var item in context.GetAllowedSubraces())
            //{
            //    SubRaceListviewItems.Add(new Subrace(item));
            //}
            //if (context.GetAllowedSubraces().First() != SubraceEnum.None)
            //{
            //    SubRaceList.ItemsSource = SubRaceListviewItems;
            //}
            //else
            //{
            //    // Clear subrace items
            //    SubRaceList.ItemsSource = new ObservableCollection<Subrace>();
            //}
        }

        private void SubRaceList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(SubRaceList.SelectedItem is Subrace context)) return;
            RaceDetailsHeader.Text = context.Name;
            RaceDetailsSubHeader.Text = context.GetSubraceHeader();
            RaceDetailsStackPanel.Children.Clear();
            context.GetSubRaceDetails(RaceDetailsStackPanel);
        }

        private void RaceSelection_OnChecked(object sender, RoutedEventArgs e)
        {
            // Find which item was selected and select the listview item for good measure
            if (e.OriginalSource is RadioButton rb)
            {
                if (rb.DataContext is Race context)
                {
                    for (var i = 0; i < RaceListviewItems.Count; i++)
                    {
                        if (RaceListviewItems[i].Equals(context))
                        {
                            RaceList.SelectedIndex = i;
                            break;
                        }
                    }

                    // Populate subrace list if applicable
                    SubRaceListviewItems = new ObservableCollection<Subrace>();
                    foreach (var item in context.GetAllowedSubraces())
                    {
                        SubRaceListviewItems.Add(new Subrace(item));
                    }
                    if (context.GetAllowedSubraces().First() != SubraceEnum.None)
                    {
                        SubRaceList.ItemsSource = SubRaceListviewItems;
                    }
                    else
                    {
                        // Clear subrace items
                        SubRaceList.ItemsSource = new ObservableCollection<Subrace>();
                        MainPage.GenCharacter.Subrace = null;
                    }

                    MainPage.GenCharacter.Race = context;
                    ButtonNext.IsEnabled = MainPage.GenCharacter.Race != null;
                }
            }
        }

        private void SubRaceSelection_OnChecked(object sender, RoutedEventArgs e)
        {
            // Find which item was selected and select the listview item for good measure
            if (e.OriginalSource is RadioButton rb)
            {
                if (rb.DataContext is Subrace context)
                {
                    for (var i = 0; i < SubRaceListviewItems.Count; i++)
                    {
                        if (SubRaceListviewItems[i].Equals(context))
                        {
                            SubRaceList.SelectedIndex = i;
                            break;
                        }
                    }
                    MainPage.GenCharacter.Subrace = context;
                    ButtonNext.IsEnabled = MainPage.GenCharacter.Race != null;
                }
            }
        }

        private void RadioButton_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Check for already selected race
            var selectedRace = MainPage.GenCharacter.Race;
            if (selectedRace != null)
            {
                if (sender is RadioButton rb)
                {
                    if (rb.DataContext is Race context)
                    {
                        if (selectedRace.TypeEnum == context.TypeEnum)
                        {
                            rb.IsChecked = true;
                        }
                    }
                }
            }
        }

        private void SubraceRadioButton_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Check for already selected sub race
            var selectedSubRace = MainPage.GenCharacter.Subrace;
            if (selectedSubRace != null)
            {
                if (sender is RadioButton rb)
                {
                    if (rb.DataContext is Subrace context)
                    {
                        if (selectedSubRace.Name == context.Name)
                        {
                            rb.IsChecked = true;
                        }
                    }
                }
            }
        }
    }
}
