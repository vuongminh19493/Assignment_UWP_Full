﻿#pragma checksum "C:\Users\MINHVC\source\repos\Assignment_UWP_Full\Assignment_UWP_Full\Pages\ListSong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3CFBE117AD4E921935C43E6018C3974B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_UWP_Full.Pages
{
    partial class ListSong : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Media_ImageBrush_ImageSource(global::Windows.UI.Xaml.Media.ImageBrush obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.ImageSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ListSong_obj10_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IListSong_Bindings
        {
            private global::Assignment_UWP_Full.Entity.Song dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj11;
            private global::Windows.UI.Xaml.Controls.TextBlock obj12;
            private global::Windows.UI.Xaml.Controls.TextBlock obj13;
            private global::Windows.UI.Xaml.Media.ImageBrush obj14;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj11TextDisabled = false;
            private static bool isobj12TextDisabled = false;
            private static bool isobj13TextDisabled = false;
            private static bool isobj14ImageSourceDisabled = false;

            public ListSong_obj10_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 34 && columnNumber == 52)
                {
                    isobj11TextDisabled = true;
                }
                else if (lineNumber == 35 && columnNumber == 52)
                {
                    isobj12TextDisabled = true;
                }
                else if (lineNumber == 36 && columnNumber == 52)
                {
                    isobj13TextDisabled = true;
                }
                else if (lineNumber == 30 && columnNumber == 81)
                {
                    isobj14ImageSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 10: // Pages\ListSong.xaml line 27
                        this.obj10 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 11: // Pages\ListSong.xaml line 34
                        this.obj11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 12: // Pages\ListSong.xaml line 35
                        this.obj12 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 13: // Pages\ListSong.xaml line 36
                        this.obj13 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 14: // Pages\ListSong.xaml line 30
                        this.obj14 = (global::Windows.UI.Xaml.Media.ImageBrush)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj10.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::Assignment_UWP_Full.Entity.Song) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IListSong_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Assignment_UWP_Full.Entity.Song)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Assignment_UWP_Full.Entity.Song obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_name(obj.name, phase);
                        this.Update_singer(obj.singer, phase);
                        this.Update_author(obj.author, phase);
                        this.Update_thumbnail(obj.thumbnail, phase);
                    }
                }
            }
            private void Update_name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\ListSong.xaml line 34
                    if (!isobj11TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj11, obj, null);
                    }
                }
            }
            private void Update_singer(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\ListSong.xaml line 35
                    if (!isobj12TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj12, obj, null);
                    }
                }
            }
            private void Update_author(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\ListSong.xaml line 36
                    if (!isobj13TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj13, obj, null);
                    }
                }
            }
            private void Update_thumbnail(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\ListSong.xaml line 30
                    if (!isobj14ImageSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Media_ImageBrush_ImageSource(this.obj14, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 3: // Pages\ListSong.xaml line 46
                {
                    this.MyMediaPlayer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 4: // Pages\ListSong.xaml line 49
                {
                    this.PreviousButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.PreviousButton).Click += this.PreviousButton_OnClick;
                }
                break;
            case 5: // Pages\ListSong.xaml line 50
                {
                    this.StatusButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.StatusButton).Click += this.StatusButton_OnClick;
                }
                break;
            case 6: // Pages\ListSong.xaml line 51
                {
                    this.NextButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.NextButton).Click += this.NextButton_OnClick;
                }
                break;
            case 7: // Pages\ListSong.xaml line 53
                {
                    this.ControlLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Pages\ListSong.xaml line 24
                {
                    this.ListViewSong = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListViewSong).DoubleTapped += this.ListViewSong_OnDoubleTapped;
                }
                break;
            case 10: // Pages\ListSong.xaml line 27
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element10 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element10).Tapped += this.SelectSong;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 10: // Pages\ListSong.xaml line 27
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element10 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    ListSong_obj10_Bindings bindings = new ListSong_obj10_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element10.DataContext);
                    element10.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element10, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element10, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

