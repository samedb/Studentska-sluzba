﻿#pragma checksum "C:\Users\Samed\Documents\GitHub\Studentska-sluzba\Aplikacija\Studentska služba\Studentska služba\Views\Podaci\Ispiti\IspitiList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AA175999FD64144EE946E44DCDD4CEBD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Studentska_služba.Views.Podaci.Ispiti
{
    partial class IspitiList : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_ItemsSource(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj, global::System.Collections.IEnumerable value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Collections.IEnumerable) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Collections.IEnumerable), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_SelectedItem(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class IspitiList_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IIspitiList_Bindings
        {
            private global::Studentska_služba.Views.Podaci.Ispiti.IspitiList dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj2;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;
            private static bool isobj2SelectedItemDisabled = false;

            private IspitiList_obj1_BindingsTracking bindingsTracking;

            public IspitiList_obj1_Bindings()
            {
                this.bindingsTracking = new IspitiList_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 18 && columnNumber == 32)
                {
                    isobj2ItemsSourceDisabled = true;
                }
                else if (lineNumber == 20 && columnNumber == 32)
                {
                    isobj2SelectedItemDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\Podaci\Ispiti\IspitiList.xaml line 14
                        this.obj2 = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)target;
                        this.bindingsTracking.RegisterTwoWayListener_2(this.obj2);
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

            // IIspitiList_Bindings

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
                    this.dataRoot = (global::Studentska_služba.Views.Podaci.Ispiti.IspitiList)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Studentska_služba.Views.Podaci.Ispiti.IspitiList obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
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
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_vm_ItemList(obj.ItemList, phase);
                        this.Update_vm_SelectedItem(obj.SelectedItem, phase);
                    }
                }
            }
            private void Update_vm_ItemList(global::System.Collections.ObjectModel.ObservableCollection<global::StudentskaSluzba.Models.Ispit> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_vm_ItemList(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiList.xaml line 14
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_ItemsSource(this.obj2, obj, null);
                    }
                }
            }
            private void Update_vm_SelectedItem(global::StudentskaSluzba.Models.Ispit obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Podaci\Ispiti\IspitiList.xaml line 14
                    if (!isobj2SelectedItemDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_SelectedItem(this.obj2, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_2_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.vm != null)
                        {
                            this.dataRoot.vm.ItemList = (global::System.Collections.ObjectModel.ObservableCollection<global::StudentskaSluzba.Models.Ispit>)this.obj2.ItemsSource;
                        }
                    }
                }
            }
            private void UpdateTwoWay_2_SelectedItem()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.vm != null)
                        {
                            this.dataRoot.vm.SelectedItem = (global::StudentskaSluzba.Models.Ispit)this.obj2.SelectedItem;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class IspitiList_obj1_BindingsTracking
            {
                private global::System.WeakReference<IspitiList_obj1_Bindings> weakRefToBindingObj; 

                public IspitiList_obj1_BindingsTracking(IspitiList_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<IspitiList_obj1_Bindings>(obj);
                }

                public IspitiList_obj1_Bindings TryGetBindingObject()
                {
                    IspitiList_obj1_Bindings bindingObject = null;
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
                    UpdateChildListeners_(null);
                    UpdateChildListeners_vm(null);
                    UpdateChildListeners_vm_ItemList(null);
                }

                public void DependencyPropertyChanged_vm(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    IspitiList_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::Studentska_služba.Views.Podaci.Ispiti.IspitiList obj = sender as global::Studentska_služba.Views.Podaci.Ispiti.IspitiList;
                        if (obj != null)
                        {
                            bindings.Update_vm(obj.vm, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_vm = 0;
                public void UpdateChildListeners_(global::Studentska_služba.Views.Podaci.Ispiti.IspitiList obj)
                {
                    IspitiList_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::Studentska_služba.Views.Podaci.Ispiti.IspitiList.vmProperty, tokenDPC_vm);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_vm = obj.RegisterPropertyChangedCallback(global::Studentska_služba.Views.Podaci.Ispiti.IspitiList.vmProperty, DependencyPropertyChanged_vm);
                        }
                    }
                }
                public void PropertyChanged_vm(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    IspitiList_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel obj = sender as global::Studentska_služba.ViewModels.Podaci.Ispiti.IspitiViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_vm_ItemList(obj.ItemList, DATA_CHANGED);
                                bindings.Update_vm_SelectedItem(obj.SelectedItem, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "ItemList":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_vm_ItemList(obj.ItemList, DATA_CHANGED);
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
                public void PropertyChanged_vm_ItemList(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    IspitiList_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::StudentskaSluzba.Models.Ispit> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::StudentskaSluzba.Models.Ispit>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_vm_ItemList(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    IspitiList_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::StudentskaSluzba.Models.Ispit> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::StudentskaSluzba.Models.Ispit>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::StudentskaSluzba.Models.Ispit> cache_vm_ItemList = null;
                public void UpdateChildListeners_vm_ItemList(global::System.Collections.ObjectModel.ObservableCollection<global::StudentskaSluzba.Models.Ispit> obj)
                {
                    if (obj != cache_vm_ItemList)
                    {
                        if (cache_vm_ItemList != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_vm_ItemList).PropertyChanged -= PropertyChanged_vm_ItemList;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_vm_ItemList).CollectionChanged -= CollectionChanged_vm_ItemList;
                            cache_vm_ItemList = null;
                        }
                        if (obj != null)
                        {
                            cache_vm_ItemList = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_vm_ItemList;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_vm_ItemList;
                        }
                    }
                }
                public void RegisterTwoWayListener_2(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_2_ItemsSource();
                        }
                    });
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_2_SelectedItem();
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
            case 2: // Views\Podaci\Ispiti\IspitiList.xaml line 14
                {
                    this.dataGrid = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.dataGrid).Sorting += this.DataGrid_Sorting;
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
            case 1: // Views\Podaci\Ispiti\IspitiList.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.UserControl element1 = (global::Windows.UI.Xaml.Controls.UserControl)target;
                    IspitiList_obj1_Bindings bindings = new IspitiList_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
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

