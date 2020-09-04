﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace AppLeanMaint.ConfigWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ConfigSoap", Namespace="http://objlab.it/")]
    public partial class Config : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetOrganizationCentersTreeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Config() {
            this.Url = "http://dev1.objlab.it/WS/Config.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetOrganizationCentersTreeCompletedEventHandler GetOrganizationCentersTreeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://objlab.it/GetOrganizationCentersTree", RequestNamespace="http://objlab.it/", ResponseNamespace="http://objlab.it/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public RootOfInt32OrganizationCenter GetOrganizationCentersTree() {
            object[] results = this.Invoke("GetOrganizationCentersTree", new object[0]);
            return ((RootOfInt32OrganizationCenter)(results[0]));
        }
        
        /// <remarks/>
        public void GetOrganizationCentersTreeAsync() {
            this.GetOrganizationCentersTreeAsync(null);
        }
        
        /// <remarks/>
        public void GetOrganizationCentersTreeAsync(object userState) {
            if ((this.GetOrganizationCentersTreeOperationCompleted == null)) {
                this.GetOrganizationCentersTreeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrganizationCentersTreeOperationCompleted);
            }
            this.InvokeAsync("GetOrganizationCentersTree", new object[0], this.GetOrganizationCentersTreeOperationCompleted, userState);
        }
        
        private void OnGetOrganizationCentersTreeOperationCompleted(object arg) {
            if ((this.GetOrganizationCentersTreeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetOrganizationCentersTreeCompleted(this, new GetOrganizationCentersTreeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NodeOfInt32OrganizationCenter))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://objlab.it/")]
    public partial class RootOfInt32OrganizationCenter {
        
        private NodeOfInt32OrganizationCenter[] childrenField;
        
        /// <remarks/>
        public NodeOfInt32OrganizationCenter[] Children {
            get {
                return this.childrenField;
            }
            set {
                this.childrenField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://objlab.it/")]
    public partial class NodeOfInt32OrganizationCenter : RootOfInt32OrganizationCenter {
        
        private int keyField;
        
        private OrganizationCenter valueField;
        
        private bool hasParentField;
        
        private int parentKeyField;
        
        /// <remarks/>
        public int Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        public OrganizationCenter Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        public bool HasParent {
            get {
                return this.hasParentField;
            }
            set {
                this.hasParentField = value;
            }
        }
        
        /// <remarks/>
        public int ParentKey {
            get {
                return this.parentKeyField;
            }
            set {
                this.parentKeyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://objlab.it/")]
    public partial class OrganizationCenter {
        
        private int iD_OrganizationCenterField;
        
        private string nameField;
        
        private string descriptionField;
        
        private int iD_OrganizationCenterTypeField;
        
        private int iD_ObjStatusField;
        
        private int iD_ParentField;
        
        private bool iD_Parent_HasValueField;
        
        /// <remarks/>
        public int ID_OrganizationCenter {
            get {
                return this.iD_OrganizationCenterField;
            }
            set {
                this.iD_OrganizationCenterField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public int ID_OrganizationCenterType {
            get {
                return this.iD_OrganizationCenterTypeField;
            }
            set {
                this.iD_OrganizationCenterTypeField = value;
            }
        }
        
        /// <remarks/>
        public int ID_ObjStatus {
            get {
                return this.iD_ObjStatusField;
            }
            set {
                this.iD_ObjStatusField = value;
            }
        }
        
        /// <remarks/>
        public int ID_Parent {
            get {
                return this.iD_ParentField;
            }
            set {
                this.iD_ParentField = value;
            }
        }
        
        /// <remarks/>
        public bool ID_Parent_HasValue {
            get {
                return this.iD_Parent_HasValueField;
            }
            set {
                this.iD_Parent_HasValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GetOrganizationCentersTreeCompletedEventHandler(object sender, GetOrganizationCentersTreeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetOrganizationCentersTreeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetOrganizationCentersTreeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RootOfInt32OrganizationCenter Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RootOfInt32OrganizationCenter)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591