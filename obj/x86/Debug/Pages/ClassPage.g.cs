﻿#pragma checksum "C:\Users\aldth\source\repos\5ECharacterCreator\5ECharacterCreator\Pages\ClassPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "44A316D9CE8FA9F71E7A7BE5C6857D52"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _5ECharacterCreator.Pages
{
    partial class ClassPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 10 "..\..\..\Pages\ClassPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.ClassPage_OnLoaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.ButtonNext = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 72 "..\..\..\Pages\ClassPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButtonNext).Click += this.ButtonNext_OnClick;
                    #line default
                }
                break;
            case 3:
                {
                    this.MainStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4:
                {
                    this.SubclassStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5:
                {
                    this.AddButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 43 "..\..\..\Pages\ClassPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddButton).Click += this.AddButton_OnClick;
                    #line default
                }
                break;
            case 6:
                {
                    this.ClassDetailsHeader = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.ClassDetailsSubHeader = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.ClassDetailsStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 9:
                {
                    this.RaceDetails = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

