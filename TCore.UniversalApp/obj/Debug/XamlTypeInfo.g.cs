﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks","14.0.0.0")]
    public sealed class XamlMetaDataProvider: global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[8];
            _typeNameTable[0] = "TCore.UniversalApp.Common.AutoView";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[2] = "Int32";
            _typeNameTable[3] = "System.Collections.Generic.List`1<String>";
            _typeNameTable[4] = "Object";
            _typeNameTable[5] = "String";
            _typeNameTable[6] = "Boolean";
            _typeNameTable[7] = "TCore.UniversalApp.Interfaces.Common.ITCoreViewModel";

            _typeTable = new global::System.Type[8];
            _typeTable[0] = typeof(global::TCore.UniversalApp.Common.AutoView);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[2] = typeof(global::System.Int32);
            _typeTable[3] = typeof(global::System.Collections.Generic.List<global::System.String>);
            _typeTable[4] = typeof(global::System.Object);
            _typeTable[5] = typeof(global::System.String);
            _typeTable[6] = typeof(global::System.Boolean);
            _typeTable[7] = typeof(global::TCore.UniversalApp.Interfaces.Common.ITCoreViewModel);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_AutoView() { return new global::TCore.UniversalApp.Common.AutoView(); }
        private object Activate_3_List() { return new global::System.Collections.Generic.List<global::System.String>(); }
        private void VectorAdd_3_List(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::System.String>)instance;
            var newItem = (global::System.String)item;
            collection.Add(newItem);
        }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  TCore.UniversalApp.Common.AutoView
                userType = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_0_AutoView;
                userType.AddMemberName("AnimationsLengthMilliSecond");
                userType.AddMemberName("PreCacheableViewsNameList");
                userType.AddMemberName("IsViewCacheAble");
                userType.AddMemberName("IsAnimated");
                userType.AddMemberName("ViewModel");
                userType.AddMemberName("AssemblyNameForViews");
                userType.AddMemberName("NameSpaceForViews");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Int32
                xamlType = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  System.Collections.Generic.List`1<String>
                userType = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.CollectionAdd = VectorAdd_3_List;
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 4:   //  Object
                xamlType = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  String
                xamlType = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 6:   //  Boolean
                xamlType = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 7:   //  TCore.UniversalApp.Interfaces.Common.ITCoreViewModel
                userType = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType(this, typeName, type, null);
                userType.SetIsReturnTypeStub();
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_AutoView_AnimationsLengthMilliSecond(object instance)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            return that.AnimationsLengthMilliSecond;
        }
        private void set_0_AutoView_AnimationsLengthMilliSecond(object instance, object Value)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            that.AnimationsLengthMilliSecond = (global::System.Int32)Value;
        }
        private object get_1_AutoView_PreCacheableViewsNameList(object instance)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            return that.PreCacheableViewsNameList;
        }
        private void set_1_AutoView_PreCacheableViewsNameList(object instance, object Value)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            that.PreCacheableViewsNameList = (global::System.Collections.Generic.List<global::System.String>)Value;
        }
        private object get_2_AutoView_IsViewCacheAble(object instance)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            return that.IsViewCacheAble;
        }
        private void set_2_AutoView_IsViewCacheAble(object instance, object Value)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            that.IsViewCacheAble = (global::System.Boolean)Value;
        }
        private object get_3_AutoView_IsAnimated(object instance)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            return that.IsAnimated;
        }
        private void set_3_AutoView_IsAnimated(object instance, object Value)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            that.IsAnimated = (global::System.Boolean)Value;
        }
        private object get_4_AutoView_ViewModel(object instance)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            return that.ViewModel;
        }
        private void set_4_AutoView_ViewModel(object instance, object Value)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            that.ViewModel = (global::TCore.UniversalApp.Interfaces.Common.ITCoreViewModel)Value;
        }
        private object get_5_AutoView_AssemblyNameForViews(object instance)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            return that.AssemblyNameForViews;
        }
        private void set_5_AutoView_AssemblyNameForViews(object instance, object Value)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            that.AssemblyNameForViews = (global::System.String)Value;
        }
        private object get_6_AutoView_NameSpaceForViews(object instance)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            return that.NameSpaceForViews;
        }
        private void set_6_AutoView_NameSpaceForViews(object instance, object Value)
        {
            var that = (global::TCore.UniversalApp.Common.AutoView)instance;
            that.NameSpaceForViews = (global::System.String)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlMember xamlMember = null;
            global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "TCore.UniversalApp.Common.AutoView.AnimationsLengthMilliSecond":
                userType = (global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("TCore.UniversalApp.Common.AutoView");
                xamlMember = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlMember(this, "AnimationsLengthMilliSecond", "Int32");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_0_AutoView_AnimationsLengthMilliSecond;
                xamlMember.Setter = set_0_AutoView_AnimationsLengthMilliSecond;
                break;
            case "TCore.UniversalApp.Common.AutoView.PreCacheableViewsNameList":
                userType = (global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("TCore.UniversalApp.Common.AutoView");
                xamlMember = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlMember(this, "PreCacheableViewsNameList", "System.Collections.Generic.List`1<String>");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_1_AutoView_PreCacheableViewsNameList;
                xamlMember.Setter = set_1_AutoView_PreCacheableViewsNameList;
                break;
            case "TCore.UniversalApp.Common.AutoView.IsViewCacheAble":
                userType = (global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("TCore.UniversalApp.Common.AutoView");
                xamlMember = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlMember(this, "IsViewCacheAble", "Boolean");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_2_AutoView_IsViewCacheAble;
                xamlMember.Setter = set_2_AutoView_IsViewCacheAble;
                break;
            case "TCore.UniversalApp.Common.AutoView.IsAnimated":
                userType = (global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("TCore.UniversalApp.Common.AutoView");
                xamlMember = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlMember(this, "IsAnimated", "Boolean");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_3_AutoView_IsAnimated;
                xamlMember.Setter = set_3_AutoView_IsAnimated;
                break;
            case "TCore.UniversalApp.Common.AutoView.ViewModel":
                userType = (global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("TCore.UniversalApp.Common.AutoView");
                xamlMember = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlMember(this, "ViewModel", "TCore.UniversalApp.Interfaces.Common.ITCoreViewModel");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_4_AutoView_ViewModel;
                xamlMember.Setter = set_4_AutoView_ViewModel;
                break;
            case "TCore.UniversalApp.Common.AutoView.AssemblyNameForViews":
                userType = (global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("TCore.UniversalApp.Common.AutoView");
                xamlMember = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlMember(this, "AssemblyNameForViews", "String");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_5_AutoView_AssemblyNameForViews;
                xamlMember.Setter = set_5_AutoView_AssemblyNameForViews;
                break;
            case "TCore.UniversalApp.Common.AutoView.NameSpaceForViews":
                userType = (global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlUserType)GetXamlTypeByName("TCore.UniversalApp.Common.AutoView");
                xamlMember = new global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlMember(this, "NameSpaceForViews", "String");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_6_AutoView_NameSpaceForViews;
                xamlMember.Setter = set_6_AutoView_NameSpaceForViews;
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlSystemBaseType
    {
        global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::TCore.UniversalApp.TCore_UniversalApp_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}

