using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using _5ECharacterCreator.Classes;
using _5ECharacterCreator.Pages;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _5ECharacterCreator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Character GenCharacter = new Character();
        public static SpellList AllSpells;

        public MainPage()
        {
            this.InitializeComponent();
            GenerateAllSpells("Spells.json");
            MainFrame.Navigate(typeof(Home));
            TitleTextBlock.Text = "Dungeons And Dragons 5E Character Creator";
            // Test Text for JSON Parsing
            //foreach (var item in AllSpells)
            //{
            //    if ((string) item["name"] == "Aid")
            //    {
            //        TitleTextBlock.Text = (string) item["name"];
            //    }
            //}
        }

        private static void GenerateAllSpells(string spellsJson)
        {
            using (var r = File.OpenText(spellsJson))
            {
                var json = r.ReadToEnd();
                AllSpells = new SpellList(JArray.Parse(json));
            }
        }

        public void UpdateTitlebar(string words)
        {
            TitleTextBlock.Text = words;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.IsPaneOpen = !SplitViewMenu.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(Home));
            }
            else if (RaceListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(RaceSelection));
            }
            else if (ClassListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(ClassPage));
            }
            else if (CharacteristicsListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(Characteristics));
            }
            else if (AbilityScoreListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(AbilityScores));
            }
            else if (SkillsListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(Skills));
            }
            else if (SpellsListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(SpellsPage));
            }
            else if (EquipmentListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(EquipmentPage));
            }
            else if (ReviewListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(SummaryPage));
            }

        }
    }
}
