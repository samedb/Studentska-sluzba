﻿#pragma checksum "C:\Users\Samed\Documents\GitHub\Studentska-sluzba\Aplikacija\Studentska služba\Studentska služba\Views\Podaci\Ispiti\IspitiView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5F46D9F166FBE2AF7A1969146B9ED7F8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Studentska_služba.Views.Podaci
{
    partial class IspitiView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Studentska_služba_Views_Podaci_Ispiti_IspitiList_vm(global::Studentska_služba.Views.Podaci.Ispiti.IspitiList obj, global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel), targetNullValue);
                }
                obj.vm = value;
            }
            public static void Set_Studentska_služba_Views_Podaci_CommandLine_AddNewItemCommand(global::Studentska_služba.Views.Podaci.CommandLine obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.AddNewItemCommand = value;
            }
            public static void Set_Studentska_služba_Views_Podaci_CommandLine_UpdateItemCommand(global::Studentska_služba.Views.Podaci.CommandLine obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.UpdateItemCommand = value;
            }
            public static void Set_Studentska_služba_Views_Podaci_CommandLine_DeleteItemCommand(global::Studentska_služba.Views.Podaci.CommandLine obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.DeleteItemCommand = value;
            }
            public static void Set_Studentska_služba_Views_Podaci_CommandLine_RefreshTableCommand(global::Studentska_služba.Views.Podaci.CommandLine obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.RefreshTableCommand = value;
            }
            public static void Set_Studentska_služba_Views_Podaci_CommandLine_SearchBoxText(global::Studentska_služba.Views.Podaci.CommandLine obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.SearchBoxText = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
            public static void Set_Studentska_služba_Views_Podaci_Ispiti_IspitDetails_Ispit(global::Studentska_služba.Views.Podaci.Ispiti.IspitDetails obj, global::StudentskaSluzba.Models.Ispit value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::StudentskaSluzba.Models.Ispit) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::StudentskaSluzba.Models.Ispit), targetNullValue);
                }
                obj.Ispit = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Control_IsEnabled(global::Windows.UI.Xaml.Controls.Control obj, global::System.Boolean value)
            {
                obj.IsEnabled = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class IspitiView_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IIspitiView_Bindings
        {
            private global::Studentska_služba.Views.Podaci.IspitiView dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Studentska_služba.Views.Podaci.CommandLine obj3;
            private global::Windows.UI.Xaml.Controls.StackPanel obj4;
            private global::Studentska_služba.Views.Podaci.Ispiti.IspitDetails obj5;
            private global::Windows.UI.Xaml.Controls.StackPanel obj6;
            private global::Windows.UI.Xaml.Controls.Button obj7;
            private global::Windows.UI.Xaml.Controls.Button obj8;
            private global::Studentska_služba.Views.Podaci.Ispiti.IspitiList obj9;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj3AddNewItemCommandDisabled = false;
            private static bool isobj3UpdateItemCommandDisabled = false;
            private static bool isobj3DeleteItemCommandDisabled = false;
            private static bool isobj3RefreshTableCommandDisabled = false;
            private static bool isobj3SearchBoxTextDisabled = false;
            private static bool isobj4VisibilityDisabled = false;
            private static bool isobj5IspitDisabled = false;
            private static bool isobj5IsEnabledDisabled = false;
            private static bool isobj6VisibilityDisabled = false;
            private static bool isobj7CommandDisabled = false;
            private static bool isobj8CommandDisabled = false;
            private static bool isobj9vmDisabled = false;

            private IspitiView_obj1_BindingsTracking bindingsTracking;

            public IspitiView_obj1_Bindings()
            {
                this.bindingsTracking = new IspitiView_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 35 && columnNumber == 25)
                {
                    isobj3AddNewItemCommandDisabled = true;
                }
                else if (lineNumber == 36 && columnNumber == 25)
                {
                    isobj3UpdateItemCommandDisabled = true;
                }
                else if (lineNumber == 37 && columnNumber == 25)
                {
                    isobj3DeleteItemCommandDisabled = true;
                }
                else if (lineNumber == 38 && columnNumber == 25)
                {
                    isobj3RefreshTableCommandDisabled = true;
                }
                else if (lineNumber == 39 && columnNumber == 25)
                {
                    isobj3SearchBoxTextDisabled = true;
                }
                else if (lineNumber == 50 && columnNumber == 17)
                {
                    isobj4VisibilityDisabled = true;
                }
                else if (lineNumber == 52 && columnNumber == 33)
                {
                    isobj5IspitDisabled = true;
                }
                else if (lineNumber == 53 && columnNumber == 45)
                {
                    isobj5IsEnabledDisabled = true;
                }
                else if (lineNumber == 56 && columnNumber == 25)
                {
                    isobj6VisibilityDisabled = true;
                }
                else if (lineNumber == 60 && columnNumber == 25)
                {
                    isobj7CommandDisabled = true;
                }
                else if (lineNumber == 64 && columnNumber == 25)
                {
                    isobj8CommandDisabled = true;
                }
                else if (lineNumber == 43 && columnNumber == 31)
                {
                    isobj9vmDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // Views\Podaci\Ispiti\IspitiView.xaml line 33
                        this.obj3 = (global::Studentska_služba.Views.Podaci.CommandLine)target;
                        this.bindingsTracking.RegisterTwoWayListener_3(this.obj3);
                        break;
                    case 4: // Views\Podaci\Ispiti\IspitiView.xaml line 46
                        this.obj4 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                        break;
                    case 5: // Views\Podaci\Ispiti\IspitiView.xaml line 52
                        this.obj5 = (global::Studentska_služba.Views.Podaci.Ispiti.IspitDetails)target;
                        this.bindingsTracking.RegisterTwoWayListener_5(this.obj5);
                        break;
                    case 6: // Views\Podaci\Ispiti\IspitiView.xaml line 55
                        this.obj6 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                        break;
                    case 7: // Views\Podaci\Ispiti\IspitiView.xaml line 59
                        this.obj7 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 8: // Views\Podaci\Ispiti\IspitiView.xaml line 63
                        this.obj8 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 9: // Views\Podaci\Ispiti\IspitiView.xaml line 43
                        this.obj9 = (global::Studentska_služba.Views.Podaci.Ispiti.IspitiList)target;
                        this.bindingsTracking.RegisterTwoWayListener_9(this.obj9);
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                throw new global::System.NotImplementedException();
            }

            public void Recycle()
            {
                throw new global::System.NotImplementedException();
            }

            // IIspitiView_Bindings

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
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Studentska_služba.Views.Podaci.IspitiView)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }
            public void SetConverterLookupRoot(global::Windows.UI.Xaml.FrameworkElement rootElement)
            {
                this.converterLookupRoot = new global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement>(rootElement);
            }

            public global::Windows.UI.Xaml.Data.IValueConverter LookupConverter(string key)
            {
                if (this.localResources == null)
                {
                    global::Windows.UI.Xaml.FrameworkElement rootElement;
                    this.converterLookupRoot.TryGetTarget(out rootElement);
                    this.localResources = rootElement.Resources;
                    this.converterLookupRoot = null;
                }
                return (global::Windows.UI.Xaml.Data.IValueConverter) (this.localResources.ContainsKey(key) ? this.localResources[key] : global::Windows.UI.Xaml.Application.Current.Resources[key]);
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Studentska_služba.Views.Podaci.IspitiView obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_vm(obj.vm, phase);
                    }
                }
            }
            private void Update_vm(global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_vm(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_vm_AddNewItemCommand(obj.AddNewItemCommand, phase);
                        this.Update_vm_UpdateItemCommand(obj.UpdateItemCommand, phase);
                        this.Update_vm_DeleteItemCommand(obj.DeleteItemCommand, phase);
                        this.Update_vm_RefreshTableCommand(obj.RefreshTableCommand, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_vm_SearchBoxText(obj.SearchBoxText, phase);
                        this.Update_vm_SelectedItem(obj.SelectedItem, phase);
                        this.Update_vm_DetailsMode(obj.DetailsMode, phase);
                        this.Update_vm_SaveChangesCommand(obj.SaveChangesCommand, phase);
                        this.Update_vm_CancelCommand(obj.CancelCommand, phase);
                    }
                }
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 43
                    if (!isobj9vmDisabled)
                    {
                        XamlBindingSetters.Set_Studentska_služba_Views_Podaci_Ispiti_IspitiList_vm(this.obj9, obj, null);
                    }
                }
            }
            private void Update_vm_AddNewItemCommand(global::GalaSoft.MvvmLight.Command.RelayCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 33
                    if (!isobj3AddNewItemCommandDisabled)
                    {
                        XamlBindingSetters.Set_Studentska_služba_Views_Podaci_CommandLine_AddNewItemCommand(this.obj3, obj, null);
                    }
                }
            }
            private void Update_vm_UpdateItemCommand(global::GalaSoft.MvvmLight.Command.RelayCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 33
                    if (!isobj3UpdateItemCommandDisabled)
                    {
                        XamlBindingSetters.Set_Studentska_služba_Views_Podaci_CommandLine_UpdateItemCommand(this.obj3, obj, null);
                    }
                }
            }
            private void Update_vm_DeleteItemCommand(global::GalaSoft.MvvmLight.Command.RelayCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 33
                    if (!isobj3DeleteItemCommandDisabled)
                    {
                        XamlBindingSetters.Set_Studentska_služba_Views_Podaci_CommandLine_DeleteItemCommand(this.obj3, obj, null);
                    }
                }
            }
            private void Update_vm_RefreshTableCommand(global::GalaSoft.MvvmLight.Command.RelayCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 33
                    if (!isobj3RefreshTableCommandDisabled)
                    {
                        XamlBindingSetters.Set_Studentska_služba_Views_Podaci_CommandLine_RefreshTableCommand(this.obj3, obj, null);
                    }
                }
            }
            private void Update_vm_SearchBoxText(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 33
                    if (!isobj3SearchBoxTextDisabled)
                    {
                        XamlBindingSetters.Set_Studentska_služba_Views_Podaci_CommandLine_SearchBoxText(this.obj3, obj, null);
                    }
                }
            }
            private void Update_vm_SelectedItem(global::StudentskaSluzba.Models.Ispit obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 46
                    if (!isobj4VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj4, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("ObjectToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), null, null));
                    }
                    // Views\Podaci\Ispiti\IspitiView.xaml line 52
                    if (!isobj5IspitDisabled)
                    {
                        XamlBindingSetters.Set_Studentska_služba_Views_Podaci_Ispiti_IspitDetails_Ispit(this.obj5, obj, null);
                    }
                }
            }
            private void Update_vm_DetailsMode(global::Studentska_služba.DetailsMode obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 52
                    if (!isobj5IsEnabledDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Control_IsEnabled(this.obj5, (global::System.Boolean)this.LookupConverter("DetailsModeToBooleanConverter").Convert(obj, typeof(global::System.Boolean), null, null));
                    }
                    // Views\Podaci\Ispiti\IspitiView.xaml line 55
                    if (!isobj6VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj6, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("DetailsButtonVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), null, null));
                    }
                }
            }
            private void Update_vm_SaveChangesCommand(global::GalaSoft.MvvmLight.Command.RelayCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 59
                    if (!isobj7CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj7, obj, null);
                    }
                }
            }
            private void Update_vm_CancelCommand(global::GalaSoft.MvvmLight.Command.RelayCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiView.xaml line 63
                    if (!isobj8CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj8, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_3_SearchBoxText()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.vm != null)
                        {
                            this.dataRoot.vm.SearchBoxText = this.obj3.SearchBoxText;
                        }
                    }
                }
            }
            private void UpdateTwoWay_5_Ispit()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.vm != null)
                        {
                            this.dataRoot.vm.SelectedItem = this.obj5.Ispit;
                        }
                    }
                }
            }
            private void UpdateTwoWay_9_vm()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        this.dataRoot.vm = this.obj9.vm;
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class IspitiView_obj1_BindingsTracking
            {
                private global::System.WeakReference<IspitiView_obj1_Bindings> weakRefToBindingObj; 

                public IspitiView_obj1_BindingsTracking(IspitiView_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<IspitiView_obj1_Bindings>(obj);
                }

                public IspitiView_obj1_Bindings TryGetBindingObject()
                {
                    IspitiView_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_vm(null);
                }

                public void PropertyChanged_vm(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    IspitiView_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel obj = sender as global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_vm_SearchBoxText(obj.SearchBoxText, DATA_CHANGED);
                                bindings.Update_vm_SelectedItem(obj.SelectedItem, DATA_CHANGED);
                                bindings.Update_vm_DetailsMode(obj.DetailsMode, DATA_CHANGED);
                                bindings.Update_vm_SaveChangesCommand(obj.SaveChangesCommand, DATA_CHANGED);
                                bindings.Update_vm_CancelCommand(obj.CancelCommand, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "SearchBoxText":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_vm_SearchBoxText(obj.SearchBoxText, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SelectedItem":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_vm_SelectedItem(obj.SelectedItem, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "DetailsMode":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_vm_DetailsMode(obj.DetailsMode, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SaveChangesCommand":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_vm_SaveChangesCommand(obj.SaveChangesCommand, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "CancelCommand":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_vm_CancelCommand(obj.CancelCommand, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel cache_vm = null;
                public void UpdateChildListeners_vm(global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel obj)
                {
                    if (obj != cache_vm)
                    {
                        if (cache_vm != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_vm).PropertyChanged -= PropertyChanged_vm;
                            cache_vm = null;
                        }
                        if (obj != null)
                        {
                            cache_vm = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_vm;
                        }
                    }
                }
                public void RegisterTwoWayListener_3(global::Studentska_služba.Views.Podaci.CommandLine sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Studentska_služba.Views.Podaci.CommandLine.SearchBoxTextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_3_SearchBoxText();
                        }
                    });
                }
                public void RegisterTwoWayListener_5(global::Studentska_služba.Views.Podaci.Ispiti.IspitDetails sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Studentska_služba.Views.Podaci.Ispiti.IspitDetails.IspitProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_5_Ispit();
                        }
                    });
                }
                public void RegisterTwoWayListener_9(global::Studentska_služba.Views.Podaci.Ispiti.IspitiList sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Studentska_služba.Views.Podaci.Ispiti.IspitiList.vmProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_9_vm();
                        }
                    });
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\Podaci\Ispiti\IspitiView.xaml line 23
                {
                    this.MainGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\Podaci\Ispiti\IspitiView.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    IspitiView_obj1_Bindings bindings = new IspitiView_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    bindings.SetConverterLookupRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

