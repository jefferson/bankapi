﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankApplication.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SharedResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SharedResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BankApplication.Resource.SharedResource", typeof(SharedResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Action called: type: {0}, Origin: {1}, Destination: {2}.
        /// </summary>
        public static string ActionCalled {
            get {
                return ResourceManager.GetString("ActionCalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Balance event called for account: {0}.
        /// </summary>
        public static string BalanceEventCalled {
            get {
                return ResourceManager.GetString("BalanceEventCalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to System internal error.
        /// </summary>
        public static string InternalError {
            get {
                return ResourceManager.GetString("InternalError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to KeyNotFound for action: type: {0}, Origin: {1}, Destination: {2}.
        /// </summary>
        public static string KeyNotFound {
            get {
                return ResourceManager.GetString("KeyNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insufficient Funds.
        /// </summary>
        public static string NoBalance {
            get {
                return ResourceManager.GetString("NoBalance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Application was reseted..
        /// </summary>
        public static string ResetMessage {
            get {
                return ResourceManager.GetString("ResetMessage", resourceCulture);
            }
        }
    }
}
